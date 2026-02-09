# Task 703: Diagnostic Rule DTO Mapping Verification

## Status: TODO
## Sprint: 4
## Priority: MEDIUM
## Estimated Effort: SMALL

## Description
Verify and validate AutoMapper profiles for the DiagnosticRule entity, ensuring all properties map correctly between entity, request DTOs, and response DTOs.

## Acceptance Criteria
- [ ] AutoMapper profile exists for DiagnosticRule entity with correct property mappings
- [ ] Mapping from DiagnosticRule entity to DiagnosticRuleResponseDto works correctly
- [ ] Mapping from DiagnosticRuleCreateDto/UpdateDto to DiagnosticRule entity works correctly
- [ ] No unmapped properties or mapping errors at startup

## Files to Modify/Create
- `app/server/API/Mapping/DiagnosticRuleProfile.cs`
- `app/server/API/DTOs/DiagnosticRule/DiagnosticRuleResponseDto.cs`
- `app/server/API/DTOs/DiagnosticRule/DiagnosticRuleCreateDto.cs`
- `app/server/API/DTOs/DiagnosticRule/DiagnosticRuleUpdateDto.cs`

## Dependencies
- Task 003: Database Schema Alignment (COMPLETED)

## Implementation Steps
1. Review the DiagnosticRule entity and identify all properties that need mapping
2. Verify or create AutoMapper profile with correct source-destination mappings
3. Ensure all DTOs have matching properties for the entity fields
4. Run mapping configuration validation to detect any unmapped members

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
