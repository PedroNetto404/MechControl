using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Core.Primitives.Result;

namespace MechControl.Domain.Shared.ValueObjects;

public record Cpf : ValueObject
{
    public string Value { get; private set; }

    private Cpf(string value) => Value = value;

    public static Result<Cpf> New(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Result<Cpf>.Fail(
                new Error("invalid_cpf", "Cpf is required"));

        if (value.Length != 11)
            return Result<Cpf>.Fail(
                new Error("invalid_cpf", "Cpf must have 11 characters"));


        if (!IsValid(value))
            return Result<Cpf>.Fail(
                new Error("invalid_cpf", "Cpf is invalid"));

        return Result<Cpf>.Ok(new Cpf(value));
    }

    private static bool IsValid(string value)
    {
        //TODO: Implement CPF validation logic
        return true;
    }
}
