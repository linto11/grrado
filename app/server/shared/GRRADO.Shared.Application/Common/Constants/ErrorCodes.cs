namespace GRRADO.Shared.Application.Common.Constants;

/// <summary>
/// Shared error codes used across all microservices
/// </summary>
public static class ErrorCodes
{
    // Pagination
    public const string PAGE_NUMBER_INVALID = "PAGE_NUMBER_INVALID";
    public const string PAGE_SIZE_INVALID = "PAGE_SIZE_INVALID";
    public const string PAGE_SIZE_EXCEEDS_LIMIT = "PAGE_SIZE_EXCEEDS_LIMIT";

    // Generic
    public const string OPERATION_FAILED = "OPERATION_FAILED";
    public const string VALIDATION_FAILED = "VALIDATION_FAILED";
    public const string UNAUTHORIZED = "UNAUTHORIZED";
    public const string FORBIDDEN = "FORBIDDEN";
    public const string GENERIC_ERROR_MESSAGE = "An error occurred processing your request";
    public const string ENTITY_NOT_FOUND = "ENTITY_NOT_FOUND";
    public const string ENTITY_ID_INVALID = "ENTITY_ID_INVALID";

    // Cross-service validation
    public const string CROSS_SERVICE_VALIDATION_FAILED = "CROSS_SERVICE_VALIDATION_FAILED";
    public const string SERVICE_UNAVAILABLE = "SERVICE_UNAVAILABLE";
}
