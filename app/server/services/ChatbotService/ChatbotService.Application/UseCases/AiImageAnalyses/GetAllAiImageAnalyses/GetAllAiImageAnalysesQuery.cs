using GRRADO.Shared.Application.Common;
using MediatR;
using ChatbotService.Application.DTOs;

namespace ChatbotService.Application.UseCases.AiImageAnalyses.GetAllAiImageAnalyses;

public class GetAllAiImageAnalysesQuery : IRequest<Result<List<AiImageAnalysisDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
