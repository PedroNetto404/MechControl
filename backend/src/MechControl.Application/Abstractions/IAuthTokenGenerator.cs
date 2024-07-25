using MechControl.Application.Interfaces;
using MechControl.Domain.Features.Users;

namespace MechControl.Application.Abstractions;

public interface IAuthTokenGenerator
{
    AuthToken GenerateToken(UserId userId, string email, IDictionary<string, string> claims);
}
