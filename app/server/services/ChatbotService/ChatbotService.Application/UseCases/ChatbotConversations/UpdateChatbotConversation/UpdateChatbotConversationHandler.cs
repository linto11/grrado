using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using ChatbotService.Domain.Entities;
using MediatR;

namespace ChatbotService.Application.UseCases.ChatbotConversations.UpdateChatbotConversation;

public class UpdateChatbotConversationHandler : IRequestHandler<UpdateChatbotConversationCommand, Result<ChatbotConversationDto>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateChatbotConversationHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ChatbotConversationDto>> Handle(UpdateChatbotConversationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotConversations.GetByIdAsync(request.Id);
            if (entity == null)
                return Result<ChatbotConversationDto>.Failure($"ChatbotConversation with id {request.Id} not found");

            entity.UserId = request.UserId;
            entity.Title = request.Title;
            entity.Summary = request.Summary;
            entity.StartedAt = request.StartedAt;
            entity.EndedAt = request.EndedAt;
            entity.MessageCount = request.MessageCount;
            entity.TotalTokensUsed = request.TotalTokensUsed;
            entity.TotalCostUsd = request.TotalCostUsd;
            entity.SatisfactionRating = request.SatisfactionRating;
            entity.SatisfactionComment = request.SatisfactionComment;
            entity.ConversationMode = request.ConversationMode;
            entity.IsArchived = request.IsArchived;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.ChatbotConversations.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<ChatbotConversationDto>.Success(_mapper.Map<ChatbotConversationDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<ChatbotConversationDto>.Failure($"Failed to update chatbot conversation: {ex.Message}");
        }
    }
}
