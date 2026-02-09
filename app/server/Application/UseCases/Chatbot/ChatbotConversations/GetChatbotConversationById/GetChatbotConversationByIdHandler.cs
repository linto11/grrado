using Abstractions.DTOs.ChatbotConversation;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Chatbot.ChatbotConversations.GetChatbotConversationById;

public class GetChatbotConversationByIdHandler : IRequestHandler<GetChatbotConversationByIdRequest, Result<ChatbotConversationDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetChatbotConversationByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ChatbotConversationDto>> Handle(GetChatbotConversationByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotConversations.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<ChatbotConversationDto>.Failure($"ChatbotConversation with ID {request.Id} not found");
            }
            var dto = _mapper.Map<ChatbotConversationDto>(entity);
            return Result<ChatbotConversationDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<ChatbotConversationDto>.Failure($"Failed to retrieve chatbotConversation: {ex.Message}");
        }
    }
}
