using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using MediatR;

namespace ChatbotService.Application.UseCases.AiImageAnalyses.DeleteAiImageAnalysis;

public class DeleteAiImageAnalysisHandler : IRequestHandler<DeleteAiImageAnalysisCommand, Result>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    public DeleteAiImageAnalysisHandler(IChatbotUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteAiImageAnalysisCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.AiImageAnalyses.GetByIdAsync(request.Id);
            if (entity == null) return Result.Failure($"AiImageAnalysis with id {request.Id} not found");
            await _unitOfWork.AiImageAnalyses.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex) { return Result.Failure($"Failed to delete ai image analysis: {ex.Message}"); }
    }
}
