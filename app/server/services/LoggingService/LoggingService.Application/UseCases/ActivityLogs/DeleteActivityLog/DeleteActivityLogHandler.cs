using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using MediatR;

namespace LoggingService.Application.UseCases.ActivityLogs.DeleteActivityLog;

public class DeleteActivityLogHandler : IRequestHandler<DeleteActivityLogCommand, Result>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    public DeleteActivityLogHandler(ILoggingUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    public async Task<Result> Handle(DeleteActivityLogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var deleted = await _unitOfWork.ActivityLogs.DeleteAsync(request.Id);
            if (!deleted) return Result.Failure("ActivityLog not found");

            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex) { return Result.Failure($"Failed to delete activity log: {ex.Message}"); }
    }
}
