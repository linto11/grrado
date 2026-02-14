using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using MediatR;

namespace LoggingService.Application.UseCases.ErrorLogs.DeleteErrorLog;

public class DeleteErrorLogHandler : IRequestHandler<DeleteErrorLogCommand, Result>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    public DeleteErrorLogHandler(ILoggingUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    public async Task<Result> Handle(DeleteErrorLogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var deleted = await _unitOfWork.ErrorLogs.DeleteAsync(request.Id);
            if (!deleted) return Result.Failure("ErrorLog not found");

            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex) { return Result.Failure($"Failed to delete error log: {ex.Message}"); }
    }
}
