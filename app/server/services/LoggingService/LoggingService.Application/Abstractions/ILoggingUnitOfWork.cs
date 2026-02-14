using GRRADO.Shared.Abstractions.Persistence;
using LoggingService.Domain.Entities;

namespace LoggingService.Application.Abstractions;

public interface ILoggingUnitOfWork : IUnitOfWork
{
    IRepository<AuditLog> AuditLogs { get; }
    IRepository<ErrorLog> ErrorLogs { get; }
    IRepository<ActivityLog> ActivityLogs { get; }
    IRepository<RequestResponseLog> RequestResponseLogs { get; }
    IRepository<ErrorMessage> ErrorMessages { get; }
}
