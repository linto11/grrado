using GRRADO.Shared.Application.Common;
using MediatR;

namespace ChatbotService.Application.UseCases.ChatbotMessages.DeleteChatbotMessage;

public class DeleteChatbotMessageCommand : IRequest<Result>
{
    public int Id { get; set; }
    public DeleteChatbotMessageCommand(int id) => Id = id;
}
