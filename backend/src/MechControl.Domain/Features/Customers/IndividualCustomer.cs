using MechControl.Domain.Features.Customers.Events;
using MechControl.Domain.Features.Customers.ValueObjects;
using MechControl.Domain.Features.MechShops;
using MechControl.Domain.Shared.ValueObjects;

namespace MechControl.Domain.Features.Customers;

public sealed class IndividualCustomer : Customer
{
    public DateOnly BirthDate { get; private set; }

    internal IndividualCustomer(
        Name name,
        Email email,
        Phone phone,
        Address address,
        Cpf cpf,
        DateOnly birthDate,
        MechShopId mechShopId) :
            base(
                name,
                cpf,
                email,
                phone,
                address,
                mechShopId) => BirthDate = birthDate;

    public static IndividualCustomer Create(
        Name name,
        Email email,
        Phone phone,
        Address address,
        Cpf cpf,
        DateOnly birthDate,
        MechShopId mechShopId)
    {
        var customer = new IndividualCustomer(
            name,
            email,
            phone,
            address,
            cpf,
            birthDate,
            mechShopId);

        customer.RaiseDomainEvent(new CustomerCreated(customer.Id));

        return customer;
    }

#pragma warning disable CS0628 // New protected member declared in sealed type
    protected IndividualCustomer()
#pragma warning restore CS0628 // New protected member declared in sealed type
    {
    }
}
