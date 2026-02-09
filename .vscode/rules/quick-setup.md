# ⚡ Quick Setup: PR Checklist & Git Hooks

**For:** New developers on GRRADO project  
**Time:** 5 minutes  
**Last Updated:** February 1, 2026

---

## 🎯 What You Need to Know

GRRADO enforces a **mandatory PR checklist system** with automatic Git hooks to catch code violations BEFORE they reach GitHub.

### Three Rules (Remember These!)

| # | Rule | When | Example |
|---|------|------|---------|
| **1** | 🚫 NO hard-coded values | Before commit | ❌ `if (role == "Admin")` → ✅ `if (role == RoleConstants.ADMIN)` |
| **2** | 📝 Language-appropriate filenames | Before commit | C#=PascalCase, Dart/Py=snake_case, docs=kebab-case |
| **3** | 📋 Changelog entry | Before push | Create `docs/changelogs/01022026.001` |

---

## 📖 Reading Order

1. **This file** (5 min) - Quick overview
2. [`.vscode/rulebook.md`](rulebook.md) (30 min) - Full standards
3. [`.vscode/pr-checklist-enforcement.md`](pr-checklist-enforcement.md) (20 min) - Enforcement system
4. [`docs/pr-checklist.md`](../../docs/pr-checklist.md) (15 min) - Code review checklist

---

## 🚀 Workflow: Make Changes → Commit → Push

### Step 1: Make Code Changes

```bash
# Edit files...
# Run tests...
# Build locally...

git add .
```

### Step 2: Commit (Pre-Commit Hook Runs ✅)

```bash
git commit -m "feat: add new feature"

# 🔍 Pre-commit hook checks:
# [1/5] Checking for hard-coded literals...
# [2/5] Checking file naming conventions...
# [3/5] Checking for secrets...
# [4/5] Checking async method naming...
# [5/5] Checking for documentation...

# ✅ All pre-commit checks passed!
# Commit created.
```

**If hook BLOCKS commit:**
```
❌ COMMIT BLOCKED: 1 violation(s) detected

Please fix the issues above before committing:
  1. Hard-coded values → Extract to Constants
  2. File naming → Use language-appropriate convention
  3. Async methods → Add 'Async' suffix
```

**Fix and retry:**
```bash
# 1. Extract hard-coded "Admin" to RoleConstants.ADMIN
# 2. Ensure C# files use PascalCase, docs use kebab-case
# 3. Rename GetUser() to GetUserAsync()

git add .
git commit -m "feat: add new feature"  # Should pass now
```

### Step 3: Create Changelog Entry

```bash
# Create file: docs/changelogs/01022026.001
```

**Content:**
```markdown
## [0.1.5] - 2026-02-01

### Added
- New user authentication feature
- JWT token validation

### Changed
- Updated API error handling

### Version Bump
**Proposed:** minor (0.1.0 → 0.1.5)
**Reason:** New features, backward compatible
```

### Step 4: Push to GitHub (Pre-Push Hook Runs ✅)

```bash
git push

# 🚀 Running GRRADO Pre-Push Validation...
# [1/4] Validating commit messages...
# [2/4] Checking for changelog entry...
# [3/4] Pre-push readiness checklist...
# [4/4] Validating branch structure...

# ✅ All pre-push checks passed!
# Ready to push! 🚀
```

### Step 5: Create Pull Request

In GitHub, include checklist:

```markdown
## 📋 Code Review Checklist

- [x] Changelog Updated
- [x] Architecture & Layers
- [x] No Hard-Coding
- [x] File Naming (language-appropriate)
- [x] Async Suffix
- [x] XML Documentation
- [x] Error Codes Used
- [x] Correlation ID Logging
- [x] Unit Tests (>70% coverage)
```

### Step 6: Code Review

Reviewers check **7 auto-rejection criteria:**

1. ✅ No hard-coded values?
2. ✅ Language-appropriate filenames?
3. ✅ Correct architecture layer?
4. ✅ Async suffix on async methods?
5. ✅ XML documentation present?
6. ✅ Error codes used?
7. ✅ Correlation ID logging?

**Result:**
- ✅ All pass → **APPROVED**
- ❌ Any fail → **REJECTED** (fix & retry)

---

## ⚠️ Common Violations (Don't Do These!)

### Hard-Coded Values

