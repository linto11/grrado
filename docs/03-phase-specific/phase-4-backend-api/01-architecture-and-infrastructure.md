# Backend Architecture & Infrastructure

**Last Updated:** January 25, 2026  
**Status:** Phase 4 Backend (Extended for Chatbot) - 55% Complete  
**Strategic Focus:** Portal APIs + Chatbot Database Infrastructure

---

## 📁 Project Structure

### Server Structure (Clean Architecture)

```
app/server/
├── API/                                    # HTTP Layer & Entry Point
│   ├── Controllers/                        # REST API endpoints (pending)
│   ├── Middleware/
│   │   └── CorrelationIdMiddleware.cs     # Request tracking across layers
│   ├── Properties/
│   │   └── launchSettings.json            # Dev environment config
│   ├── appsettings.json                   # Production config with Serilog
│   ├── appsettings.Development.json       # Development config with Serilog
│   ├── Program.cs                         # Startup & DI configuration
│   └── API.csproj
│
├── Application/                            # Business Logic Layer
│   ├── Mapping/
│   │   └── DomainToDtoProfile.cs          # AutoMapper entity<->DTO mappings
│   ├── Services/                          # Business services (pending)
│   ├── DependencyInjection.cs             # Application layer DI registration
│   └── Application.csproj
│
├── Abstractions/                           # Interfaces & Contracts
│   ├── DTOs/                              # Data Transfer Objects
│   │   ├── BaseDto.cs                     # Base request/response classes
│   │   ├── User/UserDtos.cs               # User CRUD DTOs
│   │   ├── Vehicle/VehicleDtos.cs         # Vehicle CRUD DTOs
│   │   ├── Garage/GarageDtos.cs           # Garage CRUD DTOs
│   │   ├── Service/ServiceDtos.cs         # Service CRUD DTOs
│   │   ├── ServiceHistory/ServiceHistoryDtos.cs
│   │   ├── VehicleIssue/VehicleIssueDtos.cs
│   │   ├── DiagnosticRule/DiagnosticRuleDtos.cs
│   │   ├── ImageDiagnostic/ImageDiagnosticDtos.cs
│   │   ├── ChatbotConversation/            # 🤖 NEW - Chatbot conversation
│   │   │   ├── ChatbotConversationDto.cs
│   │   │   ├── CreateChatbotConversationRequest.cs
│   │   │   └── UpdateChatbotConversationRequest.cs
│   │   ├── ChatbotMessage/                 # 🤖 NEW - Chatbot messages
│   │   │   ├── ChatbotMessageDto.cs
│   │   │   ├── CreateChatbotMessageRequest.cs
│   │   │   └── UpdateChatbotMessageRequest.cs
│   │   ├── ChatbotKnowledgeBase/            # 🤖 NEW - Knowledge base Q&A
│   │   │   ├── ChatbotKnowledgeBaseDto.cs
│   │   │   ├── CreateChatbotKnowledgeBaseRequest.cs
│   │   │   └── UpdateChatbotKnowledgeBaseRequest.cs
│   │   ├── AiImageAnalysis/                 # 🤖 NEW - Vision API results
│   │   │   ├── AiImageAnalysisDto.cs
│   │   │   ├── CreateAiImageAnalysisRequest.cs
│   │   │   └── UpdateAiImageAnalysisRequest.cs
│   │   └── AiUsageLog/                      # 🤖 NEW - AI service usage tracking
│   │       ├── AiUsageLogDto.cs
│   │       ├── CreateAiUsageLogRequest.cs
│   │       └── UpdateAiUsageLogRequest.cs
│   ├── Persistence/
│   │   ├── IRepository.cs                 # Generic repository interface
│   │   └── IUnitOfWork.cs                 # Transaction management interface
│   ├── Integration/
│   │   ├── IImageService.cs               # Image processing interface
│   │   ├── ITimezoneService.cs            # Timezone conversion interface
│   │   └── Keycloak/                      # Keycloak authentication
│   │       ├── IKeycloakService.cs        # Keycloak HTTP client interface
│   │       ├── IJwtTokenValidator.cs      # JWT validation interface
│   │       ├── IUserContext.cs            # User claims interface
│   │       ├── KeycloakUserInfo.cs        # User info model
│   │       └── UserTokenInfo.cs           # Token info model
│   └── Abstractions.csproj
│
├── Infrastructure/                         # External Services & Data Access
│   ├── Persistance/
│   │   ├── DBContext/
│   │   │   └── VehicleServiceDbContext.cs # EF Core context with 13 DbSets (8 core + 5 chatbot)
│   │   ├── Repository/
│   │   │   ├── BaseRepository.cs          # Generic CRUD + soft-delete + pagination
│   │   │   └── UnitOfWork.cs              # Transaction management implementation
│   │   ├── Liquibase/                     # Database migrations
│   │   │   ├── master-changelog.xml       # Migration orchestrator
│   │   │   ├── liquibase.properties       # Connection config
│   │   │   └── changelogs/                # Version-specific SQL files
│   │   │       ├── 001-initial-schema.xml # Core 8 tables (416 lines)
│   │   │       ├── 002-seed-data.xml      # Seed data (3,400+ records)
│   │   │       └── 003-create-chatbot-tables.xml # 🤖 NEW - 5 chatbot tables + 17 indexes
│   │   └── DataSeedingService.cs          # CSV data seeding (3,400+ records)
│   ├── Integration/
│   │   ├── ImageService.cs                # Thumbnail generation (200x200px)
│   │   ├── TimezoneService.cs             # UTC<->User timezone conversion
│   │   └── Keycloak/                      # Authentication implementation
│   │       ├── KeycloakService.cs         # HTTP client for Keycloak API
│   │       ├── JwtTokenValidator.cs       # Token introspection + parsing
│   │       └── UserContext.cs             # Claims extraction from HTTP context
│   ├── DependencyInjection.cs             # Infrastructure layer DI registration
│   └── Infrastructure.csproj
│
├── Domain/                                 # Pure Business Entities
│   ├── Abstractions/
│   │   └── IEntity.cs                     # Base interface with soft-delete
│   ├── Entities/
│   │   ├── User.cs                        # User entity
│   │   ├── Vehicle.cs                     # Vehicle entity
│   │   ├── Garage.cs                      # Garage entity
│   │   ├── Service.cs                     # Service entity
│   │   ├── ServiceHistory.cs              # Service history entity
│   │   ├── VehicleIssue.cs                # Vehicle issue entity
│   │   ├── DiagnosticRule.cs              # Diagnostic rule entity
│   │   ├── ImageDiagnostic.cs             # Image diagnostic entity
│   │   ├── ChatbotConversation.cs         # 🤖 NEW - AI conversations
│   │   ├── ChatbotMessage.cs              # 🤖 NEW - Chat messages
│   │   ├── ChatbotKnowledgeBase.cs        # 🤖 NEW - Q&A knowledge base
│   │   ├── AiImageAnalysis.cs             # 🤖 NEW - Vision API results
│   │   └── AiUsageLog.cs                  # 🤖 NEW - API usage tracking
│   └── Domain.csproj
│
└── VehicleServicePortal.sln               # Solution file

logs/                                       # Auto-generated log files (gitignored)
├── api/api-YYYYMMDD.log                   # API layer logs
├── application/app-YYYYMMDD.log           # Application layer logs
├── infrastructure/infra-YYYYMMDD.log      # Infrastructure layer logs
├── all/all-YYYYMMDD.log                   # Consolidated logs (all layers)
└── errors/api-error-YYYYMMDD.log          # Error-only logs
```

