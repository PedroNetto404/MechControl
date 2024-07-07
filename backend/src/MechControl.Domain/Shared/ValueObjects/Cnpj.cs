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
        try 
        {
            var cnpj = new Cnpj(value);
            return Result<Cnpj>.Ok(cnpj);
        }
        catch (ArgumentException ex)
        {
            return Result<Cnpj>.Fail(new Error("invalid_cnpj", ex.Message));
        }
        catch
        {
            return Result<Cnpj>.Fail(new Error("invalid_cnpj", "Invalid CNPJ"));
        }
    }

    public override bool IsValidFormat(string value)
    {
        throw new NotImplementedException();
    }
}
