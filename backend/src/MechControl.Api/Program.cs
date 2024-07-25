using System.IdentityModel.Tokens.Jwt;
using MechControl.Api;
using MechControl.Api.Extensions;
using MechControl.Application;
using MechControl.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder
    .Services
    .AddPresentation()
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

await builder
    .Build()
    .ApplyMigrations()
    .AddPipeline()
    .RunAsync();
