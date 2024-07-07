namespace MechControl.Domain.Features.Customers.Specifications;

using Ardalis.Specification;
using MechControl.Domain.Features.MechShops;
using MechControl.Domain.Shared.ValueObjects;

public class GetCustomerByEmailSpec : Specification<Customer>
{
	public GetCustomerByEmailSpec(
		MechShopId mechanicShopId,
		Email email) =>
		Query
			.Where(customer => customer.MechShopId == mechanicShopId)
			.Where(customer => customer.Email == email);

}