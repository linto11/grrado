# Task 803: Image Diagnostic DTO Mapping Verification

## Status: TODO
## Sprint: 4
## Priority: MEDIUM
## Estimated Effort: SMALL

## Description
Verify and validate AutoMapper profiles for the ImageDiagnostic entity, ensuring all properties map correctly between entity, request DTOs, and response DTOs.

## Acceptance Criteria
- [ ] AutoMapper profile exists for ImageDiagnostic entity with correct property mappings
- [ ] Mapping from ImageDiagnostic entity to ImageDiagnosticResponseDto works correctly
- [ ] Mapping from ImageDiagnosticCreateDto/UpdateDto to ImageDiagnostic entity works correctly
- [ ] No unmapped properties or mapping errors at startup

## Files to Modify/Create
- `app/server/API/Mapping/ImageDiagnosticProfile.cs`
- `app/server/API/DTOs/ImageDiagnostic/ImageDiagnosticResponseDto.cs`
- `app/server/API/DTOs/ImageDiagnostic/ImageDiagnosticCreateDto.cs`
- `app/server/API/DTOs/ImageDiagnostic/ImageDiagnosticUpdateDto.cs`

## Dependencies
- Task 003: Database Schema Alignment (COMPLETED)

## Implementation Steps
1. Review the ImageDiagnostic entity and identify all properties that need mapping
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
