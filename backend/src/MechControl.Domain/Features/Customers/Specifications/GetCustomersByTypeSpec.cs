namespace MechControl.Domain.Features.Customers.Specifications
{
	using Ardalis.Specification;
	using MechControl.Domain.Features.MechShops;
	using MechControl.Domain.Shared.ValueObjects;

	public class GetCustomersByTypeSpec : Specification<Customer>
	{
		public GetCustomersByTypeSpec(
			MechShopId mechanicShopId,
			Type type,
			int fetch,
			int offset) =>
			Query
				.Where(customer => customer.GetType() == type)
				.Where(customer => customer.MechShopId == mechanicShopId)
				.Skip(offset)
				.Take(fetch);
	}
}