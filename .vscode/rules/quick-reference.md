# 🎯 PR Checklist & Enforcement Quick Reference Card

**Print This! Post This! Remember This!**

---

## The 3 Rules (Must Follow!)

```
┌─────────────────────────────────────────────────────────────────┐
│ 1️⃣  NO HARD-CODED VALUES                                        │
│    ❌ if (role == "Admin")                                      │
│    ✅ if (role == RoleConstants.ADMIN)                          │
├─────────────────────────────────────────────────────────────────┤
│ 2️⃣  KEBAB-CASE FILES ONLY                                       │
│    ❌ UserService.cs                                            │
│    ✅ user-service.cs                                           │
├─────────────────────────────────────────────────────────────────┤
│ 3️⃣  CHANGELOG ENTRY REQUIRED                                    │
│    Create: docs/changelogs/ddmmyyyy.<seq>                       │
│    Before: git push                                             │
└─────────────────────────────────────────────────────────────────┘
```

---

## Enforcement System Flow

```
┌─────────────┐
│ Make Code   │
│  Changes    │
└──────┬──────┘
       │
       ▼
┌──────────────────────────────┐
│ git commit -m "message"      │
│                              │
│ 🔍 PRE-COMMIT HOOK RUNS      │
│ ✓ No hard-coded values?      │
│ ✓ Kebab-case files?          │
│ ✓ Async suffix on methods?   │
└──────┬───────────┬──────────┘
       │ ✅ Pass  │ ❌ Block
       ▼           ▼
   Commit      Fix violations
   created     & retry
       │
       ▼
┌──────────────────────────┐
│ Create Changelog Entry   │
│ docs/changelogs/...      │
└──────────┬───────────────┘
           │
           ▼
┌──────────────────────────────┐
│ git push                     │
│                              │
│ 🔍 PRE-PUSH HOOK RUNS        │
│ ✓ No WIP commits?            │
│ ✓ Changelog exists?          │
└──────┬───────────┬──────────┘
       │ ✅ Pass  │ ⚠️ Warn
       ▼           ▼
    Push      Confirm & push
    OK        anyway
       │
       ▼
┌──────────────────────────┐
│ Create PR on GitHub      │
│ Include checklist        │
└──────┬───────────────────┘
       │
       ▼
┌──────────────────────────────┐
│ CODE REVIEW (Manual Gate)    │
│                              │
│ Check 7 Auto-Rejection       │
│ Criteria:                    │
│ 1. No hard-coded values      │
│ 2. Kebab-case files          │
│ 3. Correct architecture      │
│ 4. Async suffix              │
│ 5. XML documentation         │
│ 6. Error codes used          │
│ 7. Correlation ID logging    │
└──────┬───────────┬──────────┘
       │ ✅ All OK │ ❌ Violated
       ▼           ▼
    APPROVED   REJECTED
       │        (Fix & retry)
       ▼
┌──────────────────────────┐
│ MERGE & DONE             │
└──────────────────────────┘
```

---

## Quick Lookup: Common Violations

### Hard-Coded Values
```csharp
// ❌ BAD
var timeout = 30000;
var url = "https://api.grrado.com";
if (user.Role == "Admin") { }

// ✅ GOOD
var timeout = TimeoutConstants.API_TIMEOUT_MS;
var url = ApiEndpoints.BASE_URL;
if (user.Role == RoleConstants.ADMIN) { }

// FIX: Create Constants.cs
public static class TimeoutConstants { const int API_TIMEOUT_MS = 30000; }
public static class ApiEndpoints { const string BASE_URL = "https://..."; }
public static class RoleConstants { const string ADMIN = "Admin"; }
```

### File Naming
```
❌ UserService.cs (PascalCase)
❌ user_service.cs (snake_case)
❌ UserService.dart (PascalCase)

✅ user-service.cs (kebab-case)
✅ user-service.dart (kebab-case)

FIX: mv UserService.cs user-service.cs
```

### Async Methods
```csharp
// ❌ BAD
public Task<User> GetUser(int id) { }

// ✅ GOOD
public async Task<User> GetUserAsync(int id) { }

// FIX: Add "Async" suffix
```

### XML Documentation
```csharp
// ❌ BAD
public class UserService { }

// ✅ GOOD
/// <summary>Manages user operations.</summary>
public class UserService { }

// FIX: Add /// comments above public members
```

### Error Codes
```csharp
// ❌ BAD
throw new Exception("User not found");
return Result.Failure("Invalid user");

// ✅ GOOD
return Result.Failure(ErrorCodes.USER_NOT_FOUND);
return Result.Failure(ErrorCodes.VALIDATION_FAILED);

// FIX: Use ErrorCodes constants
```

### Correlation ID Logging
```csharp
// ❌ BAD
_logger.LogInformation("User {UserId} fetched", userId);

// ✅ GOOD
_logger.LogInformation(
    "User {UserId} fetched. CorrelationId: {CorrelationId}",
    userId,
    correlationId);

// FIX: Include CorrelationId in all public endpoint logs
```

---

## Documentation Quick Links

| When You Need... | Read This |
|-----------------|-----------|
| 5-min overview | `.vscode/QUICK-SETUP.md` |
| Full enforcement details | `.vscode/PR-CHECKLIST-ENFORCEMENT.md` |
| All standards & rules | `.vscode/rulebook.md` |
| Code review checklist | `docs/pr-checklist.md` |
| Implementation status | `.vscode/IMPLEMENTATION-SUMMARY.md` |

---

## Pre-Commit Hook Blocks On:

```
✅ Hard-coded literals found
   → Extract to Constants

✅ File not in kebab-case
   → Rename file

✅ Async method without "Async" suffix
   → Add "Async" to method name

⚠️  Missing public member documentation
   → Add /// comments (warning only)

⚠️  Possible secrets detected
   → Review & remove if needed (warning only)
```

---

## Pre-Push Hook Warns On:

```
✅ WIP/TEMP/DEBUG commits found
   → Use meaningful commit messages

✅ Changelog entry missing
   → Create docs/changelogs/ddmmyyyy.<seq>

✅ Poor commit message quality
   → Use descriptive messages
```

---

## Code Review Auto-Rejection (❌ REJECTED):

```
1. Hard-Coded Values
   → All literals must be Constants

2. Wrong File Naming
   → All files must be kebab-case

3. Wrong Architecture Layer
   → Code must be in correct layer (Domain/App/Infra/API)

4. Missing Async Suffix
   → All async methods must end with "Async"

5. No XML Documentation
   → Public members must have /// comments

6. No Error Codes
   → Must use ErrorCodes constants, never throw exceptions

7. No Correlation ID Logging
   → Public endpoints must log with CorrelationId
```

---

## Bypass Hooks? ⚠️ (Only in Emergencies!)

```bash
# Skip pre-commit hook
git commit --no-verify -m "message"

# Skip pre-push hook
git push --force-with-lease

# ⚠️  WARNING: Code review WILL catch this and REJECT your PR
# Only use if you REALLY know what you're doing
```

---

## Golden Rules

```
1. ALWAYS use Constants, NEVER hard-code
2. ALWAYS use kebab-case for filenames
3. ALWAYS add Async suffix to async methods
4. ALWAYS document public members
5. ALWAYS use ErrorCodes, NEVER throw exceptions
6. ALWAYS log with CorrelationId
7. ALWAYS create changelog entry
```

---

## One More Thing...

> **Read `.vscode/rulebook.md` BEFORE making changes.**
>
> It's the source of truth for all GRRADO standards.

---

**Bookmark this file!** 📌  
`.vscode/QUICK-REFERENCE.md`

Last Updated: February 1, 2026
