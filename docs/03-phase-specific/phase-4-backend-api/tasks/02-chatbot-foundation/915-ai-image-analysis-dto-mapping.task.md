# Task 915: AI Image Analysis DTO Mapping

## Status: TODO
## Sprint: 5
## Priority: MEDIUM
## Estimated Effort: SMALL

## Description
Configure AutoMapper (or manual mapping) profiles for mapping between AiImageAnalysis entity and its DTOs. Ensure clean separation between domain entities and API contracts, including proper handling of the DetectedObjects and DiagnosticSuggestions JSON fields.

## Acceptance Criteria
- [ ] Response DTO defined with all public-facing fields
- [ ] AutoMapper profile maps AiImageAnalysis entity to AiImageAnalysisResponseDto
- [ ] AutoMapper profile maps CreateAiImageAnalysisDto to AiImageAnalysis entity
- [ ] AutoMapper profile maps UpdateAiImageAnalysisDto to AiImageAnalysis entity (partial update)
- [ ] DetectedObjects JSON field is properly serialized/deserialized in mapping
- [ ] DiagnosticSuggestions JSON field is properly serialized/deserialized in mapping
- [ ] Sensitive or internal fields are excluded from response DTOs
- [ ] Mapping profile is registered in the DI container

## Files to Modify/Create
- `app/server/Application/DTOs/AiImageAnalysis/AiImageAnalysisResponseDto.cs`
- `app/server/Application/Mappings/AiImageAnalysisProfile.cs`

## Dependencies
- Task 913: AiImageAnalysis entity defined
- Task 914: Create/Update DTOs defined
- AutoMapper NuGet package installed

## Implementation Steps
1. Define AiImageAnalysisResponseDto with appropriate public fields
2. Create AutoMapper profile class with entity-to-DTO and DTO-to-entity mappings
3. Handle DetectedObjects and DiagnosticSuggestions JSON serialization in the mapping
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
