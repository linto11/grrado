# Task 2004: Role-Based Authorization Attributes

## Status: TODO
## Sprint: 6
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Add [Authorize] attributes with role requirements to all controller endpoints, ensuring each action is protected with the appropriate authorization policy based on the operation type and resource sensitivity.

## Acceptance Criteria
- [ ] All controllers have [Authorize] attributes applied
- [ ] Read operations require at least Viewer role
- [ ] Create/Update operations require at least User role
- [ ] Delete operations require Admin role
- [ ] Admin-only endpoints are restricted to Admin role
- [ ] [AllowAnonymous] is applied only to health check and public endpoints
- [ ] Authorization is consistent across all entity controllers

## Files to Modify/Create
- `app/server/API/Controllers/*.cs`

## Dependencies
- Task 2003: Authorization Middleware

## Implementation Steps
1. Audit all existing controllers and their endpoints
2. Define role requirements for each endpoint type (GET, POST, PUT, DELETE)
3. Apply [Authorize(Policy = "ViewerPolicy")] to GET endpoints
4. Apply [Authorize(Policy = "UserPolicy")] to POST and PUT endpoints
5. Apply [Authorize(Policy = "AdminPolicy")] to DELETE endpoints
6. Mark health check and public endpoints with [AllowAnonymous]
7. Verify no endpoints are accidentally left unprotected
8. Test each endpoint with tokens of different roles to verify access control

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
