using MechControl.Application.Abstractions;
using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Core.Errors;
using MechControl.Domain.Core.Primitives.Result;
using MechControl.Domain.Features.Customers;

namespace MechControl.Application.Features.Customers.Queries.GetById;

public class GetCustomerByIdQueryHandler(
    IRepository<Customer, CustomerId> customerRepository
) :
    IQueryHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly IRepository<Customer, CustomerId> _customerRepository = customerRepository;

    public async Task<Result<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customerId = StrongId.From<CustomerId>(request.Id);
        var customer = await _customerRepository.GetByIdAsync(customerId, cancellationToken);

        if (customer is null)
            return new DomainError("not_found", "Customer not found", "Customers");

        return Result.Ok((CustomerDto)customer);
    }
}
