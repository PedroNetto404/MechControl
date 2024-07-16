using System.IdentityModel.Tokens.Jwt;
using MechControl.Api.Extensions;
using MechControl.Application;
using MechControl.Domain.Extensions;
using MechControl.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder
    .Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication()
    .AddServices();

var app = builder.Build(); 

app.AddPipeline();