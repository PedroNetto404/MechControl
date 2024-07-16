using MechControl.Application.Abstractions;
using MechControl.Domain.Attributes;
using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Features.Customers;
using MechControl.Domain.Features.Users;

namespace MechControl.Infrastructure.Persistence;

[ScopedService(typeof(IUnitOfWork))]
internal class UnitOfWork(
    MechControlContext context,
    IRepository<Customer, CustomerId> customers,
    IRepository<User, UserId> users
) : IUnitOfWork
{
    private readonly MechControlContext _context = context;

    public IRepository<Customer, CustomerId> Customers { get; } = customers;
    public IRepository<User, UserId> Users { get; } = users;

    public async ValueTask<bool> CommitAsync(CancellationToken cancellationToken = default) =>
        await _context.SaveChangesAsync(cancellationToken) > 0;
}
