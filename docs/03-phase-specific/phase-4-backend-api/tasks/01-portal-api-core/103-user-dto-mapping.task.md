# Task 103: User DTO Mapping Verification

## Status: TODO
## Sprint: 2
## Priority: MEDIUM
## Estimated Effort: SMALL

## Description
Verify AutoMapper profiles correctly map all User entity fields to DTOs and vice versa.

## Acceptance Criteria
- [ ] All User entity fields mapped to UserDto
- [ ] CreateUserRequest maps correctly to User entity
- [ ] UpdateUserRequest maps correctly to User entity
- [ ] Null fields handled gracefully
- [ ] Audit fields (CreatedAt, UpdatedAt) mapped correctly

## Files to Modify/Create
- `app/server/Application/Mappings/UserMappingProfile.cs`

## Dependencies
- Task 101: User Service CRUD Verification

## Implementation Steps
1. Review existing mapping profile
2. Test mapping with full and partial data
3. Verify audit field mapping behavior
4. Fix any unmapped or incorrectly mapped fields

## Completion Checklist
- [ ] All fields mapped correctly
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
