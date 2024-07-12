using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MechControl.Application.Features.Customers.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace MechControl.Api.Controllers.Customer;

public partial class CustomerController
{

  public record GetAllCustomersRequest
  {
    [Required]
    [DefaultValue(0)]
    public required int Offset { get; init; }

    [Required]
    [DefaultValue(10)]
    public required int Limit { get; init; }

    [DefaultValue(null)]
    [FromQuery(Name = "customer_type")]
    [AllowedValues("individual", "corporate")]
    public string? CustomerType { get; init; }
  }

  [HttpGet]
  public Task<IActionResult> GetAsync(GetAllCustomersRequest request) =>
    HandleResult(
        _sender.Send(new GetAllCustomersQuery(
          request.Offset,
          request.Limit,
          request.CustomerType)));
}
