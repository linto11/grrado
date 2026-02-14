# Task 2103: Rate Limiting Middleware

## Status: TODO
## Sprint: 7
## Priority: MEDIUM
## Estimated Effort: MEDIUM

## Description
Implement fixed window rate limiting middleware with per-endpoint configuration. When the rate limit is exceeded, the API returns 429 Too Many Requests with appropriate Retry-After headers.

## Acceptance Criteria
- [ ] Rate limiting middleware is registered in the pipeline
- [ ] Fixed window rate limiting algorithm is implemented
- [ ] Rate limits are configurable per endpoint or globally
- [ ] Exceeded rate limit returns 429 Too Many Requests
- [ ] Response includes Retry-After header with wait time
- [ ] Response includes X-RateLimit-Limit and X-RateLimit-Remaining headers
- [ ] Rate limiting configuration is stored in appsettings
- [ ] Health check and public endpoints are excluded from rate limiting

## Files to Modify/Create
- `app/server/API/Program.cs`
- `app/server/API/appsettings.json`

## Dependencies
- None

## Implementation Steps
1. Add Microsoft.AspNetCore.RateLimiting reference (built-in .NET 7+)
2. Configure rate limiting services in Program.cs with AddRateLimiter
3. Define fixed window rate limiter with configurable window size and permit limit
4. Add rate limit configuration section to appsettings (Window, PermitLimit, QueueLimit)
5. Configure per-endpoint rate limiting policies for different endpoint groups
6. Set rejection status code to 429 with Retry-After header
7. Exclude health check endpoints from rate limiting
8. Add app.UseRateLimiter() in the middleware pipeline
9. Apply rate limiting policies to controllers via [EnableRateLimiting] attribute
10. Test by sending requests exceeding the limit and verifying 429 response

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
