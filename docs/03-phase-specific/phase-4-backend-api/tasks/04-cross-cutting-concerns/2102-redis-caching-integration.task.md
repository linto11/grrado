# Task 2102: Redis Caching Integration

## Status: TODO
## Sprint: 7
## Priority: HIGH
## Estimated Effort: LARGE

## Description
Implement distributed caching with Redis using the cache-aside pattern. Provide a caching service with configurable TTL that is registered in DI and can be consumed by any service or controller in the application.

## Acceptance Criteria
- [ ] Redis connection is configured and registered in DI
- [ ] ICacheService interface is defined with Get, Set, Remove, and Exists methods
- [ ] RedisCacheService implements ICacheService with cache-aside pattern
- [ ] TTL is configurable per cache entry and has a sensible default
- [ ] Cache keys follow a consistent naming convention
- [ ] Serialization/deserialization handles complex objects (JSON)
- [ ] Cache failures are handled gracefully (fallback to DB, not crash)
- [ ] Redis connection string is environment-configurable

## Files to Modify/Create
- `app/server/API/Interfaces/ICacheService.cs`
- `app/server/API/Services/RedisCacheService.cs`
- `app/server/API/Program.cs`
- `app/server/API/appsettings.json`
- `app/server/API/appsettings.Development.json`

## Dependencies
- Redis service must be running in Docker compose

## Implementation Steps
1. Add StackExchange.Redis NuGet package
2. Add Microsoft.Extensions.Caching.StackExchangeRedis NuGet package
3. Add Redis connection string to appsettings configuration
4. Create ICacheService interface with generic Get<T>, Set<T>, Remove, Exists methods
5. Implement RedisCacheService using IDistributedCache or IConnectionMultiplexer
6. Implement cache-aside pattern: check cache, miss goes to source, populate cache
7. Add configurable TTL with default value from configuration
8. Implement JSON serialization for complex object caching
9. Add try-catch around cache operations to handle Redis unavailability gracefully
10. Register ICacheService as singleton in DI container
11. Test caching with sample data, verify TTL expiry, and test Redis-down scenario

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
