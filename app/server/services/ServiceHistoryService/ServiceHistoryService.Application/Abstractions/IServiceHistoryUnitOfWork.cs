using GRRADO.Shared.Abstractions.Persistence;
using ServiceHistoryService.Domain.Entities;

namespace ServiceHistoryService.Application.Abstractions;

public interface IServiceHistoryUnitOfWork : IUnitOfWork
{
    IRepository<ServiceHistory> ServiceHistories { get; }
}
