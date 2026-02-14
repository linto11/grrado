# Task 802: Image Diagnostic Validation Logic

## Status: TODO
## Sprint: 4
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Implement FluentValidation validators for ImageDiagnostic create and update DTOs, ensuring all required fields are validated with appropriate rules for length, format, and business constraints.

## Acceptance Criteria
- [ ] FluentValidation validator exists for ImageDiagnosticCreateDto with rules for all required fields
- [ ] FluentValidation validator exists for ImageDiagnosticUpdateDto with appropriate rules
- [ ] Image-related fields are validated for correct format and size constraints
- [ ] Validation errors return structured 400 responses with field-level messages

## Files to Modify/Create
- `app/server/API/Validators/ImageDiagnosticCreateValidator.cs`
- `app/server/API/Validators/ImageDiagnosticUpdateValidator.cs`
- `app/server/API/DTOs/ImageDiagnostic/ImageDiagnosticCreateDto.cs`
- `app/server/API/DTOs/ImageDiagnostic/ImageDiagnosticUpdateDto.cs`

## Dependencies
- Task 003: Database Schema Alignment (COMPLETED)

## Implementation Steps
1. Define validation rules for ImageDiagnosticCreateDto (required fields, max lengths, format constraints)
2. Define validation rules for ImageDiagnosticUpdateDto (partial update support, same constraints)
3. Add image-specific validation rules (file type, size limits) if applicable
4. Register validators in the DI container
5. Test validation by sending invalid payloads and verifying error responses

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
