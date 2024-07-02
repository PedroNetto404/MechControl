using System.Text.RegularExpressions;
using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Core.Primitives.Result;

namespace MechControl.Domain.Shared.ValueObjects;

public sealed record Email : ValueObject
{
    private static readonly Regex EmailRegex = new(
        "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", 
        RegexOptions.Compiled);

    public string Value { get; private set; }

    private Email(string value) => Value = value;

    public static Result<Email> New(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Result<Email>.Fail(
                new Error("invalid_email", "Email is required"));

        if (!EmailRegex.IsMatch(value))
            return Result<Email>.Fail(
                new Error("invalid_email", "Email is invalid"));

        return Result<Email>.Ok(new Email(value));
    }
}