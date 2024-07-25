using MechControl.Application.Abstractions;
using MechControl.Application.Interfaces;
using MechControl.Domain.Features.Users;

namespace MechControl.Infrastructure.Security.Services;

public class JwtAuthTokenGenerator : IAuthTokenGenerator
{
    public AuthToken GenerateToken(UserId userId, string email, IDictionary<string, string> claims)
    {
        throw new NotImplementedException();
    }
}
