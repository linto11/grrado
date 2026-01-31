# Coding Standards & Best Practices
## Vehicle Service Portal - Universal Development Rulebook

**Document Version:** 1.1  
**Last Updated:** January 18, 2026  
**Applies To:** All developers, AI assistants  
**Status:** ✅ **MANDATORY** - All code must follow these standards

---

## 🏗️ 1. ARCHITECTURAL PRINCIPLE: CLEAN ARCHITECTURE

All projects (Backend & Frontend) MUST follow **Clean Architecture** principles to ensure separation of concerns, testability, and maintainability.

### 🧩 1.1 Backend (.NET 9) Layers
1. **Domain:** Enterprise business rules (Entities, Value Objects, Logic). NO dependencies.
2. **Application:** Application business rules (Use Cases/Commands/Queries, DTO mappings). Depends on Domain.
3. **Infrastructure:** Data persistence (EF Core), external APIs (Keycloak, Azure AI), caching (Redis). Depends on Application.
4. **API:** Web API controllers, middleware, configuration. Entry point.
5. **Utility:** Cross-cutting concerns (Logging infrastructure). Shared by all.

### 🧩 1.2 Frontend (Flutter) Layers
Each Flutter app or shared package must follow this internal structure:
1. **Domain:** Entities, Repository Interfaces, Use Cases. PURE DART (no Flutter widgets).
2. **Data:** Repository implementations, Models (JSON), Data sources (API/Local).
3. **Presentation:** Widgets, Pages, Blocs/Cubits (State Management).
4. **Core:** App-wide utilities, constants, themes.

---

## 🎯 2. CORE PRINCIPLE: NO HARD-CODING

### Zero Tolerance Policy

**❌ NEVER write literal values in code:**
```dart
// BAD - Hard-coded
if (user.role == "SuperAdmin") { }
final timeout = 30000;
final apiUrl = "https://api.example.com";
```

**✅ ALWAYS use constants:**
```dart
// GOOD - Use constants
if (user.role == RoleConstants.SUPER_ADMIN) { }
final timeout = TimeoutConstants.API_REQUEST_TIMEOUT_MS;
final apiUrl = ApiEndpoints.BASE_URL;
```

**Rule:** If you type a literal value that could change, STOP and create a constant.

---

## 📂 3. CONSTANTS ORGANIZATION

### Backend (.NET)
`app/server/Application/Common/Constants/`
- `ApiEndpoints.cs`
- `AuthConstants.cs`
- `ErrorCodes.cs`
- `RoleConstants.cs`
- `TimeoutConstants.cs`

### Frontend (Flutter)
`app/client/shared/core/lib/constants/` (Shared constants)
- `api_endpoints.dart`
- `auth_constants.dart`
- `error_codes.dart`
- `role_constants.dart`

---

## 🔤 4. NAMING CONVENTIONS

### 4.1 Backend (.NET Specific)
- **Classes/Interfaces:** PascalCase (`UserService`, `IUserRepository`)
- **Methods:** PascalCase (`GetUserByIdAsync`)
- **Private fields:** _camelCase (`_unitOfWork`)
- **Parameters:** camelCase (`userId`)

### 4.2 Frontend (Flutter/Dart Specific)
- **Files/Folders:** snake_case (`user_service.dart`, `vehicle_list_page.dart`)
- **Classes:** PascalCase (`UserService`, `VehicleListPage`)
- **Variables/Functions:** camelCase (`userName`, `getUserById`)
- **Constants:** SCREAMING_SNAKE_CASE (`MAX_FILE_SIZE`)
- **Private members:** `_camelCase` with leading underscore

---

## 🛡️ 5. LOGGING & CORRELATION ID (MANDATORY)

### 5.1 Correlation ID Flow
- Every request must have a Correlation ID: `yyyyMMddHHmmss-{GUID}`.
- Handled by `CorrelationIdMiddleware` in Backend.
- Flutter apps must include `X-Correlation-ID` header in all API calls.

### 5.2 Logging Standard
- Use structured logging.
- Include Correlation ID in all logs.
- Log significant state changes and errors.

---

## 🤖 6. AI ASSISTANT INSTRUCTIONS

When generating code:
1. **Verify Layers:** Ensure code is placed in the correct Clean Architecture layer.
2. **Check Constants:** Search for existing constants before creating new ones.
3. **No Literals:** Never use hard-coded strings/numbers unless they are primitive math defaults (0, 1).
4. **Dart/Flutter Docs:** Use proper documentation comments (`///`) for all public classes and methods.

---

## 📝 7. FLUTTER SPECIFIC STANDARDS

### 7.1 State Management
- Use **Bloc** (Cubit specifically) for state management.
- Keep UI separate from logic. No logic in `build` methods.

### 7.2 Widget Composition
- Prefer **Composition** over inheritance.
- Break down large widgets into smaller, reusable components.
- Use `const` constructors wherever possible.

### 7.3 Styling
- Use **ThemeData** for global styling.
- No hard-coded colors or font sizes in widgets. Use `Theme.of(context)`.

---

## 🎯 8. ENFORCEMENT
Violations of these standards will result in PR rejection. Consistency across the unified Flutter frontend and .NET backend is critical for the success of GRRADO.

