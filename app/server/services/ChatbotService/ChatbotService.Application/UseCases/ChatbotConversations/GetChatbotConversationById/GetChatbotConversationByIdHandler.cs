using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using MediatR;

namespace ChatbotService.Application.UseCases.ChatbotConversations.GetChatbotConversationById;

public class GetChatbotConversationByIdHandler : IRequestHandler<GetChatbotConversationByIdQuery, Result<ChatbotConversationDto>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetChatbotConversationByIdHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ChatbotConversationDto>> Handle(GetChatbotConversationByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotConversations.GetByIdAsync(request.Id);
            if (entity == null)
                return Result<ChatbotConversationDto>.Failure($"ChatbotConversation with id {request.Id} not found");
            return Result<ChatbotConversationDto>.Success(_mapper.Map<ChatbotConversationDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<ChatbotConversationDto>.Failure($"Failed to get chatbot conversation: {ex.Message}");
        }
    }
}
