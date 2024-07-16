
using MechControl.Application.Abstractions;
using MechControl.Domain.Core.Primitives.Result;
using MechControl.Domain.Features.Customers.Enums;
using MechControl.Domain.Shared.ValueObjects;

namespace MechControl.Application.Features.Customers.Commands.CreateCustomer;

public record CreateCustomerCommand(
	string Name,
	string Document,
	string Email,
	string Phone,
	CustomerType CustomerType,
	DateOnly? BirthDate,
	string AddressStreet,
	string AddressNumber,
	string AddressNeighborhood,
	string AddressCity,
	string AddressStateCode,
	string AddressCountryCode,
	string AddressZipCode,
	string? AddressComplement,
	string? AddressReference,
	bool? IsMei
) : ICommand<CustomerDto>
{
	public Result<Address> MakeAddress() =>
		Address.New(
			AddressStreet,
			AddressNumber,
			AddressNeighborhood,
			AddressCity,
			AddressZipCode,
			AddressStateCode,
			AddressCountryCode,
			AddressComplement,
			AddressReference
		);
}
