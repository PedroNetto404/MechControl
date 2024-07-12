using MechControl.Domain.Core.Primitives.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MechControl.Api.Controllers;

[ApiController]
public abstract class Controller(ISender sender) : ControllerBase
{
	protected readonly ISender _sender = sender;

	protected Task<IActionResult> HandleResult<TResult>(
		Task<Result<TResult>> result) =>
		result.Match<TResult, IActionResult>(
			onSuccess: (value) => value switch
			{
				null => NotFound(),
				_ => Ok(value)
			},
			onFailure: BadRequest);

	protected Task<IActionResult> HandleResult(
		Task<Result> result) =>
		result.Match<IActionResult>(
			onSuccess: Ok,
			onFailure: BadRequest);
}
