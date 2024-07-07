using MechControl.Application.Abstractions;

namespace MechControl.Application.Features.Customers;

public record GetCustomerByIdQuery(
	Guid MechanicShopId,
	Guid Id) : IQuery<CustomerDto>;
