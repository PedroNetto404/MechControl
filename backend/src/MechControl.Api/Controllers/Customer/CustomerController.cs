using MechControl.Application.Features.Customers.Commands.CreateCustomer;
using MechControl.Application.Features.Customers.Queries.GetAll;
using MechControl.Application.Features.Customers.Queries.GetById;
using MechControl.Domain.Features.Customers.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MechControl.Api.Controllers.Customer;

[Authorize]
[Route("api/v1/customers")]
public sealed class CustomerController(ISender sender) :
	Controller(sender)
{
	[HttpGet("{id:guid}")]
	public Task<IActionResult> GetAsync([FromRoute(Name = "id")] Guid id) =>
		HandleResult(
		_sender.Send(new GetCustomerByIdQuery(id)));


	[HttpGet]
	public Task<IActionResult> GetAsync([FromQuery] GetAllCustomersRequest request) =>
	  HandleResult(
		  _sender.Send(new GetAllCustomersQuery(
			request.Offset,
			request.Fetch,
			request.CustomerType is not null ?
				Enum.Parse<CustomerType>(request.CustomerType) :
				null)));

	[HttpPost]
	public Task<IActionResult> CreateAsync([FromBody] CreateCustomerRequest request) =>
  HandleResult(_sender.Send(new CreateCustomerCommand(
	  request.Name,
	  request.Document,
	  request.Email,
	  request.Phone,
	  Enum.Parse<CustomerType>(request.CustomerType),
	  request.BirthDate is not null ?
		DateOnly.FromDateTime(request.BirthDate.Value) :
		null,
	  request.AddressStreet,
	  request.AddressNumber,
	  request.AddressNeighborhood,
	  request.AddressCity,
	  request.AddressStateCode,
	  request.AddressCountryCode,
	  request.AddressZipCode,
	  request.AddressComplement,
	  request.AddressReference,
	  request.IsMei
	)));
}
