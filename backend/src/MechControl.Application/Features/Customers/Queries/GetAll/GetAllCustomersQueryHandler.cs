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
        CancellationToken cancellationToken)
    {
        IEnumerable<Customer> customers = await (
            request switch
            {
                { CustomerType: not null } => _customerRepository.ListAsync(
                    new GetCustomersByTypeSpec(
                        _currentMechShopProvider.GetCurrentId(),
                        request.CustomerType == "individual"
                            ? typeof(IndividualCustomer)
                            : typeof(CorporateCustomer),
                        request.Fetch,
                        request.Offset),
                    cancellationToken),
                _ => _customerRepository.ListAsync(
                    new GetAllCustomersSpec(
                        _currentMechShopProvider.GetCurrentId(),
                        request.Fetch,
                        request.Offset),
                    cancellationToken)
            }
        );

        return Result.Ok(customers.Select(customer => (CustomerDto)customer));
    }
}