```csharp
// ❌ BAD
var timeout = 30000;
if (user.Role == "Admin") { }
var url = "https://api.grrado.com";

// ✅ GOOD
var timeout = TimeoutConstants.API_REQUEST_TIMEOUT_MS;
if (user.Role == RoleConstants.ADMIN) { }
var url = ApiEndpoints.BASE_URL;
```

**Fix:** Create Constants file (e.g., `api-endpoints.cs`)
```csharp
public static class ApiEndpoints
{
    public const string BASE_URL = "https://api.grrado.com";
}

public static class TimeoutConstants
{
    public const int API_REQUEST_TIMEOUT_MS = 30000;
}
```

### Wrong File Naming

```
❌ BAD:
- user-service.cs (kebab-case for C#)
- UserService.dart (PascalCase for Dart)
- SetupGuide.md (PascalCase for docs)

✅ GOOD:
- UserService.cs (PascalCase for C#)
- user_service.dart (snake_case for Dart)
- setup-guide.md (kebab-case for docs)
```

**Fix:** Use language-appropriate convention

### Missing Async Suffix

```csharp
// ❌ BAD
public Task<User> GetUser(int id) { }

// ✅ GOOD
public async Task<User> GetUserAsync(int id) { }
```

### No XML Documentation

```csharp
// ❌ BAD
public class UserService
{
    public async Task<User> GetUserAsync(int id) { }
}

// ✅ GOOD
/// <summary>
/// Manages user operations.
/// </summary>
public class UserService
{
    /// <summary>
    /// Retrieves a user by ID.
    /// </summary>
    /// <param name="id">User ID</param>
    /// <returns>User if found; otherwise null</returns>
    public async Task<User> GetUserAsync(int id) { }
}
```

### No Error Codes

```csharp
// ❌ BAD
throw new Exception("User not found");
return null;

// ✅ GOOD
if (!user.Exists)
    return Result<UserDto>.Failure(ErrorCodes.USER_NOT_FOUND);
```

### Missing Correlation ID

```csharp
// ❌ BAD
_logger.LogInformation("User {UserId} fetched", userId);

// ✅ GOOD
_logger.LogInformation(
    "User {UserId} fetched. CorrelationId: {CorrelationId}",
    userId,
    correlationId
);
```

---

## 🛠️ Bypass Hooks? (Don't!)

```bash
# Skip pre-commit hook (NOT RECOMMENDED)
git commit --no-verify -m "message"

# Code review will catch violations and REJECT your PR
```

---

## 📚 Full Documentation

| Document | Purpose |
|----------|---------|
| [.vscode/rulebook.md](.vscode/rulebook.md) | All development standards |
| [.vscode/PR-CHECKLIST-ENFORCEMENT.md](PR-CHECKLIST-ENFORCEMENT.md) | How enforcement system works |
| [docs/pr-checklist.md](../docs/pr-checklist.md) | Code review checklist & process |

---

## ❓ FAQ

**Q: What happens if pre-commit hook blocks my commit?**  
A: Fix the violations (extract constants, rename files, etc.) and try again.

**Q: Can I bypass the hooks?**  
A: Yes, with `git commit --no-verify` or `git push --force-with-lease`, but code review will catch violations and reject your PR.

**Q: Why does file naming vary by language?**
A: Each language has its own official convention. C# uses PascalCase, Dart/Python use snake_case, and docs use kebab-case. See rulebook.md Section 3.1.

**Q: What if my async method should not have "Async" suffix?**  
A: It must have it anyway. GRRADO requires it for all async methods.

**Q: Can I use hard-coded values in tests?**  
A: For test data yes, but not magic literals. Use TestConstants for reusable test values.

**Q: What if I forgot to create a changelog entry?**  
A: Pre-push hook will catch it. Create the entry and try push again.

---

## 🎓 Next Steps

1. ✅ Read this file (5 min)
2. 📖 Read [.vscode/rulebook.md](.vscode/rulebook.md) (30 min)
3. 👨‍💻 Make your first PR and follow the workflow above
4. 📋 Use [docs/pr-checklist.md](../docs/pr-checklist.md) as your PR template

---

**Welcome to GRRADO!** 🎉

Follow the three rules, use the checklist, and you'll be shipping clean code in no time.

**Questions?** Ask your team lead or check the full documentation linked above.
