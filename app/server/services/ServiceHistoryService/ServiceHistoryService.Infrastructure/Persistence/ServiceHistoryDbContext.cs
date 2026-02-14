using Microsoft.EntityFrameworkCore;
using ServiceHistoryService.Domain.Entities;

namespace ServiceHistoryService.Infrastructure.Persistence;

public class ServiceHistoryDbContext : DbContext
{
    public ServiceHistoryDbContext(DbContextOptions<ServiceHistoryDbContext> options) : base(options) { }

    public DbSet<ServiceHistory> ServiceHistories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ServiceHistory>(e =>
        {
            e.HasKey(sh => sh.Id);
            e.HasQueryFilter(sh => !sh.IsDeleted);
        });
    }
}
