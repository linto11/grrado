# Task 2006: CORS Policy Configuration

## Status: TODO
## Sprint: 6
## Priority: MEDIUM
## Estimated Effort: SMALL

## Description
Tighten the CORS policy from AllowAll to specific allowed origins. Development environment allows localhost origins while production restricts to specific domains only.

## Acceptance Criteria
- [ ] CORS policy no longer uses AllowAll in any environment
- [ ] Development allows localhost origins (ports 3000, 5173, etc.)
- [ ] Production restricts to specific configured domains
- [ ] Allowed methods are limited to GET, POST, PUT, DELETE, OPTIONS
- [ ] Allowed headers include Authorization, Content-Type, and required custom headers
- [ ] Credentials are allowed for authenticated requests
- [ ] CORS origins are configurable via appsettings per environment

## Files to Modify/Create
- `app/server/API/Program.cs`
- `app/server/API/appsettings.json`
- `app/server/API/appsettings.Development.json`

## Dependencies
- None

## Implementation Steps
1. Add CORS configuration section to appsettings with allowed origins array
2. Add development-specific origins to appsettings.Development.json
3. Replace AllowAll CORS policy in Program.cs with named policy
4. Configure WithOrigins using values from configuration
5. Set WithMethods to restrict allowed HTTP methods
6. Set WithHeaders to restrict allowed headers
7. Enable AllowCredentials for authenticated cross-origin requests
8. Test CORS headers in browser dev tools from allowed and disallowed origins

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
