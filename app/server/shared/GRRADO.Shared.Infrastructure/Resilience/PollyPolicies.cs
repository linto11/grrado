using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;
using GRRADO.Shared.Abstractions.Constants;
using Microsoft.Extensions.Logging;

namespace GRRADO.Shared.Infrastructure.Resilience;

/// <summary>
/// Polly resilience policies configuration
/// </summary>
public static class PollyPolicies
{
    public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .Or<HttpRequestException>()
            .OrResult(r => r.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            .WaitAndRetryAsync(
                retryCount: PollyConstants.RetryPolicy.MAX_RETRY_ATTEMPTS,
                sleepDurationProvider: retryAttempt =>
                    TimeSpan.FromMilliseconds(
                        PollyConstants.RetryPolicy.INITIAL_DELAY_MS *
                        Math.Pow(PollyConstants.RetryPolicy.BACKOFF_MULTIPLIER, retryAttempt - 1)));
    }

    public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(r => r.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            .CircuitBreakerAsync(
                handledEventsAllowedBeforeBreaking: PollyConstants.CircuitBreakerPolicy.FAILURE_THRESHOLD,
                durationOfBreak: TimeSpan.FromSeconds(PollyConstants.CircuitBreakerPolicy.CIRCUIT_OPEN_TIMEOUT_SECONDS));
    }

    public static IAsyncPolicy<HttpResponseMessage> GetTimeoutPolicy()
    {
        return Policy.TimeoutAsync<HttpResponseMessage>(
            TimeSpan.FromMilliseconds(PollyConstants.TimeoutPolicy.HTTP_REQUEST_TIMEOUT_MS),
            timeoutStrategy: TimeoutStrategy.Optimistic);
    }

    public static IAsyncPolicy<HttpResponseMessage> GetHttpResiliencePolicy()
    {
        return Policy.WrapAsync(GetRetryPolicy(), GetCircuitBreakerPolicy(), GetTimeoutPolicy());
    }

    public static IAsyncPolicy GetDatabaseBulkheadPolicy()
    {
        return Policy.BulkheadAsync(
            maxParallelization: PollyConstants.BulkheadPolicy.MAX_PARALLEL_REQUESTS,
            maxQueuingActions: PollyConstants.BulkheadPolicy.MAX_QUEUE_DEPTH);
    }

    public static IAsyncPolicy<HttpResponseMessage> GetAzureAIServicesPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .Or<HttpRequestException>()
            .OrResult(r =>
                r.StatusCode == System.Net.HttpStatusCode.TooManyRequests ||
                r.StatusCode == (System.Net.HttpStatusCode)429)
            .WaitAndRetryAsync(
                retryCount: PollyConstants.RetryPolicy.MAX_RETRY_ATTEMPTS,
                sleepDurationProvider: retryAttempt =>
                    TimeSpan.FromMilliseconds(
                        PollyConstants.RetryPolicy.INITIAL_DELAY_MS *
                        Math.Pow(PollyConstants.RetryPolicy.BACKOFF_MULTIPLIER, retryAttempt - 1)))
            .WrapAsync(GetCircuitBreakerPolicy())
            .WrapAsync(GetTimeoutPolicy());
    }

    public static IAsyncPolicy<HttpResponseMessage> GetKeycloakPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(r => r.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            .WaitAndRetryAsync(
                retryCount: 2,
                sleepDurationProvider: retryAttempt =>
                    TimeSpan.FromMilliseconds(PollyConstants.RetryPolicy.INITIAL_DELAY_MS * retryAttempt))
            .WrapAsync(GetCircuitBreakerPolicy());
    }

    public static IAsyncPolicy GetDatabaseRetryPolicy()
    {
        return Policy
            .Handle<Exception>(ex =>
                ex.InnerException?.Message?.Contains("deadlock") == true ||
                ex.InnerException?.Message?.Contains("timeout") == true ||
                ex.Message?.Contains("connection refused") == true)
            .Or<InvalidOperationException>()
            .WaitAndRetryAsync(
                retryCount: PollyConstants.RetryPolicy.MAX_RETRY_ATTEMPTS,
                sleepDurationProvider: retryAttempt =>
                    TimeSpan.FromMilliseconds(
                        PollyConstants.RetryPolicy.INITIAL_DELAY_MS *
                        Math.Pow(PollyConstants.RetryPolicy.BACKOFF_MULTIPLIER, retryAttempt - 1)));
    }

    public static IAsyncPolicy GetDatabaseTimeoutPolicy()
    {
        return Policy.TimeoutAsync(
            TimeSpan.FromMilliseconds(PollyConstants.TimeoutPolicy.DATABASE_TIMEOUT_MS),
            timeoutStrategy: TimeoutStrategy.Pessimistic);
    }

    public static IAsyncPolicy GetDatabaseResiliencePolicy()
    {
        return Policy.WrapAsync(GetDatabaseRetryPolicy(), GetDatabaseBulkheadPolicy(), GetDatabaseTimeoutPolicy());
    }
}

/// <summary>
/// Extension methods for Polly context
/// </summary>
public static class PollyContextExtensions
{
    private const string LoggerKey = "Logger";

    public static void SetLogger(this Polly.Context context, ILogger logger)
    {
        context[LoggerKey] = logger;
    }

    public static ILogger? GetLogger(this Polly.Context context)
    {
        return context.TryGetValue(LoggerKey, out var logger) ? logger as ILogger : null;
    }
}
