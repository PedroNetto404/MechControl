using System.ComponentModel.DataAnnotations;

namespace MechControl.Infrastructure.Security.Models;

public sealed record JwtOptions
{
    public const string SectionName = "Jwt";

    [Required]
    public string Secret { get; init; }

    [Required]
    public string Issuer { get; init; }

    [Required]
    public string Audience { get; init; }

    [Required]
    public int ExpiresInMinutes { get; init; }
}
