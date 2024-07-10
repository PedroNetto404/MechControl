using MechControl.Application.Abstractions;
using MechControl.Application.Interfaces;
using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Core.Primitives.Result;
using MechControl.Domain.Features.Customers;
using MechControl.Domain.Features.Customers.ValueObjects;
using MechControl.Domain.Shared.ValueObjects;

namespace MechControl.Application.Features.Customers.Commands.CreateCustomer;

public sealed class CreateCustomerCommandHandler(
	ICurrentMechShopProvider currentMechShopProvider,
	IUnitOfWork unitOfWork
) : 
	ICommandHandler<CreateCustomerCommand, CustomerDto>
{
	private readonly ICurrentMechShopProvider _currentMechShopProvider = currentMechShopProvider;
	private readonly IUnitOfWork _unitOfWork = unitOfWork;
	
	public async Task<Result<CustomerDto>> Handle(
		CreateCustomerCommand request,
		CancellationToken cancellationToken)
	{
		var isIndividual = request.DocumentType == nameof(Cpf);

		var nameResult = Name.New(request.Name);
		var documentResult = isIndividual
			? Cpf.New(request.Document).Map(x => (Document)x)
			: Cnpj.New(request.Document).Map(x => (Document)x);
		var addressResult = Address.New(
			request.AddressStreet,
			request.AddressNumber,
			request.AddressNeighborhood,
			request.AddressCity,
			request.AddressZipCode,
			request.AddressStateCode,
			request.AddressCountryCode,
			request.AddressComplement,
			request.AddressReference
		);
		var phoneResult = Phone.New(request.Phone);
		var emailResult = Email.New(request.Email);
		var mechShopId = _currentMechShopProvider.GetCurrentId();
	
		var result = Result.Combine(
			nameResult,
			documentResult,
			addressResult,
			phoneResult,
			emailResult
		);

		if (result.IsFailure) return result.Error!;

		var customer = isIndividual
			? (Customer)new IndividualCustomer(
				nameResult.Value, 
				emailResult.Value, 
				phoneResult.Value, 
				addressResult.Value, 
				(documentResult.Value as Cpf)!,
				request.BirthDate!.Value,
				mechShopId) 
			: new CorporateCustomer(
				nameResult.Value, 
				emailResult.Value, 
				phoneResult.Value, 
				addressResult.Value, 
				(documentResult.Value as Cnpj)!,
				request.IsMei!.Value,
				mechShopId);

		await _unitOfWork.Customers.AddAsync(customer);
		var commited = await _unitOfWork.CommitAsync(cancellationToken);

		return commited
			? Result.Ok<CustomerDto>(customer)
			: Error.Unknow();
	}
}