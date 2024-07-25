using MechControl.Application.Abstractions;
using MechControl.Application.Interfaces;
using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Core.Primitives.Result;
using MechControl.Domain.Features.Users;
using MechControl.Domain.Features.Users.Specifications;
using MechControl.Domain.Shared.ValueObjects;

namespace MechControl.Infrastructure.Security.Services;

public sealed class AuthService(
    IPasswordHasher passwordHasher,
    IRepository<User, UserId> userRepository,
    IAuthTokenGenerator authTokenGenerator
) : IAuthenticationService
{
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    private readonly IRepository<User, UserId> _userRepository = userRepository;
    private readonly IAuthTokenGenerator _authTokenGenerator = authTokenGenerator;

    public async Task<Result<AuthToken>> SigninAsync(
        string email,
        string password, 
        CancellationToken cancellationToken = default)
    {
        var emailResult = Email.New(email);
        if (emailResult.IsFailure)
        {
            return emailResult.Error!;
        }

        var user = await _userRepository.ListAsync(new GetUserByEmailSpec(emailResult.Value), cancellationToken);
        if (user.Count == 0)
        {
            return new Error("invalid_credentials", "Invalid credentials");
        }

        var userEntity = user.First();
        if (!_passwordHasher.VerifyPassword(password, userEntity.HashedPassword))
        {
            return new Error("invalid_credentials", "Invalid credentials");
        }

        return _authTokenGenerator.GenerateToken(
            userEntity.Id, 
            userEntity.Email.Value, 
            new Dictionary<string, string>());
    }
}