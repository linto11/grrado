# Task 918: AI Usage Log Validation

## Status: TODO
## Sprint: 5
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Implement FluentValidation validators for AiUsageLog create and update DTOs. Ensure all usage log input data is properly validated, including non-negative token counts, valid cost values, proper service name and model identifiers, and GUID format for session and correlation IDs.

## Acceptance Criteria
- [ ] FluentValidation validator created for CreateAiUsageLogDto
- [ ] FluentValidation validator created for UpdateAiUsageLogDto
- [ ] UserId is required and must be a valid identifier
- [ ] ServiceName is required and has a reasonable maximum length
- [ ] ApiEndpoint is required and has a reasonable maximum length
- [ ] InputTokens, OutputTokens, TotalTokens must be non-negative
- [ ] TotalTokens should equal InputTokens + OutputTokens (cross-field validation)
- [ ] Model is required and has a reasonable maximum length
- [ ] RequestDurationMs must be non-negative
- [ ] CostUsd must be non-negative when provided
- [ ] SessionId and CorrelationId are validated as proper GUID format when provided
- [ ] ErrorMessage is required when IsSuccessful is false
- [ ] Validation errors return 400 Bad Request with structured error messages

## Files to Modify/Create
- `app/server/Application/Validators/AiUsageLog/CreateAiUsageLogValidator.cs`
- `app/server/Application/Validators/AiUsageLog/UpdateAiUsageLogValidator.cs`
- `app/server/Application/DTOs/AiUsageLog/CreateAiUsageLogDto.cs`
- `app/server/Application/DTOs/AiUsageLog/UpdateAiUsageLogDto.cs`

## Dependencies
- Task 917: AiUsageLog entity must be defined
- FluentValidation NuGet package installed
- Validation pipeline configured in the application

## Implementation Steps
1. Define CreateAiUsageLogDto with required input fields
2. Define UpdateAiUsageLogDto with limited mutable fields
3. Create CreateAiUsageLogValidator with rules for all required fields and numeric constraints
4. Add cross-field validation for TotalTokens = InputTokens + OutputTokens
5. Add conditional validation: ErrorMessage required when IsSuccessful is false
6. Create UpdateAiUsageLogValidator with rules for limited update fields
7. Register validators in DI container
8. Test with invalid payloads to confirm proper error responses

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
