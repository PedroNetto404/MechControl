using System.Text.RegularExpressions;
using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Core.Primitives.Result;

namespace MechControl.Domain.Shared.ValueObjects;

public sealed partial class Email : ValueObject<Email>
{
    private static readonly Regex EmailRegex = MyRegex();

    public string Value { get; private set; }

    private Email(string value) => Value = value;

    public static Result<Email> New(string value)
    {
        if (string.IsNullOrEmpty(value))
            return new Error("invalid_email", "Email is required");

        if (!EmailRegex.IsMatch(value))
            return new Error("invalid_email", "Email is invalid");

        return Result.Ok(new Email(value));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    public static implicit operator string(Email email) => email.Value;

    [GeneratedRegex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", RegexOptions.Compiled)]
    private static partial Regex MyRegex();
}
