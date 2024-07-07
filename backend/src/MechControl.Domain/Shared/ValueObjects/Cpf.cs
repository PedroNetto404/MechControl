using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Core.Primitives.Result;

namespace MechControl.Domain.Shared.ValueObjects;

public sealed class Cpf : Document
{
    public const int Length = 11;

    private Cpf(string value) : base(value)
    {
    }

    public static Result<Cpf> New(string value)
    {
        try
        {
            var cpf = new Cpf(value);
            return Result<Cpf>.Ok(cpf);
        }
        catch (ArgumentException ex)
        {
            return Result<Cpf>.Fail(new Error("invalid_cpf", ex.Message));
        }
        catch
        {
            return Result<Cpf>.Fail(new Error("invalid_cpf", "Invalid CPF"));
        }
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override bool IsValidFormat(string value)
    {
        throw new NotImplementedException();
    }
}
