# Task 2301: Integration Test Suite

## Status: TODO
## Sprint: 8
## Priority: HIGH
## Estimated Effort: LARGE

## Description
Set up a comprehensive integration test suite using WebApplicationFactory, covering all CRUD endpoints for all entities with authentication and error scenario testing to ensure the API behaves correctly end-to-end.

## Acceptance Criteria
- [ ] Test project is configured with WebApplicationFactory
- [ ] All entity controllers have CRUD endpoint tests (Create, Read, Update, Delete)
- [ ] Tests cover successful operations (200/201 responses)
- [ ] Tests cover validation errors (400 responses)
- [ ] Tests cover not found scenarios (404 responses)
- [ ] Tests cover authentication failures (401 responses)
- [ ] Tests cover authorization failures (403 responses)
- [ ] Tests cover server error handling (500 responses)
- [ ] Test database is isolated per test run (in-memory or test container)
- [ ] Tests are repeatable and independent of each other

## Files to Modify/Create
- `app/server/API.Tests/IntegrationTests/CustomWebApplicationFactory.cs`
- `app/server/API.Tests/IntegrationTests/Controllers/*ControllerTests.cs`
- `app/server/API.Tests/IntegrationTests/Helpers/TestDataSeeder.cs`
- `app/server/API.Tests/API.Tests.csproj`

## Dependencies
- All entity controllers must be implemented
- Authentication middleware must be configured
- Authorization policies must be defined

## Implementation Steps
1. Create or update test project with required NuGet packages (Microsoft.AspNetCore.Mvc.Testing, xUnit)
2. Implement CustomWebApplicationFactory with test database configuration
3. Configure test authentication handler to bypass real Keycloak
4. Create TestDataSeeder to populate test database with known data
5. Implement base test class with common setup and helper methods
6. Write CRUD tests for each entity controller (minimum 5 tests per controller)
7. Write tests for validation error scenarios (invalid input, missing required fields)
8. Write tests for not found scenarios (non-existent IDs)
9. Write tests for auth scenarios (no token, wrong role)
10. Write tests for error handling (trigger exceptions, verify error response format)
11. Ensure test isolation (each test gets clean database state)
12. Run full test suite and verify all tests pass

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
