# Task 2106: Global Exception Handling Refinement

## Status: TODO
## Sprint: 7
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Refine the global exception handling middleware to produce consistent error JSON responses, use error codes sourced from the ErrorMessages database table, include stack traces only in development, and attach correlation IDs for request tracing.

## Acceptance Criteria
- [ ] All exceptions produce a consistent JSON error response format
- [ ] Error response includes: errorCode, message, correlationId, timestamp
- [ ] Error codes are sourced from the ErrorMessages database table
- [ ] Stack traces are included only in Development environment
- [ ] Correlation ID is generated per request and included in error responses
- [ ] Correlation ID is also returned in response headers (X-Correlation-ID)
- [ ] Different exception types map to appropriate HTTP status codes
- [ ] Validation exceptions return 400 with field-level error details
- [ ] Unhandled exceptions return 500 with generic user-facing message

## Files to Modify/Create
- `app/server/API/Middleware/ExceptionHandlingMiddleware.cs`
- `app/server/API/Models/ErrorResponse.cs`
- `app/server/API/Program.cs`

## Dependencies
- ErrorMessages table must exist in database
- ExceptionHandlingMiddleware must already exist (refine existing)

## Implementation Steps
1. Define ErrorResponse model with ErrorCode, Message, CorrelationId, Timestamp, Details properties
2. Generate or extract correlation ID at start of each request (use X-Correlation-ID header if provided)
3. Refine ExceptionHandlingMiddleware to catch all exception types
4. Map specific exception types to HTTP status codes (ArgumentException->400, UnauthorizedAccessException->401, KeyNotFoundException->404, etc.)
5. Look up error codes and messages from ErrorMessages table/cache
6. Include stack trace in response only when IHostEnvironment.IsDevelopment()
7. Set X-Correlation-ID response header on all responses
8. Log exceptions with correlation ID for traceability
9. Return consistent JSON format for all error responses
10. Test with various exception types and verify response format

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
