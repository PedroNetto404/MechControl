using MechControl.Domain.Core.Primitives.Result;
using MechControl.Application.Interfaces;
using Microsoft.Extensions.Options;
using MechControl.Domain.Core.Primitives;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace MechControl.Infrastructure.Authentication;

internal sealed class KeycloakAuthenticationService(
    HttpClient httpClient,
    IOptions<KeycloakOptions> keycloakOptions,
    IHttpContextAccessor httpContextAccessor
) : IAuthenticationService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly KeycloakOptions _keycloakOptions = keycloakOptions.Value;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    public async Task<Result> SigninAsync(
        string email,
        string password,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Post,
            $"{_keycloakOptions.Authority}/protocol/openid-connect/token")
        {
            Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["client_id"] = _keycloakOptions.ClientId,
                ["client_secret"] = _keycloakOptions.ClientSecret,
                ["username"] = email,
                ["password"] = password,
                ["grant_type"] = "password"
            })
        };

        var response = await _httpClient.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
            return new Error(
                "authentication_failed",
                "Invalid credentials");

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        if (string.IsNullOrWhiteSpace(content))
            return new Error(
                "authentication_failed",
                "Invalid credentials");

        _httpContextAccessor.HttpContext!
                            .Session
                            .SetString("auth_data", content);

        return Result.Ok();
    }

    public async Task<Result> SignoutAsync(CancellationToken cancellationToken = default)
    {
        var userData = _httpContextAccessor.HttpContext!
                            .Session
                            .GetString("auth_data");

        if (string.IsNullOrWhiteSpace(userData))
            return new Error(
                "authentication_failed",
                "Invalid credentials");

        var refreshToken = JsonSerializer.Deserialize<Dictionary<string, string>>(userData)!["refresh_token"];

        var request = new HttpRequestMessage(
            HttpMethod.Post,
            $"{_keycloakOptions.Authority}/protocol/openid-connect/logout")
        {
            Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["client_id"] = _keycloakOptions.ClientId,
                ["client_secret"] = _keycloakOptions.ClientSecret,
                ["refresh_token"] = refreshToken
            })
        };

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return response.IsSuccessStatusCode
            ? Result.Ok()
            : new Error(
                "authentication_failed",
                "Invalid credentials");
    }
}
