using MechControl.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MechControl.Api.Middlewares;

public class CustomExceptionHandlerMiddleware(
    RequestDelegate next,
    ILogger<CustomExceptionHandlerMiddleware> logger
)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Expected occurred: {message}", ex.Message);

            var details = GetExceptionDetails(ex);

            var problemDetails = new ProblemDetails
            {
                Status = details.Status,
                Type = details.Type,
                Title = details.Title,
                Detail = details.Detail,
                Instance = context.TraceIdentifier
            };
            if (details.Errors is not null)
                problemDetails.Extensions["errors"] = details.Errors;

            context.Response.StatusCode = problemDetails.Status.Value;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

    private static ExceptionDetails GetExceptionDetails(Exception exception)
    {
        return exception switch
        {
            ValidationException validationException => new ExceptionDetails(
                StatusCodes.Status400BadRequest,
                "ValidationFailure",
                "Validation error",
                "One or more validation errors has occurred",
                validationException.Errors),
            _ => new ExceptionDetails(
                StatusCodes.Status500InternalServerError,
                "ServerError",
                "Server error",
                "An unexpected error has occurred",
                null)
        };
    }

    internal sealed record ExceptionDetails(
        int Status,
        string Type,
        string Title,
        string Detail,
        IEnumerable<object>? Errors);
}
