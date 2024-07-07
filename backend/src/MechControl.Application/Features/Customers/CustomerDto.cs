using MechControl.Domain.Features.Customers;

namespace MechControl.Application.Features.Customers;
public record CustomerDto(
	Guid Id,
	string Phone,
	string Email,
	string AddressLine,
	string CustomerType,
	string DocumentType,
	string DocumentNumber,
	string? FullName = null,
	string? FristName = null,
	string? LastName = null,
	DateTime? BirthDate = null,
	bool? IsMei = null,
	string? TradeName = null,
	string? CompanyName = null
)
{
	public static implicit operator CustomerDto(Customer customer) =>
		customer switch
		{
			IndividualCustomer individualCustomer => new CustomerDto(
				individualCustomer.Id.Value,
				individualCustomer.Phone.Value,
				individualCustomer.Email.Value,
				individualCustomer.Address.ToString(),
				"individual",
				"CPF",
				individualCustomer.Document.Value,
				individualCustomer.Name.Fullname,
				individualCustomer.Name.First,
				individualCustomer.Name.Last,
				individualCustomer.BirthDate,
				null,
				null,
				null
			),
			CorporateCustomer corporateCustomer => new CustomerDto(
				corporateCustomer.Id.Value,
				corporateCustomer.Phone.Value,
				corporateCustomer.Email.Value,
				corporateCustomer.Address.ToString(),
				"corporate",
				"CNPJ",
				corporateCustomer.Document.Value,
				null,
				null,
				null,
				null,
				corporateCustomer.IsMei,
				corporateCustomer.TradeName,
				corporateCustomer.CompanyName
			),
			_ => throw new NotSupportedException()
		};
}
