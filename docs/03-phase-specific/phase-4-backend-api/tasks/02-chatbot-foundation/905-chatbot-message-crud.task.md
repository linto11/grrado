# Task 905: Chatbot Message CRUD Operations

## Status: TODO
## Sprint: 5
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Implement full CRUD operations for the ChatbotMessage entity. This entity stores individual messages within a conversation, including both user input and bot responses, along with AI processing metadata such as intent detection, confidence scores, and token usage.

## Acceptance Criteria
- [ ] ChatbotMessage entity is properly defined with all required fields (ConversationId, UserId, UserMessage, BotResponse, MessageType, TokensUsed, ProcessingTimeMs, DetectedIntent, ConfidenceScore, ReferencedEntities)
- [ ] Repository interface and implementation follow existing patterns
- [ ] CREATE operation persists a new message linked to a conversation
- [ ] READ operation retrieves messages by ID, by ConversationId (ordered chronologically), and supports pagination
- [ ] UPDATE operation modifies mutable fields (BotResponse, DetectedIntent, ConfidenceScore, ReferencedEntities)
- [ ] DELETE operation removes a message
- [ ] Foreign key relationship to ChatbotConversation is enforced
- [ ] All operations return appropriate HTTP status codes
- [ ] Controller endpoints are properly routed and documented

## Files to Modify/Create
- `app/server/Domain/Entities/ChatbotMessage.cs`
- `app/server/Application/Interfaces/IChatbotMessageRepository.cs`
- `app/server/Infrastructure/Repositories/ChatbotMessageRepository.cs`
- `app/server/API/Controllers/ChatbotMessageController.cs`
- `app/server/Infrastructure/Data/Configurations/ChatbotMessageConfiguration.cs`

## Dependencies
- Task 901: ChatbotConversation entity must exist for foreign key relationship
- Database schema with ChatbotMessage table
- Base entity/repository patterns established in prior tasks

## Implementation Steps
1. Define the ChatbotMessage entity class with all properties and navigation property to ChatbotConversation
2. Create the EF Core entity configuration with proper column types, constraints, and foreign key
3. Define the repository interface with CRUD method signatures including GetByConversationId
4. Implement the repository with EF Core queries, ensuring chronological ordering
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
