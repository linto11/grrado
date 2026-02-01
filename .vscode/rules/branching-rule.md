# Git Branching Rules & Workflow

**Last Updated:** February 1, 2026  
**Version:** 1.0  

---

## 📋 Branching Strategy Overview

This document defines the branching conventions for GRRADO project to ensure consistent, traceable, and organized development workflow.

---

## 🎯 Branch Naming Conventions

### Rule 1: New Feature Branch Naming

For completely new features or tasks within a phase:

```
feature/<phase-number>-<feature-name>
```

**Examples:**
- `feature/4-user-controller`
- `feature/4-keycloak-integration`
- `feature/5-rbac-implementation`
- `feature/6-cms-platform`

**Requirements:**
- Phase number: Use existing phase number (1-12)
- Feature name: Lowercase, hyphens instead of spaces
- No special characters except hyphens
- Keep under 50 characters total

---

### Rule 2: Change-to-Completed-Feature Branch Naming

When making changes to an already-completed feature or task:

```
feature/<phase-number>-<feature-name>/<change-type>
```

**Examples:**
- `feature/4-user-controller/fix-validation`
- `feature/4-keycloak-integration/update-realm-config`
- `feature/5-rbac-implementation/add-superadmin-role`
- `feature/3-database/add-indexes`

**Requirements:**
- Use same base feature name as original feature
- Add slash (/) followed by change type
- Change type: Describe what's being fixed/updated
- Format: lowercase, hyphens instead of spaces

**Valid Change Types:**
- `fix-<issue-name>` — Bug fix
- `update-<component>` — Update existing functionality
- `add-<feature>` — Add new capability to existing feature
- `refactor-<component>` — Code refactoring
- `docs-<topic>` — Documentation updates
- `optimize-<area>` — Performance optimization

---

### Rule 3: Hotfix Branch Naming (Production Issues)

For critical production issues:

```
hotfix/<issue-number>-<description>
```

**Example:**
- `hotfix/001-database-connection-crash`

---

### Rule 4: Bugfix Branch Naming (Development Issues)

For bugs found during development:

```
bugfix/<phase-number>-<component>/<issue-description>
```

**Example:**
- `bugfix/4-user-controller/null-reference-exception`

---

## ⚠️ MANDATORY FILE NAMING VALIDATION (AI & Developer)

**This rule exists to prevent the exact mistake that was made on 2026-02-01.**

### Before Creating ANY File:

1. **Filename Check:** Does your filename contain ANY uppercase letters?
   - ❌ YES → STOP. Rename to lowercase. Use hyphens only.
   - ✅ NO → Continue

2. **Validation Pattern:** Filename must match:
   ```regex
   ^[a-z0-9]+(-[a-z0-9]+)*\.[a-z0-9]+$
   ```
   - ✅ Valid: `user-service.cs`, `implementation-complete.md`, `quick-start.md`
   - ❌ Invalid: `UserService.cs`, `IMPLEMENTATION-COMPLETE.md`, `QuickStart.md`

3. **AI Self-Check Before File Creation:**
   ```
   PSEUDO-CODE FOR AI:
   
   filename = "desired-filename.ext"
   
   if filename.contains(uppercase):
       return ERROR("Filename contains uppercase - VIOLATES kebab-case rule")
   
   if not matches_regex(filename, "^[a-z0-9]+(-[a-z0-9]+)*\.[a-z0-9]+$"):
       return ERROR("Filename format invalid - must be kebab-case")
   
   # If both checks pass, safe to create file
   create_file(filename)
   ```

4. **Common Mistakes to Avoid:**
   | ❌ WRONG | ✅ CORRECT | Reason |
   |----------|-----------|--------|
   | `UserController.cs` | `user-controller.cs` | No CamelCase |
   | `IMPLEMENTATION-COMPLETE.md` | `implementation-complete.md` | No UPPERCASE |
   | `quickStart.md` | `quick-start.md` | No camelCase |
   | `MyFile.TXT` | `my-file.txt` | Extension must be lowercase |
   | `file name.md` | `file-name.md` | Use hyphens, not spaces |

5. **Zero Tolerance Policy:**
   - This is not a warning
   - This is not a suggestion
   - This is a MANDATORY REQUIREMENT
   - Violations will be caught in pre-commit hooks and rejected

---

## 🔍 Pre-File-Creation Checklist

**Every developer AND AI must complete this before creating a file:**

```checklist
Before creating [filename]:

□ Does filename contain ONLY lowercase letters, numbers, and hyphens?
□ Does filename match pattern: ^[a-z0-9]+(-[a-z0-9]+)*\.[a-z0-9]+$ ?
□ Does filename have NO spaces?
□ Does filename extension match the file type?
□ Have I NOT used: PascalCase, camelCase, UPPERCASE, or underscore?

If ANY checkbox is unchecked → DO NOT CREATE FILE
Fix the filename first, THEN create the file.
```

