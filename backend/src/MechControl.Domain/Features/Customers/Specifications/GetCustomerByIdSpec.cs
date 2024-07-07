using Ardalis.Specification;
using MechControl.Domain.Features.MechShops;

namespace MechControl.Domain.Features.Customers.Specifications;

public class GetCustomerByIdSpec : Specification<Customer>
{
	public GetCustomerByIdSpec(
		MechShopId mechanicShopId,
		CustomerId id) =>
		Query.Where(customer => customer.Id == id)
			.Where(customer => customer.MechShopId == mechanicShopId);
}
