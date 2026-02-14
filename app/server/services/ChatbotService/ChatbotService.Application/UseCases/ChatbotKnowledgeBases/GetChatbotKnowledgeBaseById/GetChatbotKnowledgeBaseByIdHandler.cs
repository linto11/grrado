using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using MediatR;

namespace ChatbotService.Application.UseCases.ChatbotKnowledgeBases.GetChatbotKnowledgeBaseById;

public class GetChatbotKnowledgeBaseByIdHandler : IRequestHandler<GetChatbotKnowledgeBaseByIdQuery, Result<ChatbotKnowledgeBaseDto>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetChatbotKnowledgeBaseByIdHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<ChatbotKnowledgeBaseDto>> Handle(GetChatbotKnowledgeBaseByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotKnowledgeBases.GetByIdAsync(request.Id);
            if (entity == null) return Result<ChatbotKnowledgeBaseDto>.Failure($"ChatbotKnowledgeBase with id {request.Id} not found");
            return Result<ChatbotKnowledgeBaseDto>.Success(_mapper.Map<ChatbotKnowledgeBaseDto>(entity));
        }
        catch (Exception ex) { return Result<ChatbotKnowledgeBaseDto>.Failure($"Failed to get knowledge base entry: {ex.Message}"); }
    }
}
