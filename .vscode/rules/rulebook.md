# 📋 GRRADO Development Rulebook
## Vehicle Service Portal - Universal Standards & Enforcement

**Document Version:** 2.0  
**Last Updated:** January 31, 2026  
**Applies To:** All developers, AI assistants, code reviewers  
**Status:** ✅ **MANDATORY** - All code MUST follow these standards  
**Enforcement:** Violations result in PR rejection; manual review required for exceptions

> 📌 **ENFORCEMENT SYSTEM ACTIVE** — See [PR-CHECKLIST-ENFORCEMENT.md](PR-CHECKLIST-ENFORCEMENT.md) for automated Git hooks and mandatory PR checklist validation

---

## Table of Contents
1. [Architectural Principles](#1-architectural-principles-clean-architecture)
2. [Core Coding Rules](#2-core-coding-principles)
3. [Naming Conventions](#3-naming-conventions--file-organization)
4. [Constants Management](#4-constants-organization)
5. [Logging & Correlation IDs](#5-logging--correlation-id-mandatory)
6. [Backend Standards (.NET)](#6-backend-standards-net-9)
7. [Frontend Standards (Flutter/Dart)](#7-frontend-standards-flutterdart)
8. [Validation & Error Handling](#8-validation--error-handling)
9. [Documentation Standards](#9-documentation-standards)
10. [Versioning & Changelog](#10-versioning--changelog)
11. [Enforcement & Code Review](#11-enforcement--code-review)

---

## 1. ARCHITECTURAL PRINCIPLES: CLEAN ARCHITECTURE

All projects (Backend & Frontend) **MUST** follow **Clean Architecture** principles to ensure separation of concerns, testability, and maintainability.

### 1.1 Backend (.NET 9) Layers

The backend MUST follow this strict layering:

| Layer | Purpose | Dependencies | Examples |
|-------|---------|--------------|----------|
| **Domain** | Enterprise business rules, Entities, Value Objects, Interfaces | NONE - Pure Dart/C# | `User`, `Vehicle`, `IUserRepository` |
| **Application** | Use Cases, Business Logic, Commands/Queries, DTOs, Service interfaces | Domain only | `CreateUserHandler`, `UserDto`, `IUserService` |
| **Infrastructure** | Data persistence (EF Core), External APIs, Caching, Repositories | Application | `UserRepository`, `ApiClient`, `RedisCache` |
| **API** | REST Controllers, Middleware, Configuration, Dependency Injection | Infrastructure | `UsersController`, `ErrorHandlingMiddleware` |
| **Utility** | Cross-cutting concerns, Logging, Extensions (shared by all) | None | `LoggingService`, `StringExtensions` |

**RULE:** Code MUST be placed in the correct layer. Violating this structure results in immediate PR rejection.

### 1.2 Frontend (Flutter) Layers

Each Flutter app/package MUST follow this internal structure:

| Layer | Purpose | Examples |
|-------|---------|----------|
| **Domain** | Entities, Repository Interfaces, Use Cases (PURE DART - no Flutter) | `User`, `IUserRepository`, `GetUserUseCase` |
| **Data** | Repository implementations, Models (JSON), Data sources (API/Local) | `UserRepository`, `UserModel`, `RemoteUserDataSource` |
| **Presentation** | Widgets, Pages, BLoCs/Cubits (State Management) | `UserListPage`, `UserBloc`, `UserWidget` |
| **Core** | App-wide utilities, constants, themes, extensions | `ApiEndpoints`, `AppTheme`, `DateUtils` |

**RULE:** Domain layer MUST NOT import Flutter packages. Keep business logic pure.

---

## 2. CORE CODING PRINCIPLES

### 2.1 ZERO HARD-CODING TOLERANCE

**❌ STRICTLY PROHIBITED:**
```csharp
// BAD - Hard-coded values
if (user.Role == "SuperAdmin") { }
var timeout = 30000;
var apiUrl = "https://api.example.com";
```

```dart
// BAD - Hard-coded strings
if (userRole == "ADMIN") {}
final timeout = Duration(seconds: 30);
```

**✅ MANDATORY APPROACH:**
```csharp
// GOOD - Use constants
if (user.Role == RoleConstants.SUPER_ADMIN) { }
var timeout = TimeoutConstants.API_REQUEST_TIMEOUT_MS;
var apiUrl = ApiEndpoints.BASE_URL;
```

```dart
// GOOD - Use constants
if (userRole == RoleConstants.ADMIN) {}
final timeout = TimeoutConstants.API_REQUEST_TIMEOUT;
```

**RULE:** Every literal that could change MUST be extracted to a constant. No exceptions.

### 2.2 DRY PRINCIPLE (Don't Repeat Yourself)

- **Eliminate duplicate code** through inheritance, composition, or utility functions
- **Create reusable services** for common operations
- **Use base classes** for shared behavior in controllers/pages

### 2.3 SOLID PRINCIPLES

- **S**ingle Responsibility: One class = one reason to change
- **O**pen/Closed: Open for extension, closed for modification
- **L**iskov Substitution: Subtypes must be substitutable for base types
- **I**nterface Segregation: Many specific interfaces > one fat interface
- **D**ependency Inversion: Depend on abstractions, not concretions

---

## 3. NAMING CONVENTIONS & FILE ORGANIZATION

### 3.1 File Naming: KEBAB-CASE (UNIVERSAL - CRITICAL RULE)

🚨 **CRITICAL ENFORCEMENT RULE:** ALL filenames MUST be lowercase kebab-case with NO EXCEPTIONS.

**ALL filenames across the workspace MUST use lowercase kebab-case:**

```
✅ user-service.cs                      (Filename: kebab-case)
✅ user-controller.cs                   (Filename: kebab-case)
✅ user-service.dart                    (Filename: kebab-case)
✅ github-repo-description.md           (Filename: lowercase kebab-case)
✅ comprehensive-project-plan.md        (Filename: lowercase kebab-case)
✅ validation-error-messages.md         (Documentation)
✅ error-codes.json
✅ README.md                            (Standard - exception)
✅ LICENSE                              (Standard - exception)

❌ UserService.cs                       (FORBIDDEN - uppercase)
❌ GITHUB_REPO_DESCRIPTION.md           (FORBIDDEN - uppercase)
❌ COMPREHENSIVE-PROJECT-PLAN.md        (FORBIDDEN - uppercase)
❌ user_service.cs                      (FORBIDDEN - snake_case)
❌ user_service.dart                    (FORBIDDEN for public packages - use kebab-case)
❌ User-Service.cs                      (FORBIDDEN - mixed casing)
```

**Critical Details:**
- **Filenames:** Always lowercase kebab-case (NEVER UPPERCASE, NEVER mixed case)
- **Class Names:** Always PascalCase in C#, PascalCase in Dart (class name ≠ filename)
- **No uppercase in filenames ever** - not even for acronyms (e.g., `api-endpoints.cs` NOT `API-Endpoints.cs`)
- **No mixed casing** - not even readable names like `GitHub` should be `github-repo-description.md`

**Distinction:**
```csharp
// Filename: user-service.cs (lowercase kebab-case)
// Class Name Inside:
public class UserService  // PascalCase - NOT kebab-case
{
    public async Task<UserDto> GetUserByIdAsync(int userId)
    {
        // ...
    }
}
```

**ENFORCEMENT:** Any PR with non-kebab-case filenames (including uppercase) will be rejected. This rule applies to ALL files across the project.

### 3.2 Backend (.NET) - Naming Conventions

| Element | Convention | Example | Notes |
|---------|-----------|---------|-------|
| **File** | kebab-case | `user-service.cs`, `user-controller.cs` | Filename only - NOT the class name |
| **Class** | PascalCase | `UserService`, `IUserRepository` | **Class name** - different from filename |
| **Folder** | kebab-case | `request-handlers/`, `repositories/` | |
| **Method** | PascalCase | `GetUserByIdAsync`, `CreateUser` | Async methods end with `Async` |
| **Property** | PascalCase | `FirstName`, `IsActive` | Boolean properties start with `Is`, `Has` |
| **Field (Private)** | _camelCase | `_unitOfWork`, `_logger` | Start with underscore |
| **Parameter** | camelCase | `userId`, `userName` | |
| **Constant** | SCREAMING_SNAKE_CASE | `MAX_PAGE_SIZE`, `API_TIMEOUT_MS` | All caps with underscores |
| **Variable (Local)** | camelCase | `userData`, `isValid` | |

**Key Point:** Filename (`user-service.cs`) ≠ Class Name (`class UserService`)

### 3.3 Frontend (Flutter/Dart) - Naming Conventions

| Element | Convention | Example | Notes |
|---------|-----------|---------|-------|
| **Class** | PascalCase | `UserService`, `UserListPage`, `IUserRepository` | |
| **File** | snake_case (local) OR kebab-case (global) | `user_service.dart` OR `user-service.dart` | Use kebab-case in public packages |
| **Variable/Function** | camelCase | `userName`, `getUserById()` | |
| **Constant** | SCREAMING_SNAKE_CASE | `MAX_FILE_SIZE`, `DEFAULT_TIMEOUT` | |
| **Private members** | _camelCase | `_userRepository`, `_fetchData()` | Leading underscore for private |
| **Getter/Setter** | camelCase | `get userName`, `set age` | |
| **Enum values** | camelCase | `enum Status { active, inactive }` | |

**RULE FOR DART FILES:** Prefer kebab-case for public APIs, snake_case acceptable internally. Be consistent per project.

### 3.4 Folder Structure: kebab-case

```
✅ docs/00-getting-started/
✅ server/Application/Common/Constants/
✅ client/shared/core/lib/constants/
✅ docs/04-validation-system/
❌ docs/00GettingStarted/    (FORBIDDEN)
❌ docs/00_getting_started/  (FORBIDDEN)
```

---

## 4. CONSTANTS ORGANIZATION

All magic values, endpoints, timeouts, and configuration MUST be centralized in constants files.

### 4.1 Backend (.NET)

**Location:** `server/Application/Common/Constants/`

```csharp
// api-endpoints.cs
public static class ApiEndpoints
{
    public const string BASE_URL = "https://api.grrado.com";
    public const string USERS_ENDPOINT = "/api/v1/users";
    public const string VEHICLES_ENDPOINT = "/api/v1/vehicles";
}

// auth-constants.cs
public static class AuthConstants
{
    public const string JWT_SECRET = ""; // Set via configuration
    public const string SUPER_ADMIN_ROLE = "SuperAdmin";
    public const string ADMIN_ROLE = "Admin";
    public const string USER_ROLE = "User";
}

// error-codes.cs
public static class ErrorCodes
{
    // User Validation (USER_001-015)
    public const string USER_NAME_REQUIRED = "USER_001";
    public const string USER_EMAIL_REQUIRED = "USER_003";
    public const string USER_NOT_FOUND = "USER_015";
    
    // Generic
    public const string VALIDATION_FAILED = "GEN_002";
    public const string UNAUTHORIZED = "GEN_003";
}

// timeout-constants.cs
public static class TimeoutConstants
{
    public const int API_REQUEST_TIMEOUT_MS = 30000;  // 30 seconds
    public const int DATABASE_COMMAND_TIMEOUT_S = 60; // 60 seconds
}
```

### 4.2 Frontend (Flutter)

**Location:** `client/shared/core/lib/constants/`

```dart
// api_endpoints.dart
class ApiEndpoints {
  static const String BASE_URL = 'https://api.grrado.com';
  static const String USERS_ENDPOINT = '/api/v1/users';
  static const String VEHICLES_ENDPOINT = '/api/v1/vehicles';
}

// auth_constants.dart
class AuthConstants {
  static const String SUPER_ADMIN_ROLE = 'SuperAdmin';
  static const String ADMIN_ROLE = 'Admin';
  static const String USER_ROLE = 'User';
}

// error_codes.dart
class ErrorCodes {
  // User validation
  static const String USER_NAME_REQUIRED = 'USER_001';
  static const String USER_EMAIL_REQUIRED = 'USER_003';
  static const String USER_NOT_FOUND = 'USER_015';
  
  // Generic
  static const String VALIDATION_FAILED = 'GEN_002';
  static const String UNAUTHORIZED = 'GEN_003';
}

// timeout_constants.dart
class TimeoutConstants {
  static const Duration API_REQUEST_TIMEOUT = Duration(seconds: 30);
  static const Duration DATABASE_TIMEOUT = Duration(seconds: 60);
}
```

**RULE:** Never use magic numbers/strings in code. Always reference a constant.

---

## 5. LOGGING & CORRELATION ID (MANDATORY)

Every request MUST be traceable through the entire system using Correlation IDs.

### 5.1 Correlation ID Flow

- **Format:** `yyyyMMddHHmmss-{GUID}` (e.g., `20260131143025-a1b2c3d4-e5f6-7890-abcd-ef1234567890`)
- **Generation:** `CorrelationIdMiddleware` in Backend generates on request entry
- **Propagation:** Included in all logs and passed to downstream services
- **Frontend:** Must include `X-Correlation-ID` header in all API calls

### 5.2 Structured Logging Standard

```csharp
// Backend (.NET) - Using ILogger
_logger.LogInformation(
    "User {UserId} logged in. CorrelationId: {CorrelationId}",
    userId,
    correlationId
);

_logger.LogError(
    "Failed to fetch vehicle {VehicleId}. CorrelationId: {CorrelationId}. Error: {Error}",
    vehicleId,
    correlationId,
    exception.Message
);
```

```dart
// Frontend (Flutter) - Using custom logger
logger.info(
  'User login successful',
  extra: {
    'userId': userId,
    'correlationId': correlationId,
  },
);

logger.error(
  'API request failed',
  error: exception,
  stackTrace: stackTrace,
  extra: {
    'correlationId': correlationId,
    'endpoint': endpoint,
  },
);
```

**RULE:** Every significant operation MUST log with Correlation ID. Include error context for debugging.

---

## 6. BACKEND STANDARDS (.NET 9)

### 6.1 Code Organization

```
server/
├── Domain/                          # Enterprise rules
│   ├── Entities/
│   │   ├── user.cs                 # Entity class (PascalCase class, kebab-case file)
│   │   └── vehicle.cs
│   └── Interfaces/
│       ├── i-user-repository.cs
│       └── i-vehicle-repository.cs
├── Application/                     # Business logic & DTOs
│   ├── Common/
│   │   └── Constants/
│   │       ├── api-endpoints.cs
│   │       ├── auth-constants.cs
│   │       └── error-codes.cs
│   ├── DTOs/
│   │   ├── user-dto.cs
│   │   └── create-user-request.cs
│   └── Services/
│       ├── user-service.cs
│       └── vehicle-service.cs
├── Infrastructure/                  # Data persistence
│   ├── Repositories/
│   │   ├── user-repository.cs
│   │   └── vehicle-repository.cs
│   └── Data/
│       └── database-context.cs
├── API/                             # REST entry point
│   ├── Controllers/
│   │   ├── users-controller.cs
│   │   └── vehicles-controller.cs
│   └── Middleware/
│       └── correlation-id-middleware.cs
└── Utility/                         # Shared utilities
    ├── logging-service.cs
    └── extensions.cs
```

### 6.2 Database Naming

- **Tables:** snake_case (PostgreSQL convention)
  ```sql
  CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(100) NOT NULL,
    email_address VARCHAR(255) NOT NULL
  );
  ```
- **Columns:** snake_case
- **Constraints:** `pk_table_name`, `fk_table_name_reference`
- **Indexes:** `idx_table_name_column`

### 6.3 Repository Pattern

```csharp
// Domain/Interfaces/i-user-repository.cs
public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<bool> DeleteAsync(int id);
}

// Infrastructure/Repositories/user-repository.cs
public class UserRepository : IUserRepository
{
    private readonly IDbContext _context;
    
    public async Task<User?> GetByIdAsync(int id) 
        => await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    
    // Implementation...
}
```

**RULE:** Always use interfaces for repositories. Depend on abstractions, not implementations.

### 6.4 Async/Await

- **MANDATORY:** All I/O operations (database, HTTP) MUST be async
- **Naming:** Methods with async operations end with `Async`
  ```csharp
  public async Task<User> GetUserAsync(int id) // ✅ Async method
  public User GetUser(int id)                    // ❌ Sync method (database call is async)
  ```

### 6.5 Error Handling

- **Use Result Pattern:** Return `Result<T>` instead of throwing exceptions
  ```csharp
  public async Task<Result<UserDto>> GetUserAsync(int userId)
  {
      var user = await _userRepository.GetByIdAsync(userId);
      if (user == null)
          return Result<UserDto>.Failure(ErrorCodes.USER_NOT_FOUND);
      
      return Result<UserDto>.Success(_mapper.Map<UserDto>(user));
  }
  ```
- **Exception logging:** Only log exceptions for unexpected errors
- **Client errors (4xx):** Return error codes, not exceptions

---

## 7. FRONTEND STANDARDS (FLUTTER/DART)

### 7.1 Project Structure

```
client/
├── consumer/                        # Consumer app
│   ├── lib/
│   │   ├── main.dart
│   │   ├── domain/
│   │   │   ├── entities/
│   │   │   │   └── user.dart       # Entity (PascalCase class)
│   │   │   ├── repositories/
│   │   │   │   └── i-user-repository.dart
│   │   │   └── use_cases/
│   │   │       └── get_user_use_case.dart
│   │   ├── data/
│   │   │   ├── datasources/
│   │   │   │   └── user_remote_data_source.dart
│   │   │   ├── models/
│   │   │   │   └── user_model.dart
│   │   │   └── repositories/
│   │   │       └── user_repository.dart
│   │   ├── presentation/
│   │   │   ├── bloc/
│   │   │   │   ├── user_bloc.dart
│   │   │   │   └── user_event.dart
│   │   │   └── pages/
│   │   │       └── user_list_page.dart
│   │   └── core/
│   │       ├── constants/
│   │       │   ├── api_endpoints.dart
│   │       │   └── error_codes.dart
│   │       ├── theme/
│   │       └── extensions/
│   └── pubspec.yaml
└── shared/                         # Shared across apps
    └── core/
        ├── lib/constants/
        │   ├── api-endpoints.dart
        │   └── error-codes.dart
        └── pubspec.yaml
```

### 7.2 State Management: BLoC Pattern

```dart
// bloc/user_bloc.dart
class UserBloc extends Bloc<UserEvent, UserState> {
  final GetUserUseCase getUserUseCase;
  
  UserBloc({required this.getUserUseCase}) : super(UserInitial()) {
    on<FetchUserEvent>(_onFetchUser);
  }
  
  Future<void> _onFetchUser(FetchUserEvent event, Emitter<UserState> emit) async {
    emit(UserLoading());
    
    final result = await getUserUseCase(event.userId);
    result.fold(
      (failure) => emit(UserError(failure.message)),
      (user) => emit(UserLoaded(user)),
    );
  }
}
```

**RULE:** Keep business logic OUT of widgets. Use BLoCs/Cubits for state management.

### 7.3 Widget Best Practices

```dart
// GOOD - Composition & const constructors
class UserCard extends StatelessWidget {
  final User user;
  
  const UserCard({Key? key, required this.user}) : super(key: key);
  
  @override
  Widget build(BuildContext context) {
    return Card(
      color: Theme.of(context).cardColor,  // ✅ Use theme, no hard-coding
      child: Column(
        children: [
          UserAvatar(user: user),
          UserInfo(user: user),
        ],
      ),
    );
  }
}

// BAD - Large monolithic widget
class UserCard extends StatelessWidget {
  final User user;
  
  const UserCard({Key? key, required this.user}) : super(key: key);
  
  @override
  Widget build(BuildContext context) {
    return Card(
      color: Color(0xFF2196F3),  // ❌ Hard-coded color
      child: Column(
        children: [
          CircleAvatar(child: Text(user.name)),  // ❌ Logic mixed with UI
          Text(user.email, style: TextStyle(color: Color(0xFF000000))),
          // ... 200 more lines
        ],
      ),
    );
  }
}
```

### 7.4 JSON Serialization

```dart
// models/user_model.dart
class UserModel {
  final int id;
  final String name;
  final String email;
  
  UserModel({
    required this.id,
    required this.name,
    required this.email,
  });
  
  factory UserModel.fromJson(Map<String, dynamic> json) {
    return UserModel(
      id: json['id'] as int,
      name: json['name'] as String,
      email: json['email'] as String,
    );
  }
  
  Map<String, dynamic> toJson() => {
    'id': id,
    'name': name,
    'email': email,
  };
}
```

### 7.5 HTTP Client

```dart
// domain/repositories/i-user-repository.dart
abstract class IUserRepository {
  Future<Result<User>> getUser(int id);
  Future<Result<List<User>>> getAllUsers();
}

// data/repositories/user_repository.dart
class UserRepository implements IUserRepository {
  final HttpClient httpClient;
  
  @override
  Future<Result<User>> getUser(int id) async {
    try {
      final response = await httpClient.get(
        '${ApiEndpoints.BASE_URL}${ApiEndpoints.USERS_ENDPOINT}/$id',
        headers: {
          'X-Correlation-ID': _generateCorrelationId(),
          'Content-Type': 'application/json',
        },
      ).timeout(TimeoutConstants.API_REQUEST_TIMEOUT);
      
      if (response.statusCode == 200) {
        final user = UserModel.fromJson(jsonDecode(response.body)).toEntity();
        return Result<User>.success(user);
      } else {
        return Result<User>.failure('Failed to fetch user');
      }
    } on TimeoutException {
      return Result<User>.failure('Request timeout');
    } catch (e) {
      return Result<User>.failure('Error: $e');
    }
  }
}
```

---

## 8. VALIDATION & ERROR HANDLING

### 8.1 Error Code Categories

All error codes follow the pattern: `{CATEGORY}_{NUMBER}`

| Category | Range | Purpose | Examples |
|----------|-------|---------|----------|
| USER | 001-015 | User validation & business rules | USER_001 (Name required), USER_015 (Not found) |
| VEHICLE | 001-010 | Vehicle validation | VEHICLE_001 (Brand required), VEHICLE_004 (Not found) |
| GARAGE | 001-010 | Garage validation | GARAGE_001 (Name required), GARAGE_003 (Not found) |
| SERVICE | 001-010 | Service validation | SERVICE_001 (Name required), SERVICE_003 (Not found) |
| PAGE | 001-003 | Pagination validation | PAGE_001 (Invalid page number) |
| GEN | 001-010 | Generic errors | GEN_001 (Operation failed), GEN_003 (Unauthorized) |

**Database Location:** `docs/01-requirements/error-codes.json`

### 8.2 Validation Pattern (.NET)

```csharp
// Application/DTOs/create-user-request.cs
public class CreateUserRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
}

// Application/Validators/create-user-validator.cs
public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public CreateUserValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithErrorCode(ErrorCodes.USER_NAME_REQUIRED)
            .MaximumLength(100)
            .WithErrorCode(ErrorCodes.USER_NAME_MAX_LENGTH);

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithErrorCode(ErrorCodes.USER_EMAIL_REQUIRED)
            .EmailAddress()
            .WithErrorCode(ErrorCodes.USER_EMAIL_INVALID);
    }
}
```

### 8.3 Error Response Format

**REST API Response:**
```json
{
  "success": false,
  "errorCode": "USER_001",
  "message": "Name is required",
  "data": null,
  "validationErrors": [
    {
      "code": "USER_001",
      "message": "Name is required",
      "propertyName": "Name"
    }
  ]
}
```

### 8.4 Database-Driven Error Messages

- Error messages are stored in database with support for internationalization
- Fallback to default message if localized version not found
- Cached for 24 hours to reduce database queries
- See `docs/04-validation-system/validation-error-messages.md` for implementation details

---

## 9. DOCUMENTATION STANDARDS

### 9.1 Code Comments

- **Classes:** Must have XML documentation (`///` in C#, `///` in Dart)
  ```csharp
  /// <summary>
  /// Manages user creation, retrieval, and deletion operations.
  /// </summary>
  public class UserService
  {
  }
  ```

- **Public methods:** Must have documentation
  ```csharp
  /// <summary>
  /// Retrieves a user by their unique identifier.
  /// </summary>
  /// <param name="userId">The unique user ID</param>
  /// <returns>The user if found; otherwise null</returns>
  public async Task<User?> GetUserAsync(int userId)
  {
  }
  ```

- **Complex logic:** Explain WHY, not WHAT
  ```csharp
  // ✅ GOOD - Explains reasoning
  // Cache for 24 hours because user roles don't change frequently
  var cachedUser = await _cache.GetAsync(cacheKey);
  
  // ❌ BAD - Obvious from code
  // Get user from cache
  var cachedUser = await _cache.GetAsync(cacheKey);
  ```

### 9.2 Markdown Files

- **Use kebab-case filenames:** ✅ `setup-guide.md`, ❌ `SetupGuide.md`
- **Include table of contents** for files >500 words
- **Use consistent heading levels:** H1 for title, H2 for sections, H3 for subsections
- **Include code examples** with language specification
- **Link to source:** Reference actual file paths when relevant

---

## 10. VERSIONING & CHANGELOG

### 10.1 Semantic Versioning
The project follows [Semantic Versioning](https://semver.org/):

```
MAJOR.MINOR.PATCH (e.g., 1.2.3)
  │      │      └─ Fix (backward compatible) — increment on bug fixes
  │      └────── Feature (backward compatible) — increment on new features
  └───────────── Breaking Change — increment on breaking API changes
```

**Version bump text format: LOWERCASE (major/minor/patch)**
```
❌ REJECTED: "Proposed: MAJOR (0.1.0 → 1.0.0)"
✅ APPROVED: "Proposed: major (0.1.0 → 1.0.0)"
```

**Examples:**
- `0.0.1` → `0.0.2` (patch: bug fix)
- `0.0.2` → `0.1.0` (minor: new feature)
- `0.1.0` → `1.0.0` (major: breaking change)

### 10.2 Changelog Directory Structure

**Changelog files are organized by date in:** `docs/changelogs/`

**File naming format:** `ddmmyyyy.<sequence>`
- `dd` = Day (01-31)
- `mm` = Month (01-12)
- `yyyy` = Year (2026)
- `<sequence>` = Sequential number (001, 002, etc.)

**Examples:**
- `31012026.001` — January 31, 2026, first entry
- `31012026.002` — January 31, 2026, second entry
- `01022026.001` — February 1, 2026, first entry

**Directory structure:**
```
docs/06-changelogs/
├── changelog.01022026.001    ← Master changelog (aggregates all released versions)
└── (PR entries are merged here from changelogs folder)
```

**Master changelog naming:** `changelog.ddmmyyyy.<sequence>`
- Follows same format as individual PR entries
- Located at: `docs/06-changelogs/changelog.ddmmyyyy.<sequence>`
- Contains aggregated entries from merged PRs
- Created on initial release and updated when changelog is aggregated

**Individual PR changelog entries:**
Located in temporary working directory (e.g., `docs/changelogs-temp/`) before merging into master changelog.

### 10.3 Changelog Entry Format

**Each file in `docs/changelogs/ddmmyyyy.<sequence>` contains:**

```markdown
## [Version Number] - YYYY-MM-DD

### Category (Added/Changed/Fixed/Removed/Deprecated)
- Brief description of the change
- Additional detail if relevant

### Version Bump
**Proposed:** major/minor/patch (X.Y.Z → X.Y.Z)
**Reason:** Why this version bump was chosen
```

**Example file: `docs/changelogs/31012026.001`**
```markdown
## [0.1.0] - 2026-01-31

### Added
- Keycloak JWT validation for user authentication
- Correlation ID tracking on all API endpoints
- User service with async operations

### Version Bump
**Proposed:** minor (0.0.1 → 0.1.0)
**Reason:** New features, backward compatible
```

### 10.4 PR Changelog Entry Process

**For developers creating PRs:**
1. Create file: `docs/changelogs/ddmmyyyy.<sequence>`
2. Add entry with category, description, and version bump
3. Use **lowercase** for version bump text: major/minor/patch
4. Include in PR description:
   ```markdown
   ## Changelog
   See: [docs/changelogs/31012026.001](docs/changelogs/31012026.001)
   ```

**For reviewers merging PRs:**
1. Verify changelog file exists in `docs/changelogs/`
2. Verify version bump is appropriate (see 10.5)
3. Update master `docs/changelog.md` with aggregated entry
4. Create git tag: `git tag v0.1.0`
5. Merge the PR

### 10.5 Version Bump Guidelines

| Change Type | Bump | Example |
|------------|------|---------|
| Bug fix only | patch | 0.1.0 → 0.1.1 |
| New feature(s), backward compatible | minor | 0.1.0 → 0.2.0 |
| Breaking API change, database schema change | major | 0.1.0 → 1.0.0 |
| Multiple features + bug fixes | minor | 0.1.0 → 0.2.0 |
| Multiple breaking changes | major | 0.1.0 → 1.0.0 |

---

## 11. ENFORCEMENT & CODE REVIEW

All code MUST comply with these standards. Code review is MANDATORY.

### 11.1 Automated Enforcement (Git Hooks)

**Three-layer enforcement system active** — See [PR-CHECKLIST-ENFORCEMENT.md](PR-CHECKLIST-ENFORCEMENT.md)

| Layer | When | Tool | Action |
|-------|------|------|--------|
| **Pre-Commit** | Before `git commit` | `.git/hooks/pre-commit` | Blocks commits with violations |
| **Pre-Push** | Before `git push` | `.git/hooks/pre-push` | Warns before GitHub push |
| **Code Review** | PR submitted | Manual review | Final approval gate |

### 11.2 Pre-Commit Hook Checks

Runs BEFORE commit creation. **BLOCKS commit if violations found:**

- ❌ Hard-coded literals (strings, numbers)
- ❌ File naming not kebab-case
- ❌ Async methods without `Async` suffix
- ⚠️ Missing documentation on public members (warning only)
- ⚠️ Secrets detected (warning only)

**Command to bypass (NOT RECOMMENDED):**
```bash
git commit --no-verify  # Skips hook - code review will catch this
```

### 11.3 Pre-Push Hook Checks

Runs BEFORE push to GitHub. **Warns before pushing:**

- ⚠️ No WIP/TEMP/DEBUG commits
- ⚠️ Changelog entry exists
- ⚠️ Commit messages follow conventions

### 11.4 Mandatory PR Checklist

**File:** [docs/pr-checklist.md](../../docs/pr-checklist.md)

All PRs MUST include checklist and pass **7 automatic rejection criteria:**

1. ✅ **No Hard-Coded Values** — All literals in Constants
2. ✅ **Kebab-Case Files** — All filenames use kebab-case
3. ✅ **Clean Architecture Layer** — Code in correct layer only
4. ✅ **Async Suffix** — All async methods end with `Async`
5. ✅ **XML Documentation** — Public members documented
6. ✅ **Error Codes** — Using ErrorCodes constants
7. ✅ **Correlation ID Logging** — Public endpoints log Correlation ID

**PRs violating these criteria are REJECTED WITHOUT REVIEW.**

### 11.5 Code Review Process

**Green Path (Auto-Approval):**
- All checklist items ✅
- No violation criteria broken
- Tests passing
- → **APPROVED in <15 min**

**Yellow Path (Feedback Required):**
- Minor issues in checklist items
- Fixable violations
- → **REQUEST CHANGES** → Developer fixes → Re-review

**Red Path (Rejection):**
- Auto-rejection criteria violated
- Major architectural issues
- → **REJECT** → Cannot merge until fixed

---

## 12. QUICK REFERENCE: Common Violations & Fixes

| Violation | Example | Fix |
|-----------|---------|-----|
| **Hard-coded string** | `if (role == "Admin")` | Use `RoleConstants.ADMIN` |
| **Hard-coded timeout** | `timeout = 5000` | Use `TimeoutConstants.API_TIMEOUT_MS` |
| **Wrong layer** | Business logic in controller | Move to service/use case |
| **Missing Async** | `public Task<User> GetUser()` | Change to `GetUserAsync()` |
| **Bad filename** | `UserService.cs` | Rename to `user-service.cs` |
| **No error code** | `throw new Exception("Error")` | Return `Result.Failure(ErrorCode.CONSTANT)` |
| **Hard-coded color** | `Color(0xFF2196F3)` | Use `Theme.of(context).primaryColor` |

---

## 13. RELATED DOCUMENTATION

- **PR Checklist & Enforcement:** [PR-CHECKLIST-ENFORCEMENT.md](PR-CHECKLIST-ENFORCEMENT.md) ⭐ **START HERE**
- **PR Checklist & Code Review:** [docs/pr-checklist.md](../../docs/pr-checklist.md)
- **Git Hooks Setup:** [PR-CHECKLIST-ENFORCEMENT.md](PR-CHECKLIST-ENFORCEMENT.md#-setting-up-git-hooks-locally)
- **Changelog:** [docs/06-changelogs/changelog.01022026.001](../../docs/06-changelogs/changelog.01022026.001)
- **Full Validation Guide:** [docs/05-validation-system/validation-error-messages.md](../../docs/05-validation-system/validation-error-messages.md)
- **API Documentation:** [docs/00-getting-started/how-to-run-and-test-api.md](../../docs/00-getting-started/how-to-run-and-test-api.md)
- **Project Structure:** [docs/00-getting-started/02-folder-structure.md](../../docs/00-getting-started/02-folder-structure.md)
- **Build Status:** [docs/build-verification.md](../../docs/build-verification.md)

---

**Last Review:** February 1, 2026  
**Maintained By:** GRRADO Development Team  
**Enforcement Date:** Active - All new code must comply with v2.0 + enforcement system
