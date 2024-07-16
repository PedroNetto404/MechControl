using Ardalis.Specification;
using MechControl.Domain.Features.MechShops;
using MechControl.Domain.Shared.ValueObjects;

namespace MechControl.Domain.Features.Customers.Specifications;


public class GetCustomerByDocumentSpec : Specification<Customer>
{
	public GetCustomerByDocumentSpec(
		MechShopId mechanicShopId,
		Document document) =>
		Query
			.Where(customer => customer.MechShopId == mechanicShopId)
			.Where(customer => customer.Document == document);
}