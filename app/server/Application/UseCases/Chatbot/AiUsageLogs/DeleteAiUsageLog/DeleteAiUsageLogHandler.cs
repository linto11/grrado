using Abstractions.Persistence;
using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Chatbot.AiUsageLogs.DeleteAiUsageLog;

public class DeleteAiUsageLogHandler : IRequestHandler<DeleteAiUsageLogRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAiUsageLogHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAiUsageLogRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.AiUsageLogs.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result.Failure($"AiUsageLog with ID {request.Id} not found");
            }
            await _unitOfWork.AiUsageLogs.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete aiUsageLog: {ex.Message}");
        }
    }
}
