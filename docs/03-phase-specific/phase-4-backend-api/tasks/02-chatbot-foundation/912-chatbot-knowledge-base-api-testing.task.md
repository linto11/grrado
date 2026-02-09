# Task 912: Chatbot Knowledge Base API Testing

## Status: TODO
## Sprint: 5
## Priority: MEDIUM
## Estimated Effort: MEDIUM

## Description
Create comprehensive API tests for all ChatbotKnowledgeBase endpoints. Cover happy paths, validation errors, not-found scenarios, search/filter functionality, and authorization checks to ensure the knowledge base CRUD operations are robust and reliable.

## Acceptance Criteria
- [ ] Unit tests for ChatbotKnowledgeBase repository methods
- [ ] Unit tests for ChatbotKnowledgeBase validators
- [ ] Integration tests for POST /api/chatbot-knowledge-base (create)
- [ ] Integration tests for GET /api/chatbot-knowledge-base/{id} (read single)
- [ ] Integration tests for GET /api/chatbot-knowledge-base?category={cat} (read by category)
- [ ] Integration tests for GET /api/chatbot-knowledge-base/search?q={query} (search)
- [ ] Integration tests for PUT /api/chatbot-knowledge-base/{id} (update)
- [ ] Integration tests for DELETE /api/chatbot-knowledge-base/{id} (delete)
- [ ] Tests verify proper HTTP status codes (200, 201, 400, 404)
- [ ] Tests verify validation error responses for invalid input
- [ ] All tests pass in CI pipeline

## Files to Modify/Create
- `app/server/Tests/Unit/Validators/ChatbotKnowledgeBaseValidatorTests.cs`
- `app/server/Tests/Unit/Repositories/ChatbotKnowledgeBaseRepositoryTests.cs`
- `app/server/Tests/Integration/Controllers/ChatbotKnowledgeBaseControllerTests.cs`

## Dependencies
- Task 909: CRUD operations implemented
- Task 910: Validation implemented
- Task 911: DTO mapping implemented
- Test project and test infrastructure configured

## Implementation Steps
1. Set up test fixtures and mock data for ChatbotKnowledgeBase
2. Write unit tests for CreateChatbotKnowledgeBaseValidator covering all rules
3. Write unit tests for UpdateChatbotKnowledgeBaseValidator covering all rules
4. Write repository unit tests with in-memory database or mocks
5. Write integration tests using WebApplicationFactory for each endpoint
6. Test edge cases: missing Topic, invalid SourceUrl, invalid Language code, RelevanceScore out of range
7. Test search functionality with various query terms
8. Test category and tag filtering
9. Run all tests and verify they pass

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
