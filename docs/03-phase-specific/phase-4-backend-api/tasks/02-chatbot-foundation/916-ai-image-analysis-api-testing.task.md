# Task 916: AI Image Analysis API Testing

## Status: TODO
## Sprint: 5
## Priority: MEDIUM
## Estimated Effort: MEDIUM

## Description
Create comprehensive API tests for all AiImageAnalysis endpoints. Cover happy paths, validation errors, not-found scenarios, foreign key constraint enforcement, and authorization checks to ensure the image analysis CRUD operations are robust and reliable.

## Acceptance Criteria
- [ ] Unit tests for AiImageAnalysis repository methods
- [ ] Unit tests for AiImageAnalysis validators
- [ ] Integration tests for POST /api/ai-image-analyses (create)
- [ ] Integration tests for GET /api/ai-image-analyses/{id} (read single)
- [ ] Integration tests for GET /api/ai-image-analyses?userId={id} (read by user)
- [ ] Integration tests for GET /api/ai-image-analyses?messageId={id} (read by message)
- [ ] Integration tests for PUT /api/ai-image-analyses/{id} (update)
- [ ] Integration tests for DELETE /api/ai-image-analyses/{id} (delete)
- [ ] Tests verify foreign key constraint (invalid ChatbotMessageId returns error)
- [ ] Tests verify proper HTTP status codes (200, 201, 400, 404)
- [ ] Tests verify validation error responses for invalid input
- [ ] All tests pass in CI pipeline

## Files to Modify/Create
- `app/server/Tests/Unit/Validators/AiImageAnalysisValidatorTests.cs`
- `app/server/Tests/Unit/Repositories/AiImageAnalysisRepositoryTests.cs`
- `app/server/Tests/Integration/Controllers/AiImageAnalysisControllerTests.cs`

## Dependencies
- Task 913: CRUD operations implemented
- Task 914: Validation implemented
- Task 915: DTO mapping implemented
- Test project and test infrastructure configured

## Implementation Steps
1. Set up test fixtures and mock data for AiImageAnalysis and parent ChatbotMessage
2. Write unit tests for CreateAiImageAnalysisValidator covering all rules
3. Write unit tests for UpdateAiImageAnalysisValidator covering all rules
4. Write repository unit tests with in-memory database or mocks
5. Write integration tests using WebApplicationFactory for each endpoint
6. Test edge cases: missing ChatbotMessageId, invalid AnalysisType, ConfidenceScore out of range, negative ProcessingTimeMs
7. Test JSON fields (DetectedObjects, DiagnosticSuggestions) serialization
8. Run all tests and verify they pass

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
