using MechControl.Application.Features.Customers.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MechControl.Api.Controllers.Customer;

public partial class CustomerController(ISender sender) :
	Controller(sender)
{
	[HttpGet("{id:guid}")]
	public Task<IActionResult> GetAsync(Guid id) =>
		HandleResultAsync(
		_sender.Send(new GetCustomerByIdQuery(id))
  );
}
