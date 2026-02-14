using Microsoft.EntityFrameworkCore;
using GarageService.Domain.Entities;

namespace GarageService.Infrastructure.Persistence;

public class GarageDbContext : DbContext
{
    public GarageDbContext(DbContextOptions<GarageDbContext> options) : base(options) { }

    public DbSet<Garage> Garages => Set<Garage>();
    public DbSet<Service> Services => Set<Service>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Garage>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasQueryFilter(x => !x.IsDeleted);
            e.HasMany(x => x.Services).WithOne(x => x.Garage).HasForeignKey(x => x.GarageId);
        });

        modelBuilder.Entity<Service>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasQueryFilter(x => !x.IsDeleted);
        });
    }
}
