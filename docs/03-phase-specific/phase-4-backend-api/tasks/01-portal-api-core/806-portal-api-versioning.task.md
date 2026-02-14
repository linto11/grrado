# Task 806: Portal API Versioning

## Status: TODO
## Sprint: 4
## Priority: MEDIUM
## Estimated Effort: MEDIUM

## Description
Implement API versioning using Asp.Versioning.Http to support multiple API versions, enabling backward-compatible evolution of the portal API surface.

## Acceptance Criteria
- [ ] v1 routes work correctly for all existing endpoints (e.g., /api/v1/vehicles)
- [ ] API version can be specified via URL path segment and version request header
- [ ] Scalar documentation shows version information for each endpoint
- [ ] Default version is set to v1 when no version is specified
- [ ] Unsupported version requests return appropriate error responses

## Files to Modify/Create
- `app/server/API/Program.cs`
- `app/server/API/Controllers/VehicleController.cs`
- `app/server/API/Controllers/ServiceHistoryController.cs`
- `app/server/API/Controllers/DiagnosticRuleController.cs`
- `app/server/API/Controllers/ImageDiagnosticController.cs`

## Dependencies
- Task 003: Database Schema Alignment (COMPLETED)

## Implementation Steps
1. Install the Asp.Versioning.Http and Asp.Versioning.Mvc.ApiExplorer NuGet packages
2. Configure API versioning in Program.cs with default version and version reading strategies
3. Add ApiVersion attributes to all controllers specifying supported versions
4. Update route templates to include version segment (e.g., api/v{version:apiVersion}/[controller])
5. Configure Scalar/OpenAPI to display version information
6. Test that v1 routes work and unversioned routes default correctly

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
