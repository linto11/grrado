# Task 2104: Request/Response Logging Activation

## Status: TODO
## Sprint: 7
## Priority: MEDIUM
## Estimated Effort: MEDIUM

## Description
Activate the existing RequestResponseLoggingMiddleware, configure it to persist request/response data to the RequestResponseLogs database table, and ensure sensitive data such as passwords and tokens are masked in logs.

## Acceptance Criteria
- [ ] RequestResponseLoggingMiddleware is activated in the pipeline
- [ ] Request details (method, path, headers, body) are logged
- [ ] Response details (status code, headers, body) are logged
- [ ] Logs are persisted to the RequestResponseLogs database table
- [ ] Sensitive data (Authorization headers, passwords, tokens) is masked
- [ ] Large request/response bodies are truncated to configurable max length
- [ ] Logging is configurable (enable/disable, max body size)
- [ ] Health check endpoints are excluded from logging

## Files to Modify/Create
- `app/server/API/Program.cs`
- `app/server/API/Middleware/RequestResponseLoggingMiddleware.cs`
- `app/server/API/appsettings.json`

## Dependencies
- RequestResponseLogs table must exist in database
- RequestResponseLoggingMiddleware must be implemented (already exists)

## Implementation Steps
1. Review existing RequestResponseLoggingMiddleware implementation
2. Add configuration section for request/response logging (enabled, maxBodyLength, excludedPaths)
3. Implement sensitive data masking for Authorization headers, password fields, token values
4. Add body truncation for requests/responses exceeding configured max length
5. Implement database persistence to RequestResponseLogs table
6. Add path exclusion filter for health check and other noisy endpoints
7. Register middleware in Program.cs pipeline at appropriate position
8. Configure logging settings in appsettings.json
9. Test logging by making API calls and verifying database records
10. Verify sensitive data is properly masked in stored logs

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
