using MechControl.Api.Hooks.Attributes;
using MechControl.Application.Features.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MechControl.Api.Controllers.Customer;

public partial class CustomerController(ISender sender) :
	Controller(sender)
{
	[HttpGet("{id:guid}")]
	public Task<IActionResult> GetAsync(
		[FromSession("mechanic_shop_id")] Guid mechanicShopId,
		Guid id) =>
		HanldeResultAsync(
		_sender.Send(new GetCustomerByIdQuery(mechanicShopId, id))
);
}
