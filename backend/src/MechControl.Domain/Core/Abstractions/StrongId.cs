using System.Reflection;

namespace MechControl.Domain.Core.Abstractions;

public abstract record StrongId<T> where T : StrongId<T>
{
    protected StrongId(Guid value) => Value = value;

    public Guid Value { get; } 

    public static T New() => (T)GetConstructor().Invoke([Guid.NewGuid()]);

    public static T From(Guid value) => (T)GetConstructor().Invoke([value]);
    
    private static ConstructorInfo GetConstructor()
    {
        var constructor = typeof(T).GetConstructor(
            BindingFlags.NonPublic | BindingFlags.Instance,
            null,
            [typeof(Guid)],
            null);
        
        if (constructor == null)
        {
            throw new InvalidOperationException($"Type {typeof(T)} does not have a private constructor that accepts a Guid.");
        }
        
        return constructor;
    }

    public static implicit operator Guid(StrongId<T> id) => id.Value;
}