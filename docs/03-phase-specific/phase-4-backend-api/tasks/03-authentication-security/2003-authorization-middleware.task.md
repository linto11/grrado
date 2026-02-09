# Task 2003: Authorization Middleware

## Status: TODO
## Sprint: 6
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Implement the authorization pipeline with policy-based authorization, defining policies that map to Keycloak roles and configuring the middleware to enforce access control across API endpoints.

## Acceptance Criteria
- [ ] Authorization middleware is registered in the pipeline
- [ ] Policies are defined for each role (Admin, User, Viewer)
- [ ] Policy requirements map correctly to Keycloak role claims
- [ ] Unauthenticated requests to protected endpoints return 401
- [ ] Authenticated requests without required role return 403
- [ ] Default policy requires authenticated user
- [ ] Fallback policy is configured appropriately

## Files to Modify/Create
- `app/server/API/Program.cs`

## Dependencies
- Task 2001: JWT Token Validation Middleware
- Task 2002: Keycloak Integration Middleware

## Implementation Steps
1. Configure AddAuthorization in Program.cs with policy definitions
2. Define "AdminPolicy" requiring Admin role claim
3. Define "UserPolicy" requiring User role claim
4. Define "ViewerPolicy" requiring Viewer role claim
5. Set default authorization policy to require authenticated users
6. Configure role claim type to match Keycloak token structure
7. Ensure app.UseAuthorization() is placed after app.UseAuthentication()
8. Test policy enforcement with tokens containing different roles

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
