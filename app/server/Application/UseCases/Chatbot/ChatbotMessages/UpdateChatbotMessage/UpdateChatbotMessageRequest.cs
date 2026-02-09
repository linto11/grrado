using Application.Common.Models;
using Abstractions.DTOs.ChatbotMessage;
using MediatR;

namespace Application.UseCases.Chatbot.ChatbotMessages.UpdateChatbotMessage;

public class UpdateChatbotMessageRequest : IRequest<Result<ChatbotMessageDto>>
{
    public int Id { get; set; }
    public bool? IsHelpful { get; set; }
    public string? UserFeedback { get; set; }
}
