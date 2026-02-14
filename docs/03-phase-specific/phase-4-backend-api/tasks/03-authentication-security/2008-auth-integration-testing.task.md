# Task 2008: Authentication Integration Testing

## Status: TODO
## Sprint: 6
## Priority: HIGH
## Estimated Effort: LARGE

## Description
Create end-to-end authentication tests covering all auth scenarios: unauthenticated requests returning 401, requests with wrong role returning 403, and requests with valid token returning 200.

## Acceptance Criteria
- [ ] Test project is set up with WebApplicationFactory
- [ ] Tests verify 401 for unauthenticated requests to protected endpoints
- [ ] Tests verify 403 for authenticated requests with insufficient role
- [ ] Tests verify 200 for authenticated requests with correct role
- [ ] Tests verify [AllowAnonymous] endpoints return 200 without token
- [ ] Tests use mock JWT tokens (not real Keycloak dependency)
- [ ] All auth scenarios across all controllers are covered
- [ ] Tests run in CI pipeline

## Files to Modify/Create
- `app/server/API.Tests/Authentication/JwtAuthenticationTests.cs`
- `app/server/API.Tests/Authentication/AuthorizationPolicyTests.cs`
- `app/server/API.Tests/Helpers/TestAuthHandler.cs`
- `app/server/API.Tests/Helpers/TokenHelper.cs`

## Dependencies
- Task 2001: JWT Token Validation Middleware
- Task 2003: Authorization Middleware
- Task 2004: Role-Based Authorization Attributes

## Implementation Steps
1. Create test authentication handler that generates mock JWT tokens
2. Create TokenHelper utility to generate tokens with specific claims and roles
3. Configure WebApplicationFactory to use test authentication scheme
4. Write tests for unauthenticated access (expect 401) on all protected endpoints
5. Write tests for wrong-role access (expect 403) on role-restricted endpoints
6. Write tests for valid-role access (expect 200) on each endpoint
7. Write tests for [AllowAnonymous] endpoints without any token
8. Write tests for expired token handling
9. Write tests for malformed token handling
10. Ensure all tests pass and add to CI pipeline

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
