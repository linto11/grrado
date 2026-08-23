using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GRRADO.Shared.Infrastructure.Persistence;

public abstract class PostgresDesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext>
    where TContext : DbContext
{
    public TContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TContext>();
        optionsBuilder.UseNpgsql(GetConnectionString());

        return CreateNewInstance(optionsBuilder.Options);
    }

    protected abstract string DatabaseName { get; }

    protected abstract string ConnectionStringEnvironmentVariable { get; }

    protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

    protected virtual string GetConnectionString()
    {
        return Environment.GetEnvironmentVariable(ConnectionStringEnvironmentVariable)
            ?? $"Host=localhost;Port=5433;Database={DatabaseName};Username=postgres;Password=postgres";
    }
}
