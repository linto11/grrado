using System.Linq.Expressions;

namespace GRRADO.Shared.Abstractions.Persistence;

/// <summary>
/// Generic repository interface for CRUD operations with soft-delete support
/// </summary>
public interface IRepository<T> where T : class
{
    IQueryable<T> GetAll(bool includeDeleted = false);
    Task<T?> GetByIdAsync(int id, bool includeDeleted = false);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool includeDeleted = false);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task<bool> RestoreAsync(int id);
    Task<bool> ExistsAsync(int id, bool includeDeleted = false);
    Task<int> CountAsync(bool includeDeleted = false);
    Task<PaginatedResult<T>> GetPagedAsync(int skip, int take, bool includeDeleted = false);
}

/// <summary>
/// Result wrapper for paginated data
/// </summary>
public class PaginatedResult<T>
{
    public IEnumerable<T> Items { get; set; } = new List<T>();
    public int TotalCount { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
    public int TotalPages => (TotalCount + Take - 1) / Take;
}