---

## 📦 NuGet Packages Installed

### API Project (API.csproj)
```xml
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.1" />
<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="10.0.1" />
<PackageReference Include="Microsoft.AspNetCore.Authentication.OpenIdConnect" Version="10.0.1" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="10.0.1" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="10.0.1" />
<PackageReference Include="SkiaSharp" Version="2.88.8" />
<PackageReference Include="Serilog.AspNetCore" Version="8.0.1" />
<PackageReference Include="Serilog.Settings.Configuration" Version="8.0.0" />
<PackageReference Include="Serilog.Sinks.File" Version="5.0.0" />
<PackageReference Include="Serilog.Filters.Expressions" Version="2.1.1-dev-00054" />
```

### Application Project (Application.csproj)
```xml
<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.1" />
```

### Infrastructure Project (Infrastructure.csproj)
```xml
<PackageReference Include="CsvHelper" Version="33.1.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="10.0.1" />
<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="10.0.0" />
<PackageReference Include="SkiaSharp" Version="2.88.8" />
<PackageReference Include="System.IdentityModel.Tokens.Jwt" Version="7.1.0" />
<PackageReference Include="Microsoft.IdentityModel.Protocols.OpenIdConnect" Version="7.1.0" />
<PackageReference Include="Microsoft.Extensions.Logging.Abstractions" Version="10.0.1" />
<PackageReference Include="Microsoft.AspNetCore.Http.Abstractions" Version="2.2.0" />
<PackageReference Include="Microsoft.AspNetCore.Http" Version="2.2.0" />
<PackageReference Include="Microsoft.Extensions.Http" Version="10.0.0" />
<PackageReference Include="Serilog" Version="3.1.1" />
```

---

## 🔧 Key Architectural Decisions

### 1. Clean Architecture with Abstractions Layer
**Pattern:** Domain → Abstractions → Application → Infrastructure → API

