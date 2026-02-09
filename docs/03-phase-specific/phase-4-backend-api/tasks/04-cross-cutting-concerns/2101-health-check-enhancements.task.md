# Task 2101: Health Check Enhancements

## Status: TODO
## Sprint: 7
## Priority: MEDIUM
## Estimated Effort: MEDIUM

## Description
Add comprehensive health checks for all infrastructure dependencies including database, Redis, and Keycloak. Expose /health for aggregate status, /health/ready for dependency readiness, and /health/live for simple liveness probes.

## Acceptance Criteria
- [ ] /health returns aggregate health status of all dependencies
- [ ] /health/ready checks database connectivity
- [ ] /health/ready checks Redis connectivity
- [ ] /health/ready checks Keycloak availability
- [ ] /health/live returns simple 200 for liveness probes
- [ ] Health check responses include detailed status per dependency
- [ ] Unhealthy dependencies return appropriate degraded/unhealthy status
- [ ] Health checks have configurable timeout thresholds

## Files to Modify/Create
- `app/server/API/Program.cs`
- `app/server/API/HealthChecks/RedisHealthCheck.cs`
- `app/server/API/HealthChecks/KeycloakHealthCheck.cs`

## Dependencies
- Database connection must be configured
- Redis must be available in Docker compose
- Keycloak must be available in Docker compose

## Implementation Steps
1. Add AspNetCore.HealthChecks.NpgSql NuGet package for PostgreSQL health checks
2. Create RedisHealthCheck implementing IHealthCheck to ping Redis
3. Create KeycloakHealthCheck implementing IHealthCheck to call Keycloak discovery endpoint
4. Register health checks in Program.cs with AddHealthChecks()
5. Map /health endpoint with aggregate status
6. Map /health/ready endpoint filtering to readiness checks (DB, Redis, Keycloak)
7. Map /health/live endpoint with simple liveness response
8. Configure health check response writer to output JSON with dependency details
9. Set timeout thresholds for each health check
10. Test with dependencies up and down to verify correct status reporting

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
