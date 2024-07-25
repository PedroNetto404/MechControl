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
    public string CountryCode { get; } = "BR";
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
        CountryCode = country;
        Reference = reference;
    }

    protected Address() { }

    public static Result<Address> New(
        string street,
        string number,
        string neighborhood,
        string city,
        string zipCode,
        string stateCode = "SP",
        string countryCode = "BR",
        string? complement = null,
        string? reference = null)
    {
        if (string.IsNullOrEmpty(street))
            return new Error("invalid_address", "Street is required");

        if (string.IsNullOrEmpty(number))
            return new Error("invalid_address", "Number is required");

        if (string.IsNullOrEmpty(neighborhood))
            return new Error("invalid_address", "Neighborhood is required");

        if (string.IsNullOrEmpty(city))
            return new Error("invalid_address", "City is required");

        if (string.IsNullOrEmpty(stateCode) || stateCode.Length != 2)
            return new Error("invalid_address", "State Code is required");

        return Result.Ok(new Address(
            street,
            number,
            neighborhood,
            city,
            stateCode,
            zipCode,
            countryCode,
            complement,
            reference));
    }

    public override string ToString() =>
        $"{ZipCode}, {Street}, {Number}, {Neighborhood}, {City}, {StateCode}, {CountryCode}; {Complement ?? string.Empty}; {Reference ?? string.Empty}";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return Number;
        yield return Neighborhood;
        yield return City;
        yield return StateCode;
        yield return ZipCode;
        yield return CountryCode;
        yield return Complement ?? string.Empty;
        yield return Reference ?? string.Empty;
    }
}
