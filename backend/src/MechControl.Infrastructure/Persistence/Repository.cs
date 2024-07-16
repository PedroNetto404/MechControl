using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using MechControl.Domain.Attributes;
using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Core.Primitives;
using Microsoft.EntityFrameworkCore;

namespace MechControl.Infrastructure.Persistence;

[ScopedService(typeof(IRepository<,>))]
internal class Repository<TAggregateRoot, TAggregateRootId>(
    MechControlContext context
) :
    IRepository<TAggregateRoot, TAggregateRootId>
      where TAggregateRoot : AggregateRoot<TAggregateRootId>
    where TAggregateRootId : StrongId
{
    private readonly MechControlContext _context = context;

    public Task<TAggregateRoot?> GetByIdAsync(
        TAggregateRootId id, 
        CancellationToken cancellationToken = default) =>
        _context
            .Set<TAggregateRoot>()
            .FindAsync([id], cancellationToken)
            .AsTask();

    public Task<List<TAggregateRoot>> ListAsync(
        ISpecification<TAggregateRoot> specification,
        CancellationToken cancellationToken = default) =>
        SpecificationEvaluator
            .Default
            .GetQuery(
                _context.Set<TAggregateRoot>().AsQueryable(),
                specification)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public Task AddAsync(TAggregateRoot aggregate)
    {
        _context.Set<TAggregateRoot>().Add(aggregate);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(TAggregateRoot entity)
    {
        _context.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(TAggregateRoot aggregate)
    {
        if (aggregate is IAuditableEntity auditableEntity)
        {
            auditableEntity.Delete();
            _context.Set<TAggregateRoot>().Update(aggregate);

            return Task.CompletedTask;
        }


        _context.Set<TAggregateRoot>().Remove(aggregate);
        return Task.CompletedTask;
    }
}