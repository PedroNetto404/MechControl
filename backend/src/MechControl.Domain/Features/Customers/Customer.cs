using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Features.Customers.ValueObjects;
using MechControl.Domain.Features.MechShops;
using MechControl.Domain.Shared.ValueObjects;

namespace MechControl.Domain.Features.Customers;

public sealed class CustomerId : StrongId
{
    private CustomerId(Guid value) : base(value)
    {
    }
}

public abstract class Customer : AggregateRoot<CustomerId>, IAuditableEntity
{
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Phone Phone { get; private set; }
    public Address Address { get; private set; }
    public Document Document { get; private set; }
    public MechShopId MechShopId { get; private set; }

    public DateTime CreatedOnUtc { get; } = DateTime.UtcNow;

    public DateTime ModifiedOnUtc { get; private set; } = DateTime.UtcNow;

    public DateTime? DeletedOnUtc { get; private set; }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Customer()
    {
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    protected Customer(
        Name name,
        Document document,
        Email email,
        Phone phone,
        Address address,
        MechShopId mechShopId)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
        Document = document;
        MechShopId = mechShopId;
    }
}