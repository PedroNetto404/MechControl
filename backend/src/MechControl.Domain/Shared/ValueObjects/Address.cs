using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Core.Primitives.Result;

namespace MechControl.Domain.Shared.ValueObjects;

public sealed class Address : ValueObject<Address>
{
    public string Street { get; }
    public string Number { get; }
    public string Neighborhood { get; }
    public string? Complement { get; }
    public string? Reference { get; }
    public string City { get; }
    public string Country { get; } = "Brazil";
    public string StateCode { get; }
    public string ZipCode { get; }

    private Address(
        string street,
        string number,
        string neighborhood,
        string city,
        string stateCode,
        string zipCode,
        string country = "Brazil",
        string? complement = null,
        string? reference = null)
    {
        Street = street;
        Number = number;
        Complement = complement;
        Neighborhood = neighborhood;
        City = city;
        StateCode = stateCode;
        ZipCode = zipCode;
        Country = country;
        Reference = reference;
    }

    public static Result<Address> New(
        string street,
        string number,
        string neighborhood,
        string city,
        string stateCode,
        string zipCode,
        string country = "Brazil",
        string? complement = null,
        string? reference = null)
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

        return Result<Address>.Ok(new(
            street,
            number,
            neighborhood,
            city,
            stateCode,
            zipCode,
            country,
            complement,
            reference));
    }

    public override string ToString() =>
    $"{ZipCode}, {Street}, {Number}, {Neighborhood}, {City}, {StateCode}, {Country}; {Complement ?? string.Empty}; {Reference ?? string.Empty}";

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return Number;
        yield return Neighborhood;
        yield return City;
        yield return StateCode;
        yield return ZipCode;
        yield return Country;
        yield return Complement ?? string.Empty;
        yield return Reference ?? string.Empty;
    }
}
