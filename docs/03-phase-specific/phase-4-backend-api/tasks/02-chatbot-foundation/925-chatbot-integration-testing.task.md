# Task 925: Chatbot Integration Testing

## Status: TODO
## Sprint: 5
## Priority: HIGH
## Estimated Effort: LARGE

## Description
Create end-to-end integration tests for the complete chatbot flow. These tests verify the full pipeline from conversation creation through message exchange, image analysis, and usage logging, ensuring all components work together correctly as a cohesive system.

## Acceptance Criteria
- [ ] E2E test: Create conversation, send messages, receive responses, end conversation
- [ ] E2E test: Upload image, trigger analysis, receive diagnostic results within a conversation
- [ ] E2E test: Verify conversation context is maintained across multiple messages
- [ ] E2E test: Verify token usage is tracked and accumulated in conversation metadata
- [ ] E2E test: Verify AI usage logs are created for each AI service call
- [ ] E2E test: Verify conversation archival flow
- [ ] E2E test: Verify knowledge base articles are referenced in responses when relevant
- [ ] E2E test: Verify response formatting with Markdown content
- [ ] E2E test: Verify error handling when AI service stub returns errors
- [ ] E2E test: Verify pagination works for conversation list and message history
- [ ] All tests use the stub AI service (no external dependencies)
- [ ] Tests are isolated and can run independently
- [ ] Tests clean up their data after execution
- [ ] All tests pass in CI pipeline

## Files to Modify/Create
- `app/server/Tests/Integration/Flows/ChatbotConversationFlowTests.cs`
- `app/server/Tests/Integration/Flows/ChatbotImageAnalysisFlowTests.cs`
- `app/server/Tests/Integration/Flows/ChatbotUsageTrackingFlowTests.cs`
- `app/server/Tests/Integration/Flows/ChatbotKnowledgeBaseFlowTests.cs`
- `app/server/Tests/Integration/Helpers/ChatbotTestFixture.cs`

## Dependencies
- Task 901-904: ChatbotConversation CRUD, validation, mapping, and tests
- Task 905-908: ChatbotMessage CRUD, validation, mapping, and tests
- Task 909-912: ChatbotKnowledgeBase CRUD, validation, mapping, and tests
- Task 913-916: AiImageAnalysis CRUD, validation, mapping, and tests
- Task 917-920: AiUsageLog CRUD, validation, mapping, and tests
- Task 921: Azure AI Stub Service
- Task 922: File Upload Endpoint
- Task 923: Conversation Context Service
- Task 924: Chatbot Response Formatting

## Implementation Steps
1. Create ChatbotTestFixture with shared setup logic (WebApplicationFactory, test database, authentication helpers)
2. Implement conversation flow test: create conversation -> send multiple messages -> verify context -> end conversation
3. Implement image analysis flow test: create conversation -> upload image -> trigger analysis -> verify results
4. Implement usage tracking flow test: perform AI operations -> verify usage logs are created with correct token counts
5. Implement knowledge base flow test: create knowledge base entries -> send related query -> verify knowledge is referenced
6. Implement error handling flow test: configure stub to return errors -> verify graceful degradation
7. Implement pagination flow test: create many conversations/messages -> verify pagination parameters work
8. Add data cleanup logic in test teardown
9. Run all integration tests and verify they pass
10. Verify tests run successfully in CI pipeline

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
