# 🔒 PR Checklist & Git Hooks Enforcement System

**Document Version:** 1.0  
**Effective Date:** February 1, 2026  
**Status:** ✅ ACTIVE - All developers must comply  
**Location:** `.vscode/` & `docs/pr-checklist.md`

---

## 📋 Overview

GRRADO enforces a mandatory **PR checklist system** with automated Git hooks to prevent code violations BEFORE pushing to GitHub. This ensures consistent code quality and adherence to the [Rulebook](.vscode/rulebook.md).

### Three Layers of Enforcement

| Layer | When | Tool | Purpose |
|-------|------|------|---------|
| **Layer 1: Pre-Commit** | Before `git commit` | `.git/hooks/pre-commit` | Block commits with violations |
| **Layer 2: Pre-Push** | Before `git push` | `.git/hooks/pre-push` | Validate before GitHub push |
| **Layer 3: Code Review** | PR submitted | Manual review + checklist | Final review & approval |

---

## 🚫 Layer 1: Pre-Commit Hook Enforcement

**File:** `.git/hooks/pre-commit` (also `.git/hooks/pre-commit.bat` for Windows)

Runs automatically BEFORE creating a commit. **BLOCKS commit** if violations detected.

### What It Checks

```
✅ Hard-coded literals          ❌ If found: block commit
✅ File naming (kebab-case)     ❌ If found: block commit  
✅ Secret detection             ⚠️  If found: warning (allow commit)
✅ Async method naming          ❌ If found: block commit
✅ Public member documentation  ⚠️  If found: warning (allow commit)
```

### Example: Hard-Coding Violation

**BAD CODE:**
```csharp
if (user.Role == "Admin") { }  // Hard-coded string!
var timeout = 30000;            // Hard-coded number!
```

**Pre-Commit Hook Output:**
```
🔍 Running GRRADO Pre-Commit Checks...

[1/5] Checking for hard-coded literals...
  ❌ Potential hard-coded string in: API/Controllers/user-controller.cs
     Check these lines for extracted constants:
     + if (user.Role == "Admin") {

❌ COMMIT BLOCKED: 1 violation(s) detected

Please fix the issues above before committing:
  1. Hard-coded values → Extract to Constants
  2. File naming → Rename to kebab-case

Reference: .vscode/rulebook.md
```

**FIX:**
```csharp
if (user.Role == RoleConstants.ADMIN) { }    // Using constant
var timeout = TimeoutConstants.API_TIMEOUT_MS; // Using constant
```

Then retry: `git commit -m "..."`

### How to Bypass (NOT RECOMMENDED)

```bash
# Force commit skipping pre-commit hook (ONLY for emergencies)
git commit --no-verify -m "message"

# ⚠️  WARNING: Code review will catch this and reject PR
```

---

## 🚀 Layer 2: Pre-Push Hook Enforcement

**File:** `.git/hooks/pre-push` (also `.git/hooks/pre-push.bat` for Windows)

Runs automatically BEFORE pushing to GitHub. **Warns if issues** but allows push with consent.

### What It Checks

```
✅ Commit message quality       ⚠️  Warning (WIP commits)
✅ Changelog entry exists       ❌ If missing: warn user
✅ No WIP/TEMP/DEBUG commits    ❌ If found: block push
```

### Example: Missing Changelog

**Pre-Push Output:**
```
🚀 Running GRRADO Pre-Push Validation...

[1/4] Validating commit messages...
  ✅ All commit messages acceptable

[2/4] Checking for changelog entry...
  ⚠️  No changelog entry detected
     Should create: docs/changelogs/ddmmyyyy.<seq>
     Reference: docs/pr-checklist.md (Automatic Rejection Criteria #1)

❌ PUSH BLOCKED: 1 violation(s) detected

Please fix the issues above before committing:
  1. Create changelog entry
  2. Improve commit messages

Or force push with: git push --force-with-lease
(only use if you understand the consequences)

Continue anyway? (type 'yes' to proceed): 
```

**CREATE CHANGELOG:**
```bash
# Create: docs/changelogs/01022026.001
```

File content example:
```markdown
## [0.1.0] - 2026-02-01

### Added
- PR checklist enforcement via Git hooks
- Pre-commit validation for hard-coded values
- Pre-push validation for changelog entries

### Version Bump
**Proposed:** minor (0.0.1 → 0.1.0)
**Reason:** New enforcement features, backward compatible
```

Then retry: `git push`

---

## 📋 Layer 3: Manual Code Review (GitHub)

**File:** `docs/pr-checklist.md`

