# Task 201: Vehicle Service CRUD Verification

## Status: TODO
## Sprint: 3
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Verify all CRUD operations for the Vehicle entity work correctly. Ensure the BaseService generic implementation handles Vehicle operations properly end-to-end, including the UserId foreign key relationship.

## Acceptance Criteria
- [ ] GET /api/Vehicles returns 200 with paginated list
- [ ] GET /api/Vehicles/{id} returns 200 with vehicle details
- [ ] POST /api/Vehicles creates vehicle and returns 201
- [ ] PUT /api/Vehicles/{id} updates vehicle and returns 200
- [ ] DELETE /api/Vehicles/{id} soft-deletes and returns 204
- [ ] Pagination parameters (skip/take) work correctly
- [ ] Soft-deleted vehicles excluded from GET queries
- [ ] UserId foreign key validated against existing users

## Files to Modify/Create
- `app/server/API/Controllers/VehiclesController.cs`
- `app/server/Application/Services/Core/VehicleService.cs`
- `app/server/Application/Services/Core/IVehicleService.cs`

## Dependencies
- Task 003: Database Schema Alignment (COMPLETED)
- Task 101: User Service CRUD Verification

## Implementation Steps
1. Run API and test GET /api/Vehicles with empty database
2. Create a User first (dependency for UserId FK)
3. Test POST with valid vehicle data including all fields (Brand, Model, Year, VehicleType, FuelType, Color, MileageKm, LicensePlate, City, UserId)
4. Test GET by ID for created vehicle
5. Test PUT with updated fields
6. Test DELETE and verify soft-delete behavior
7. Test pagination with multiple records
8. Test with invalid UserId to verify FK constraint

## Completion Checklist
- [ ] All CRUD endpoints return correct status codes
- [ ] Build passes
- [ ] Tested manually via curl/Scalar
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
