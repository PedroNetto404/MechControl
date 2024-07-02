using MechControl.Domain.Features.Customers.ValueObjects;
using MechControl.Domain.Shared.ValueObjects;

namespace MechControl.Domain.Features.Customers;

public sealed class CorporateCustomer : Customer
{
    public Cnpj Cnpj { get; private set; } 
    public bool IsMei { get; private set; } 
    public string TradeName { get; private set; } 
    public string CompanyName { get; private set; }
    
    public CorporateCustomer(
        PersonName name,
        Email email,
        Phone phone,
        Address address,
        Cnpj cnpj,
        bool isMei,
        string tradeName,
        string companyName) : 
            base(
                name, 
                email, 
                phone, 
                address)
    {
        Cnpj = cnpj;
        IsMei = isMei;
        TradeName = tradeName;
        CompanyName = companyName;
    }
    
    protected CorporateCustomer()
    {
    }
}
