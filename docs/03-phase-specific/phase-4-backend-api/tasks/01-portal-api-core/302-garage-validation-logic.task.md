# Task 302: Garage Validation Logic

## Status: TODO
## Sprint: 4
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Implement FluentValidation rules for Garage create and update requests. Ensure invalid data is rejected with clear 400 error responses. Validate all Garage-specific fields.

## Acceptance Criteria
- [ ] Name required, max 255 characters
- [ ] Address required, max 500 characters
- [ ] City required, max 100 characters
- [ ] PhoneNumber format validated when provided
- [ ] Email format validated when provided
- [ ] Foreign key references validated against existing entities
- [ ] Invalid requests return 400 with validation details
- [ ] Validation error response follows consistent format

## Files to Modify/Create
- `app/server/Application/Validators/CreateGarageRequestValidator.cs`
- `app/server/Application/Validators/UpdateGarageRequestValidator.cs`

## Dependencies
- Task 301: Garage Service CRUD Verification

## Implementation Steps
1. Create CreateGarageRequestValidator with FluentValidation rules
2. Create UpdateGarageRequestValidator with FluentValidation rules
3. Add rules for all Garage-specific fields
4. Verify validators auto-discovered by assembly scanning in DI
5. Test with invalid payloads and verify 400 responses

## Completion Checklist
- [ ] Validators created and registered
- [ ] Build passes
- [ ] Invalid requests return proper 400 responses
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
