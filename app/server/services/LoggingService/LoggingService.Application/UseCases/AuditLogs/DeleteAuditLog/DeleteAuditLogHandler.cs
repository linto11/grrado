using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using MediatR;

namespace LoggingService.Application.UseCases.AuditLogs.DeleteAuditLog;

public class DeleteAuditLogHandler : IRequestHandler<DeleteAuditLogCommand, Result>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    public DeleteAuditLogHandler(ILoggingUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    public async Task<Result> Handle(DeleteAuditLogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var deleted = await _unitOfWork.AuditLogs.DeleteAsync(request.Id);
            if (!deleted) return Result.Failure("AuditLog not found");

            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex) { return Result.Failure($"Failed to delete audit log: {ex.Message}"); }
    }
}
