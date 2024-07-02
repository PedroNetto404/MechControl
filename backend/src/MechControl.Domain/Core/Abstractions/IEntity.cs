namespace MechControl.Domain.Core.Abstractions;

/// <summary>
/// Represents an entity in the domain.
/// </summary>
/// <typeparam name="TId">Strong type for the entity's identifier.</typeparam>
public interface IEntity<out TId>
{
    public TId Id { get; }
}