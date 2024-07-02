using System.Data.Common;
using MechControl.Domain.Features.Customers;
using Microsoft.EntityFrameworkCore;

namespace MechControl.Infrastructure.Persistence;

public class MechControlContext : DbContext
{
    public MechControlContext(DbContextOptions<MechControlContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MechControlContext).Assembly);
    }
    
}