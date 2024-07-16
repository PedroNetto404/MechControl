using MechControl.Domain.Core.Primitives.Result;
using MediatR;

namespace MechControl.Application.Abstractions;

public interface IQueryHandler<TQuery, TResponse> : 
	IRequestHandler<TQuery, Result<TResponse>>
	where TQuery : IQuery<TResponse>;