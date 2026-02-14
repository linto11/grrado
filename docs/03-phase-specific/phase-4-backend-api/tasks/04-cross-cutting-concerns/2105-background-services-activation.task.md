# Task 2105: Background Services Activation

## Status: TODO
## Sprint: 7
## Priority: LOW
## Estimated Effort: MEDIUM

## Description
Implement background hosted services for periodic cleanup of old logs and stale data. Services run on configurable intervals and handle cleanup of RequestResponseLogs and other time-sensitive data.

## Acceptance Criteria
- [ ] Background service is implemented using IHostedService/BackgroundService
- [ ] Old RequestResponseLogs entries are cleaned up based on configurable retention period
- [ ] Cleanup interval is configurable via appsettings
- [ ] Retention period is configurable (e.g., 30 days default)
- [ ] Service logs cleanup actions (count of records deleted)
- [ ] Service handles errors gracefully without crashing the application
- [ ] Service respects cancellation token for graceful shutdown

## Files to Modify/Create
- `app/server/API/BackgroundServices/LogCleanupService.cs`
- `app/server/API/Program.cs`
- `app/server/API/appsettings.json`

## Dependencies
- RequestResponseLogs table must exist in database

## Implementation Steps
1. Create LogCleanupService extending BackgroundService
2. Inject IServiceScopeFactory for scoped DbContext access
3. Add configuration section for cleanup settings (IntervalMinutes, RetentionDays)
4. Implement ExecuteAsync with periodic timer using PeriodicTimer or Task.Delay
5. In each cycle, delete RequestResponseLogs older than retention period
6. Log the number of records cleaned up in each cycle
7. Wrap cleanup logic in try-catch to prevent service crash on errors
8. Respect CancellationToken for graceful shutdown
9. Register service in Program.cs with AddHostedService
10. Test by inserting old records and verifying they are cleaned up

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
