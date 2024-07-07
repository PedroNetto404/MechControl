using System.Text;
using MechControl.Api.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace MechControl.Api.DependencyInjection;

public static class AuthServiceConfig
{
	public static void AddAuthServices(this IServiceCollection services, IConfiguration configuration)
	{
		if (configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>() is not { } jwtOptions)
			throw new InvalidOperationException("JwtOptions not found in configuration.");

		services
			.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new()
				{
					ValidateIssuer = true,
					ValidIssuer = jwtOptions.Issuer,
					ValidateAudience = true,
					ValidAudience = jwtOptions.Audience,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.UTF8
								.GetBytes(jwtOptions.Secret)),
				};
			});
	}
}