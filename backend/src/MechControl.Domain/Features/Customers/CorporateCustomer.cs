using MechControl.Domain.Features.Customers.Events;
using MechControl.Domain.Features.Customers.ValueObjects;
using MechControl.Domain.Features.MechShops;
using MechControl.Domain.Shared.ValueObjects;

namespace MechControl.Domain.Features.Customers;

public sealed class CorporateCustomer : Customer
{
    public bool IsMei { get; private set; }

    public CorporateCustomer(
        Name name,
        Email email,
        Phone phone,
        Address address,
        Cnpj cnpj,
        bool isMei,
        MechShopId mechShopId) :
            base(
                name,
                cnpj,
                email,
                phone,
                address,
                mechShopId)
    {
        IsMei = isMei;
    }

    public static CorporateCustomer Create(
        Name name,
        Email email,
        Phone phone,
        Address address,
        Cnpj cnpj,
        bool isMei,
        MechShopId mechShopId)
    {
        var customer = new CorporateCustomer(
            name,
            email,
            phone,
            address,
            cnpj,
            isMei,
            mechShopId);

        customer.RaiseDomainEvent(new CustomerCreated(customer.Id));

        return customer;
    }

#pragma warning disable CS0628 // New protected member declared in sealed type
    protected CorporateCustomer()
#pragma warning restore CS0628 // New protected member declared in sealed type
    {
    }
}
