using MechControl.Domain.Core.Abstractions;

namespace MechControl.Domain.Features.Users.Events;

public record UserCreated(
    UserId UserId
) : IDomainEvent;
