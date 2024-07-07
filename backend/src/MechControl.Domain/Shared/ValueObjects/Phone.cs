using System.Text.RegularExpressions;
using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Core.Primitives.Result;

namespace MechControl.Domain.Shared.ValueObjects;

public sealed partial class Phone : ValueObject<Phone>
{
    private static readonly Regex Regex = MyRegex();
    public string Value { get; private set; }

    public string Ddd => Value[..2];

    public string Number => Value[2..];

    private Phone(string value) => Value = value;
    

    public static Result<Phone> New(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Result<Phone>.Fail(
                new Error("invalid_phone", "Phone is required"));

        if (!Regex.IsMatch(value))
            return Result<Phone>.Fail(
                new Error("invalid_phone", "Phone is invalid"));

        return Result<Phone>.Ok(new Phone(value));
    }

    public override string ToString() => $"({Ddd}) {Number[..1]} {Number[1..5]}-{Number[5..]}";

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(Phone phone) => phone.Value;

    [GeneratedRegex(@"^\d{11}$", RegexOptions.Compiled)]
    private static partial Regex MyRegex();
}