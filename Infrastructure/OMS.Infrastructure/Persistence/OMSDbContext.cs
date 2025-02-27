using Microsoft.EntityFrameworkCore;
using OMS.Domain.Entities;

namespace OMS.Infrastructure.Persistence;

public class OMSDbContext : DbContext
{
    public OMSDbContext(DbContextOptions<OMSDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OMSDbContext).Assembly);
    }
}