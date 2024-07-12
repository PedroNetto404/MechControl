using MechControl.Domain.Core.Primitives.Result;

namespace MechControl.Application.Interfaces;
public interface IAuthenticationService
{
    Task<Result> SigninAsync(
        string email, 
        string password, 
        CancellationToken cancellationToken = default);

    Task<Result> SignoutAsync(
        CancellationToken cancellationToken = default);
}