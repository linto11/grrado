# Task 101: User Service CRUD Verification

## Status: TODO
## Sprint: 2
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Verify all CRUD operations for the User entity work correctly after the database schema fix. Ensure the BaseService generic implementation handles User operations properly end-to-end.

## Acceptance Criteria
- [ ] GET /api/Users returns 200 with paginated list
- [ ] GET /api/Users/{id} returns 200 with user details
- [ ] POST /api/Users creates user and returns 201
- [ ] PUT /api/Users/{id} updates user and returns 200
- [ ] DELETE /api/Users/{id} soft-deletes and returns 204
- [ ] Pagination parameters (skip/take) work correctly
- [ ] Soft-deleted users excluded from GET queries

## Files to Modify/Create
- `app/server/API/Controllers/UsersController.cs`
- `app/server/Application/Services/Core/UserService.cs`
- `app/server/Application/Services/Core/IUserService.cs`

## Dependencies
- Task 003: Database Schema Alignment (COMPLETED)

## Implementation Steps
1. Run API and test GET /api/Users with empty database
2. Test POST with valid user data
3. Test GET by ID for created user
4. Test PUT with updated fields
5. Test DELETE and verify soft-delete behavior
6. Test pagination with multiple records

## Completion Checklist
- [ ] All CRUD endpoints return correct status codes
- [ ] Build passes
- [ ] Tested manually via curl/Scalar
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
