using Application.Common.Models;
using Abstractions.DTOs.AiUsageLog;
using MediatR;

namespace Application.UseCases.AiUsageLogs.UpdateAiUsageLog;

public class UpdateAiUsageLogRequest : IRequest<Result<AiUsageLogDto>>
{
    public int Id { get; set; }
    public int? RemainingQuotaPercentage { get; set; }
    public DateTime? QuotaResetAt { get; set; }
}
