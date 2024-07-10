using MechControl.Application;
using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Features.Customers;

namespace MechControl.Infrastructure.Persistence;

public class UnitOfWork(
    MechControlContext context,
    IRepository<Customer, CustomerId> customers
) : IUnitOfWork
{
    private readonly IRepository<Customer, CustomerId> _customers = customers;
    private readonly MechControlContext _context = context;
    
    public IRepository<Customer, CustomerId> Customers => 
        _customers;

    public async ValueTask<bool> CommitAsync(CancellationToken cancellationToken = default) =>
        await _context.SaveChangesAsync(cancellationToken) > 0;
}
