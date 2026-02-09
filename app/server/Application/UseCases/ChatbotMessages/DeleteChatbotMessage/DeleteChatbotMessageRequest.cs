using Application.Common.Models;
using MediatR;

namespace Application.UseCases.ChatbotMessages.DeleteChatbotMessage;

public class DeleteChatbotMessageRequest : IRequest<Result>
{
    public int Id { get; set; }

    public DeleteChatbotMessageRequest(int id)
    {
        Id = id;
    }

    public DeleteChatbotMessageRequest()
    {
    }
}
