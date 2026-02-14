# Task 2002: Keycloak Integration Middleware

## Status: TODO
## Sprint: 6
## Priority: HIGH
## Estimated Effort: LARGE

## Description
Connect the API to Keycloak for user authentication, configuring the realm, client, login flow, and token issuance. This establishes Keycloak as the identity provider for the entire application.

## Acceptance Criteria
- [ ] Keycloak realm is configured and accessible from the API
- [ ] API client is registered in Keycloak with correct redirect URIs
- [ ] Login flow issues valid access and refresh tokens
- [ ] Token refresh mechanism is functional
- [ ] Keycloak connection settings are environment-configurable
- [ ] Docker compose includes properly configured Keycloak service
- [ ] Realm roles are defined (admin, user, viewer)

## Files to Modify/Create
- `app/server/API/Program.cs`
- `app/server/API/appsettings.json`
- `app/server/API/appsettings.Development.json`
- `docker-compose.yml`

## Dependencies
- Task 002: Keycloak Realm Setup

## Implementation Steps
1. Verify Keycloak service is running and accessible in Docker compose
2. Configure Keycloak realm with required roles (admin, user, viewer)
3. Create API client in Keycloak with appropriate grant types
4. Configure client scopes and mappers for role claims
5. Add Keycloak connection configuration to appsettings
6. Implement OpenID Connect discovery for automatic endpoint resolution
7. Test login flow and verify token contents include expected claims
8. Verify token refresh works correctly
9. Document realm and client configuration for team reference

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
