using System.ComponentModel.DataAnnotations;

namespace MechControl.Api.Options;

public record JwtOptions
{
	public const string SectionName = "Jwt";

	[Required]
	[MinLength(16, ErrorMessage = "The {0} field must be at least {1} characters long.")]
	public required string Secret { get; init; }

	[Required]
	[MinLength(1, ErrorMessage = "The {0} field must be at least {1} characters long.")]
	public required string Issuer { get; init; }

	[Required]
	[MinLength(1, ErrorMessage = "The {0} field must be at least {1} characters long.")]
	public required string Audience { get; init; }

	[Required]
	[Range(1, int.MaxValue, ErrorMessage = "The {0} field must be greater than {1}.")]
	public required int ExpiryMinutes { get; init; }
}
