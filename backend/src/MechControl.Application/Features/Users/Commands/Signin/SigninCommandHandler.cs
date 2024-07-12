using MechControl.Application.Abstractions;
using MechControl.Application.Interfaces;
using MechControl.Domain.Core.Primitives.Result;

namespace MechControl.Application.Features.Users.Commands.Signin;

public sealed class SigninCommandHandler(
    IAuthenticationService authenticationService
) : ICommandHandler<SigninCommand>
{

    public Task<Result> Handle(
        SigninCommand request, 
        CancellationToken cancellationToken) =>
        authenticationService.SigninAsync(
            request.Email, 
            request.Password, 
            cancellationToken);
}