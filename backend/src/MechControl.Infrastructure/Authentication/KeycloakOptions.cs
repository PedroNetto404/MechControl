
using System.ComponentModel.DataAnnotations;

namespace MechControl.Infrastructure.Authentication;

internal sealed record KeycloakOptions
{
    public const string Key = "Keycloak";

    [Required]
    public string Realm { get; init; }
    [Required]
    public string ClientId { get; init; }
    [Required]
    public string ClientSecret { get; init; }
    [Required]
    public string Authority { get; init; }
}
