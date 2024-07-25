using MechControl.Application.Abstractions;
using MechControl.Application.Interfaces;

namespace MechControl.Application.Features.Users.Commands.Signin;

public sealed record SigninCommand(
    string Email,
    string Password) :
    ICommand<AuthToken>;

