using MechControl.Domain.Core.Primitives.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MechControl.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class Controller(ISender sender) : ControllerBase
{
	protected readonly ISender _sender = sender;

	protected Task<IActionResult> HandleResultAsync<TResult>(
		Task<Result<TResult>> result) =>
		result.Match<TResult, IActionResult>(
			onSuccess: (value) => value switch
			{
				null => NotFound(),
				_ => Ok(value)
			},
			onFailure: BadRequest);
}
