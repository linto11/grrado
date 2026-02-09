using Application.Common.Models;
using Abstractions.DTOs.ChatbotMessage;
using Abstractions.Persistence;
using MediatR;

namespace Application.UseCases.Chatbot.ChatbotMessages.GetAllChatbotMessages;

public class GetAllChatbotMessagesRequest : IRequest<Result<PaginatedResult<ChatbotMessageDto>>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