---

### Step 1: Branch Creation (Before Starting Work)

**Command:**
```powershell
git checkout main
git pull origin main
git checkout -b feature/4-<feature-name>
```

**AI Requirement:** Before ANY file modification, ensure you are on a feature branch. If on `main` or `develop`, automatically create and switch to the appropriate feature branch.

---

### Step 2: Task Execution (10-Minute Tasks)

1. **Mark task as IN-PROGRESS** in task file status header
2. **Execute task** (implement code, tests, documentation)
3. **Test locally** (build, run, validate)
4. **Commit with semantic messages:**

   ```
   feat(phase4-user-controller): add POST endpoint for user creation

   - Implements /api/v1/users POST endpoint
   - Adds CreateUserDto validation
   - Integrates with UserService
   - Adds unit tests for validation
   
   Related-Task: 102
   Branch: feature/4-user-controller
   ```

   **Commit Format Requirements:**
   - Type: `feat`, `fix`, `docs`, `refactor`, `test`
   - Scope: `phase<N>-<domain>`
   - Subject: Concise description (50 chars max)
   - Body: Detailed description (optional)
   - Footer: Include `Related-Task: <NNN>` and `Branch: <branch-name>`

---

### Step 3: Task Status Update (Upon Completion)

**Mark task as COMPLETED:**

Update task file status to: ✅ COMPLETED

Required fields:
- Completion time
- Time spent
- Any blockers encountered

**Example from task file:**
```markdown
**Status:** ✅ COMPLETED

**Progress Notes:**
- **Started:** 2026-02-01 09:00 AM
- **Completed:** 2026-02-01 09:08 AM
- **Time Spent:** 8 minutes
- **Blockers:** None
```

---

### Step 4: Changelog Entry (Before Push)

Before pushing to remote, create a changelog entry:

**File Location:** `docs/06-changelogs/changelog.<date>.<sequence>.md`

**Format:**
```markdown
# Changelog - [Date]

**Branch:** feature/4-user-controller  
**Task(s):** 102  
**Completion Time:** [Date/Time]  

## Changes Made
- [Summary of changes]
- [Files modified]
- [Key functionality added]

## Validation
- ✅ Build successful (0 errors)
- ✅ Tests passing
- ✅ Local deployment verified

## Next Task
- [Next task number and name]
```

**AI Requirement:** Automatically create changelog entry before pushing any changes. Include branch name as part of changelog header.

---

### Step 5: Push & Pull Request (After Task Completion)

**Commands:**
```powershell
git add .
git commit -m "..."
git push origin feature/4-<feature-name>
```

**Create Pull Request:**
- Title: `[Phase 4] Task #102: User Controller - CRUD Operations`
- Description: Reference task file
- Link changelog entry
- Require 1 reviewer approval before merge

**PR Checklist:**
- [ ] Branch follows naming convention
- [ ] Changelog entry created
- [ ] All tasks marked as completed
- [ ] Build successful (0 errors, 0 warnings)
- [ ] Tests passing (if applicable)
- [ ] Code review approval received

---

### Step 6: Merge to Develop (After Approval)

**Only merge after:**
1. PR approved
2. All checks passing
3. Task status verified as completed

**Merge Command:**
```powershell
git checkout develop
git pull origin develop
git merge --no-ff feature/4-<feature-name>
git push origin develop
```

**Merge Commit Message:**
```
Merge branch 'feature/4-<feature-name>' into develop

Task #102: User Controller - CRUD Operations
Includes 4 sub-tasks completed, all tests passing.
```

---

### Step 7: Sprint Completion (After 8 Tasks Complete)

Once a sprint is complete:

1. Create sprint summary in `docs/03-phase-specific/phase-4-backend-api/sprint-plans/sprint-<N>-summary.md`
2. Document any blockers or risks
3. Update `docs/03-phase-specific/phase-4-backend-api/status-tracking/completion-log.md`
4. Merge develop → main only at major milestones

---

## ⚠️ Rule Enforcement - AI Responsibilities

### Before Every Code Change:
- [ ] Verify current branch is feature branch (not main/develop)
- [ ] If on main/develop, automatically create feature branch per naming rules
- [ ] Log branch creation in task status

### After Every Task Completion:
- [ ] Update task file status: COMPLETED
- [ ] Create changelog entry with branch name
- [ ] Commit with semantic message including task number
- [ ] Do NOT push until changelog is created

### Before Every Push:
- [ ] Verify all related tasks marked COMPLETED
- [ ] Confirm changelog entry exists
- [ ] Build succeeds locally (0 errors)
- [ ] Tests passing (if applicable)

