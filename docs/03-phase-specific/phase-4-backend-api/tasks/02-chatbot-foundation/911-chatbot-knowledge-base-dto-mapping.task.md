# Task 911: Chatbot Knowledge Base DTO Mapping

## Status: TODO
## Sprint: 5
## Priority: MEDIUM
## Estimated Effort: SMALL

## Description
Configure AutoMapper (or manual mapping) profiles for mapping between ChatbotKnowledgeBase entity and its DTOs. Ensure clean separation between domain entities and API contracts, including proper handling of the Tags collection and usage metrics.

## Acceptance Criteria
- [ ] Response DTO defined with all public-facing fields
- [ ] AutoMapper profile maps ChatbotKnowledgeBase entity to ChatbotKnowledgeBaseResponseDto
- [ ] AutoMapper profile maps CreateChatbotKnowledgeBaseDto to ChatbotKnowledgeBase entity
- [ ] AutoMapper profile maps UpdateChatbotKnowledgeBaseDto to ChatbotKnowledgeBase entity (partial update)
- [ ] Tags collection is properly serialized/deserialized in mapping
- [ ] UsageCount is included in response but not settable via create/update
- [ ] Mapping profile is registered in the DI container

## Files to Modify/Create
- `app/server/Application/DTOs/ChatbotKnowledgeBase/ChatbotKnowledgeBaseResponseDto.cs`
- `app/server/Application/Mappings/ChatbotKnowledgeBaseProfile.cs`

## Dependencies
- Task 909: ChatbotKnowledgeBase entity defined
- Task 910: Create/Update DTOs defined
- AutoMapper NuGet package installed

## Implementation Steps
1. Define ChatbotKnowledgeBaseResponseDto with appropriate public fields
2. Create AutoMapper profile class with entity-to-DTO and DTO-to-entity mappings
3. Handle Tags collection serialization in the mapping if needed
4. Ensure UsageCount is read-only in the response DTO
5. Register the profile in the mapping configuration
6. Verify mappings work correctly in controller actions
7. Test that unmapped or internal fields are not exposed

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
