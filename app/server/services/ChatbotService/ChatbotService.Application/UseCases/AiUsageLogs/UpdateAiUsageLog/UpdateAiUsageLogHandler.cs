using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using ChatbotService.Domain.Entities;
using MediatR;

namespace ChatbotService.Application.UseCases.AiUsageLogs.UpdateAiUsageLog;

public class UpdateAiUsageLogHandler : IRequestHandler<UpdateAiUsageLogCommand, Result<AiUsageLogDto>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateAiUsageLogHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<AiUsageLogDto>> Handle(UpdateAiUsageLogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.AiUsageLogs.GetByIdAsync(request.Id);
            if (entity == null) return Result<AiUsageLogDto>.Failure($"AiUsageLog with id {request.Id} not found");

            entity.UserId = request.UserId;
            entity.ServiceName = request.ServiceName;
            entity.ApiEndpoint = request.ApiEndpoint;
            entity.OperationType = request.OperationType;
            entity.InputTokens = request.InputTokens;
            entity.OutputTokens = request.OutputTokens;
            entity.TotalTokens = request.TotalTokens;
            entity.Model = request.Model;
            entity.CostUsd = request.CostUsd;
            entity.DurationMs = request.DurationMs;
            entity.IsSuccessful = request.IsSuccessful;
            entity.ErrorMessage = request.ErrorMessage;
            entity.ErrorCode = request.ErrorCode;
            entity.RemainingQuotaPercentage = request.RemainingQuotaPercentage;
            entity.QuotaResetAt = request.QuotaResetAt;
            entity.ConversationId = request.ConversationId;
            entity.MessageId = request.MessageId;
            entity.Tags = request.Tags;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.AiUsageLogs.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<AiUsageLogDto>.Success(_mapper.Map<AiUsageLogDto>(entity));
        }
        catch (Exception ex) { return Result<AiUsageLogDto>.Failure($"Failed to update AI usage log: {ex.Message}"); }
    }
}
