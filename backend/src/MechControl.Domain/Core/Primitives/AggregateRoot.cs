using MechControl.Domain.Core.Abstractions;

namespace MechControl.Domain.Core.Primitives;

public abstract class AggregateRoot<TId> :
	Entity<TId>,
	IAggregateRoot
	where TId : StrongId
{
	private readonly List<IDomainEvent> _domainEvents = [];

	protected AggregateRoot()
	{
	}

	IReadOnlyCollection<IDomainEvent> IAggregateRoot.DomainEvents => [.. _domainEvents];

	public void ClearDomainEvents() => _domainEvents.Clear();

	public void RaiseDomainEvent(IDomainEvent domainEvent) => 
		_domainEvents.Add(domainEvent);
}