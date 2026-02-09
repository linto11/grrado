# Task 2203: Error Message Service with Redis

## Status: TODO
## Sprint: 7
## Priority: MEDIUM
## Estimated Effort: MEDIUM

## Description
Implement an error message service that caches error messages from the ErrorMessages database table in Redis, reducing database lookups for frequently accessed error codes and improving response times for error handling.

## Acceptance Criteria
- [ ] Error messages are loaded from the ErrorMessages database table
- [ ] Messages are cached in Redis with configurable TTL
- [ ] Cache is populated on first access (lazy loading)
- [ ] Cache can be manually invalidated/refreshed
- [ ] Service falls back to database if Redis is unavailable
- [ ] Error codes resolve to localized messages
- [ ] Service is registered in DI and injectable
- [ ] Cache miss triggers database lookup and cache population

## Files to Modify/Create
- `app/server/API/Services/ErrorMessageService.cs`
- `app/server/API/Interfaces/IErrorMessageService.cs`
- `app/server/API/Program.cs`

## Dependencies
- Task 2102: Redis Caching Integration

## Implementation Steps
1. Create IErrorMessageService interface with GetMessage(errorCode), RefreshCache methods
2. Implement ErrorMessageService injecting ICacheService and DbContext
3. On GetMessage: check Redis cache first, on miss query ErrorMessages table
4. Cache individual messages with key pattern "error:messages:{code}"
5. Implement bulk cache population for warming (load all messages at once)
6. Add cache refresh endpoint or method for admin use
7. Implement fallback: if Redis unavailable, query database directly
8. Set configurable TTL for cached messages (default 1 hour)
9. Register IErrorMessageService in DI container
10. Integrate with ExceptionHandlingMiddleware for error response messages
11. Test cache hit, cache miss, cache expiry, and Redis-down scenarios

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
