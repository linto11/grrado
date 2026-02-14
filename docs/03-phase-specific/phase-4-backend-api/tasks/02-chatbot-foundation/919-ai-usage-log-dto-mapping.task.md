# Task 919: AI Usage Log DTO Mapping

## Status: TODO
## Sprint: 5
## Priority: MEDIUM
## Estimated Effort: SMALL

## Description
Configure AutoMapper (or manual mapping) profiles for mapping between AiUsageLog entity and its DTOs. Ensure clean separation between domain entities and API contracts, with particular attention to cost and token usage fields that may need formatting or aggregation.

## Acceptance Criteria
- [ ] Response DTO defined with all public-facing fields
- [ ] AutoMapper profile maps AiUsageLog entity to AiUsageLogResponseDto
- [ ] AutoMapper profile maps CreateAiUsageLogDto to AiUsageLog entity
- [ ] AutoMapper profile maps UpdateAiUsageLogDto to AiUsageLog entity (partial update)
- [ ] Summary/aggregation DTO defined for usage statistics responses
- [ ] CostUsd is properly formatted with appropriate decimal precision
- [ ] Sensitive or internal fields are excluded from response DTOs
- [ ] Mapping profile is registered in the DI container

## Files to Modify/Create
- `app/server/Application/DTOs/AiUsageLog/AiUsageLogResponseDto.cs`
- `app/server/Application/DTOs/AiUsageLog/AiUsageLogSummaryDto.cs`
- `app/server/Application/Mappings/AiUsageLogProfile.cs`

## Dependencies
- Task 917: AiUsageLog entity defined
- Task 918: Create/Update DTOs defined
- AutoMapper NuGet package installed

## Implementation Steps
1. Define AiUsageLogResponseDto with appropriate public fields
2. Define AiUsageLogSummaryDto for aggregated usage statistics
3. Create AutoMapper profile class with entity-to-DTO and DTO-to-entity mappings
4. Configure proper decimal precision for CostUsd mapping
5. Register the profile in the mapping configuration
6. Verify mappings work correctly in controller actions
7. Test that unmapped or sensitive fields are not exposed

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
