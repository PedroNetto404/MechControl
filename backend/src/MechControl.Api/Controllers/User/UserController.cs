using MechControl.Application.Features.Users.Commands.Signin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MechControl.Api.Controllers.User;

[Authorize]
[Route("api/v1/users")]
public sealed partial class UserController(ISender sender) : Controller(sender)
{

  [HttpPost("sign-in")]
  public Task<IActionResult> Signin([FromBody] SigninRequest request) =>
    HandleResult(
      _sender.Send(
        new SigninCommand(
          request.Email,
          request.Password)));
}
