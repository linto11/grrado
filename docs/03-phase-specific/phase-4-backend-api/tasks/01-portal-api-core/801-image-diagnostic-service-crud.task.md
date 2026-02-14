# Task 801: Image Diagnostic Service CRUD Operations

## Status: TODO
## Sprint: 4
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Verify and implement CRUD operations for the ImageDiagnostic entity, ensuring all fields are properly handled through the service layer with correct database persistence.

## Acceptance Criteria
- [ ] ImageDiagnostic entity has all required fields mapped to the database schema
- [ ] Create operation persists all ImageDiagnostic fields correctly to the database
- [ ] Read operations retrieve single and multiple ImageDiagnostic records with all fields populated
- [ ] Update operation modifies ImageDiagnostic fields and persists changes
- [ ] Delete operation performs soft delete on ImageDiagnostic records

## Files to Modify/Create
- `app/server/API/Models/ImageDiagnostic.cs`
- `app/server/API/Services/ImageDiagnosticService.cs`
- `app/server/API/Controllers/ImageDiagnosticController.cs`
- `app/server/API/Repositories/IImageDiagnosticRepository.cs`

## Dependencies
- Task 003: Database Schema Alignment (COMPLETED)

## Implementation Steps
1. Review the ImageDiagnostic entity model and confirm all required columns exist in the database
2. Implement or verify the service layer with Create, Read, Update, and Delete methods
3. Ensure the repository layer correctly queries and persists ImageDiagnostic records
4. Wire up the controller endpoints to the service layer
5. Test each CRUD operation against the database

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
