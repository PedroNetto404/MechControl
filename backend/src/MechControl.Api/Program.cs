using System.IdentityModel.Tokens.Jwt;
using MechControl.Api;
using MechControl.Api.Extensions;
using MechControl.Application;
using MechControl.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder
    .Services
    .AddPresentation(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

var app = builder.Build(); 

app.AddPipeline();

await app.RunAsync();