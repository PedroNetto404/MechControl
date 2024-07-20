using MechControl.Application.Abstractions;
using MechControl.Application.Interfaces;
using MechControl.Domain.Core.Abstractions;
using MechControl.Infrastructure.Authentication;
using MechControl.Infrastructure.Persistence;
using MechControl.Infrastructure.Persistence.Interceptors;
using MechControl.Infrastructure.Session;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MechControl.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<MechControlContext>(opt =>
        {
            opt.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(MechControlContext).Assembly.FullName)
            );
        });

        services.AddOptions<KeycloakOptions>()
                .Bind(configuration.GetSection(KeycloakOptions.Key))
                 .ValidateDataAnnotations();

        services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddTransient<DomainEventsInterceptor>();
        services.AddScoped<ICurrentMechShopProvider, SessionInfoProvider>();
        services.AddScoped<IAuthenticationService, KeycloakAuthenticationService>();

        AddKeyclockJwtAuth(services, configuration);

        return services;
    }

    private static void AddKeyclockJwtAuth(
        IServiceCollection services,
        IConfiguration config)
    {
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            var keycloakOptions =
                config.GetSection(KeycloakOptions.Key)
                      .Get<KeycloakOptions>() ?? throw new ArgumentNullException(nameof(KeycloakOptions));

            opt.Authority = keycloakOptions.Authority;
            opt.Audience = keycloakOptions.ClientId;
            opt.RequireHttpsMetadata = false;

            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = keycloakOptions.Authority,
                ValidateAudience = true,
                ValidAudience = keycloakOptions.ClientId,
                ValidateLifetime = true
            };
        });

        services.AddAuthorization();

        services.AddHttpClient<IAuthenticationService, KeycloakAuthenticationService>();
    }

    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope =
            app
                .ApplicationServices
                .CreateScope();

        var context =
            scope
                .ServiceProvider
                .GetRequiredService<MechControlContext>();

        context
            .Database
            .Migrate();
    }
}
