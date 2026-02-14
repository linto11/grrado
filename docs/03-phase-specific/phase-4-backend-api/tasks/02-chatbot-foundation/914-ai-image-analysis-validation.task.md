# Task 914: AI Image Analysis Validation

## Status: TODO
## Sprint: 5
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Implement FluentValidation validators for AiImageAnalysis create and update DTOs. Ensure all image analysis input data is properly validated, including file path formats, valid analysis types, numeric range constraints, and proper JSON format for detected objects and diagnostic suggestions.

## Acceptance Criteria
- [ ] FluentValidation validator created for CreateAiImageAnalysisDto
- [ ] FluentValidation validator created for UpdateAiImageAnalysisDto
- [ ] ChatbotMessageId is required and must reference an existing message
- [ ] UserId is required and must be a valid identifier
- [ ] OriginalImagePath is required and must be a valid file path
- [ ] AnalysisType is required and validated against allowed values
- [ ] SeverityLevel is validated against allowed enum values when provided
- [ ] ConfidenceScore must be between 0 and 1 when provided
- [ ] ProcessingTimeMs must be non-negative when provided
- [ ] ModelUsed has a reasonable maximum length
- [ ] Validation errors return 400 Bad Request with structured error messages

## Files to Modify/Create
- `app/server/Application/Validators/AiImageAnalysis/CreateAiImageAnalysisValidator.cs`
- `app/server/Application/Validators/AiImageAnalysis/UpdateAiImageAnalysisValidator.cs`
- `app/server/Application/DTOs/AiImageAnalysis/CreateAiImageAnalysisDto.cs`
- `app/server/Application/DTOs/AiImageAnalysis/UpdateAiImageAnalysisDto.cs`

## Dependencies
- Task 913: AiImageAnalysis entity must be defined
- FluentValidation NuGet package installed
- Validation pipeline configured in the application

## Implementation Steps
1. Define CreateAiImageAnalysisDto with required input fields
2. Define UpdateAiImageAnalysisDto with mutable fields
3. Create CreateAiImageAnalysisValidator with rules for ChatbotMessageId, UserId, OriginalImagePath, AnalysisType
4. Create UpdateAiImageAnalysisValidator with rules for optional but constrained fields
5. Add numeric range validations for ConfidenceScore, ProcessingTimeMs
6. Add enum validation for SeverityLevel
7. Register validators in DI container
8. Test with invalid payloads to confirm proper error responses

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
