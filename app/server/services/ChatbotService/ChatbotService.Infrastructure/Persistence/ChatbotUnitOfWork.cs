using ChatbotService.Application.Abstractions;
using ChatbotService.Domain.Entities;
using GRRADO.Shared.Abstractions.Persistence;
using GRRADO.Shared.Infrastructure.Persistence;
using Polly;

namespace ChatbotService.Infrastructure.Persistence;

public class ChatbotUnitOfWork : BaseUnitOfWork, IChatbotUnitOfWork
{
    private readonly ChatbotDbContext _context;
    private IRepository<ChatbotConversation>? _chatbotConversations;
    private IRepository<ChatbotMessage>? _chatbotMessages;
    private IRepository<AiImageAnalysis>? _aiImageAnalyses;
    private IRepository<ChatbotKnowledgeBase>? _chatbotKnowledgeBases;
    private IRepository<AiUsageLog>? _aiUsageLogs;

    public ChatbotUnitOfWork(ChatbotDbContext context, IAsyncPolicy resiliencePolicy) : base(context, resiliencePolicy)
    {
        _context = context;
    }

    public IRepository<ChatbotConversation> ChatbotConversations => _chatbotConversations ??= new BaseRepository<ChatbotConversation>(_context);
    public IRepository<ChatbotMessage> ChatbotMessages => _chatbotMessages ??= new BaseRepository<ChatbotMessage>(_context);
    public IRepository<AiImageAnalysis> AiImageAnalyses => _aiImageAnalyses ??= new BaseRepository<AiImageAnalysis>(_context);
    public IRepository<ChatbotKnowledgeBase> ChatbotKnowledgeBases => _chatbotKnowledgeBases ??= new BaseRepository<ChatbotKnowledgeBase>(_context);
    public IRepository<AiUsageLog> AiUsageLogs => _aiUsageLogs ??= new BaseRepository<AiUsageLog>(_context);
}
