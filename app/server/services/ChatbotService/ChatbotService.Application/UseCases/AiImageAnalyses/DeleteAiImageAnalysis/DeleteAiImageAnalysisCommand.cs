using GRRADO.Shared.Application.Common;
using MediatR;

namespace ChatbotService.Application.UseCases.AiImageAnalyses.DeleteAiImageAnalysis;

public class DeleteAiImageAnalysisCommand : IRequest<Result>
{
    public int Id { get; set; }
    public DeleteAiImageAnalysisCommand(int id) => Id = id;
}
