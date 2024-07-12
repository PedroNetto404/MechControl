using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Features.Customers;
using MechControl.Domain.Features.Users;

namespace MechControl.Application.Abstractions;

public interface IUnitOfWork
{
    IRepository<Customer, CustomerId> Customers { get; }

    IRepository<User, UserId> Users { get; }

    ValueTask<bool> CommitAsync(CancellationToken cancellationToken = default);
}
