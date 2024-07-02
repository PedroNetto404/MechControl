using MechControl.Domain.Features.Customers.ValueObjects;
using MechControl.Domain.Shared.ValueObjects;

namespace MechControl.Domain.Features.Customers;

public sealed class IndividualCustomer : Customer
{
    public Cpf Cpf { get; private set; } 
    public DateTime BirthDate { get; private set; } 
    
    public IndividualCustomer(
        PersonName name,
        Email email,
        Phone phone,
        Address address,
        Cpf cpf,
        DateTime birthDate) : 
            base(
                name, 
                email, 
                phone, 
                address)
    {
        Cpf = cpf;
        BirthDate = birthDate;
    }
    
    protected IndividualCustomer()
    {
    }
}
