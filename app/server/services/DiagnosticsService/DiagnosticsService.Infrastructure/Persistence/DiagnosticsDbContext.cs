using Microsoft.EntityFrameworkCore;
using DiagnosticsService.Domain.Entities;

namespace DiagnosticsService.Infrastructure.Persistence;

public class DiagnosticsDbContext : DbContext
{
    public DiagnosticsDbContext(DbContextOptions<DiagnosticsDbContext> options) : base(options) { }

    public DbSet<VehicleIssue> VehicleIssues => Set<VehicleIssue>();
    public DbSet<DiagnosticRule> DiagnosticRules => Set<DiagnosticRule>();
    public DbSet<ImageDiagnostic> ImageDiagnostics => Set<ImageDiagnostic>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<VehicleIssue>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasQueryFilter(x => !x.IsDeleted);
        });

        modelBuilder.Entity<DiagnosticRule>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasQueryFilter(x => !x.IsDeleted);
        });

        modelBuilder.Entity<ImageDiagnostic>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasQueryFilter(x => !x.IsDeleted);
        });
    }
}
