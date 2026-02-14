# Task 906: Chatbot Message Validation

## Status: TODO
## Sprint: 5
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Implement FluentValidation validators for ChatbotMessage create and update DTOs. Ensure all message input data is properly validated, including content length constraints, valid conversation references, and proper enum values for message types.

## Acceptance Criteria
- [ ] FluentValidation validator created for CreateChatbotMessageDto
- [ ] FluentValidation validator created for UpdateChatbotMessageDto
- [ ] ConversationId is required and must reference an existing conversation
- [ ] UserId is required and must be a valid identifier
- [ ] UserMessage is required and has a reasonable maximum length
- [ ] MessageType is validated against allowed enum values
- [ ] TokensUsed must be non-negative when provided
- [ ] ProcessingTimeMs must be non-negative when provided
- [ ] ConfidenceScore must be between 0 and 1 when provided
- [ ] Validation errors return 400 Bad Request with structured error messages

## Files to Modify/Create
- `app/server/Application/Validators/ChatbotMessage/CreateChatbotMessageValidator.cs`
- `app/server/Application/Validators/ChatbotMessage/UpdateChatbotMessageValidator.cs`
- `app/server/Application/DTOs/ChatbotMessage/CreateChatbotMessageDto.cs`
- `app/server/Application/DTOs/ChatbotMessage/UpdateChatbotMessageDto.cs`

## Dependencies
- Task 905: ChatbotMessage entity must be defined
- FluentValidation NuGet package installed
- Validation pipeline configured in the application

## Implementation Steps
1. Define CreateChatbotMessageDto with required input fields
2. Define UpdateChatbotMessageDto with mutable fields
3. Create CreateChatbotMessageValidator with rules for ConversationId, UserId, UserMessage, MessageType
4. Create UpdateChatbotMessageValidator with rules for optional but constrained fields
5. Add numeric range validations for TokensUsed, ProcessingTimeMs, ConfidenceScore
6. Register validators in DI container
7. Test with invalid payloads to confirm proper error responses

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
