using GRRADO.Shared.Abstractions.Persistence;
using GRRADO.Shared.Infrastructure.Persistence;
using Polly;
using ServiceHistoryService.Application.Abstractions;
using ServiceHistoryService.Domain.Entities;

namespace ServiceHistoryService.Infrastructure.Persistence;

public class ServiceHistoryUnitOfWork : BaseUnitOfWork, IServiceHistoryUnitOfWork
{
    private IRepository<ServiceHistory>? _serviceHistories;

    public ServiceHistoryUnitOfWork(ServiceHistoryDbContext context, IAsyncPolicy databaseResiliencePolicy)
        : base(context, databaseResiliencePolicy) { }

    public IRepository<ServiceHistory> ServiceHistories =>
        _serviceHistories ??= new BaseRepository<ServiceHistory>(_context);
}
