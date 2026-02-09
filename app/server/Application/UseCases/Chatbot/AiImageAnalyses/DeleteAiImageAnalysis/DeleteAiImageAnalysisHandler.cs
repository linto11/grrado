using Abstractions.Persistence;
using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Chatbot.AiImageAnalyses.DeleteAiImageAnalysis;

public class DeleteAiImageAnalysisHandler : IRequestHandler<DeleteAiImageAnalysisRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAiImageAnalysisHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAiImageAnalysisRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.AiImageAnalyses.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result.Failure($"AiImageAnalysis with ID {request.Id} not found");
            }
            await _unitOfWork.AiImageAnalyses.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete aiImageAnalysis: {ex.Message}");
        }
    }
}
