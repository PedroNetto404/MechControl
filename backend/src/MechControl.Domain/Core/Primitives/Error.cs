
namespace MechControl.Domain.Core.Primitives;

/// <summary>
/// Represents an error.
/// </summary>
public sealed class Error(string Code, string Message) : ValueObject<Error>
{
    public static Error Unknow() => new("unknow", "An unknow error has occurred.");

    public static Error NotFound() => new("not_found", "The resource was not found.");

    public static Error InvalidOperation(string message) => new("invalid_operation", message);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
        yield return Message;
    }
}