When you create a PR on GitHub, **reviewers use this checklist** to validate your code.

### Automatic Rejection Criteria (Red Path)

PRs are **REJECTED WITHOUT REVIEW** for:

#### 1. **Hard-Coded Values** 🚫

```csharp
// REJECTED
if (userRole == "Admin") { }
var timeout = 30000;
var apiUrl = "https://api.grrado.com";

// APPROVED
if (userRole == RoleConstants.ADMIN) { }
var timeout = TimeoutConstants.API_REQUEST_TIMEOUT_MS;
var apiUrl = ApiEndpoints.BASE_URL;
```

**Action:** Extract all literals to constants

#### 2. **File Naming Violations** 🚫

```
REJECTED:
- UserService.cs       ❌ PascalCase
- user_service.cs      ❌ snake_case
- UserService.dart     ❌ PascalCase

APPROVED:
- user-service.cs      ✅ kebab-case
- user-service.dart    ✅ kebab-case
```

**Action:** Rename file before pushing

#### 3. **Wrong Clean Architecture Layer** 🚫

```csharp
// REJECTED - Business logic in controller
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<User> GetUser(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }
}

// APPROVED - Proper separation
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<Result<UserDto>> GetUserAsync(int id)
    {
        var result = await _userService.GetUserAsync(id);
        return result;
    }
}
```

**Action:** Move code to correct layer (Domain/Application/Infrastructure/API)

#### 4. **Missing Async Suffix** 🚫

```csharp
// REJECTED
public Task<User> GetUser(int id)       // Async method missing suffix
public void FetchData()                  // Contains async call

// APPROVED
public async Task<User> GetUserAsync(int id)
public async Task FetchDataAsync()
```

**Action:** Add `Async` suffix to all async methods

#### 5. **No XML Documentation** 🚫

```csharp
// REJECTED
public class UserService
{
    public async Task<User> GetUserAsync(int id) { }
}

// APPROVED
/// <summary>
/// Manages user creation, retrieval, and deletion operations.
/// </summary>
public class UserService
{
    /// <summary>
    /// Retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique user ID</param>
    /// <returns>The user if found; otherwise null</returns>
    public async Task<User?> GetUserAsync(int id) { }
}
```

**Action:** Add XML comments to all public APIs

#### 6. **No Error Code Usage** 🚫

```csharp
// REJECTED
return Result<UserDto>.Failure("User not found");
throw new Exception("Invalid user");

// APPROVED
return Result<UserDto>.Failure(ErrorCodes.USER_NOT_FOUND);
if (!IsValid(user))
    return Result<UserDto>.Failure(ErrorCodes.USER_VALIDATION_FAILED);
```

**Action:** Use error codes from `ErrorCodes` constant class

#### 7. **Missing Correlation ID in Logs** 🚫

```csharp
// REJECTED
_logger.LogInformation("User {UserId} fetched", userId);

// APPROVED
_logger.LogInformation(
    "User {UserId} fetched. CorrelationId: {CorrelationId}",
    userId,
    correlationId
);
```

**Action:** Include Correlation ID in all public endpoint logs

---

## 🔄 Complete Workflow Example

### Step 1: Make Code Changes

```bash
cd d:\_GRRADO\src
# Edit files...
git add .
```

### Step 2: Commit (Pre-Commit Hook Runs)

```bash
git commit -m "feat: add user authentication"

# Pre-commit hook checks:
# ✅ No hard-coded values
# ✅ Kebab-case filenames
# ✅ No secrets
# ✅ Async suffix
# ✅ Documentation

# If all pass: commit created ✅
# If any fail: commit blocked ❌ → Fix → Retry
```

### Step 3: Create Changelog Entry

```bash
# Create file: docs/changelogs/01022026.001
```

Content:
```markdown
## [0.1.5] - 2026-02-01

### Added
- JWT token validation in middleware
- User authentication service

### Changed
- Updated API error responses to use error codes

### Version Bump
**Proposed:** minor (0.1.0 → 0.1.5)
**Reason:** New features, backward compatible
```

### Step 4: Push to GitHub (Pre-Push Hook Runs)

```bash
git push

# Pre-push hook checks:
# ✅ No WIP commits
# ✅ Changelog exists
# ✅ Commit messages valid

# If all pass: pushed to GitHub ✅
# If any fail: push blocked ❌ → Fix → Retry
```

### Step 5: Create Pull Request

