# Task 2007: API Key Validation

## Status: TODO
## Sprint: 6
## Priority: LOW
## Estimated Effort: MEDIUM

## Description
Implement optional API key authentication for service-to-service calls, allowing internal services to authenticate without user tokens using a shared API key passed via request headers.

## Acceptance Criteria
- [ ] API key validation middleware is implemented
- [ ] API key is read from a configurable header (e.g., X-API-Key)
- [ ] Valid API keys are stored securely in configuration
- [ ] Invalid or missing API key returns 401 on key-protected endpoints
- [ ] API key auth works alongside JWT auth (dual auth scheme)
- [ ] API keys can be rotated without code changes
- [ ] Service-to-service endpoints are identified and protected

## Files to Modify/Create
- `app/server/API/Authentication/ApiKeyAuthenticationHandler.cs`
- `app/server/API/Program.cs`
- `app/server/API/appsettings.json`

## Dependencies
- Task 2001: JWT Token Validation Middleware

## Implementation Steps
1. Create ApiKeyAuthenticationHandler extending AuthenticationHandler
2. Read expected API key from IConfiguration
3. Extract API key from X-API-Key request header
4. Compare provided key against configured key securely (constant-time comparison)
5. Return AuthenticateResult.Success or AuthenticateResult.Fail accordingly
6. Register API key authentication scheme in Program.cs
7. Configure dual authentication (JWT + API Key) using policy schemes
8. Apply API key auth to service-to-service endpoints
9. Add API key configuration to appsettings (use secrets in production)
10. Test with valid and invalid API keys

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
