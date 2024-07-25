using System.Text;
using MechControl.Application.Abstractions;
using MechControl.Application.Interfaces;
using MechControl.Domain.Core.Abstractions;
using MechControl.Infrastructure.Persistence;
using MechControl.Infrastructure.Persistence.Interceptors;
using MechControl.Infrastructure.Security.Models;
using MechControl.Infrastructure.Security.Services;
using MechControl.Infrastructure.Session;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;

namespace MechControl.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AddHealthCheck(services);

        services.AddDbContext<MechControlContext>(opt =>
        {
            opt.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(MechControlContext).Assembly.FullName)
            );
        });

        services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddTransient<DomainEventsInterceptor>();
        services.AddScoped<ICurrentMechShopProvider, SessionInfoProvider>();
        services.AddScoped<IAuthenticationService, AuthService>();
        services.AddScoped<IAuthTokenGenerator, JwtAuthTokenGenerator>();
        services.AddScoped<IPasswordHasher, SHA256PasswordHasher>();

        AddJwtAuth(services, configuration);

        return services;
    }

    private static void AddJwtAuth(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddOptions<JwtOptions>()
            .Bind(configuration.GetSection(JwtOptions.SectionName))
            .ValidateDataAnnotations();

        var jwtOptions = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>() ??
            throw new InvalidOperationException($"{JwtOptions.SectionName} not found in configuration");

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtOptions.Audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Secret)),
                    ValidateIssuerSigningKey = true,
                };
            });
    }

    private static void AddHealthCheck(IServiceCollection services)
    {
        var healthChecksBuilder = services.AddHealthChecks();

        healthChecksBuilder.AddAsyncCheck("Database", async () =>
        {
            await using var context =
                services.BuildServiceProvider().GetService<MechControlContext>();

            return context is not null
                ? HealthCheckResult.Healthy("Database is healthy")
                : HealthCheckResult.Unhealthy("Database is unhealthy");
        });

        healthChecksBuilder.AddCheck("Self", () => HealthCheckResult.Healthy("Self is healthy"));
    }

    public static WebApplication ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context =
            scope
                .ServiceProvider
                .GetRequiredService<MechControlContext>();

        context
            .Database
            .Migrate();

        return app;
    }
}
