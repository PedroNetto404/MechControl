using MechControl.Application.Abstractions;
using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Features.Customers;
using MechControl.Domain.Features.Users;

namespace MechControl.Infrastructure.Persistence;

public class UnitOfWork(
    MechControlContext context,
    IRepository<Customer, CustomerId> customers,
    IRepository<User, UserId> users
) : IUnitOfWork
{
    private readonly IRepository<Customer, CustomerId> _customers = customers;
    
    private readonly IRepository<User, UserId> _users = users;
    private readonly MechControlContext _context = context;
    
    public IRepository<Customer, CustomerId> Customers => 
        _customers;

    public IRepository<User, UserId> Users => 
        _users;

    public async ValueTask<bool> CommitAsync(CancellationToken cancellationToken = default) =>
        await _context.SaveChangesAsync(cancellationToken) > 0;
}
