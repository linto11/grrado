# Task 904: Chatbot Conversation API Testing

## Status: TODO
## Sprint: 5
## Priority: MEDIUM
## Estimated Effort: MEDIUM

## Description
Create comprehensive API tests for all ChatbotConversation endpoints. Cover happy paths, validation errors, not-found scenarios, and authorization checks to ensure the conversation CRUD operations are robust and reliable.

## Acceptance Criteria
- [ ] Unit tests for ChatbotConversation repository methods
- [ ] Unit tests for ChatbotConversation validators
- [ ] Integration tests for POST /api/chatbot-conversations (create)
- [ ] Integration tests for GET /api/chatbot-conversations/{id} (read single)
- [ ] Integration tests for GET /api/chatbot-conversations?userId={id} (read list with filters)
- [ ] Integration tests for PUT /api/chatbot-conversations/{id} (update)
- [ ] Integration tests for DELETE /api/chatbot-conversations/{id} (delete)
- [ ] Tests verify proper HTTP status codes (200, 201, 400, 404)
- [ ] Tests verify validation error responses for invalid input
- [ ] All tests pass in CI pipeline

## Files to Modify/Create
- `app/server/Tests/Unit/Validators/ChatbotConversationValidatorTests.cs`
- `app/server/Tests/Unit/Repositories/ChatbotConversationRepositoryTests.cs`
- `app/server/Tests/Integration/Controllers/ChatbotConversationControllerTests.cs`

## Dependencies
- Task 901: CRUD operations implemented
- Task 902: Validation implemented
- Task 903: DTO mapping implemented
- Test project and test infrastructure configured

## Implementation Steps
1. Set up test fixtures and mock data for ChatbotConversation
2. Write unit tests for CreateChatbotConversationValidator covering all rules
3. Write unit tests for UpdateChatbotConversationValidator covering all rules
4. Write repository unit tests with in-memory database or mocks
5. Write integration tests using WebApplicationFactory for each endpoint
6. Test edge cases: empty title, title exceeding 255 chars, invalid ConversationMode, missing UserId
7. Test pagination and filtering on list endpoint
8. Run all tests and verify they pass

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
