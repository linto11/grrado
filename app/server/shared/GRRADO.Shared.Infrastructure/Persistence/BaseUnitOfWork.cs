using GRRADO.Shared.Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Polly;

namespace GRRADO.Shared.Infrastructure.Persistence;

/// <summary>
/// Base Unit of Work implementation with Polly resilience
/// Each microservice extends this with specific repository properties
/// </summary>
public abstract class BaseUnitOfWork : IUnitOfWork
{
    protected readonly DbContext _context;
    protected readonly IAsyncPolicy _databaseResiliencePolicy;
    private IDbContextTransaction? _transaction;

    protected BaseUnitOfWork(DbContext context, IAsyncPolicy databaseResiliencePolicy)
    {
        _context = context;
        _databaseResiliencePolicy = databaseResiliencePolicy;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _databaseResiliencePolicy.ExecuteAsync(
            async () => await _context.SaveChangesAsync());
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _databaseResiliencePolicy.ExecuteAsync(
            async () => await _context.Database.BeginTransactionAsync());
    }

    public async Task CommitAsync()
    {
        try
        {
            await SaveChangesAsync();
            if (_transaction != null)
                await _transaction.CommitAsync();
        }
        finally
        {
            if (_transaction != null)
                await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackAsync()
    {
        try
        {
            if (_transaction != null)
                await _transaction.RollbackAsync();
        }
        finally
        {
            if (_transaction != null)
                await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        if (_transaction is not null)
            await _transaction.DisposeAsync();
        await _context.DisposeAsync();
    }
}
