# Task 2005: User Context Claims Extraction

## Status: TODO
## Sprint: 6
## Priority: MEDIUM
## Estimated Effort: MEDIUM

## Description
Extract user information from JWT claims to populate audit trail fields such as CreatedBy and UpdatedBy. Implement a service that provides the current user's identity from the token for use across the application.

## Acceptance Criteria
- [ ] User context service extracts user ID from JWT claims
- [ ] User context service extracts username/email from JWT claims
- [ ] User context service extracts roles from JWT claims
- [ ] CreatedBy field is automatically populated on entity creation
- [ ] UpdatedBy field is automatically populated on entity updates
- [ ] User context is available via dependency injection
- [ ] Claims extraction handles missing or malformed claims gracefully

## Files to Modify/Create
- `app/server/API/Services/UserContextService.cs`
- `app/server/API/Interfaces/IUserContextService.cs`
- `app/server/API/Program.cs`

## Dependencies
- Task 2001: JWT Token Validation Middleware

## Implementation Steps
1. Create IUserContextService interface with properties for UserId, Username, Email, Roles
2. Implement UserContextService that reads from IHttpContextAccessor.HttpContext.User
3. Map Keycloak claim types (sub, preferred_username, email, realm_access.roles) to properties
4. Register IUserContextService as scoped in DI container
5. Register IHttpContextAccessor in DI if not already registered
6. Inject IUserContextService into repositories or DbContext for audit population
7. Override SaveChangesAsync to auto-populate CreatedBy/UpdatedBy using the service
8. Test that audit fields are populated correctly after authenticated requests

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
