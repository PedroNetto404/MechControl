using MechControl.Application.Abstractions;

namespace MechControl.Application.Features.Users.Commands.Signin;

public sealed record SigninCommand(
    string Email,
    string Password) :
    ICommand;

