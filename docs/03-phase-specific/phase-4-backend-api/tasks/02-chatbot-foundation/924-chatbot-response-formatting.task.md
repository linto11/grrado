# Task 924: Chatbot Response Formatting

## Status: TODO
## Sprint: 5
## Priority: MEDIUM
## Estimated Effort: SMALL

## Description
Implement support for Markdown formatting in chatbot responses. Ensure that AI responses containing Markdown elements (code blocks, lists, headers, links) are properly preserved and that both formatted (Markdown) and raw (plain text) versions of responses are available to the client.

## Acceptance Criteria
- [ ] Response formatting service/utility created
- [ ] Markdown content in bot responses is properly preserved in the API response
- [ ] Code blocks with language identifiers are supported (e.g., ```csharp)
- [ ] Ordered and unordered lists are supported
- [ ] Inline code, bold, italic formatting is supported
- [ ] Both formatted (Markdown) and raw (plain text stripped) versions are available in the response DTO
- [ ] Plain text version strips all Markdown syntax for accessibility/fallback
- [ ] Response DTO includes a field indicating whether the response contains Markdown
- [ ] Formatting does not alter or corrupt the original AI response content

## Files to Modify/Create
- `app/server/Application/Services/Chat/IResponseFormattingService.cs`
- `app/server/Application/Services/Chat/ResponseFormattingService.cs`
- `app/server/Application/DTOs/ChatbotMessage/ChatbotMessageResponseDto.cs` (add formatted/raw fields)

## Dependencies
- Task 905: ChatbotMessage entity for storing responses
- Task 907: ChatbotMessage DTO mapping for response structure
- Markdown parsing library (e.g., Markdig) if needed for stripping

## Implementation Steps
1. Define IResponseFormattingService interface with methods: FormatResponse, StripMarkdown, DetectMarkdown
2. Implement ResponseFormattingService with Markdown detection logic
3. Implement plain text stripping that removes Markdown syntax while preserving content
4. Update ChatbotMessageResponseDto to include FormattedResponse, RawResponse, and HasMarkdown fields
5. Integrate formatting service into the message creation/retrieval pipeline
6. Register service in DI container
7. Write unit tests for Markdown detection, formatting, and stripping
8. Test with various Markdown content samples

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
