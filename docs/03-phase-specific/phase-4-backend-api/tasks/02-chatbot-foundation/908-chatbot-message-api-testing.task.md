# Task 908: Chatbot Message API Testing

## Status: TODO
## Sprint: 5
## Priority: MEDIUM
## Estimated Effort: MEDIUM

## Description
Create comprehensive API tests for all ChatbotMessage endpoints. Cover happy paths, validation errors, not-found scenarios, foreign key constraint enforcement, and authorization checks to ensure the message CRUD operations are robust and reliable.

## Acceptance Criteria
- [ ] Unit tests for ChatbotMessage repository methods
- [ ] Unit tests for ChatbotMessage validators
- [ ] Integration tests for POST /api/chatbot-messages (create)
- [ ] Integration tests for GET /api/chatbot-messages/{id} (read single)
- [ ] Integration tests for GET /api/chatbot-messages?conversationId={id} (read by conversation)
- [ ] Integration tests for PUT /api/chatbot-messages/{id} (update)
- [ ] Integration tests for DELETE /api/chatbot-messages/{id} (delete)
- [ ] Tests verify foreign key constraint (invalid ConversationId returns error)
- [ ] Tests verify proper HTTP status codes (200, 201, 400, 404)
- [ ] Tests verify validation error responses for invalid input
- [ ] All tests pass in CI pipeline

## Files to Modify/Create
- `app/server/Tests/Unit/Validators/ChatbotMessageValidatorTests.cs`
- `app/server/Tests/Unit/Repositories/ChatbotMessageRepositoryTests.cs`
- `app/server/Tests/Integration/Controllers/ChatbotMessageControllerTests.cs`

## Dependencies
- Task 905: CRUD operations implemented
- Task 906: Validation implemented
- Task 907: DTO mapping implemented
- Test project and test infrastructure configured

## Implementation Steps
1. Set up test fixtures and mock data for ChatbotMessage and parent ChatbotConversation
2. Write unit tests for CreateChatbotMessageValidator covering all rules
3. Write unit tests for UpdateChatbotMessageValidator covering all rules
4. Write repository unit tests with in-memory database or mocks
5. Write integration tests using WebApplicationFactory for each endpoint
6. Test edge cases: missing ConversationId, invalid MessageType, negative TokensUsed, ConfidenceScore out of range
7. Test chronological ordering of messages within a conversation
8. Run all tests and verify they pass

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
