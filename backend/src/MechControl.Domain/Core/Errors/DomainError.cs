using MechControl.Domain.Core.Primitives;

namespace MechControl.Domain.Core.Errors;

/// <summary>
/// Represents a domain error.
/// </summary>
/// <param name="Code">Error Identifier.</param>
/// <param name="Message">Error description.</param>
/// <param name="Feature">Domain feature that originated the error.</param>
public class DomainError(string Code, string Message, string Feature) : Error(Code, Message)
{
    public string Feature { get; } = Feature;
}