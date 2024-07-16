using Microsoft.Extensions.DependencyInjection;

namespace MechControl.Domain.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public abstract class ServiceLifetimeAttribute(
    params Type[] AbstractionTypes
) : Attribute
{
     public Type[] AbstractionTypes { get; } = AbstractionTypes;

    public abstract ServiceLifetime Lifetime {get;}
}

public class TransientServiceAttribute(params Type[] AbstractionTypes) : ServiceLifetimeAttribute(AbstractionTypes)
{
    public override ServiceLifetime Lifetime => ServiceLifetime.Transient;
}


public class ScopedServiceAttribute(params Type[] AbstractionTypes) : ServiceLifetimeAttribute(AbstractionTypes)
{
    public override ServiceLifetime Lifetime => ServiceLifetime.Scoped;
}


public class SingletonServiceAttribute(params Type[] AbstractionTypes) : ServiceLifetimeAttribute(AbstractionTypes)
{
    public override ServiceLifetime Lifetime => ServiceLifetime.Singleton;
}

