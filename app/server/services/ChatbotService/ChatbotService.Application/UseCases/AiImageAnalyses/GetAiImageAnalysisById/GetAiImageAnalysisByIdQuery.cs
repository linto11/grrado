using GRRADO.Shared.Application.Common;
using MediatR;
using ChatbotService.Application.DTOs;

namespace ChatbotService.Application.UseCases.AiImageAnalyses.GetAiImageAnalysisById;

public class GetAiImageAnalysisByIdQuery : IRequest<Result<AiImageAnalysisDto>>
{
    public int Id { get; set; }
    public GetAiImageAnalysisByIdQuery(int id) => Id = id;
}
