namespace MechControl.Domain.Features.Customers.Specifications;
using Ardalis.Specification;
using MechControl.Domain.Features.MechShops;
using MechControl.Domain.Shared.ValueObjects;

public sealed class GetAllCustomersSpec : Specification<Customer>
{
	public GetAllCustomersSpec(
		MechShopId mechanicShopId,
		int fetch,
		int offset) =>
		Query
			.Where(customer => customer.MechShopId == mechanicShopId)
			.Skip(offset)
			.Take(fetch);
}