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
		var nameResult = Name.New(request.Name);
		var documentResult = Document.New(request.CustomerType, request.Document);
		var addressResult = request.MakeAddress();
		var phoneResult = Phone.New(request.Phone);
		var emailResult = Email.New(request.Email);
		if(Result.Combine(
			nameResult,
			documentResult,
			addressResult,
			phoneResult,
			emailResult
		) is {IsFailure: true, Error: var error}) return error!;

		var customer = Customer.Create(
			nameResult,
			emailResult,
			phoneResult,
			addressResult, 
			 _currentMechShopProvider.Current, 
			request.CustomerType, 
			documentResult.Value, 
			request.IsMei, 
			request.BirthDate);

		await _unitOfWork.Customers.AddAsync(customer);

		return await _unitOfWork.CommitAsync(cancellationToken)
			? Result.Ok<CustomerDto>((Customer)customer)
			: Error.Unknow();
	}
}