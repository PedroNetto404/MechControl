using Ardalis.Specification;
using MechControl.Domain.Core.Primitives;

namespace MechControl.Domain.Core.Abstractions;

public interface IRepository<TAggregateRoot, TAggregateId>
	where TAggregateRoot : AggregateRoot<TAggregateId>
	where TAggregateId : StrongId
{
	Task<TAggregateRoot?> GetByIdAsync(TAggregateId id, CancellationToken cancellationToken = default);
	Task<List<TAggregateRoot>> ListAsync(ISpecification<TAggregateRoot> specification, CancellationToken cancellationToken = default);
	Task AddAsync(TAggregateRoot aggregate);
	Task UpdateAsync(TAggregateRoot aggregate);
	Task DeleteAsync(TAggregateRoot aggregate);
}