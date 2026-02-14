using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using ChatbotService.Domain.Entities;
using MediatR;

namespace ChatbotService.Application.UseCases.ChatbotKnowledgeBases.CreateChatbotKnowledgeBase;

public class CreateChatbotKnowledgeBaseHandler : IRequestHandler<CreateChatbotKnowledgeBaseCommand, Result<ChatbotKnowledgeBaseDto>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateChatbotKnowledgeBaseHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<ChatbotKnowledgeBaseDto>> Handle(CreateChatbotKnowledgeBaseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<ChatbotKnowledgeBase>(request);
            await _unitOfWork.ChatbotKnowledgeBases.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<ChatbotKnowledgeBaseDto>.Success(_mapper.Map<ChatbotKnowledgeBaseDto>(entity));
        }
        catch (Exception ex) { return Result<ChatbotKnowledgeBaseDto>.Failure($"Failed to create knowledge base entry: {ex.Message}"); }
    }
}
