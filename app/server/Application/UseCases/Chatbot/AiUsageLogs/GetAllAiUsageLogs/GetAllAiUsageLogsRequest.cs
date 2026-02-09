using Application.Common.Models;
using Abstractions.DTOs.AiUsageLog;
using Abstractions.Persistence;
using MediatR;

namespace Application.UseCases.Chatbot.AiUsageLogs.GetAllAiUsageLogs;

public class GetAllAiUsageLogsRequest : IRequest<Result<PaginatedResult<AiUsageLogDto>>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
