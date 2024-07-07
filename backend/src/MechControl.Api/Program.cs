using MechControl.Api.DependencyInjection;
using MechControl.Api.Hooks.Binders;
using MechControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    var services = builder.Services;
    services.AddEndpointsApiExplorer();

    services.AddControllers(options =>
    {
        options.ModelBinderProviders
               .Insert(0, new FromSessionBinder.Provider());
    });

    services.AddSwaggerGen();
    services.AddDbContext<MechControlContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


    services.AddAuthServices(builder.Configuration);
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