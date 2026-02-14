using GRRADO.Shared.Application.Common;
using ChatbotService.Application.DTOs;
using MediatR;

namespace ChatbotService.Application.UseCases.AiUsageLogs.GetAiUsageLogById;

public record GetAiUsageLogByIdQuery(int Id) : IRequest<Result<AiUsageLogDto>>;
