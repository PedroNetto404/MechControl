using MechControl.Application.Abstractions;

namespace MechControl.Application.Features.Customers.Queries.GetById;

public record GetCustomerByIdQuery(Guid Id) : IQuery<CustomerDto>;
