# Task 901: Chatbot Conversation CRUD Operations

## Status: TODO
## Sprint: 5
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Implement full CRUD operations for the ChatbotConversation entity. This entity tracks user conversations with the AI chatbot, including metadata such as token usage, conversation mode, and archival status. The implementation should follow the existing repository pattern established in the project.

## Acceptance Criteria
- [ ] ChatbotConversation entity is properly defined with all required fields (UserId, Title, Summary, StartedAt, EndedAt, MessageCount, TotalTokensUsed, ConversationMode, IsArchived)
- [ ] Repository interface and implementation follow existing patterns
- [ ] CREATE operation persists a new conversation with all required fields
- [ ] READ operation retrieves conversations by ID, by UserId, and supports pagination
- [ ] UPDATE operation modifies mutable fields (Title, Summary, EndedAt, MessageCount, TotalTokensUsed, IsArchived)
- [ ] DELETE operation soft-deletes or removes a conversation
- [ ] All operations return appropriate HTTP status codes
- [ ] Controller endpoints are properly routed and documented

## Files to Modify/Create
- `app/server/Domain/Entities/ChatbotConversation.cs`
- `app/server/Application/Interfaces/IChatbotConversationRepository.cs`
- `app/server/Infrastructure/Repositories/ChatbotConversationRepository.cs`
- `app/server/API/Controllers/ChatbotConversationController.cs`
- `app/server/Infrastructure/Data/Configurations/ChatbotConversationConfiguration.cs`

## Dependencies
- Database schema with ChatbotConversation table
- Base entity/repository patterns established in prior tasks
- Authentication middleware for UserId resolution

## Implementation Steps
1. Define the ChatbotConversation entity class with all properties
2. Create the EF Core entity configuration with proper column types and constraints
3. Define the repository interface with CRUD method signatures
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
