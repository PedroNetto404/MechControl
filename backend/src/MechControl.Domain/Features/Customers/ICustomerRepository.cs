using MechControl.Domain.Core.Abstractions;

namespace MechControl.Domain.Features.Customers;

public interface ICustomerRepository : IRepository<Customer, CustomerId>
{
}