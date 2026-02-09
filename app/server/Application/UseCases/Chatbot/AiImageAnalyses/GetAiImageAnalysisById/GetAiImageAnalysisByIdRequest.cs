using Application.Common.Models;
using Abstractions.DTOs.AiImageAnalysis;
using MediatR;

namespace Application.UseCases.Chatbot.AiImageAnalyses.GetAiImageAnalysisById;

public class GetAiImageAnalysisByIdRequest : IRequest<Result<AiImageAnalysisDto>>
{
    public int Id { get; set; }

    public GetAiImageAnalysisByIdRequest(int id)
    {
        Id = id;
    }

    public GetAiImageAnalysisByIdRequest()
    {
    }
}
