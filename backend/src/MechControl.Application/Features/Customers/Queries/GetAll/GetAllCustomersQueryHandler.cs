using MechControl.Application.Abstractions;
using MechControl.Application.Interfaces;
using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Core.Primitives.Result;
using MechControl.Domain.Features.Customers;
using MechControl.Domain.Features.Customers.Specifications;

namespace MechControl.Application.Features.Customers.Queries.GetAll;

public sealed class GetAllCustomersQueryHandler(
	IRepository<Customer, CustomerId> customerRepository,
	ICurrentMechShopProvider currentMechShopProvider) :
    IQueryHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
{
    private readonly IRepository<Customer, CustomerId> _customerRepository = customerRepository;
	private readonly ICurrentMechShopProvider _currentMechShopProvider = currentMechShopProvider;

    public async Task<Result<IEnumerable<CustomerDto>>> Handle(
        GetAllCustomersQuery request,
        CancellationToken cancellationToken) => 
            Result
                .Ok
                (
                    (
                        await _customerRepository.ListAsync(
                            new GetAllCustomersSpec(
                                _currentMechShopProvider.Current,
                                request.Fetch,
                                request.Offset,
                                request.CustomerType),
                            cancellationToken)
                    ).Select(customer => (CustomerDto)customer)
                );
}