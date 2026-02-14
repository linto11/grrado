# Task 805: Portal Global Query Filters

## Status: TODO
## Sprint: 4
## Priority: HIGH
## Estimated Effort: LARGE

## Description
Implement EF Core global query filters for soft delete (IsDeleted==false) and standardize pagination across all portal API endpoints to ensure consistent data access patterns.

## Acceptance Criteria
- [ ] Soft-deleted records are excluded by default from all queries via EF Core global query filters
- [ ] Pagination is consistent across all endpoints with standardized page size, page number, and total count response
- [ ] Global query filter can be overridden when needed (e.g., admin viewing deleted records via IgnoreQueryFilters)
- [ ] All existing endpoints continue to function correctly with the new filters applied
- [ ] Pagination metadata is included in response headers or response body consistently

## Files to Modify/Create
- `app/server/API/Data/VehicleServiceDbContext.cs`
- `app/server/API/Services/BaseService.cs`

## Dependencies
- Task 003: Database Schema Alignment (COMPLETED)

## Implementation Steps
1. Add global query filter in VehicleServiceDbContext OnModelCreating for all entities with IsDeleted property
2. Create a standardized pagination request model (PageNumber, PageSize, SortBy, SortDirection)
3. Implement pagination logic in BaseService as a reusable method for all derived services
4. Update all existing service methods to use the standardized pagination
5. Add IgnoreQueryFilters option for administrative queries that need to include soft-deleted records
6. Test that soft-deleted records are excluded by default and pagination works consistently

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
