using GRRADO.Shared.Abstractions.Messaging;
using GRRADO.Shared.Infrastructure.Messaging;
using GRRADO.Shared.Infrastructure.Resilience;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace GRRADO.Shared.Infrastructure;

/// <summary>
/// Shared infrastructure DI registration used by all microservices
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services)
    {
        // Polly database resilience policy
        services.AddSingleton<IAsyncPolicy>(_ => PollyPolicies.GetDatabaseResiliencePolicy());

        // RabbitMQ event publisher
        services.AddSingleton<IEventPublisher, RabbitMqEventPublisher>();

        // HttpContextAccessor for correlation ID propagation
        services.AddHttpContextAccessor();

        return services;
    }
}
