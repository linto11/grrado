namespace GRRADO.Shared.Abstractions.Persistence;

/// <summary>
/// Generic Unit of Work interface for transaction management
/// Each microservice implements its own IUnitOfWork with specific repository properties
/// </summary>
public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
