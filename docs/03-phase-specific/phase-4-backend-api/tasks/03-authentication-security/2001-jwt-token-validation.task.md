# Task 2001: JWT Token Validation Middleware

## Status: TODO
## Sprint: 6
## Priority: HIGH
## Estimated Effort: LARGE

## Description
Configure JWT Bearer authentication to validate Keycloak-issued tokens in the API pipeline. The middleware must validate token signatures, check expiry, verify issuer/audience claims, and return 401 Unauthorized for invalid or missing tokens.

## Acceptance Criteria
- [ ] JWT Bearer authentication is configured in Program.cs
- [ ] Token signature validation uses Keycloak's public key/JWKS endpoint
- [ ] Expired tokens are rejected with 401
- [ ] Missing tokens on protected endpoints return 401
- [ ] Invalid/malformed tokens return 401
- [ ] Issuer and audience claims are validated against configuration
- [ ] Token validation parameters are configurable via appsettings

## Files to Modify/Create
- `app/server/API/Program.cs`
- `app/server/API/appsettings.json`
- `app/server/API/appsettings.Development.json`

## Dependencies
- Keycloak realm must be configured (Task 002)
- Microsoft.AspNetCore.Authentication.JwtBearer NuGet package

## Implementation Steps
1. Add Microsoft.AspNetCore.Authentication.JwtBearer NuGet package if not already present
2. Add Keycloak JWT configuration section to appsettings (Authority, Audience, Issuer)
3. Configure authentication services in Program.cs with AddAuthentication and AddJwtBearer
4. Set TokenValidationParameters (ValidateIssuer, ValidateAudience, ValidateLifetime, ValidateIssuerSigningKey)
5. Point JWKS URI to Keycloak's well-known endpoint
6. Add app.UseAuthentication() in the middleware pipeline before UseAuthorization
7. Test with valid Keycloak token to confirm 200 response
8. Test with expired/invalid/missing token to confirm 401 response

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
