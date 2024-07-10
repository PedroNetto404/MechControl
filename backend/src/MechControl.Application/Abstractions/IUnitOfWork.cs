using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Features.Customers;

namespace MechControl.Application;

public interface IUnitOfWork
{
    IRepository<Customer, CustomerId> Customers { get; }

    ValueTask<bool> CommitAsync(CancellationToken cancellationToken = default);
}
