namespace GRRADO.Shared.Domain.Constants;

/// <summary>
/// Shared audit-trail constants used across all microservices
/// </summary>
public static class AuditConstants
{
    /// <summary>Actor name recorded when a deletion is performed by the system rather than an authenticated user</summary>
    public const string SYSTEM_ACTOR = "system";
}
