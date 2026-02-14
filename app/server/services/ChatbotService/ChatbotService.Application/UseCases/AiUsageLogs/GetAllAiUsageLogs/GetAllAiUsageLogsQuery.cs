using GRRADO.Shared.Application.Common;
using ChatbotService.Application.DTOs;
using MediatR;

namespace ChatbotService.Application.UseCases.AiUsageLogs.GetAllAiUsageLogs;

public class GetAllAiUsageLogsQuery : IRequest<Result<List<AiUsageLogDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
