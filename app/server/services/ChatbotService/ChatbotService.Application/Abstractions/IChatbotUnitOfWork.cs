using GRRADO.Shared.Abstractions.Persistence;
using ChatbotService.Domain.Entities;

namespace ChatbotService.Application.Abstractions;

public interface IChatbotUnitOfWork : IUnitOfWork
{
    IRepository<ChatbotConversation> ChatbotConversations { get; }
    IRepository<ChatbotMessage> ChatbotMessages { get; }
    IRepository<AiImageAnalysis> AiImageAnalyses { get; }
    IRepository<ChatbotKnowledgeBase> ChatbotKnowledgeBases { get; }
    IRepository<AiUsageLog> AiUsageLogs { get; }
}
