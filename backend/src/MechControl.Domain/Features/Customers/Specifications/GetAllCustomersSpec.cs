using Ardalis.Specification;
using MechControl.Domain.Features.Customers.Enums;
using MechControl.Domain.Features.MechShops;

namespace MechControl.Domain.Features.Customers.Specifications;

public sealed class GetAllCustomersSpec : Specification<Customer>
{
    public GetAllCustomersSpec(
        MechShopId mechanicShopId,
        int fetch,
        int offset,
        CustomerType? customerType)
    {
		if(customerType is not null)
		{
			Query.Where(customer => 
				customer
					.GetType()
					.Name
					.Contains(
						customerType.ToString()!,
						StringComparison.InvariantCultureIgnoreCase
					)
			);
		}

        Query
            .Where(customer => customer.MechShopId == mechanicShopId)
            .Skip(offset)
            .Take(fetch);
    }

}