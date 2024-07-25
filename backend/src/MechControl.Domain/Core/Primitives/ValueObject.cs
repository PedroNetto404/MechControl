namespace MechControl.Domain.Core.Primitives;

/// <summary>
/// Represents a value object. <see href="https://martinfowler.com/bliki/ValueObject.html">Value Object</see>
/// </summary>
public abstract class ValueObject<T> :
    IEquatable<T>
    where T : ValueObject<T>
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public bool Equals(T? other)
    {
        if (other is null) return false;
        return ReferenceEquals(this, other) || GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override bool Equals(object? obj) => obj is T other && Equals(other);

    public override int GetHashCode() => GetEqualityComponents()
        .Aggregate(1, (current, obj) => current * 23 + (obj?.GetHashCode() ?? 0));

    public static bool operator ==(ValueObject<T>? a, ValueObject<T>? b) =>
        ReferenceEquals(a, b) || a?.Equals(b) == true;

    public static bool operator !=(ValueObject<T>? a, ValueObject<T>? b) =>
        !(a == b);
}
