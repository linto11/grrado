using Application.Common.Models;
using MediatR;

namespace Application.UseCases.AiImageAnalyses.DeleteAiImageAnalysis;

public class DeleteAiImageAnalysisRequest : IRequest<Result>
{
    public int Id { get; set; }

    public DeleteAiImageAnalysisRequest(int id)
    {
        Id = id;
    }

    public DeleteAiImageAnalysisRequest()
    {
    }
}
