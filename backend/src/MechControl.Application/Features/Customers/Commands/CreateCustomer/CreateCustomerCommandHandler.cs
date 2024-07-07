using MechControl.Application.Abstractions;
using MechControl.Domain.Core.Primitives.Result;
using MechControl.Domain.Features.Customers;
using MechControl.Domain.Features.Customers.ValueObjects;
using MechControl.Domain.Shared.ValueObjects;

namespace MechControl.Application.Features.Customers.Commands.CreateCustomer;

public sealed class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, CustomerDto>
{
    public async Task<Result<CustomerDto>> Handle(
		CreateCustomerCommand request, 
		CancellationToken cancellationToken)
    {
		var nameResult = Name.New(request.Name);
		var documentResult = Document.New(request.Document);
    }
}