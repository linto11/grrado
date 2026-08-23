using GRRADO.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GarageService.Infrastructure.Persistence;

public sealed class GarageDbContextFactory : PostgresDesignTimeDbContextFactoryBase<GarageDbContext>
{
    protected override string DatabaseName => "grrado_garage_db";

    protected override string ConnectionStringEnvironmentVariable => "GRRADO_GARAGE_DB_CONNECTION";

    protected override GarageDbContext CreateNewInstance(DbContextOptions<GarageDbContext> options) => new(options);
}
