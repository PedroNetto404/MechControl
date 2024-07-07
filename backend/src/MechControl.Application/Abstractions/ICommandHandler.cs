using MechControl.Domain.Core.Primitives.Result;
using MediatR;

namespace MechControl.Application.Abstractions;

public interface ICommandHandler<TCommand, TResponse> : 
	IRequestHandler<TCommand, Result<TResponse>>
	where TCommand : ICommand<TResponse>;