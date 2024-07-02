using MechControl.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace MechControl.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController(
    MechControlContext dbContext) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var customer = await dbContext.Customers.FindAsync(id);
        return customer == null ? NotFound() : Ok(customer);
    }
}