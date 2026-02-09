using Application.Common.Models;
using Abstractions.DTOs.AiImageAnalysis;
using Abstractions.Persistence;
using MediatR;

namespace Application.UseCases.AiImageAnalyses.GetAllAiImageAnalyses;

public class GetAllAiImageAnalysesRequest : IRequest<Result<PaginatedResult<AiImageAnalysisDto>>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
