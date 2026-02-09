# 🔍 Pull Request Checklist & Code Review Enforcement

**Document Version:** 1.0  
**Effective Date:** January 31, 2026  
**Owner:** Development Team  
**Reference:** [../.vscode/rulebook.md](../.vscode/rulebook.md#10-enforcement--code-review)

---

## 📋 MANDATORY PR Review Checklist

Every Pull Request MUST pass all these checks before merging. Use this checklist in your PR description.

```markdown
## 📋 Code Review Checklist

- [ ] **Changelog Updated** - Entry added to [docs/06-changelogs/changelog.ddmmyyyy.<seq>](../06-changelogs/) with proposed version bump (major/minor/patch)
- [ ] **Architecture & Layers** - Code in correct Clean Architecture layer (Domain/Application/Infrastructure/API)
- [ ] **No Circular Dependencies** - Dependencies flow downward, no reverse dependencies
- [ ] **File Naming** - All filenames use language-appropriate convention (C#=PascalCase, Dart/Py=snake_case, docs=kebab-case)
- [ ] **Class/Method Naming** - PascalCase for backend; camelCase for frontend
- [ ] **No Hard-Coding** - All magic strings/numbers extracted to constants
- [ ] **Constants Organization** - Constants in correct constants files (not scattered)
- [ ] **Error Handling** - Using ErrorCodes constants, Result<T> pattern, no bare throws
- [ ] **Async/Await** - I/O operations are async, methods end with Async suffix
- [ ] **Logging & Correlation** - All public endpoints log with Correlation ID
- [ ] **Interfaces** - External dependencies use interfaces, not concrete types
- [ ] **XML Documentation** - Public classes/methods have documentation comments
- [ ] **No Sensitive Data in Logs** - No passwords, tokens, or PII logged
- [ ] **Unit Tests** - Business logic has tests, >70% coverage for critical paths
- [ ] **Database Naming** - Tables/columns use snake_case (PostgreSQL convention)
- [ ] **Flutter Specifics** - Domain layer is pure Dart (no Flutter imports), const constructors used
- [ ] **Backend Specifics** - DTOs use mapping profiles, validators use error codes

```

---

## ❌ AUTOMATIC REJECTION CRITERIA

PRs will be **REJECTED WITHOUT REVIEW** for:

### 1. **Hard-Coded Values** 🚫
**Example:** Any literal string/number that should be a constant

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

**Action:** Extract all literals to constants. Use grep to find patterns: `"string"`, `\d{4,}`, hardcoded URLs.

### 2. **File Naming Violations** 🚫
**Example:** Files not following their language's naming convention

```
REJECTED:
- user-service.cs       ❌ kebab-case (C# must be PascalCase)
- user_service.cs       ❌ snake_case (C# must be PascalCase)
- UserService.dart      ❌ PascalCase (Dart must be snake_case)
- SetupGuide.md         ❌ PascalCase (docs must be kebab-case)

APPROVED:
- UserService.cs        ✅ PascalCase (C# convention)
- user_service.dart     ✅ snake_case (Dart convention)
- setup-guide.md        ✅ kebab-case (docs convention)
```

**Action:** Use the language-appropriate convention for each file type.

### 3. **Wrong Clean Architecture Layer** 🚫
**Example:** Business logic in controller, repository in application layer, etc.

```csharp
// REJECTED - Business logic in controller
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<User> GetUser(int id)
    {
        // ❌ Data access logic in controller
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
        return result;  // Returns Result<T>, not direct entity
    }
}
```

**Action:** Move code to correct layer. Use interfaces for dependencies.

### 4. **Missing Async Suffix** 🚫
**Example:** Async methods without `Async` suffix

```csharp
// REJECTED
public Task<User> GetUser(int id)       // ❌ Async method missing suffix
public void FetchData()                  // ❌ Contains async call

// APPROVED
public async Task<User> GetUserAsync(int id)
public async Task FetchDataAsync()
```

**Action:** Add `Async` suffix to all methods with async/await or Task return.

### 5. **No XML Documentation** 🚫
**Example:** Public classes/methods without documentation

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

**Action:** Add XML comments to all public APIs.

### 6. **No Error Code Usage** 🚫
**Example:** Returning generic errors instead of error codes

```csharp
// REJECTED
return Result<UserDto>.Failure("User not found");
throw new Exception("Invalid user");

// APPROVED
return Result<UserDto>.Failure(ErrorCodes.USER_NOT_FOUND);
if (!IsValid(user))
    return Result<UserDto>.Failure(ErrorCodes.USER_VALIDATION_FAILED);
```

**Action:** Use error codes from `ErrorCodes` constant class.

### 7. **Missing Correlation ID in Logs** 🚫
**Example:** Public API calls without Correlation ID logging

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

**Action:** Include Correlation ID in all public endpoint logs.

---

## ✅ APPROVAL PROCESS

### **Quick Review (Green Path)** ✅
PRs meeting ALL requirements get **quick approval**:
- All checklist items checked
- Code follows naming conventions
- Proper layer placement
- No violations of automatic rejection criteria

### **Feedback Required (Yellow Path)** ⚠️
PRs with issues but fixable:
1. Request changes citing specific checklist items
2. Provide code examples of corrections
3. Approve after developer fixes issues

### **Rejection Required (Red Path)** ❌
PRs with automatic rejection criteria:
1. Request changes immediately
2. Do NOT merge until corrected
3. Provide specific examples and remediation steps

---

## 🔧 Tools & Automation

### **Pre-Commit Hooks (Recommended)**
Validate before pushing:

```bash
# Check for file naming violations per language convention
# Docs/config: reject uppercase
git diff --cached --name-only | grep -E '\.(md|txt|json|yml|yaml|sql)$' | grep -E '[A-Z]'
# C# files: reject kebab-case (hyphens)
git diff --cached --name-only | grep -E '\.cs$' | grep -E '-'
# If matches, REJECT with message about language-appropriate naming

# Check for common hard-coded patterns
git diff --cached | grep -E '(if|=) "[A-Za-z_]+"' | grep -v 'ErrorCodes\|Constants\|Endpoints'
# If matches, warn about possible hard-coding
```

### **Code Analysis Tools**
- **StyleCop** (.NET) — Validates naming conventions automatically
- **Flutter Analyze** (Dart) — Checks code quality
- **Pylance** (Python docs) — Markdown linting

### **CI/CD Pipeline Checks**
- Compile check must succeed
- StyleCop/Lint must pass
- No hard-coded secrets
- File naming validation

---

## 📝 Exception Process

**Exceptions to these rules require:**

1. **Document the exception** — Comment in code explaining WHY it's necessary
   ```csharp
   // EXCEPTION: Hard-coding database timeout for system critical path
   // Approved by: @DevLead, Date: 2026-01-31
   // Alternative: Use configuration once DI is available
   private const int CRITICAL_TIMEOUT_MS = 120000;
   ```

2. **Get written approval** — From **2+ senior developers**
   - Comment in PR explaining exception
   - Get explicit approval from reviewers
   - Document in exception log

3. **Create follow-up issue** — Track remediation of exception
   - Should be fixed in next sprint if possible
   - Add to technical debt tracker

---

## 🎯 Review Speed Targets

| Scenario | Target Time | Notes |
|----------|------------|-------|
| **No issues** | 15 min | Quick checklist pass |
| **Minor fixes** | 1 hour | One round of feedback |
| **Major refactoring** | 4 hours | Multiple review rounds okay |
| **Architectural change** | 24 hours | Involves senior review |
| **Auto-rejection** | 0 min | Reject immediately, no review |

---

## 🏆 Best Practices for Code Review

### **As a Reviewer:**
1. ✅ Use the checklist — Don't skip items
2. ✅ Be specific — Point to line numbers, provide examples
3. ✅ Educate — Explain WHY a standard exists
4. ✅ Be consistent — Apply same rules to everyone
5. ✅ Be constructive — Suggest fixes, don't just criticize

### **As a Developer:**
1. ✅ Self-review first — Check checklist before pushing
2. ✅ Small PRs — Easier to review, fewer conflicts
3. ✅ Descriptive messages — Explain what and why
4. ✅ Request review early — Don't wait until last minute
5. ✅ Address feedback promptly — No back-and-forth delays

---

## 📊 Review Metrics to Track

| Metric | Target | Action if Missing |
|--------|--------|-------------------|
| **Checklist completion** | 100% | Block merge until all checked |
| **Test coverage** | >70% | Request additional tests |
| **Code review time** | <4 hours | Add more reviewers if slow |
| **Rejection rate** | <5% | Provide training if high |
| **Exception rate** | <2% | Reassess if trends up |

---

## 🚨 Red Flags During Review

Stop and escalate if you see:
- [ ] Hard-coded secrets (API keys, passwords, tokens)
- [ ] SQL injection vulnerabilities
- [ ] Files uploaded that shouldn't be (binaries, .dll files)
- [ ] Massive PRs (>500 lines) — Request split
- [ ] Code from outside contributors without proper review
- [ ] Changes to security/auth without thorough review
- [ ] Database schema changes without migration script

---

## 📞 Questions?

- **About standards?** → See [../.vscode/rulebook.md](../.vscode/rulebook.md)
- **About a specific check?** → See checklist above
- **About process?** → Ask your Team Lead
- **About exceptions?** → See exception process above

---

**Next Review:** Monthly  
**Last Updated:** January 31, 2026  
**Maintained By:** Development Team
