using MechControl.Application.Abstractions;

namespace MechControl.Infrastructure.Security.Services;

public class SHA256PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        throw new NotImplementedException();
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        throw new NotImplementedException();
    }
}