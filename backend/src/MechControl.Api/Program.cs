using DotNetEnv;
using MechControl.Api.DependencyInjection;
using MechControl.Application;
using MechControl.Infrastructure;

UpEnvironmentVariables();

var builder = WebApplication.CreateBuilder(args);
{
    var services = builder.Services;
    services.AddEndpointsApiExplorer();
    services.AddControllers();
    services.AddHttpContextAccessor();

    services.AddSwaggerGen();

    services
        .AddJwt(builder.Configuration)
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

await app.RunAsync();

static void UpEnvironmentVariables()
{
    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower();
    if (env == null) Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");

    Env.Load(path: $".env-{env ?? "development"}");
}