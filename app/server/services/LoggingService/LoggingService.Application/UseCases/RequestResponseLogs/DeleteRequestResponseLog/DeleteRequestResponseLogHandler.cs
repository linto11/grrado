using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using MediatR;

namespace LoggingService.Application.UseCases.RequestResponseLogs.DeleteRequestResponseLog;

public class DeleteRequestResponseLogHandler : IRequestHandler<DeleteRequestResponseLogCommand, Result>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    public DeleteRequestResponseLogHandler(ILoggingUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    public async Task<Result> Handle(DeleteRequestResponseLogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var deleted = await _unitOfWork.RequestResponseLogs.DeleteAsync(request.Id);
            if (!deleted) return Result.Failure("RequestResponseLog not found");

            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex) { return Result.Failure($"Failed to delete request response log: {ex.Message}"); }
    }
}
