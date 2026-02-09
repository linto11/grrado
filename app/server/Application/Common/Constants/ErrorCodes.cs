namespace Application.Common.Constants;

/// <summary>
/// Error codes for validation and business rules
/// Code names map to GUIDs and use cases via error-codes.json configuration
/// </summary>
public static class ErrorCodes
{
    // User validation codes
    public const string USER_NAME_REQUIRED = "USER_NAME_REQUIRED";
    public const string USER_NAME_MAX_LENGTH = "USER_NAME_MAX_LENGTH";
    public const string USER_EMAIL_REQUIRED = "USER_EMAIL_REQUIRED";
    public const string USER_EMAIL_INVALID = "USER_EMAIL_INVALID";
    public const string USER_EMAIL_MAX_LENGTH = "USER_EMAIL_MAX_LENGTH";
    public const string USER_PHONE_REQUIRED = "USER_PHONE_REQUIRED";
    public const string USER_PHONE_MAX_LENGTH = "USER_PHONE_MAX_LENGTH";
    public const string USER_CITY_REQUIRED = "USER_CITY_REQUIRED";
    public const string USER_CITY_MAX_LENGTH = "USER_CITY_MAX_LENGTH";
    public const string USER_FAMILY_TYPE_REQUIRED = "USER_FAMILY_TYPE_REQUIRED";
    public const string USER_FAMILY_TYPE_MAX_LENGTH = "USER_FAMILY_TYPE_MAX_LENGTH";
    public const string USER_EXPERIENCE_LEVEL_REQUIRED = "USER_EXPERIENCE_LEVEL_REQUIRED";
    public const string USER_EXPERIENCE_LEVEL_MAX_LENGTH = "USER_EXPERIENCE_LEVEL_MAX_LENGTH";
    
    // User operation codes
    public const string USER_ID_INVALID = "USER_ID_INVALID";
    public const string USER_NOT_FOUND = "USER_NOT_FOUND";

    // Pagination validation codes
    public const string PAGE_NUMBER_INVALID = "PAGE_NUMBER_INVALID";
    public const string PAGE_SIZE_INVALID = "PAGE_SIZE_INVALID";
    public const string PAGE_SIZE_EXCEEDS_LIMIT = "PAGE_SIZE_EXCEEDS_LIMIT";

    // Vehicle validation codes
    public const string VEHICLE_ID_INVALID = "VEHICLE_ID_INVALID";
    public const string VEHICLE_BRAND_REQUIRED = "VEHICLE_BRAND_REQUIRED";
    public const string VEHICLE_MODEL_REQUIRED = "VEHICLE_MODEL_REQUIRED";
    public const string VEHICLE_YEAR_INVALID = "VEHICLE_YEAR_INVALID";
    public const string VEHICLE_NOT_FOUND = "VEHICLE_NOT_FOUND";

    // Garage validation codes
    public const string GARAGE_ID_INVALID = "GARAGE_ID_INVALID";
    public const string GARAGE_NAME_REQUIRED = "GARAGE_NAME_REQUIRED";
    public const string GARAGE_CITY_REQUIRED = "GARAGE_CITY_REQUIRED";
    public const string GARAGE_NOT_FOUND = "GARAGE_NOT_FOUND";

    // Service validation codes
    public const string SERVICE_ID_INVALID = "SERVICE_ID_INVALID";
    public const string SERVICE_NAME_REQUIRED = "SERVICE_NAME_REQUIRED";
    public const string SERVICE_PRICE_INVALID = "SERVICE_PRICE_INVALID";
    public const string SERVICE_NOT_FOUND = "SERVICE_NOT_FOUND";

    // ServiceHistory validation codes
    public const string SERVICE_HISTORY_ID_INVALID = "SERVICE_HISTORY_ID_INVALID";

    // VehicleIssue validation codes
    public const string VEHICLE_ISSUE_ID_INVALID = "VEHICLE_ISSUE_ID_INVALID";

    // DiagnosticRule validation codes
    public const string DIAGNOSTIC_RULE_ID_INVALID = "DIAGNOSTIC_RULE_ID_INVALID";

    // ImageDiagnostic validation codes
    public const string IMAGE_DIAGNOSTIC_ID_INVALID = "IMAGE_DIAGNOSTIC_ID_INVALID";

    // ChatbotConversation validation codes
    public const string CHATBOT_CONVERSATION_ID_INVALID = "CHATBOT_CONVERSATION_ID_INVALID";

    // ChatbotMessage validation codes
    public const string CHATBOT_MESSAGE_ID_INVALID = "CHATBOT_MESSAGE_ID_INVALID";

    // ChatbotKnowledgeBase validation codes
    public const string CHATBOT_KB_ID_INVALID = "CHATBOT_KB_ID_INVALID";

    // AiImageAnalysis validation codes
    public const string AI_IMAGE_ID_INVALID = "AI_IMAGE_ID_INVALID";

    // AiUsageLog validation codes
    public const string AI_USAGE_ID_INVALID = "AI_USAGE_ID_INVALID";

    // Generic codes
    public const string OPERATION_FAILED = "OPERATION_FAILED";
    public const string VALIDATION_FAILED = "VALIDATION_FAILED";
    public const string UNAUTHORIZED = "UNAUTHORIZED";
    public const string FORBIDDEN = "FORBIDDEN";

    // User-facing error messages
    public const string GENERIC_ERROR_MESSAGE = "An error occurred processing your request";
}

