# Task 2202: Timezone Service Verification

## Status: TODO
## Sprint: 7
## Priority: LOW
## Estimated Effort: SMALL

## Description
Verify that all timestamps in the application are stored as UTC and implement a timezone conversion utility for displaying localized times to users when needed.

## Acceptance Criteria
- [ ] All database timestamps are stored in UTC
- [ ] DateTime.UtcNow is used instead of DateTime.Now throughout the codebase
- [ ] Timezone conversion utility converts UTC to specified timezone
- [ ] API responses include UTC timestamps with proper ISO 8601 format
- [ ] CreatedAt and UpdatedAt fields use UTC consistently
- [ ] JSON serialization formats dates in ISO 8601 with Z suffix
- [ ] No timezone-related bugs exist in existing code

## Files to Modify/Create
- `app/server/API/Services/TimezoneService.cs`
- `app/server/API/Interfaces/ITimezoneService.cs`
- `app/server/API/Program.cs`

## Dependencies
- None

## Implementation Steps
1. Audit codebase for any usage of DateTime.Now and replace with DateTime.UtcNow
2. Audit database column types to ensure timestamp with time zone is used
3. Create ITimezoneService interface with ConvertFromUtc and ConvertToUtc methods
4. Implement TimezoneService using TimeZoneInfo for conversions
5. Configure JSON serializer to output ISO 8601 format with UTC indicator
6. Verify CreatedAt/UpdatedAt fields in entity base classes use UTC
7. Register ITimezoneService in DI container
8. Test timezone conversion with various timezones
9. Verify API response date formats are consistent

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
