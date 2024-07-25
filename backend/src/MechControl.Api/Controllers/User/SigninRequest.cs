namespace MechControl.Api.Controllers.User;

public sealed record SigninRequest(
    string Email,
    string Password);
