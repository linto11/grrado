using LoggingService.Application.Abstractions;
using LoggingService.Domain.Entities;
using GRRADO.Shared.Abstractions.Persistence;
using GRRADO.Shared.Infrastructure.Persistence;
using Polly;

namespace LoggingService.Infrastructure.Persistence;

public class LoggingUnitOfWork : BaseUnitOfWork, ILoggingUnitOfWork
{
    private readonly LoggingDbContext _context;
    private IRepository<AuditLog>? _auditLogs;
    private IRepository<ErrorLog>? _errorLogs;
    private IRepository<ActivityLog>? _activityLogs;
    private IRepository<RequestResponseLog>? _requestResponseLogs;
    private IRepository<ErrorMessage>? _errorMessages;

    public LoggingUnitOfWork(LoggingDbContext context, IAsyncPolicy resiliencePolicy) : base(context, resiliencePolicy)
    {
        _context = context;
    }

    public IRepository<AuditLog> AuditLogs => _auditLogs ??= new BaseRepository<AuditLog>(_context);
    public IRepository<ErrorLog> ErrorLogs => _errorLogs ??= new BaseRepository<ErrorLog>(_context);
    public IRepository<ActivityLog> ActivityLogs => _activityLogs ??= new BaseRepository<ActivityLog>(_context);
    public IRepository<RequestResponseLog> RequestResponseLogs => _requestResponseLogs ??= new BaseRepository<RequestResponseLog>(_context);
    public IRepository<ErrorMessage> ErrorMessages => _errorMessages ??= new BaseRepository<ErrorMessage>(_context);
}
