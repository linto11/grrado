# Task 902: Chatbot Conversation Validation

## Status: TODO
## Sprint: 5
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Implement FluentValidation validators for ChatbotConversation create and update DTOs. Ensure all input data is properly validated before reaching the service/repository layer, following the validation patterns established in the project.

## Acceptance Criteria
- [ ] FluentValidation validator created for CreateChatbotConversationDto
- [ ] FluentValidation validator created for UpdateChatbotConversationDto
- [ ] Title is required and has a maximum length of 255 characters
- [ ] ConversationMode is validated against allowed enum values
- [ ] UserId is required and must be a valid identifier
- [ ] Summary has a reasonable maximum length constraint
- [ ] Validation errors return 400 Bad Request with structured error messages
- [ ] Validators are registered in the DI container

## Files to Modify/Create
- `app/server/Application/Validators/ChatbotConversation/CreateChatbotConversationValidator.cs`
- `app/server/Application/Validators/ChatbotConversation/UpdateChatbotConversationValidator.cs`
- `app/server/Application/DTOs/ChatbotConversation/CreateChatbotConversationDto.cs`
- `app/server/Application/DTOs/ChatbotConversation/UpdateChatbotConversationDto.cs`

## Dependencies
- Task 901: ChatbotConversation entity must be defined
- FluentValidation NuGet package installed
- Validation pipeline configured in the application

## Implementation Steps
1. Define CreateChatbotConversationDto with required input fields
2. Define UpdateChatbotConversationDto with mutable fields
3. Create CreateChatbotConversationValidator with rules for Title (required, max 255), ConversationMode (valid enum), UserId (required)
4. Create UpdateChatbotConversationValidator with rules for optional but constrained fields
5. Register validators in DI via assembly scanning or explicit registration
6. Verify validation pipeline middleware intercepts invalid requests
7. Test with invalid payloads to confirm proper error responses

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
