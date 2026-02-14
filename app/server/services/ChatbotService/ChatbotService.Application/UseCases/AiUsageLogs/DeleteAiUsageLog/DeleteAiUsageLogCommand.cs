using GRRADO.Shared.Application.Common;
using MediatR;

namespace ChatbotService.Application.UseCases.AiUsageLogs.DeleteAiUsageLog;

public record DeleteAiUsageLogCommand(int Id) : IRequest<Result>;
