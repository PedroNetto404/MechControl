using System.Text.Json.Serialization;
using MechControl.Domain.Core.Primitives.Result;

namespace MechControl.Application.Interfaces;
public interface IAuthenticationService
{
    Task<Result<AuthToken>> SigninAsync(
        string email, 
        string password, 
        CancellationToken cancellationToken = default);
}

public sealed record AuthToken
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; init; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; init; }

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; init; }

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; init; }

    [JsonPropertyName("refresh_token_expires_in")]
    public int RefreshTokenExpiresIn { get; init; }
}