namespace MechControl.Domain.Core.Abstractions;

/// <summary>
/// Markup interface for aggregate root.
/// </summary>
internal interface IAggregateRoot
{
	IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

	void ClearDomainEvents();

	void AddDomainEvent(IDomainEvent domainEvent);
}