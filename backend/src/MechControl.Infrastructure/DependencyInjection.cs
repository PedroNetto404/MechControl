using Hangfire;
using MechControl.Application.Abstractions;
using MechControl.Application.Interfaces;
using MechControl.Domain.Core.Abstractions;
using MechControl.Infrastructure.Authentication;
using MechControl.Infrastructure.Jobs;
using MechControl.Infrastructure.Persistence;
using MechControl.Infrastructure.Persistence.Interceptors;
using MechControl.Infrastructure.Session;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        services.AddScoped<DomainEventsInterceptor>();
        services.AddDbContext<MechControlContext>(opt =>
        {
            opt.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(MechControlContext).Assembly.FullName)
            );
        });
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICurrentMechShopProvider, SessionInfoProvider>();

        services.Configure<KeycloakOptions>(
            configuration.GetSection(KeycloakOptions.Key));

        AddKeyclockJwtAuth(services, configuration);
        AddHangfireJobs(services, configuration);

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

    private static void AddHangfireJobs(IServiceCollection services, IConfiguration config)
    {
        services.AddHangfireServer();

        services.AddHangfire(c => {
            c.UseSqlServerStorage(config.GetConnectionString("DefaultConnection"));
        });

        var recurringJobManager = services.BuildServiceProvider()
                                          .GetService<IRecurringJobManager>();
                                          
        recurringJobManager.AddOrUpdate<OutboxMessagesProcessorJob>(
            "OutboxMessagesProcessorJob",
            job => job.ExecuteAsync(null!),
            Cron.Minutely);
    }   
}
