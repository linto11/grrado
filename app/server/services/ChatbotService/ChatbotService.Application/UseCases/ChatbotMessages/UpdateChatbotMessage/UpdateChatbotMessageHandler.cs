using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using ChatbotService.Domain.Entities;
using MediatR;

namespace ChatbotService.Application.UseCases.ChatbotMessages.UpdateChatbotMessage;

public class UpdateChatbotMessageHandler : IRequestHandler<UpdateChatbotMessageCommand, Result<ChatbotMessageDto>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateChatbotMessageHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<ChatbotMessageDto>> Handle(UpdateChatbotMessageCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotMessages.GetByIdAsync(request.Id);
            if (entity == null) return Result<ChatbotMessageDto>.Failure($"ChatbotMessage with id {request.Id} not found");

            entity.ConversationId = request.ConversationId;
            entity.UserId = request.UserId;
            entity.UserMessage = request.UserMessage;
            entity.BotResponse = request.BotResponse;
            entity.MessageType = request.MessageType;
            entity.TokensUsed = request.TokensUsed;
            entity.CostUsd = request.CostUsd;
            entity.DetectedIntent = request.DetectedIntent;
            entity.ConfidenceScore = request.ConfidenceScore;
            entity.ExtractionEntities = request.ExtractionEntities;
            entity.ResponseTimeMs = request.ResponseTimeMs;
            entity.IsThinkingMode = request.IsThinkingMode;
            entity.ThinkingProcess = request.ThinkingProcess;
            entity.IsHelpful = request.IsHelpful;
            entity.UserFeedback = request.UserFeedback;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.ChatbotMessages.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<ChatbotMessageDto>.Success(_mapper.Map<ChatbotMessageDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<ChatbotMessageDto>.Failure($"Failed to update chatbot message: {ex.Message}");
        }
    }
}
