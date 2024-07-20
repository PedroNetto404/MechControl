using System.ComponentModel.DataAnnotations;

namespace MechControl.Api.Controllers.User;

public sealed record SigninRequest
{
    [Required]
    public required string Email { get; init; }

    [Required]
    public required string Password { get; init; }
}