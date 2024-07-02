using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Core.Primitives.Result;

namespace MechControl.Domain.Shared.ValueObjects;

public record Address : ValueObject
{
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Complement { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string StateCode { get; private set; }

    private Address(
        string street,
        string number,
        string complement,
        string neighborhood,
        string city,
        string stateCode)
    {
        Street = street;
        Number = number;
        Complement = complement;
        Neighborhood = neighborhood;
        City = city;
        StateCode = stateCode;
    }

    public static Result<Address> New(
        string street,
        string number,
        string complement,
        string neighborhood,
        string city,
        string stateCode)
    {
        if (string.IsNullOrEmpty(street))
            return Result<Address>.Fail(
                new Error("invalid_address", "Street is required"));

        if (string.IsNullOrEmpty(number))
            return Result<Address>.Fail(
                new Error("invalid_address", "Number is required"));

        if (string.IsNullOrEmpty(neighborhood))
            return Result<Address>.Fail(
                new Error("invalid_address", "Neighborhood is required"));

        if (string.IsNullOrEmpty(city))
            return Result<Address>.Fail(
                new Error("invalid_address", "City is required"));

        if (string.IsNullOrEmpty(stateCode) || stateCode.Length != 2)
            return Result<Address>.Fail(
                new Error("invalid_address", "State is required"));

        return Result<Address>.Ok(new Address(street, number, complement, neighborhood, city, stateCode));
    }

    public override string ToString() => $"{Street}, {Number} - {Neighborhood}, {City}/{StateCode}";
}
