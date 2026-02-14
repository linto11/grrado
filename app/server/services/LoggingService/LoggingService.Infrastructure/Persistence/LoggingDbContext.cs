using LoggingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoggingService.Infrastructure.Persistence;

public class LoggingDbContext : DbContext
{
    public LoggingDbContext(DbContextOptions<LoggingDbContext> options) : base(options) { }

    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<ErrorLog> ErrorLogs => Set<ErrorLog>();
    public DbSet<ActivityLog> ActivityLogs => Set<ActivityLog>();
    public DbSet<RequestResponseLog> RequestResponseLogs => Set<RequestResponseLog>();
    public DbSet<ErrorMessage> ErrorMessages => Set<ErrorMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AuditLog>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasQueryFilter(x => !x.IsDeleted);
        });

        modelBuilder.Entity<ErrorLog>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasQueryFilter(x => !x.IsDeleted);
        });

        modelBuilder.Entity<ActivityLog>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasQueryFilter(x => !x.IsDeleted);
        });

        modelBuilder.Entity<RequestResponseLog>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasQueryFilter(x => !x.IsDeleted);
        });

        modelBuilder.Entity<ErrorMessage>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasQueryFilter(x => !x.IsDeleted);
        });
    }
}
