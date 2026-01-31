using Abstractions.Persistence;
using AutoMapper;
using Domain.Abstractions;

namespace Application.Services;

/// <summary>
/// Generic base service interface for CRUD operations
/// </summary>
public interface IBaseService<TEntity, TDto, TCreateRequest, TUpdateRequest>
    where TEntity : class, IEntity
    where TDto : class
    where TCreateRequest : class
    where TUpdateRequest : class
{
    Task<List<TDto>> GetAllAsync(int skip = 0, int take = 10, CancellationToken cancellationToken = default);
    Task<TDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TDto> CreateAsync(TCreateRequest request, CancellationToken cancellationToken = default);
    Task<TDto> UpdateAsync(int id, TUpdateRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, string deletedBy, CancellationToken cancellationToken = default);
}

/// <summary>
/// Base service implementation - concrete subclasses must override GetRepository method
/// </summary>
public abstract class BaseService<TEntity, TDto, TCreateRequest, TUpdateRequest>
    where TEntity : class, IEntity
    where TDto : class
    where TCreateRequest : class
    where TUpdateRequest : class
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    protected BaseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    protected abstract IRepository<TEntity> GetRepository();

    public virtual async Task<List<TDto>> GetAllAsync(int skip = 0, int take = 10, CancellationToken cancellationToken = default)
    {
        var result = await GetRepository().GetPagedAsync(skip, take);
        return result.Items.Select(e => _mapper.Map<TDto>(e)).ToList();
    }

    public virtual async Task<TDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await GetRepository().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<TDto>(entity);
    }

    public virtual async Task<TDto> CreateAsync(TCreateRequest request, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<TEntity>(request);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;

        await GetRepository().AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<TDto>(entity);
    }

    public virtual async Task<TDto> UpdateAsync(int id, TUpdateRequest request, CancellationToken cancellationToken = default)
    {
        var entity = await GetRepository().GetByIdAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity with id {id} not found");

        _mapper.Map(request, entity);
        entity.UpdatedAt = DateTime.UtcNow;

        await GetRepository().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<TDto>(entity);
    }

    public virtual async Task DeleteAsync(int id, string deletedBy, CancellationToken cancellationToken = default)
    {
        await GetRepository().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
