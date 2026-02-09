using Abstractions.DTOs.ChatbotKnowledgeBase;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Chatbot.ChatbotKnowledgeBases.GetChatbotKnowledgeBaseById;

public class GetChatbotKnowledgeBaseByIdHandler : IRequestHandler<GetChatbotKnowledgeBaseByIdRequest, Result<ChatbotKnowledgeBaseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetChatbotKnowledgeBaseByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ChatbotKnowledgeBaseDto>> Handle(GetChatbotKnowledgeBaseByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotKnowledgeBases.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<ChatbotKnowledgeBaseDto>.Failure($"ChatbotKnowledgeBase with ID {request.Id} not found");
            }
            var dto = _mapper.Map<ChatbotKnowledgeBaseDto>(entity);
            return Result<ChatbotKnowledgeBaseDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<ChatbotKnowledgeBaseDto>.Failure($"Failed to retrieve chatbotKnowledgeBase: {ex.Message}");
        }
    }
}
