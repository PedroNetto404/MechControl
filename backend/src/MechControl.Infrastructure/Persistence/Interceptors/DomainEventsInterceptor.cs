using System.Text.Json;
using MechControl.Domain.Core.Abstractions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MechControl.Infrastructure.Persistence.Interceptors;

public class DomainEventsInterceptor : SaveChangesInterceptor
{
    public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var context = eventData.Context ?? throw new InvalidOperationException("Context is null");

        var events = 
            context
                .ChangeTracker
                .Entries<IAggregateRoot>()
                .SelectMany(x => {
                    var events = x.Entity.DomainEvents;
                    x.Entity.ClearDomainEvents();
                    return events;
                })
                .ToList();

        foreach (var domainEvent in events)
        {
            var outboxMessage = new OutboxMessage(
                domainEvent.GetType().Name,
                JsonSerializer.Serialize(domainEvent)
            );

            eventData.Context!.Add(outboxMessage);
        }

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
