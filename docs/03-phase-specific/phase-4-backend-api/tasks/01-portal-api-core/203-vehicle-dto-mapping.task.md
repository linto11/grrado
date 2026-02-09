# Task 203: Vehicle DTO Mapping Verification

## Status: TODO
## Sprint: 3
## Priority: MEDIUM
## Estimated Effort: SMALL

## Description
Verify AutoMapper profiles correctly map all Vehicle entity fields to DTOs and vice versa. Ensure all Vehicle-specific fields (Brand, Model, Year, VehicleType, FuelType, Color, MileageKm, LicensePlate, City, UserId) are mapped correctly.

## Acceptance Criteria
- [ ] All Vehicle entity fields mapped to VehicleDto
- [ ] CreateVehicleRequest maps correctly to Vehicle entity
- [ ] UpdateVehicleRequest maps correctly to Vehicle entity
- [ ] Null/optional fields handled gracefully
- [ ] Audit fields (CreatedAt, UpdatedAt) mapped correctly
- [ ] UserId foreign key mapped properly
- [ ] Enum fields (VehicleType, FuelType) mapped correctly

## Files to Modify/Create
- `app/server/Application/Mappings/VehicleMappingProfile.cs`

## Dependencies
- Task 201: Vehicle Service CRUD Verification

## Implementation Steps
1. Review existing mapping profile
2. Test mapping with full and partial data
3. Verify all Vehicle-specific fields map correctly
4. Verify audit field mapping behavior
5. Fix any unmapped or incorrectly mapped fields

## Completion Checklist
- [ ] All fields mapped correctly
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
