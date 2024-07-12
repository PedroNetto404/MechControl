using MechControl.Domain.Core.Abstractions;

namespace MechControl.Domain.Features.Customers.Events;

public record CustomerCreated(
    CustomerId CustomerId
) : IDomainEvent;
