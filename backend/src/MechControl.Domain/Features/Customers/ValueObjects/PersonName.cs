using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Core.Primitives.Result;

namespace MechControl.Domain.Features.Customers.ValueObjects;

public record PersonName : ValueObject
{
    public const int MinLenght = 10;

    public string Fullname { get; }

    public string First => Fullname[..Fullname.IndexOf(' ')];

    public string Last => Fullname[Fullname.IndexOf(' ')..];

    public string Middle => Fullname[(Fullname.IndexOf(' ') + 1)..Fullname.LastIndexOf(' ')];

    private PersonName(string fullname) => Fullname = fullname;

    public static Result<PersonName> New(string name)
    {
        if(string.IsNullOrEmpty(name))
            return Result<PersonName>.Fail(
                new Error("invalid_customer_name", "Customer name is required"));

        if(name.Length < MinLenght)
            return Result<PersonName>.Fail(
                new Error("invalid_customer_name", $"Customer name must have at least {MinLenght} characters"));

        return Result<PersonName>.Ok(new PersonName(name));
    }
}