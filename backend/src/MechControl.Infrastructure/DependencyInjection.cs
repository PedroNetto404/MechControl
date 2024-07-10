using MechControl.Application;
using MechControl.Application.Interfaces;
using MechControl.Domain.Core.Abstractions;
using MechControl.Infrastructure.Persistence;
using MechControl.Infrastructure.Persistence.Interceptors;
using MechControl.Infrastructure.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
                $"Host={Environment.GetEnvironmentVariable("DB_HOST")};" +
                $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                $"Username={Environment.GetEnvironmentVariable("DB_USER")};" +
                $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};" +
                $"Port={Environment.GetEnvironmentVariable("DB_PORT")};");

            var logEnabled = bool.Parse(Environment.GetEnvironmentVariable("SQL_LOG_ENABLED") ?? "false");
            opt.EnableSensitiveDataLogging(logEnabled);
            opt.LogTo(Console.WriteLine, logEnabled ? LogLevel.Information : LogLevel.None);
        });

        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ICurrentMechShopProvider, SessionInfoProvider>();
            
        return services;
    }
}
