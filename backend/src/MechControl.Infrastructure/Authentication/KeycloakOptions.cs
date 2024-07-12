
namespace MechControl.Infrastructure.Authentication;

internal sealed record KeycloakOptions
{
    public const string Key = "Keycloak";

    public required string Realm { get; init; }
    public required string ClientId { get; init; }
    public required string ClientSecret { get; init; }
    public required string Authority { get; init; }
}
