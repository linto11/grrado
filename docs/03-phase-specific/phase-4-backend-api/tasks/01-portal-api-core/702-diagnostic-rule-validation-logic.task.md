# Task 702: Diagnostic Rule Validation Logic

## Status: TODO
## Sprint: 4
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Implement FluentValidation validators for DiagnosticRule create and update DTOs, ensuring all required fields are validated with appropriate rules for length, format, and business constraints.

## Acceptance Criteria
- [ ] FluentValidation validator exists for DiagnosticRuleCreateDto with rules for all required fields
- [ ] FluentValidation validator exists for DiagnosticRuleUpdateDto with appropriate rules
- [ ] RuleCode is validated for uniqueness, format, and required presence
- [ ] SeverityLevel is validated against allowed values
- [ ] Validation errors return structured 400 responses with field-level messages

## Files to Modify/Create
- `app/server/API/Validators/DiagnosticRuleCreateValidator.cs`
- `app/server/API/Validators/DiagnosticRuleUpdateValidator.cs`
- `app/server/API/DTOs/DiagnosticRule/DiagnosticRuleCreateDto.cs`
- `app/server/API/DTOs/DiagnosticRule/DiagnosticRuleUpdateDto.cs`

## Dependencies
- Task 003: Database Schema Alignment (COMPLETED)

## Implementation Steps
1. Define validation rules for DiagnosticRuleCreateDto (required fields, max lengths, format constraints)
2. Define validation rules for DiagnosticRuleUpdateDto (partial update support, same constraints)
3. Add RuleCode uniqueness check via async validator if needed
4. Register validators in the DI container
5. Test validation by sending invalid payloads and verifying error responses

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
