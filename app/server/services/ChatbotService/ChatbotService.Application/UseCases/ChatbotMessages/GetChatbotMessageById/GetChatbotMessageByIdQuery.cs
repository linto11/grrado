using GRRADO.Shared.Application.Common;
using MediatR;
using ChatbotService.Application.DTOs;

namespace ChatbotService.Application.UseCases.ChatbotMessages.GetChatbotMessageById;

public class GetChatbotMessageByIdQuery : IRequest<Result<ChatbotMessageDto>>
{
    public int Id { get; set; }
    public GetChatbotMessageByIdQuery(int id) => Id = id;
}
