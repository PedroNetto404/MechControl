using MechControl.Domain.Core.Primitives.Result;
using MediatR;

namespace MechControl.Application.Abstractions;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;