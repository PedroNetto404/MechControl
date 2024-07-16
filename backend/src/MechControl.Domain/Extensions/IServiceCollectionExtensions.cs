using System.Reflection;
using MechControl.Domain.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace MechControl.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services) => AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(p =>
                p.GetTypes()
                 .Select<Type, (Type, ServiceLifetimeAttribute?)>(static type =>
                 (type, type.GetCustomAttribute<ServiceLifetimeAttribute>())))
            .Where(tuple => tuple.Item2 is not null)
            .ToList()
            .ForEach(type =>
            {
                var serviceLifetimeAttr = type.Item2!;
                if (!serviceLifetimeAttr.AbstractionTypes.Any())
                {
                    services.Add(new(
                                      serviceType: type.Item1,
                                      implementationType: type.Item1,
                                      lifetime: serviceLifetimeAttr.Lifetime));
                    return;
                }

                foreach (var abstractionType in serviceLifetimeAttr.AbstractionTypes)
                {
                    services.Add(new(
                            serviceType: abstractionType,
                            implementationType: type.Item1,
                            lifetime: serviceLifetimeAttr.Lifetime));
                }
            });
}