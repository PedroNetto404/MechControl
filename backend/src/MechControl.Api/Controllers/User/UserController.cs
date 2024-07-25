using MechControl.Application.Features.Users.Commands.Signin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MechControl.Api.Controllers.User;

[Route("api/v1/users")]
public sealed class UserController(ISender sender) : Controller(sender)
{
    [HttpPost("sign-in")]
    public Task<IActionResult> Signin([FromBody] SigninRequest request) =>
        HandleResult(
            _sender.Send(
                new SigninCommand(
                    request.Email,
                    request.Password)));
}
