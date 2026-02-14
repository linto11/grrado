# Task 917: AI Usage Log CRUD Operations

## Status: TODO
## Sprint: 5
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Implement full CRUD operations for the AiUsageLog entity. This entity tracks all AI service usage for monitoring, billing, and analytics purposes, including token consumption, costs, request durations, and correlation identifiers for tracing requests across services.

## Acceptance Criteria
- [ ] AiUsageLog entity is properly defined with all required fields (UserId, ServiceName, ApiEndpoint, InputTokens, OutputTokens, TotalTokens, Model, RequestDurationMs, CostUsd, IsSuccessful, ErrorMessage, SessionId, CorrelationId)
- [ ] Repository interface and implementation follow existing patterns
- [ ] CREATE operation persists a new usage log entry with all required fields
- [ ] READ operation retrieves logs by ID, by UserId, by SessionId, by CorrelationId, and supports pagination with date range filters
- [ ] UPDATE operation is limited (logs are mostly immutable, but allow error correction)
- [ ] DELETE operation removes a log entry (admin only)
- [ ] All operations return appropriate HTTP status codes
- [ ] Controller endpoints are properly routed and documented

## Files to Modify/Create
- `app/server/Domain/Entities/AiUsageLog.cs`
- `app/server/Application/Interfaces/IAiUsageLogRepository.cs`
- `app/server/Infrastructure/Repositories/AiUsageLogRepository.cs`
- `app/server/API/Controllers/AiUsageLogController.cs`
- `app/server/Infrastructure/Data/Configurations/AiUsageLogConfiguration.cs`

## Dependencies
- Database schema with AiUsageLog table
- Base entity/repository patterns established in prior tasks
- Authentication middleware for UserId resolution

## Implementation Steps
1. Define the AiUsageLog entity class with all properties
2. Create the EF Core entity configuration with proper column types and constraints
3. Define the repository interface with CRUD method signatures including filtering by date range, UserId, SessionId, CorrelationId
4. Implement the repository with EF Core queries supporting aggregation queries (total tokens, total cost)
5. Create the controller with GET, POST, PUT, DELETE endpoints
6. Add summary/aggregation endpoint for usage statistics
7. Register the repository in DI container
8. Run database migration or Liquibase changelog if needed
9. Test all endpoints manually via Scalar or Postman

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
