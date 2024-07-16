using MechControl.Domain.Core.Primitives.Result;
using MediatR;

namespace MechControl.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
