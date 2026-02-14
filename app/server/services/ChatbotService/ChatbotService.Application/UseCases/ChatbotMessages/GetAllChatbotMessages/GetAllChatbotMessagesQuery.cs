using GRRADO.Shared.Application.Common;
using MediatR;
using ChatbotService.Application.DTOs;

namespace ChatbotService.Application.UseCases.ChatbotMessages.GetAllChatbotMessages;

public class GetAllChatbotMessagesQuery : IRequest<Result<List<ChatbotMessageDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
