using Ardalis.Specification;
using MechControl.Domain.Features.MechShops;
using MechControl.Domain.Shared.ValueObjects;

namespace MechControl.Domain.Features.Customers.Specifications;


public class GetCustomerByEmailSpec : Specification<Customer>
{
	public GetCustomerByEmailSpec(
		MechShopId mechanicShopId,
		Email email) =>
		Query
			.Where(customer => customer.MechShopId == mechanicShopId)
			.Where(customer => customer.Email == email);
}