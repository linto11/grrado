# Task 913: AI Image Analysis CRUD Operations

## Status: TODO
## Sprint: 5
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Implement full CRUD operations for the AiImageAnalysis entity. This entity stores results of AI-powered image analysis for diagnostic purposes, including detected objects, severity assessments, confidence scores, and diagnostic suggestions linked to chatbot messages.

## Acceptance Criteria
- [ ] AiImageAnalysis entity is properly defined with all required fields (ChatbotMessageId, UserId, OriginalImagePath, ProcessedImagePath, AnalysisType, DetectedObjects, SeverityLevel, ConfidenceScore, ProcessingTimeMs, ModelUsed, DiagnosticSuggestions)
- [ ] Repository interface and implementation follow existing patterns
- [ ] CREATE operation persists a new analysis result with all required fields
- [ ] READ operation retrieves analyses by ID, by UserId, by ChatbotMessageId, and supports pagination
- [ ] UPDATE operation modifies mutable fields (ProcessedImagePath, DetectedObjects, SeverityLevel, ConfidenceScore, DiagnosticSuggestions)
- [ ] DELETE operation removes an analysis record
- [ ] Foreign key relationship to ChatbotMessage is enforced
- [ ] All operations return appropriate HTTP status codes
- [ ] Controller endpoints are properly routed and documented

## Files to Modify/Create
- `app/server/Domain/Entities/AiImageAnalysis.cs`
- `app/server/Application/Interfaces/IAiImageAnalysisRepository.cs`
- `app/server/Infrastructure/Repositories/AiImageAnalysisRepository.cs`
- `app/server/API/Controllers/AiImageAnalysisController.cs`
- `app/server/Infrastructure/Data/Configurations/AiImageAnalysisConfiguration.cs`

## Dependencies
- Task 905: ChatbotMessage entity must exist for foreign key relationship
- Database schema with AiImageAnalysis table
- Base entity/repository patterns established in prior tasks

## Implementation Steps
1. Define the AiImageAnalysis entity class with all properties and navigation property to ChatbotMessage
2. Create the EF Core entity configuration with proper column types, constraints, and foreign key
3. Define the repository interface with CRUD method signatures including GetByMessageId and GetByUserId
4. Implement the repository with EF Core queries
5. Create the controller with GET, POST, PUT, DELETE endpoints
6. Register the repository in DI container
7. Run database migration or Liquibase changelog if needed
8. Test all endpoints manually via Swagger or Postman

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
