using GRRADO.Shared.Application.Common;
using MediatR;

namespace ChatbotService.Application.UseCases.ChatbotKnowledgeBases.DeleteChatbotKnowledgeBase;

public record DeleteChatbotKnowledgeBaseCommand(int Id) : IRequest<Result>;
