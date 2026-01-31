using Domain.Abstractions;

namespace Domain.Entities;

public class AiImageAnalysis : IEntity
{
    public int Id { get; set; }
    public int ChatbotMessageId { get; set; }
    public int UserId { get; set; }
    
    // Image metadata
    public string OriginalImageFileName { get; set; } = string.Empty;
    public string OriginalImagePath { get; set; } = string.Empty;
    public string? AnnotatedImagePath { get; set; } // Path to annotated image with highlights
    public string? ThumbnailPath { get; set; }
    public long FileSizeBytes { get; set; }
    public string ImageMimeType { get; set; } = string.Empty;
    
    // Analysis results
    public string AnalysisType { get; set; } = string.Empty; // e.g., "damage-detection", "fluid-leak", "obd-code"
    public string DetectedObjects { get; set; } = string.Empty; // JSON array of detected objects
    public string? SeverityLevel { get; set; } // low, medium, high, critical
    
    // Damage/Issue detection
    public string? DamageType { get; set; } // e.g., "dent", "scratch", "rust", "crack"
    public string? PartsIdentified { get; set; } // JSON array of identified vehicle parts
    public decimal? ConfidenceScore { get; set; } // 0-1 confidence
    public string? Recommendations { get; set; } // JSON array of recommended actions
    
    // Additional details
    public string? VehiclePartLocation { get; set; } // e.g., "front-left-door"
    public int? EstimatedRepairCostRange { get; set; } // Low end of repair cost
    public bool RequiresExpertReview { get; set; } = false;
    
    // Metrics
    public int ResponseTimeMs { get; set; } = 0;
    public int TokensUsed { get; set; } = 0;
    public decimal CostUsd { get; set; } = 0;
    
    // Audit columns
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Soft delete columns
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    
    // Navigation properties
    public ChatbotMessage? ChatbotMessage { get; set; }
    public User? User { get; set; }
}
