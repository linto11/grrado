# Task 907: Chatbot Message DTO Mapping

## Status: TODO
## Sprint: 5
## Priority: MEDIUM
## Estimated Effort: SMALL

## Description
Configure AutoMapper (or manual mapping) profiles for mapping between ChatbotMessage entity and its DTOs. Ensure clean separation between domain entities and API contracts, including proper handling of the ReferencedEntities JSON field and navigation properties.

## Acceptance Criteria
- [ ] Response DTO defined with all public-facing fields
- [ ] AutoMapper profile maps ChatbotMessage entity to ChatbotMessageResponseDto
- [ ] AutoMapper profile maps CreateChatbotMessageDto to ChatbotMessage entity
- [ ] AutoMapper profile maps UpdateChatbotMessageDto to ChatbotMessage entity (partial update)
- [ ] ReferencedEntities JSON field is properly serialized/deserialized in mapping
- [ ] Sensitive or internal fields are excluded from response DTOs
- [ ] Mapping profile is registered in the DI container

## Files to Modify/Create
- `app/server/Application/DTOs/ChatbotMessage/ChatbotMessageResponseDto.cs`
- `app/server/Application/Mappings/ChatbotMessageProfile.cs`

## Dependencies
- Task 905: ChatbotMessage entity defined
- Task 906: Create/Update DTOs defined
- AutoMapper NuGet package installed

## Implementation Steps
1. Define ChatbotMessageResponseDto with appropriate public fields
2. Create AutoMapper profile class with entity-to-DTO and DTO-to-entity mappings
3. Handle ReferencedEntities JSON serialization in the mapping if needed
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
