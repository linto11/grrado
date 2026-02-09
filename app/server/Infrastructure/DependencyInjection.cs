using Infrastructure.Persistance.DBContext;
using Infrastructure.Persistance.Repository;
using Infrastructure.Persistance;
using Infrastructure.Integration;
using Infrastructure.Integration.Keycloak;
using Infrastructure.Integration.Resilience;
using Infrastructure.Integration.Logging;
using Abstractions.Persistence;
using Abstractions.Integration;
using Abstractions.Integration.Keycloak;
using Abstractions.Services;
using Utility.Abstractions.Logging;
using Utility.Integration.Logging.Queue;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Serilog;
using Polly;
using Abstractions.Constants;

namespace Infrastructure;

/// <summary>
/// Extension methods for Infrastructure layer dependency injection
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure PostgreSQL DbContext
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            connectionString = "Host=localhost;Port=5433;Database=vehicle_service_db;Username=postgres;Password=postgres;";
            Log.Warning("DefaultConnection missing in configuration; using fallback connection string targeting localhost:5433.");
        }

        services.AddDbContext<VehicleServiceDbContext>(options =>
            options.UseNpgsql(connectionString));

        // Register Unit of Work and Repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Register Keycloak HttpClient with Polly resilience policy
        services.AddHttpClient<IKeycloakService, KeycloakService>()
            .AddPolicyHandler(PollyPolicies.GetKeycloakPolicy());

        // Register Keycloak Authentication Services
        services.AddScoped<IJwtTokenValidator, JwtTokenValidator>();
        services.AddScoped<IUserContext, UserContext>();

        // Register Integration Services
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<ITimezoneService, TimezoneService>();

        // Register Redis Distributed Cache
        var redisConnection = configuration.GetConnectionString("RedisConnection") ?? "localhost:6379";
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConnection;
            options.InstanceName = "GRRADO_";
        });

        // Register Error Message Service with Redis Cache
        services.AddScoped<IErrorMessageService, Integration.Redis.ErrorMessageService>();
        
        // Register background cache refresh service
        // TEMPORARILY DISABLED: Npgsql SCRAM authentication issue
        // services.AddHostedService<Integration.Redis.ErrorMessageCacheRefreshService>();

        // Register Logging Queue and Services
        services.AddSingleton<ILoggingQueue, LoggingQueue>();
        services.AddScoped<IAuditLogService, AuditLogService>();
        services.AddScoped<IErrorLogService, ErrorLogService>();
        services.AddScoped<IRequestResponseLogService, RequestResponseLogService>();
        services.AddScoped<IActivityLogService, ActivityLogService>();
        // TEMPORARILY DISABLED: Database connection issues
        // services.AddHostedService<LoggingQueueService>();

        // Register data seeding service
        services.AddScoped<IDataSeedingService>(provider => 
            new DataSeedingService(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "data")));

        // Register HttpContextAccessor for UserContext
        services.AddHttpContextAccessor();

        // Register Polly resilience policies for integration and database operations
        AddPollyPolicies(services);

        return services;
    }

    /// <summary>
    /// Registers Polly resilience policies consumed by infrastructure services.
    /// HTTP policies are wired via AddPolicyHandler on HttpClient registrations above.
    /// Database policies are injected into UnitOfWork for SaveChangesAsync resilience.
    /// </summary>
    private static void AddPollyPolicies(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        // Combined database resilience policy (retry + bulkhead + timeout)
        // Injected into UnitOfWork to wrap SaveChangesAsync
        services.AddSingleton<IAsyncPolicy>(
            _ => PollyPolicies.GetDatabaseResiliencePolicy()
        );
    }
}
