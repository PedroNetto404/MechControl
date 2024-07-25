
namespace MechControl.Domain.Core.Primitives;

/// <summary>
/// Represents an error.
/// </summary>
public class Error(string code, string message) : ValueObject<Error>
{
    public string Code { get; } = code;
    public string Message { get; } = message;

    public static Error Unknow() => new("unknow", "An unknow error has occurred.");

    public static Error NotFound() => new("not_found", "The resource was not found.");

    public static Error InvalidOperation(string message) => new("invalid_operation", message);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
        yield return Message;
    }

    public sealed override string ToString() => $"[{Code}: {Message}]";
}
