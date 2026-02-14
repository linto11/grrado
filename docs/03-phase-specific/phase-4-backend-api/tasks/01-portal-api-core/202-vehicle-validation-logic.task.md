# Task 202: Vehicle Validation Logic

## Status: TODO
## Sprint: 3
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Implement FluentValidation rules for Vehicle create and update requests. Ensure invalid data is rejected with clear 400 error responses. Validate all Vehicle-specific fields including Brand, Model, Year, VehicleType, FuelType, Color, MileageKm, LicensePlate, City, and UserId.

## Acceptance Criteria
- [ ] Brand required, max 100 characters
- [ ] Model required, max 100 characters
- [ ] Year validated (reasonable range, e.g., 1900 to current year + 1)
- [ ] VehicleType validated against allowed values
- [ ] FuelType validated against allowed values
- [ ] Color max 50 characters when provided
- [ ] MileageKm must be non-negative when provided
- [ ] LicensePlate format validated, unique constraint checked
- [ ] City max 100 characters when provided
- [ ] UserId required and must reference existing user
- [ ] Invalid requests return 400 with validation details
- [ ] Validation error response follows consistent format

## Files to Modify/Create
- `app/server/Application/Validators/CreateVehicleRequestValidator.cs`
- `app/server/Application/Validators/UpdateVehicleRequestValidator.cs`

## Dependencies
- Task 201: Vehicle Service CRUD Verification

## Implementation Steps
1. Create CreateVehicleRequestValidator with FluentValidation rules
2. Create UpdateVehicleRequestValidator with FluentValidation rules
3. Add rules for all Vehicle-specific fields
4. Verify validators auto-discovered by assembly scanning in DI
5. Test with invalid payloads and verify 400 responses

## Completion Checklist
- [ ] Validators created and registered
- [ ] Build passes
- [ ] Invalid requests return proper 400 responses
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
