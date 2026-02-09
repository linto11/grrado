using Application.Common.Models;
using Abstractions.DTOs.ChatbotMessage;
using MediatR;

namespace Application.UseCases.ChatbotMessages.GetChatbotMessageById;

public class GetChatbotMessageByIdRequest : IRequest<Result<ChatbotMessageDto>>
{
    public int Id { get; set; }

    public GetChatbotMessageByIdRequest(int id)
    {
        Id = id;
    }

    public GetChatbotMessageByIdRequest()
    {
    }
}
