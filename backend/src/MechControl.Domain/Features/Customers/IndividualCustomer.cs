using MechControl.Domain.Features.Customers.ValueObjects;
using MechControl.Domain.Features.MechShops;
using MechControl.Domain.Shared.ValueObjects;

namespace MechControl.Domain.Features.Customers;

public sealed class IndividualCustomer : Customer
{
    public DateOnly BirthDate { get; private set; }

    public IndividualCustomer(
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

    protected IndividualCustomer()
    {
    }
}
