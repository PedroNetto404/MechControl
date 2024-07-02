using MechControl.Infrastructure.Persistence;

namespace MechControl.Api.Customers;

public static class GetCustomerEndpoint
{
    public static void RegisterEndpoint(Microsoft.AspNetCore.Routing.IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/customers/{id}", async (MechControlContext dbContext, int id) =>
        {
            var customer = await dbContext.Customers.FindAsync(id);
            return customer == null ? Results.NotFound() : Results.Ok(customer);
        });
    }
}