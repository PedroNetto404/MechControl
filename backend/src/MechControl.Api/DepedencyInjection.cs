using MechControl.Api.Controllers;
using Microsoft.OpenApi.Models;

namespace MechControl.Api;

public static class DepedencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddControllers();
        services.AddHttpContextAccessor();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc($"v1", new OpenApiInfo
            {
                Title = "MechControl.Api",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Pedro Netto", Email = "pedronetto31415@gmail.com"
                }
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            });
        });

        services.AddDistributedMemoryCache();

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
            options.Cookie.Name = ".MechControl.Session";
        });

        return services;
    }
}