### On Task Failure:
- [ ] Mark task as FAILED with error description
- [ ] Document blocker in task file
- [ ] Retry task automatically after 5 minutes
- [ ] If retry fails 3 times, escalate for human review
- [ ] Do NOT mark COMPLETED until task succeeds

---

## 🔄 Task Status Lifecycle

```
TODO → IN-PROGRESS → [COMPLETED | FAILED]
                        ↓
                    COMPLETED ✅
                    
If FAILED:
FAILED → Retry (auto-retry up to 3 times)
         If all retries fail → HUMAN-REVIEW-REQUIRED
```

---

## 📝 Task File Status Format

Every task file must include this status section:

```markdown
# Task [NNN]: [Task Name]

**Task ID:** [NNN]
**Status:** ⏳ TODO | 🔄 IN-PROGRESS | ✅ COMPLETED | ❌ FAILED

**Progress Notes:**
- **Started:** [Date/Time or N/A]
- **Completed:** [Date/Time or N/A]
- **Time Spent:** [X minutes or N/A]
- **Blockers:** [None or description]
- **Related Branch:** feature/phase-[N]-[name]

**Retry Count (if failed):** [0/3]
**Last Retry:** [Date/Time or N/A]
```

---

## 🚫 Prohibited Actions

❌ **Never:**
- Commit directly to `main` branch
- Commit directly to `develop` branch (unless approved PR merge)
- Commit without branch name in message
- Create branch names with spaces or uppercase
- Merge without PR approval
- Merge without passing tests
- Push without changelog entry
- Commit incomplete tasks (mark COMPLETED only when done)

---

## ✅ Checklist for Every Commit

Use this as AI verification before each commit:

```
Pre-Commit Checklist:
- [ ] Current branch: feature/phase-X-<name> (not main/develop)
- [ ] Task file exists: docs/03-phase-specific/phase-4-backend-api/tasks/
- [ ] Task status: 🔄 IN-PROGRESS
- [ ] Changes made match task acceptance criteria
- [ ] Code builds locally: `dotnet build` → 0 errors
- [ ] Tests pass (if applicable): `dotnet test`
- [ ] Commit message includes task number
- [ ] Commit message follows semantic format

Post-Commit Checklist:
- [ ] Changelog entry created: docs/06-changelogs/
- [ ] Changelog includes branch name
- [ ] Task status updated: ✅ COMPLETED
- [ ] All acceptance criteria verified
- [ ] Ready to push

Pre-Push Checklist:
- [ ] Verify branch name: feature/4-<name>
- [ ] Verify changelog exists
- [ ] Verify task marked COMPLETED
- [ ] Run final build: `dotnet build`
- [ ] Run tests: `dotnet test`
- [ ] Ready to create PR
```

---

## 🎓 Examples

### Example 1: New Feature Branch

```powershell
# Start new feature work
git checkout main
git pull origin main
git checkout -b feature/4-user-controller

# Work on task 102: User Controller CRUD
# ... make changes ...

# Commit with semantic message
git commit -m "feat(phase4-user-controller): add POST endpoint for user creation

- Implements /api/v1/users POST endpoint
- Adds CreateUserDto validation
- Integrates with UserService
- Adds unit tests for validation

Related-Task: 102
Branch: feature/4-user-controller"

# Create changelog
# Then push
git push origin feature/4-user-controller
```

### Example 2: Change to Completed Feature

```powershell
# Making change to already-completed feature
git checkout main
git pull origin main
git checkout -b feature/4-user-controller/fix-validation

# Fix validation issue in completed feature
# ... make changes ...

git commit -m "fix(phase4-user-controller): email validation regex fix

- Fixed email regex to accept international domains
- Added test cases for edge cases

Related-Task: 102
Branch: feature/4-user-controller/fix-validation"

# Create changelog
# Then push
git push origin feature/4-user-controller/fix-validation
```

---

## 🔗 Integration with AI Rules

This branching strategy is integrated into:
- `.vscode/settings.json` — AI behavior rules
- `.vscode/rules/rulebook.md` — Project rules enforcement
- Task execution pipeline — Automatic branch creation before changes
- Changelog system — Automatic entry creation before push

**AI will automatically:**
1. Create feature branch before ANY file modification
2. Update task status during execution
3. Create changelog entries before pushes
4. Validate branch names against rules
5. Enforce semantic commit messages
6. Retry failed tasks (up to 3 times)

---

## 📞 Questions or Clarifications?

Refer to main rulebook: `.vscode/rules/rulebook.md`  
View project status: `docs/02-progress-tracking/current-status.md`  
Check phase tasks: `docs/03-phase-specific/phase-4-backend-api/tasks/`
