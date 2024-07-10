using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Core.Primitives.Result;

namespace MechControl.Domain.Shared.ValueObjects;

public sealed class Cnpj : Document
{

    public const int Length = 14;
    private Cnpj(string value) : base(value)
    {
    }


    public static Result<Cnpj> New(string value)
    {
        if (string.IsNullOrEmpty(value))
            return new Error("invalid_cnpj", "CNPJ is required");

        if (value.Length != Length)
            return new Error("invalid_cnpj", "CNPJ must have 14 characters");

        return Result.Ok(new Cnpj(value));
    }
}
