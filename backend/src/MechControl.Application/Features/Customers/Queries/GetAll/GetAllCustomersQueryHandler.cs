using MechControl.Application.Abstractions;
using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Core.Primitives.Result;
using MechControl.Domain.Features.Customers;
using MechControl.Domain.Features.Customers.Specifications;
using MechControl.Domain.Features.MechShops;

namespace MechControl.Application.Features.Customers.Queries.GetAllCustomers;

public sealed class GetAllCustomersQueryHandler(ICustomerRepository customerRepository) :
	IQueryHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
{
	private readonly ICustomerRepository _customerRepository = customerRepository;

	public async Task<Result<IEnumerable<CustomerDto>>> Handle(
		GetAllCustomersQuery request,
		CancellationToken cancellationToken)
	{
		IEnumerable<Customer> customers = await (
			request switch
			{
				{ CustomerType: not null } => _customerRepository.ListAsync(
					new GetCustomersByTypeSpec(
						StrongId.From<MechShopId>(request.MechanicShopId),
						request.CustomerType == "individual"
							? typeof(IndividualCustomer)
							: typeof(CorporateCustomer),
						request.Fetch,
						request.Offset),
					cancellationToken),
				_ => _customerRepository.ListAsync(
					new GetAllCustomersSpec(
						StrongId.From<MechShopId>(request.MechanicShopId),
						request.Fetch,
						request.Offset),
					cancellationToken)
			}
		);

		return Result<IEnumerable<CustomerDto>>.Ok(
			customers.Select(customer => (CustomerDto)customer));
	}
}