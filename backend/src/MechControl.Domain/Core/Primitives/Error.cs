namespace MechControl.Domain.Core.Primitives;

/// <summary>
/// Represents an error.
/// </summary>
public record Error(string Code, string Message) : ValueObject
{
    public static Error Unknow() => new("unknow", "An unknow error has occurred.");

    public static Error NotFound() => new("not_found", "The resource was not found.");

    public static Error InvalidOperation(string message) => new("invalid_operation", message);
}