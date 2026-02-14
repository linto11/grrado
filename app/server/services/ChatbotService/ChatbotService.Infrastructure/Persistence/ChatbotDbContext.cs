using ChatbotService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatbotService.Infrastructure.Persistence;

public class ChatbotDbContext : DbContext
{
    public ChatbotDbContext(DbContextOptions<ChatbotDbContext> options) : base(options) { }

    public DbSet<ChatbotConversation> ChatbotConversations => Set<ChatbotConversation>();
    public DbSet<ChatbotMessage> ChatbotMessages => Set<ChatbotMessage>();
    public DbSet<AiImageAnalysis> AiImageAnalyses => Set<AiImageAnalysis>();
    public DbSet<ChatbotKnowledgeBase> ChatbotKnowledgeBases => Set<ChatbotKnowledgeBase>();
    public DbSet<AiUsageLog> AiUsageLogs => Set<AiUsageLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ChatbotConversation>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasQueryFilter(x => !x.IsDeleted);
            e.HasMany(x => x.Messages).WithOne(x => x.Conversation).HasForeignKey(x => x.ConversationId);
        });

        modelBuilder.Entity<ChatbotMessage>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasQueryFilter(x => !x.IsDeleted);
            e.HasMany(x => x.ImageAnalyses).WithOne(x => x.ChatbotMessage).HasForeignKey(x => x.ChatbotMessageId);
        });

        modelBuilder.Entity<AiImageAnalysis>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasQueryFilter(x => !x.IsDeleted);
        });

        modelBuilder.Entity<ChatbotKnowledgeBase>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasQueryFilter(x => !x.IsDeleted);
        });

        modelBuilder.Entity<AiUsageLog>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasQueryFilter(x => !x.IsDeleted);
        });
    }
}
