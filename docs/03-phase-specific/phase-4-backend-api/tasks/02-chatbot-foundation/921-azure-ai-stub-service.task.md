# Task 921: Azure AI Stub Service

## Status: TODO
## Sprint: 5
## Priority: HIGH
## Estimated Effort: LARGE

## Description
Create the interface and mock implementation for Azure AI services. This stub service enables development and testing of the chatbot pipeline without requiring actual Azure AI credentials or incurring API costs. The interface should define methods for both chat completions and image analysis, while the stub returns realistic mock data.

## Acceptance Criteria
- [ ] IAzureAiService interface defines method for chat completion (send message, receive response)
- [ ] IAzureAiService interface defines method for image analysis (send image, receive analysis results)
- [ ] IAzureAiService interface defines method for streaming chat responses
- [ ] AzureAiStubService implements IAzureAiService with mock responses
- [ ] Stub service returns realistic mock data with simulated delays
- [ ] Stub service simulates token counting for usage tracking
- [ ] Stub service is registered in DI container as the default implementation
- [ ] Configuration allows switching between stub and real service via appsettings
- [ ] Mock responses include proper structure matching expected AI response format
- [ ] Service includes proper logging for debugging

## Files to Modify/Create
- `app/server/Application/Services/AI/IAzureAiService.cs`
- `app/server/Application/Services/AI/AzureAiStubService.cs`
- `app/server/Application/Models/AI/ChatCompletionRequest.cs`
- `app/server/Application/Models/AI/ChatCompletionResponse.cs`
- `app/server/Application/Models/AI/ImageAnalysisRequest.cs`
- `app/server/Application/Models/AI/ImageAnalysisResponse.cs`
- `app/server/API/Program.cs` (DI registration)
- `app/server/API/appsettings.Development.json` (stub configuration)

## Dependencies
- Base application architecture and DI container configured
- Understanding of Azure OpenAI API response formats

## Implementation Steps
1. Define ChatCompletionRequest and ChatCompletionResponse model classes
2. Define ImageAnalysisRequest and ImageAnalysisResponse model classes
3. Create IAzureAiService interface with chat completion, image analysis, and streaming methods
4. Implement AzureAiStubService with realistic mock responses
5. Add simulated processing delays (configurable) to mimic real API latency
6. Implement mock token counting logic
7. Add configuration section in appsettings for AI service provider selection
8. Register AzureAiStubService in DI container with conditional logic for environment
9. Add logging to stub service for development debugging
10. Write unit tests for the stub service behavior

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
