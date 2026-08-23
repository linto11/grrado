using GRRADO.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChatbotService.Infrastructure.Persistence;

public sealed class ChatbotDbContextFactory : PostgresDesignTimeDbContextFactoryBase<ChatbotDbContext>
{
    protected override string DatabaseName => "grrado_chatbot_db";

    protected override string ConnectionStringEnvironmentVariable => "GRRADO_CHATBOT_DB_CONNECTION";

    protected override ChatbotDbContext CreateNewInstance(DbContextOptions<ChatbotDbContext> options) => new(options);
}
