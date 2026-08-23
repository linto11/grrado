using GRRADO.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LoggingService.Infrastructure.Persistence;

public sealed class LoggingDbContextFactory : PostgresDesignTimeDbContextFactoryBase<LoggingDbContext>
{
    protected override string DatabaseName => "grrado_logging_db";

    protected override string ConnectionStringEnvironmentVariable => "GRRADO_LOGGING_DB_CONNECTION";

    protected override LoggingDbContext CreateNewInstance(DbContextOptions<LoggingDbContext> options) => new(options);
}
