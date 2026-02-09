# Task 102: User Validation Logic

## Status: TODO
## Sprint: 2
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Implement FluentValidation rules for User create and update requests. Ensure invalid data is rejected with clear 400 error responses.

## Acceptance Criteria
- [ ] Email format validated with proper regex
- [ ] Name required, max 255 characters
- [ ] PhoneNumber format validated when provided
- [ ] Invalid requests return 400 with validation details
- [ ] Validation error response follows consistent format

## Files to Modify/Create
- `app/server/Application/Validators/CreateUserRequestValidator.cs`
- `app/server/Application/Validators/UpdateUserRequestValidator.cs`

## Dependencies
- Task 101: User Service CRUD Verification

## Implementation Steps
1. Create CreateUserRequestValidator with FluentValidation rules
2. Create UpdateUserRequestValidator with FluentValidation rules
3. Verify validators auto-discovered by assembly scanning in DI
4. Test with invalid payloads and verify 400 responses

## Completion Checklist
- [ ] Validators created and registered
- [ ] Build passes
- [ ] Invalid requests return proper 400 responses
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
