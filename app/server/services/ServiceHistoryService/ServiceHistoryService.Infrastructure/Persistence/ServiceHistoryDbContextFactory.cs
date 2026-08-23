using GRRADO.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ServiceHistoryService.Infrastructure.Persistence;

public sealed class ServiceHistoryDbContextFactory : PostgresDesignTimeDbContextFactoryBase<ServiceHistoryDbContext>
{
    protected override string DatabaseName => "grrado_service_history_db";

    protected override string ConnectionStringEnvironmentVariable => "GRRADO_SERVICE_HISTORY_DB_CONNECTION";

    protected override ServiceHistoryDbContext CreateNewInstance(DbContextOptions<ServiceHistoryDbContext> options) => new(options);
}
