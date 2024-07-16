using MechControl.Application.Abstractions;
using MechControl.Domain.Features.Customers.Enums;

namespace MechControl.Application.Features.Customers.Queries.GetAll;

public sealed class GetAllCustomersQuery(
    int Fetch,
    int Offset,
    CustomerType? CustomerType) :
    IPaginatedQuery<IEnumerable<CustomerDto>>
{
    public CustomerType? CustomerType { get; } = CustomerType;
    public int Offset { get; } = Offset;
    public int Fetch { get; } = Fetch;
}