```
GitHub PR Description:

## 📋 Code Review Checklist

- [x] **Changelog Updated** - Entry added to docs/06-changelogs/
- [x] **Architecture & Layers** - Code in correct Clean Architecture layer
- [x] **No Circular Dependencies** - Dependencies flow downward
- [x] **File Naming** - All filenames use kebab-case
- [x] **Class/Method Naming** - PascalCase for backend
- [x] **No Hard-Coding** - All magic strings/numbers extracted to constants
- [x] **Constants Organization** - Constants in correct constants files
- [x] **Error Handling** - Using ErrorCodes constants, Result<T> pattern
- [x] **Async/Await** - I/O operations are async
- [x] **Logging & Correlation** - Correlation ID in all logs
- [x] **Interfaces** - External dependencies use interfaces
- [x] **XML Documentation** - Public classes/methods documented
- [x] **No Sensitive Data** - No passwords/tokens in logs
- [x] **Unit Tests** - Business logic has tests, >70% coverage

## Changelog
See: docs/changelogs/01022026.001
```

### Step 6: Code Review (Reviewer Uses Checklist)

**Reviewer checks all 7 automatic rejection criteria:**

1. ✅ No hard-coded values?
2. ✅ Kebab-case filenames?
3. ✅ Correct architecture layer?
4. ✅ Async suffix on async methods?
5. ✅ XML documentation present?
6. ✅ Error codes used (not exceptions)?
7. ✅ Correlation ID logging?

**Decision:**
- If all pass → **APPROVED** ✅
- If any fail → **REQUEST CHANGES** (cite checklist items)
- If auto-rejection criteria violated → **REJECTED** ❌

### Step 7: Address Feedback & Re-Push

```bash
# Make requested changes
git add .
git commit -m "fix: address code review feedback"
git push

# Pre-push hook runs again
# If passes: automatically re-reviewed
```

### Step 8: Merge & Close

Once approved, reviewer merges and creates git tag:

```bash
git tag v0.1.5
git push origin v0.1.5
```

---

## 🛠️ Setting Up Git Hooks Locally

Git hooks are already installed in `.git/hooks/`:

### Windows
- `pre-commit.bat` - Runs before commits
- `pre-push.bat` - Runs before pushes

### Mac/Linux
- `pre-commit` - Runs before commits
- `pre-push` - Runs before pushes

### Enable Hooks (First Time Setup)

```bash
# Navigate to repo
cd d:\_GRRADO\src

# Make hooks executable (Linux/Mac)
chmod +x .git/hooks/pre-commit
chmod +x .git/hooks/pre-push

# Windows: Already .bat files, just needs git to find them
# Git will auto-execute .bat files on Windows
```

### Verify Hooks Are Active

```bash
# Try to commit with hard-coded value
echo 'if (x == "Admin") {}' >> test.txt
git add test.txt
git commit -m "test"

# Should see:
# ❌ COMMIT BLOCKED: 1 violation(s) detected
```

---

## 📚 Related Documentation

| Document | Purpose |
|----------|---------|
| [.vscode/rulebook.md](.vscode/rulebook.md) | Core development standards |
| [docs/pr-checklist.md](docs/pr-checklist.md) | PR checklist & code review |
| [docs/pr-checklist.md](docs/pr-checklist.md#-automatic-rejection-criteria) | Auto-rejection criteria |
| [docs/pr-checklist.md](docs/pr-checklist.md#-approval-process) | Code review process |

---

## ❓ FAQ

**Q: Can I bypass the pre-commit hook?**  
A: Yes, use `git commit --no-verify`, but code review will catch violations and reject your PR.

**Q: What if my file should be PascalCase?**  
A: GRRADO requires kebab-case for all source files. No exceptions.

**Q: Can I hard-code configuration values?**  
A: No. Use `Constants.cs`, `ApiEndpoints.cs`, or `configuration.json`.

**Q: What if I forgot to create a changelog entry?**  
A: Create it before pushing (or between commits). Pre-push hook will catch it.

**Q: My async method needs to return without `Async` suffix. Can I skip it?**  
A: No. All async methods must end with `Async`. Use `Async` suffix even if unusual.

**Q: Can I document my code with inline comments instead of XML?**  
A: No. Public APIs must have XML documentation (///). Inline comments are additional.

---

## 📞 Questions?

- **Setup issues?** → Ask team lead or check hook logs
- **Code standards?** → See [.vscode/rulebook.md](.vscode/rulebook.md)
- **Checklist questions?** → See [docs/pr-checklist.md](docs/pr-checklist.md)
- **Process issues?** → Ask your Team Lead

---

**Enforcement Effective Date:** February 1, 2026  
**Maintained By:** Development Team  
**Last Updated:** February 1, 2026
