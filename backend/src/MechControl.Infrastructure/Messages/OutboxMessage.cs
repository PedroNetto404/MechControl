namespace MechControl.Infrastructure;

public record OutboxMessage(
    string EventyTypeName,
    string EventData
)
{
    public DateTime OccurredOnUtc { get; } = DateTime.UtcNow;

    public DateTime? ProcessedOnUtc { get; set; }

    public Guid Id { get; } = Guid.NewGuid();
}
