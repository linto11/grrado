using GRRADO.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DiagnosticsService.Infrastructure.Persistence;

public sealed class DiagnosticsDbContextFactory : PostgresDesignTimeDbContextFactoryBase<DiagnosticsDbContext>
{
    protected override string DatabaseName => "grrado_diagnostics_db";

    protected override string ConnectionStringEnvironmentVariable => "GRRADO_DIAGNOSTICS_DB_CONNECTION";

    protected override DiagnosticsDbContext CreateNewInstance(DbContextOptions<DiagnosticsDbContext> options) => new(options);
}
