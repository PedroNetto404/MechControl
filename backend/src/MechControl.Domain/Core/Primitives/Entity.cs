using MechControl.Domain.Core.Abstractions;

namespace MechControl.Domain.Core.Primitives;

public abstract class Entity<TId> :
    IEntity<TId>,
    IEquatable<Entity<TId>>
    where TId : StrongId
{
    public TId Id { get; protected set; } 

    protected Entity() => Id = StrongId.New<TId>();

    public bool Equals(Entity<TId>? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj) =>
        obj is Entity<TId> other && Equals(other);

    public override int GetHashCode() => Id.GetHashCode();

    public static bool operator ==(Entity<TId>? a, Entity<TId>? b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(Entity<TId>? a, Entity<TId>? b) => !(a == b);
}