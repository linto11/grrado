# Task 701: Diagnostic Rule Service CRUD Operations

## Status: TODO
## Sprint: 4
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Verify and implement CRUD operations for the DiagnosticRule entity, ensuring all fields (RuleCode, RuleDescription, Symptoms, RecommendedActions, ApplicableModels, SeverityLevel) are properly handled through the service layer.

## Acceptance Criteria
- [ ] DiagnosticRule entity has all required fields: RuleCode, RuleDescription, Symptoms, RecommendedActions, ApplicableModels, SeverityLevel
- [ ] Create operation persists all DiagnosticRule fields correctly to the database
- [ ] Read operations retrieve single and multiple DiagnosticRule records with all fields populated
- [ ] Update operation modifies DiagnosticRule fields and persists changes
- [ ] Delete operation performs soft delete on DiagnosticRule records

## Files to Modify/Create
- `app/server/API/Models/DiagnosticRule.cs`
- `app/server/API/Services/DiagnosticRuleService.cs`
- `app/server/API/Controllers/DiagnosticRuleController.cs`
- `app/server/API/Repositories/IDiagnosticRuleRepository.cs`

## Dependencies
- Task 003: Database Schema Alignment (COMPLETED)

## Implementation Steps
1. Review the DiagnosticRule entity model and confirm all required columns exist in the database
2. Implement or verify the service layer with Create, Read, Update, and Delete methods
3. Ensure the repository layer correctly queries and persists DiagnosticRule records
4. Wire up the controller endpoints to the service layer
5. Test each CRUD operation against the database

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
