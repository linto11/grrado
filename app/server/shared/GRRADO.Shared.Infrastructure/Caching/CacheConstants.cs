namespace GRRADO.Shared.Infrastructure.Caching;

/// <summary>
/// Shared distributed cache constants used across all microservices
/// </summary>
public static class CacheConstants
{
    /// <summary>Key prefix applied to all Redis cache entries to avoid collisions with other applications</summary>
    public const string INSTANCE_NAME_PREFIX = "GRRADO:";
}