- **Domain**: Pure entities with no external dependencies
- **Abstractions**: Interfaces and DTOs for dependency inversion
- **Application**: Business logic and AutoMapper profiles
- **Infrastructure**: External services, data access, integrations
- **API**: HTTP layer with controllers and middleware

**Benefits:**
- Clear separation of concerns
- Testable business logic
- Easy to swap implementations
- SOLID principles compliance

### 2. Layer-Specific Dependency Injection
**Pattern:** Each layer has its own `DependencyInjection.cs`

**Infrastructure.DependencyInjection:**
- DbContext configuration
- Repository and UnitOfWork registration
- Keycloak HTTP client setup
- Integration services (Image, Timezone)
- Data seeding service
- HttpContextAccessor

**Application.DependencyInjection:**
- AutoMapper registration (scans assembly for profiles)
- Business services (pending)

**Program.cs:**
```csharp
builder.Services.AddInfrastructureDI(builder.Configuration);
builder.Services.AddApplicationDI();
```

**Benefits:**
- Clean Program.cs
- Layer encapsulation
- Easy to locate registrations
- Modular configuration

### 3. Structured Logging with Serilog
**Pattern:** Per-layer daily rolling logs + consolidated log + error-only log

**Configuration:**
- Console sink with structured template
- File sinks with daily rolling (`RollingInterval.Day`)
- 30-day retention (`retainedFileCountLimit: 30`)
- Per-layer filtering using `Serilog.Filters.Expressions`
- Correlation ID in all log entries

**Template:**
```
{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [Corr:{CorrelationId}] {SourceContext} {Message:lj}{NewLine}{Exception}
```

**Log Files:**
- `logs/api/api-YYYYMMDD.log` - API layer only
- `logs/application/app-YYYYMMDD.log` - Application layer only
- `logs/infrastructure/infra-YYYYMMDD.log` - Infrastructure layer only
- `logs/all/all-YYYYMMDD.log` - Consolidated (all layers)
- `logs/errors/api-error-YYYYMMDD.log` - Error-level only

**Benefits:**
- Easy troubleshooting with per-layer isolation
- Quick end-to-end tracing with consolidated log
- Separate error log for critical issues
- Search by correlation ID for request flow tracking

### 4. Request Correlation Tracking
**Pattern:** `CorrelationIdMiddleware` stamps every request

**Behavior:**
1. Reads `X-Correlation-ID` header (if provided by client)
2. Generates new GUID if not provided
3. Adds to response header for client visibility
4. Pushes to Serilog log context for automatic inclusion
5. Flows across all layers automatically

**Benefits:**
- End-to-end request tracking
- Distributed tracing support
- Easy to grep logs by correlation ID
- Client can propagate correlation IDs across services

### 5. DTOs with CQRS-Style Separation
**Pattern:** Read DTOs + CreateRequest + UpdateRequest per entity

**Example (User):**
- `UserDto` - Read/response model (includes Id, CreatedAt, UpdatedAt)
- `CreateUserRequest` - Write model for POST (excludes Id, audit fields)
- `UpdateUserRequest` - Write model for PUT/PATCH (excludes Id, audit fields)

**Benefits:**
- Clear intent (read vs write)
- Prevents over-posting attacks
- API contract clarity
- AutoMapper-friendly

### 6. Soft-Delete Pattern with IEntity
**Pattern:** Domain entities implement `IEntity` interface

**Interface:**
```csharp
public interface IEntity
{
    int Id { get; set; }
    bool IsDeleted { get; set; }
    DateTime? DeletedAt { get; set; }
    string? DeletedBy { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
}
```

**Repository Implementation:**
- `GetAll()` filters `IsDeleted = false` by default
- `DeleteAsync()` sets `IsDeleted = true` (soft-delete)
- `RestoreAsync()` sets `IsDeleted = false`
- Optional `includeDeleted` parameter for queries

**Benefits:**
- Data recovery capability
- Audit trail preservation
- Regulatory compliance
- Historical reporting

### 7. Generic Repository + Unit of Work
**Pattern:** `IRepository<T>` with `IUnitOfWork`

**Repository Features:**
- CRUD operations (Add, Update, Delete, Restore)
- Pagination (`GetPagedAsync` returns `PaginatedResult<T>`)
- Soft-delete filtering
- FindAsync with LINQ expressions
- ExistsAsync and CountAsync

**Unit of Work:**
- Lazy-loaded repository instances
- Transaction management (BeginTransaction, Commit, Rollback)
- Single SaveChanges for all repositories
- 8 pre-configured repositories (User, Vehicle, Garage, etc.)

**Benefits:**
- Code reuse across entities
- Centralized transaction control
- Consistent soft-delete behavior
- Easy unit testing

