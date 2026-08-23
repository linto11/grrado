using GRRADO.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace UserService.Infrastructure.Persistence;

public sealed class UserDbContextFactory : PostgresDesignTimeDbContextFactoryBase<UserDbContext>
{
    protected override string DatabaseName => "grrado_user_db";

    protected override string ConnectionStringEnvironmentVariable => "GRRADO_USER_DB_CONNECTION";

    protected override UserDbContext CreateNewInstance(DbContextOptions<UserDbContext> options) => new(options);
}
