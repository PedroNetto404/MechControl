using Hangfire;
using MechControl.Api.Middlewares;

namespace MechControl.Api.Extensions;

public static class AppBuilderExtensions
{


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
