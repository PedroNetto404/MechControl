using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Features.Customers.ValueObjects;
using MechControl.Domain.Shared.ValueObjects;

namespace MechControl.Domain.Features.Customers;

public record CustomerId : StrongId<CustomerId>
{
    protected CustomerId(Guid value) : base(value)
    {
    }
}

public abstract class Customer : AuditableEntity<CustomerId>
{
    public PersonName Name { get; private set; }
    public Email Email { get; private set; }
    public Phone Phone { get; private set; }
    public Address Address { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Customer()
    {
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    protected Customer(
        PersonName name,
        Email email,
        Phone phone,
        Address address) : base(CustomerId.New())
    {
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
    }
}