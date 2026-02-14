# Task 923: Conversation Context Service

## Status: TODO
## Sprint: 5
## Priority: MEDIUM
## Estimated Effort: MEDIUM

## Description
Implement a service for managing conversation session context. This service tracks message history within a conversation, maintains a sliding context window to stay within token limits, performs token counting for context management, and provides the conversation context needed for AI chat completions.

## Acceptance Criteria
- [ ] IConversationContextService interface defined with methods for context management
- [ ] Service tracks message history for a given conversation
- [ ] Context window is maintained within configurable token limits (e.g., 4096 tokens)
- [ ] Oldest messages are pruned when context window is exceeded (sliding window)
- [ ] Token counting is implemented (approximate or using a tokenizer library)
- [ ] System prompt/instructions can be prepended to the context
- [ ] Context can be retrieved in the format required by the AI service
- [ ] Service integrates with ChatbotMessage repository to load history
- [ ] Context is properly cleared when a conversation ends or is reset

## Files to Modify/Create
- `app/server/Application/Services/Chat/IConversationContextService.cs`
- `app/server/Application/Services/Chat/ConversationContextService.cs`
- `app/server/Application/Models/Chat/ConversationContext.cs`
- `app/server/Application/Models/Chat/ContextMessage.cs`

## Dependencies
- Task 901: ChatbotConversation entity for conversation reference
- Task 905: ChatbotMessage entity for message history
- Task 921: IAzureAiService for understanding required context format

## Implementation Steps
1. Define ConversationContext and ContextMessage model classes
2. Define IConversationContextService interface with methods: BuildContext, AddMessage, ClearContext, GetTokenCount
3. Implement token counting logic (character-based approximation or tokenizer library)
4. Implement sliding window logic to maintain context within token limits
5. Implement BuildContext method that loads message history and constructs the context
6. Add system prompt configuration support
7. Register service in DI container
8. Write unit tests for token counting and sliding window behavior
9. Test context building with various conversation lengths

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
