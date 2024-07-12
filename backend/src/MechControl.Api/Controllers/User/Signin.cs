using System.ComponentModel.DataAnnotations;
using MechControl.Application.Features.Users.Commands.Signin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MechControl.Api.Controllers.User;

[Authorize]
[ApiVersion(ApiVersion.V1)]
[Route("api/v{version:apiVersion}/users")]
public partial class UserController(ISender sender) : Controller(sender)
{
    public sealed record SigninRequest
    {
        [Required]
        public required string Email { get; init; }

        [Required]
        public required string Password { get; init; }
    }

    [Host]
    public Task<IActionResult> Signin(SigninRequest request) =>
      HandleResult(
        _sender.Send(
          new SigninCommand(
            request.Email,
            request.Password)));
}
