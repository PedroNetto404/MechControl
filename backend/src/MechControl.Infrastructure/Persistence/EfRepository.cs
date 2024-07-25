using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Core.Primitives;
using Microsoft.EntityFrameworkCore;

namespace MechControl.Infrastructure.Persistence;

internal class EfRepository<TAggregateRoot, TAggregateRootId>(
    MechControlContext context
) :
    IRepository<TAggregateRoot, TAggregateRootId>
    where TAggregateRoot : AggregateRoot<TAggregateRootId>
    where TAggregateRootId : StrongId
{
    public Task<TAggregateRoot?> GetByIdAsync(
        TAggregateRootId id,
        CancellationToken cancellationToken = default) =>
        context
            .Set<TAggregateRoot>()
            .FindAsync([id], cancellationToken)
            .AsTask();

    public Task<List<TAggregateRoot>> ListAsync(
        ISpecification<TAggregateRoot> specification,
        CancellationToken cancellationToken = default) =>
        SpecificationEvaluator
            .Default
            .GetQuery(
                context.Set<TAggregateRoot>().AsQueryable(),
                specification)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public Task AddAsync(TAggregateRoot aggregate)
    {
        context.Set<TAggregateRoot>().Add(aggregate);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(TAggregateRoot entity)
    {
        context.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(TAggregateRoot aggregate)
    {
        context.Set<TAggregateRoot>().Remove(aggregate);
        return Task.CompletedTask;
    }
}
