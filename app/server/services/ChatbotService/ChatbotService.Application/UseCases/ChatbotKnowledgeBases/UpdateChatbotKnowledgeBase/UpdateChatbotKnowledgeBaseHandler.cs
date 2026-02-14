using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using ChatbotService.Domain.Entities;
using MediatR;

namespace ChatbotService.Application.UseCases.ChatbotKnowledgeBases.UpdateChatbotKnowledgeBase;

public class UpdateChatbotKnowledgeBaseHandler : IRequestHandler<UpdateChatbotKnowledgeBaseCommand, Result<ChatbotKnowledgeBaseDto>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateChatbotKnowledgeBaseHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<ChatbotKnowledgeBaseDto>> Handle(UpdateChatbotKnowledgeBaseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotKnowledgeBases.GetByIdAsync(request.Id);
            if (entity == null) return Result<ChatbotKnowledgeBaseDto>.Failure($"ChatbotKnowledgeBase with id {request.Id} not found");

            entity.Category = request.Category;
            entity.Question = request.Question;
            entity.Answer = request.Answer;
            entity.Tags = request.Tags;
            entity.UsageCount = request.UsageCount;
            entity.EffectivenessScore = request.EffectivenessScore;
            entity.EmbeddingVector = request.EmbeddingVector;
            entity.Synonyms = request.Synonyms;
            entity.RelatedTopics = request.RelatedTopics;
            entity.Priority = request.Priority;
            entity.IsTrainingData = request.IsTrainingData;
            entity.ModelVersionUsedFor = request.ModelVersionUsedFor;
            entity.Confidence = request.Confidence;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.ChatbotKnowledgeBases.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<ChatbotKnowledgeBaseDto>.Success(_mapper.Map<ChatbotKnowledgeBaseDto>(entity));
        }
        catch (Exception ex) { return Result<ChatbotKnowledgeBaseDto>.Failure($"Failed to update knowledge base entry: {ex.Message}"); }
    }
}
