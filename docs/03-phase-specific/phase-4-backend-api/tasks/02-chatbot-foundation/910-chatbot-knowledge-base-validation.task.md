# Task 910: Chatbot Knowledge Base Validation

## Status: TODO
## Sprint: 5
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Implement FluentValidation validators for ChatbotKnowledgeBase create and update DTOs. Ensure all knowledge base input data is properly validated, including content length constraints, valid category values, URL format validation, and language code validation.

## Acceptance Criteria
- [ ] FluentValidation validator created for CreateChatbotKnowledgeBaseDto
- [ ] FluentValidation validator created for UpdateChatbotKnowledgeBaseDto
- [ ] Topic is required and has a reasonable maximum length
- [ ] Content is required and has a reasonable maximum length
- [ ] Category is required and validated against allowed values
- [ ] Tags is validated as a proper collection/array format
- [ ] SourceUrl is validated as a proper URL format when provided
- [ ] Language is validated as a valid language/locale code when provided
- [ ] RelevanceScore must be between 0 and 1 when provided
- [ ] Validation errors return 400 Bad Request with structured error messages

## Files to Modify/Create
- `app/server/Application/Validators/ChatbotKnowledgeBase/CreateChatbotKnowledgeBaseValidator.cs`
- `app/server/Application/Validators/ChatbotKnowledgeBase/UpdateChatbotKnowledgeBaseValidator.cs`
- `app/server/Application/DTOs/ChatbotKnowledgeBase/CreateChatbotKnowledgeBaseDto.cs`
- `app/server/Application/DTOs/ChatbotKnowledgeBase/UpdateChatbotKnowledgeBaseDto.cs`

## Dependencies
- Task 909: ChatbotKnowledgeBase entity must be defined
- FluentValidation NuGet package installed
- Validation pipeline configured in the application

## Implementation Steps
1. Define CreateChatbotKnowledgeBaseDto with required input fields
2. Define UpdateChatbotKnowledgeBaseDto with mutable fields
3. Create CreateChatbotKnowledgeBaseValidator with rules for Topic, Content, Category, Tags, SourceUrl, Language
4. Create UpdateChatbotKnowledgeBaseValidator with rules for optional but constrained fields
5. Add URL format validation for SourceUrl
6. Add language code validation for Language field
7. Register validators in DI container
8. Test with invalid payloads to confirm proper error responses

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
