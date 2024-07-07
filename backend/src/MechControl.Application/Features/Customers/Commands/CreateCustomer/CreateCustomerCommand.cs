
using MechControl.Application.Abstractions;

namespace MechControl.Application.Features.Customers.Commands.CreateCustomer;

public record CreateCustomerCommand(
	string Name,
	string Document,
	string Email,
	string Phone,
	string DocumentType,
	DateOnly? BirthDate,
	string AddressStreet,
	string AddressNumber,
	string AddressNeighborhood,
	string AddressCity,
	string AddressStateCode,
	string AddressZipCode,
	string? AddressComplement,
	string? AddressReference,
	bool? IsMei
) : ICommand<CustomerDto>;
