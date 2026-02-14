using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using MediatR;

namespace ChatbotService.Application.UseCases.AiUsageLogs.DeleteAiUsageLog;

public class DeleteAiUsageLogHandler : IRequestHandler<DeleteAiUsageLogCommand, Result>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    public DeleteAiUsageLogHandler(IChatbotUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    public async Task<Result> Handle(DeleteAiUsageLogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var deleted = await _unitOfWork.AiUsageLogs.DeleteAsync(request.Id);
            if (!deleted) return Result.Failure("AiUsageLog not found");
            return Result.Success();
        }
        catch (Exception ex) { return Result.Failure($"Failed to delete AI usage log: {ex.Message}"); }
    }
}
