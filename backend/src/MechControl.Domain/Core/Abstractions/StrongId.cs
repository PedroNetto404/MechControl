using System.Reflection;
using MechControl.Domain.Core.Primitives;

namespace MechControl.Domain.Core.Abstractions;

public abstract class StrongId : ValueObject<StrongId>
{
    protected StrongId(Guid value) => Value = value;

    public Guid Value { get; }

    public static K New<K>() where K : StrongId => 
        (K)GetConstructor(typeof(K)).Invoke([Guid.NewGuid()]);

    public static K From<K>(Guid value) where K : StrongId => 
        (K)GetConstructor(typeof(K)).Invoke([value]);

    private static ConstructorInfo GetConstructor(Type type) => type.GetConstructor(
            BindingFlags.NonPublic | BindingFlags.Instance,
            null,
            [typeof(Guid)],
            null) ?? 
            throw new InvalidOperationException(
                $"Type {type.Name} does not have a private constructor that accepts a Guid.");

    public sealed override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}