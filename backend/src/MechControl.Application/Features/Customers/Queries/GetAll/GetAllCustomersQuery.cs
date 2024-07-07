using MechControl.Application.Abstractions;
using MechControl.Application.shared;
using MediatR;

namespace MechControl.Application.Features.Customers.Queries.GetAllCustomers;

public record GetAllCustomersQuery(
	Guid MechanicShopId,
	int Fetch,
	int Offset,
	string? CustomerType
) :
	PaginationFilter(Fetch, Offset),
	IQuery<IEnumerable<CustomerDto>>;
