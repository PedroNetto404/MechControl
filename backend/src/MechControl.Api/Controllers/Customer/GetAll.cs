using MechControl.Api.Hooks.Attributes;
using MechControl.Application.Features.Customers.Queries.GetAllCustomers;
using Microsoft.AspNetCore.Mvc;

namespace MechControl.Api.Controllers.Customer;

public partial class CustomerController
{

  [HttpGet]
  public Task<IActionResult> GetAsync(
  [FromSession("mechanic_shop_id")] Guid mechanicShopId,
  [FromQuery(Name = "offset")] int offset,
  [FromQuery(Name = "limit")] int limit,
  [FromQuery(Name = "customer_type")] string customerType,
  [FromQuery(Name = "name")] string name,
  [FromQuery(Name = "email")] string email,
  [FromQuery(Name = "phone")] string phone,
  [FromQuery(Name = "zip_code")] string zipCode
  ) =>
      HanldeResultAsync(
          _sender.Send(new GetAllCustomersQuery(
            mechanicShopId,
            offset,
            limit,
            customerType,
            name,
            email,
            phone,
            zipCode))
      );
}