using MechControl.Application.Features.Customers.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MechControl.Api.Controllers.Customer;

[Authorize]
[ApiVersion(ApiVersion.V1)]
[Route("api/v{version:apiVersion}/customers")]
public partial class CustomerController(ISender sender) :
	Controller(sender)
{
	[HttpGet("{id:guid}")]
	public Task<IActionResult> GetAsync(Guid id) =>
		HandleResult(
		_sender.Send(new GetCustomerByIdQuery(id))
  );
}
