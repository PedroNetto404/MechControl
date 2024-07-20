﻿using MechControl.Api.Middlewares;

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
            app.UseDeveloperExceptionPage();
            app.UseSwagger(config =>
            {
                config.RouteTemplate = "api-docs/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/api-docs/v1/swagger.json", "MechControl API V1");
                config.RoutePrefix = "api-docs";
                config.DisplayRequestDuration();
                config.EnableDeepLinking();
            });
        }
        else
        {
            app.UseHsts();
            app.UseHttpsRedirection();
        }

        app.UseHealthChecks("/health");

        app.UseRouting();

        app.UseSession();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
    }
}
