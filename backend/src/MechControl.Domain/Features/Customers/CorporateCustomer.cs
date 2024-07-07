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
        string tradeName,
        string companyName,
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

    protected CorporateCustomer()
    {
    }
}
