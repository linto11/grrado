using GRRADO.Shared.Abstractions.Caching;
using GRRADO.Shared.Abstractions.Messaging;
using GRRADO.Shared.Infrastructure.Caching;
using GRRADO.Shared.Infrastructure.Messaging;
using GRRADO.Shared.Infrastructure.Resilience;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace GRRADO.Shared.Infrastructure;

/// <summary>
/// Shared infrastructure DI registration used by all microservices
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Polly database resilience policy
        services.AddSingleton<IAsyncPolicy>(_ => PollyPolicies.GetDatabaseResiliencePolicy());

        // RabbitMQ event publisher
        services.AddSingleton<IEventPublisher, RabbitMqEventPublisher>();

        // Redis distributed caching
        var redisConnection = configuration.GetConnectionString("Redis")
            ?? configuration["Redis:Connection"]
            ?? "localhost:6379";
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConnection;
            options.InstanceName = CacheConstants.INSTANCE_NAME_PREFIX;
        });
        services.AddSingleton<ICacheService, RedisCacheService>();

        // HttpContextAccessor for correlation ID propagation
        services.AddHttpContextAccessor();

        return services;
    }
}
