using MechControl.Domain.Features.Customers;
using MechControl.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace MechControl.Infrastructure.Persistence;

public class MechControlContext(
    DbContextOptions<MechControlContext> options,
    DomainEventsInterceptor domainEventsInterceptor) : 
    DbContext(options)
{
    private readonly DomainEventsInterceptor _domainEventsInterceptor = domainEventsInterceptor;
    public DbSet<Customer> Customers { get; set; }

    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MechControlContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_domainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}