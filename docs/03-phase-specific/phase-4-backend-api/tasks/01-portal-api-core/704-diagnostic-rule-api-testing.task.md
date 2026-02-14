# Task 704: Diagnostic Rule API Endpoint Testing

## Status: TODO
## Sprint: 4
## Priority: MEDIUM
## Estimated Effort: MEDIUM

## Description
Test all DiagnosticRule CRUD endpoints to ensure they function correctly, return proper HTTP status codes, handle edge cases, and validate request/response payloads.

## Acceptance Criteria
- [ ] GET /api/diagnostic-rules returns paginated list of diagnostic rules
- [ ] GET /api/diagnostic-rules/{id} returns a single record or 404
- [ ] POST /api/diagnostic-rules creates a new record and returns 201
- [ ] PUT /api/diagnostic-rules/{id} updates an existing record and returns 200
- [ ] DELETE /api/diagnostic-rules/{id} soft-deletes a record and returns 204
- [ ] Invalid requests return appropriate 400/422 error responses

## Files to Modify/Create
- `app/server/API/Controllers/DiagnosticRuleController.cs`
- `app/server/API/Services/DiagnosticRuleService.cs`

## Dependencies
- Task 003: Database Schema Alignment (COMPLETED)

## Implementation Steps
1. Start the API and verify all DiagnosticRule endpoints are registered
2. Test each CRUD operation with valid data and verify correct responses
3. Test error scenarios including invalid IDs, missing required fields, and malformed requests
4. Verify response DTOs contain all expected fields with correct values
5. Document any issues found and fix them

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
