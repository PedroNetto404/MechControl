using Hangfire;
using MechControl.Api.Middlewares;
using MechControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MechControl.Api.Extensions;

public static class AppBuilderExtensions
{
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

    public static void UseCustomExceptionHandler(
        this IApplicationBuilder app) => 
        app.UseMiddleware<CustomExceptionHandlerMiddleware>();

    public static void AddPipeline(this WebApplication app)
    {
        app.UseCustomExceptionHandler();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();

        app.UseSession();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseHttpsRedirection();
        app.MapControllers();

        app.UseHangfireDashboard();
    }
}
