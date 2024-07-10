using MechControl.Application.Abstractions;
using MechControl.Application.shared;

namespace MechControl.Application.Features.Customers.Queries.GetAll;

public record GetAllCustomersQuery(
    int Fetch,
    int Offset,
    string? CustomerType) :
    PaginationFilter(Fetch, Offset),
    IQuery<IEnumerable<CustomerDto>>;
