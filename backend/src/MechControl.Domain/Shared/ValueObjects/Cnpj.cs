using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Core.Primitives.Result;

namespace MechControl.Domain.Shared.ValueObjects;

public record Cnpj : ValueObject
{
    public string Value { get; private set; }

    private Cnpj(string value) => Value = value;

    public static Result<Cnpj> New(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Result<Cnpj>.Fail(
                new Error("invalid_cnpj", "Cnpj is required"));

        if (value.Length != 14)
            return Result<Cnpj>.Fail(
                new Error("invalid_cnpj", "Cnpj must have 14 characters"));

        if (!IsValid(value))
            return Result<Cnpj>.Fail(
                new Error("invalid_cnpj", "Cnpj is invalid"));

        return Result<Cnpj>.Ok(new Cnpj(value));
    }

    private static bool IsValid(string value)
    {
        //TODO: Implement CNPJ validation logic
        return true;
    }
}
