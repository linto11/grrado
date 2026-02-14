using Microsoft.EntityFrameworkCore;
using VehicleService.Domain.Entities;

namespace VehicleService.Infrastructure.Persistence;

public class VehicleDbContext : DbContext
{
    public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options) { }

    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Vehicle>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasQueryFilter(x => !x.IsDeleted);
        });
    }
}
