using GRRADO.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace VehicleService.Infrastructure.Persistence;

public sealed class VehicleDbContextFactory : PostgresDesignTimeDbContextFactoryBase<VehicleDbContext>
{
    protected override string DatabaseName => "grrado_vehicle_db";

    protected override string ConnectionStringEnvironmentVariable => "GRRADO_VEHICLE_DB_CONNECTION";

    protected override VehicleDbContext CreateNewInstance(DbContextOptions<VehicleDbContext> options) => new(options);
}
