using GRRADO.Shared.Domain.Events;
using GRRADO.Shared.Infrastructure.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ChatbotService.Application.Abstractions;

namespace ChatbotService.Infrastructure.Messaging;

public class ChatbotEventConsumer : EventConsumerHostedService
{
    protected override string ServiceName => "chatbot-service";

    public ChatbotEventConsumer(
        IConfiguration configuration,
        IServiceProvider serviceProvider,
        ILogger<ChatbotEventConsumer> logger)
        : base(configuration, serviceProvider, logger)
    {
    }

    protected override void ConfigureSubscriptions()
    {
        _subscriber.Subscribe<UserDeletedEvent>(async @event =>
        {
            _logger.LogInformation("Received UserDeletedEvent for UserId: {UserId}", @event.UserId);

            using var scope = _serviceProvider.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IChatbotUnitOfWork>();

            var conversations = await unitOfWork.ChatbotConversations.FindAsync(c => c.UserId == @event.UserId);
            foreach (var conversation in conversations)
            {
                await unitOfWork.ChatbotConversations.DeleteAsync(conversation.Id);
            }
            await unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Soft-deleted {Count} conversations for UserId: {UserId}", conversations.Count(), @event.UserId);
        });
    }
}
