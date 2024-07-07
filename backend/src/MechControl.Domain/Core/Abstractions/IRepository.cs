using Ardalis.Specification;
using MechControl.Domain.Core.Primitives;

namespace MechControl.Domain.Core.Abstractions;

public interface IRepository<TAggregateRoot, TAggregateId>
	where TAggregateRoot : AggregateRoot<TAggregateId>
	where TAggregateId : StrongId
{
	Task<TAggregateRoot> GetByIdAsync(TAggregateId id, CancellationToken cancellationToken);
	Task<IList<TAggregateRoot>> ListAsync(ISpecification<TAggregateRoot> specification, CancellationToken cancellationToken);
	Task<TAggregateRoot> AddAsync(TAggregateRoot entity, CancellationToken cancellationToken);
	Task<TAggregateRoot> UpdateAsync(TAggregateRoot entity, CancellationToken cancellationToken);
	Task<TAggregateRoot> DeleteAsync(TAggregateId id, CancellationToken cancellationToken);
}