# Task 903: Chatbot Conversation DTO Mapping

## Status: TODO
## Sprint: 5
## Priority: MEDIUM
## Estimated Effort: SMALL

## Description
Configure AutoMapper (or manual mapping) profiles for mapping between ChatbotConversation entity and its DTOs. Ensure clean separation between domain entities and API contracts, following the mapping conventions established in the project.

## Acceptance Criteria
- [ ] Response DTO defined with all public-facing fields
- [ ] AutoMapper profile maps ChatbotConversation entity to ChatbotConversationResponseDto
- [ ] AutoMapper profile maps CreateChatbotConversationDto to ChatbotConversation entity
- [ ] AutoMapper profile maps UpdateChatbotConversationDto to ChatbotConversation entity (partial update)
- [ ] Pagination/list response DTO supports collection of conversations
- [ ] Sensitive or internal fields are excluded from response DTOs
- [ ] Mapping profile is registered in the DI container

## Files to Modify/Create
- `app/server/Application/DTOs/ChatbotConversation/ChatbotConversationResponseDto.cs`
- `app/server/Application/Mappings/ChatbotConversationProfile.cs`

## Dependencies
- Task 901: ChatbotConversation entity defined
- Task 902: Create/Update DTOs defined
- AutoMapper NuGet package installed

## Implementation Steps
1. Define ChatbotConversationResponseDto with appropriate public fields
2. Create AutoMapper profile class with entity-to-DTO and DTO-to-entity mappings
3. Configure any custom value resolvers or type converters if needed
4. Register the profile in the mapping configuration
5. Verify mappings work correctly in controller actions
6. Test that unmapped or sensitive fields are not exposed

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
