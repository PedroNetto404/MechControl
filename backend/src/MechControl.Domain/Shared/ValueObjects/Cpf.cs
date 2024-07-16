using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Core.Primitives.Result;

namespace MechControl.Domain.Shared.ValueObjects;

public sealed class Cpf : Document
{
    public const int Length = 11;

    private Cpf(string value) : base(value)
    {
    }

    public static Result<Document> New(string value)
    {
        if (string.IsNullOrEmpty(value))
            return new Error("invalid_cpf", "CPF is required");

        if (value.Length != Length)
            return new Error("invalid_cpf", "CPF must have 11 characters");

        return new Cpf(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