### 8. Keycloak OAuth2/OIDC Integration
**Pattern:** JWT token introspection + claims extraction

**Components:**
- `IKeycloakService` - HTTP client for Keycloak API
  - `IntrospectTokenAsync()` - Validates token with Keycloak server
  - `GetUserInfoAsync()` - Fetches user profile
  - `ValidateTokenSignatureAsync()` - JWKS verification
- `IJwtTokenValidator` - Parses and validates JWT locally
- `IUserContext` - Extracts user claims from HTTP context

**Benefits:**
- Centralized authentication
- SSO support
- Role-based access control (RBAC)
- Industry-standard OAuth2/OIDC

### 9. AutoMapper for Entity<->DTO Mapping
**Pattern:** Profile-based configuration in Application layer

**Configuration:**
- `DomainToDtoProfile` maps all 8 entities bidirectionally
- 24 mappings total (8 entities × 3 DTOs each)
- Registered via `services.AddAutoMapper(Assembly)` in Application DI

**Benefits:**
- Eliminates boilerplate mapping code
- Convention-based mapping
- Easy to customize with `ForMember()`
- Performance-optimized

---

## 🎯 Configuration Files

### appsettings.json
```json
{
  "Logging": { ... },
  "Serilog": {
    "Using": ["Serilog.Sinks.File", "Serilog.Sinks.Console", "Serilog.Filters.Expressions"],
    "MinimumLevel": { "Default": "Information" },
    "WriteTo": [
      { "Name": "Console", "Args": { "outputTemplate": "..." } },
      { "Name": "File", "Args": { "path": "logs/api/api-.log", "rollingInterval": "Day" }, "Filter": "StartsWith(SourceContext, 'API')" },
      { "Name": "File", "Args": { "path": "logs/application/app-.log", "rollingInterval": "Day" }, "Filter": "StartsWith(SourceContext, 'Application')" },
      { "Name": "File", "Args": { "path": "logs/infrastructure/infra-.log", "rollingInterval": "Day" }, "Filter": "StartsWith(SourceContext, 'Infrastructure')" },
      { "Name": "File", "Args": { "path": "logs/all/all-.log", "rollingInterval": "Day" } },
      { "Name": "File", "Args": { "path": "logs/errors/api-error-.log", "restrictedToMinimumLevel": "Error" } }
    ]
  },
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=vehicle_service_db;Username=postgres;Password=postgres;"
  },
  "Keycloak": {
    "Url": "http://localhost:8080",
    "Realm": "vehicle-service",
    "ClientId": "vehicle-service-api",
    "ClientSecret": "your-client-secret-here"
  }
}
```

---

## ✅ Phase 4 Foundation Completion Checklist

### Completed ✅
- [x] Abstractions layer with proper folder structure
- [x] Domain entities with IEntity interface in Domain/Abstractions
- [x] All 8 DTOs created with Create/Update/Read separation
- [x] AutoMapper configured with 24 mappings
- [x] Generic Repository pattern with soft-delete support
- [x] Unit of Work pattern with transaction management
- [x] Keycloak service interfaces and implementations
- [x] JWT token validation and user context extraction
- [x] Image and Timezone integration services
- [x] Layer-specific dependency injection files
- [x] Serilog structured logging with per-layer sinks
- [x] Correlation ID middleware for request tracking
- [x] EF Core DbContext with 8 DbSets
- [x] Data seeding service with CSV support
- [x] Build: 0 errors

### Pending (Next Phase)
- [ ] Application Services (business logic layer)
- [ ] API Controllers with REST endpoints
- [ ] JWT authentication middleware configuration
- [ ] Keycloak realm/client setup
- [ ] API documentation (Scalar/OpenAPI)
- [ ] Integration testing

---

## 🔍 How to Search Logs by Correlation ID

**Example: Track a single request end-to-end**

1. **Search consolidated log:**
   ```bash
   grep "Corr:abc123def456" logs/all/all-20260118.log
   ```

2. **Search specific layer:**
   ```bash
   grep "Corr:abc123def456" logs/infrastructure/infra-20260118.log
   ```

3. **Search errors only:**
   ```bash
   grep "Corr:abc123def456" logs/errors/api-error-20260118.log
   ```

**PowerShell:**
```powershell
Select-String -Path "logs/all/all-*.log" -Pattern "Corr:abc123def456"
```

---

## 📚 Related Documentation

- [Progress Tracker](../../02-progress-tracking/progress-tracker.md) - Overall project status
- [Folder Structure](../../00-getting-started/02-folder-structure.md) - Full documentation structure
- [Phase 3 Database Guide](../phase-3-database-liquibase/README.md) - Database and Liquibase setup
- [All Requirements](../../01-requirements/01-all-requirements.md) - Complete feature list

---

**Document Status:** ✅ Current as of January 18, 2026

