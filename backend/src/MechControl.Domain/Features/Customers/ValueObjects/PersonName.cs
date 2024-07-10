using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Core.Primitives.Result;

namespace MechControl.Domain.Features.Customers.ValueObjects;

public sealed class Name : ValueObject<Name>
{
    public const int MinLenght = 10;

    public string Fullname { get; }

    public string First => Fullname[..Fullname.IndexOf(' ')];

    public string Last => Fullname[Fullname.IndexOf(' ')..];

    public string Middle => Fullname[(Fullname.IndexOf(' ') + 1)..Fullname.LastIndexOf(' ')];

    private Name(string fullname) => Fullname = fullname;

    public static Result<Name> New(string name)
    {
        if(string.IsNullOrEmpty(name))
            return new Error("invalid_customer_name", "Customer name is required");

        if(name.Length < MinLenght)
            return new Error("invalid_customer_name", $"Customer name must have at least {MinLenght} characters");

        return Result.Ok(new Name(name));
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Fullname;
    }
}