# GRRADO Vehicle Service Portal

**Status:** Phase 4 In Progress -- Microservices Migration Complete | **Build:** 33 projects, 0 errors
**Last Updated:** February 14, 2026 | **Architecture:** Microservices (.NET 10.0) | **Naming:** Kebab-Case

A full-stack web application for managing vehicle service records, diagnostics, and garage operations with AI chatbot support.

---

## Quick Start

### Build the solution:
```powershell
cd d:\_GRRADO\src\app\server
dotnet build GRRADO.Microservices.sln
```

### Run a single service:
```powershell
# Start infrastructure first
docker compose -f d:\_GRRADO\src\docker-compose.yml up -d

# Run any service (e.g., UserService)
cd d:\_GRRADO\src\app\server
dotnet run --project services/UserService/UserService.API/UserService.API.csproj

# API docs at: http://localhost:5101/scalar/v1
```

### Run the gateway:
```powershell
dotnet run --project gateway/ApiGateway/ApiGateway.csproj
# All services accessible through: http://localhost:5100/api/*
```

---

## Where to Go

### New to the project? Start here:

| Goal | Read This |
|------|-----------|
| **See the complete solution** | [docs/implementation-plan.md](docs/implementation-plan.md) -- Master plan for all 12 phases |
| **Understand current progress** | [docs/02-progress-tracking/current-status.md](docs/02-progress-tracking/current-status.md) |
| **Learn development rules** | [.vscode/rules/rulebook.md](.vscode/rules/rulebook.md) -- **MANDATORY** |
| **Migration reference** | [MIGRATION-STATUS.md](MIGRATION-STATUS.md) -- Architecture details & conventions |

---

## Architecture

### Microservices (7 services + YARP Gateway)

```
d:\_GRRADO\src\app\server\
├── shared/                          # 4 shared libraries
│   ├── GRRADO.Shared.Domain/        # IEntity interface, integration events
│   ├── GRRADO.Shared.Abstractions/  # IRepository<T>, IUnitOfWork, IEventPublisher/Subscriber
│   ├── GRRADO.Shared.Application/   # Result<T>, ErrorCodes
│   └── GRRADO.Shared.Infrastructure/# BaseRepository<T>, BaseUnitOfWork, Polly, RabbitMQ, Middleware
├── gateway/
│   └── ApiGateway/                  # YARP reverse proxy (port 5100, 19 routes)
├── services/
│   ├── UserService/          (5101) # 1 entity: User
│   ├── VehicleService/       (5102) # 1 entity: Vehicle
│   ├── GarageService/        (5103) # 2 entities: Garage, Service
│   ├── ServiceHistoryService/(5104) # 1 entity: ServiceHistory
│   ├── ChatbotService/       (5105) # 5 entities
│   ├── DiagnosticsService/   (5106) # 3 entities
│   └── LoggingService/       (5107) # 5 entities
└── GRRADO.Microservices.sln         # 33 projects, 0 errors
```

### Per-Service Clean Architecture (4 layers)

```
XxxService/
├── XxxService.Domain/          # Entities implementing IEntity
├── XxxService.Application/     # CQRS handlers (MediatR), DTOs, AutoMapper
├── XxxService.Infrastructure/  # DbContext, UnitOfWork, Repositories (EF Core)
└── XxxService.API/             # Controllers, Program.cs, middleware
```

### Design Patterns
- CQRS via MediatR (Command/Query separation)
- Repository + Unit of Work
- Result<T> pattern (unified error handling)
- Database-per-service (7 PostgreSQL databases)
- Soft-delete with audit columns
- Polly resilience (retry, circuit breaker, timeout, bulkhead)

---

## The 3 Core Rules

**Read [.vscode/rules/rulebook.md](.vscode/rules/rulebook.md) for complete details.**

### 1. Language-Appropriate File Naming
```
C#:   UserService.cs          Dart: user_service.dart
Docs: setup-guide.md          NOT: SetupGuide.md
```

### 2. ZERO Hard-Coded Values
```
BAD:  if (role == "Admin") { }
GOOD: if (role == RoleConstants.ADMIN) { }
```

### 3. Clean Architecture Layers
```
Domain (entities only)
    ↓
Application (business logic, CQRS)
    ↓
Infrastructure (data access, EF Core)
    ↓
API (controllers, endpoints)
```

---

## Services & Endpoints

### Gateway (port 5100) routes to all services:

| Route Pattern | Service | Port |
|---------------|---------|------|
| /api/Users/* | UserService | 5101 |
| /api/Vehicles/* | VehicleService | 5102 |
| /api/Garages/*, /api/Services/* | GarageService | 5103 |
| /api/ServiceHistories/* | ServiceHistoryService | 5104 |
| /api/ChatbotConversations/*, /api/ChatbotMessages/*, /api/AiImageAnalyses/*, /api/ChatbotKnowledgeBases/*, /api/AiUsageLogs/* | ChatbotService | 5105 |
| /api/VehicleIssues/*, /api/DiagnosticRules/*, /api/ImageDiagnostics/* | DiagnosticsService | 5106 |
| /api/AuditLogs/*, /api/ErrorLogs/*, /api/ActivityLogs/*, /api/RequestResponseLogs/*, /api/ErrorMessages/* | LoggingService | 5107 |

### CRUD Pattern (all 18 entities)
```
GET    /api/{Resource}           (list)
POST   /api/{Resource}           (create)
GET    /api/{Resource}/{id}      (read)
PUT    /api/{Resource}/{id}      (update)
DELETE /api/{Resource}/{id}      (soft delete)
```

---

## Docker Infrastructure

```powershell
docker compose -f d:\_GRRADO\src\docker-compose.yml up -d
```

| Service | Port | Purpose |
|---------|------|---------|
| PostgreSQL 15 | 5433 | 7 service databases + Keycloak |
| Redis 7 | 6379 | Distributed caching |
| RabbitMQ 3 | 5672, 15672 | Async messaging + management UI |
| Keycloak | 8080 | Identity/Auth (deferred) |

---

## Tech Stack

| Layer | Technology |
|-------|-----------|
| **Backend** | .NET 10.0, ASP.NET Core (Microservices) |
| **CQRS** | MediatR 14.0.0 |
| **ORM** | Entity Framework Core 10.0.1 |
| **Database** | PostgreSQL 15 (database-per-service) |
| **Caching** | Redis 7 |
| **Messaging** | RabbitMQ 3 |
| **API Gateway** | YARP 2.1.0 |
| **Validation** | FluentValidation 12.1.1 |
| **Resilience** | Polly 8.4.1 |
| **Logging** | Serilog |
| **API Docs** | OpenAPI + Scalar 1.2.48 |
| **Auth** | Keycloak (planned) |
| **Frontend** | Flutter (planned - Phase 8-10) |
| **AI** | Azure AI Foundry (planned - Phase 7) |

---

## Project Status

| Phase | Name | Status | Progress |
|-------|------|--------|----------|
| 1 | Environment Setup | COMPLETE | 100% |
| 2 | Project Structure | COMPLETE | 100% |
| 3 | Database Design | COMPLETE | 100% |
| 4 | Backend API (Extended) | IN PROGRESS | ~65% |
| 5 | Roles & Permissions | Pending | 0% |
| 6 | CMS | Pending | 0% |
| 7 | AI Platform & Chatbot | Pending | 0% |
| 8 | Mobile App - Customer | Pending | 0% |
| 9 | Mobile App - Admin | Pending | 0% |
| 10 | Web Portals | Pending | 0% |
| 11 | Integration & Testing | Pending | 0% |
| 12 | Deployment & DevOps | Pending | 0% |

**Total Progress:** ~210 / 1,171 hours (~18%)

### Phase 4 Deliverables (completed so far)
- 7 microservices with Clean Architecture (28 service projects)
- 4 shared libraries
- YARP API Gateway (19 routes)
- CQRS handlers for all 18 entities (Create/GetAll/GetById/Update/Delete)
- Database-per-service (7 PostgreSQL databases)
- Polly resilience, AutoMapper, Serilog, Scalar API docs

### Phase 4 Remaining
- FluentValidation rules
- RabbitMQ event consumers
- EF Core migration strategy
- Unit/integration tests
- Authentication (deferred to Phase 5)

---

## Documentation Map

| Document | Purpose | Location |
|----------|---------|----------|
| **Rulebook** | Development standards | [.vscode/rules/rulebook.md](.vscode/rules/rulebook.md) |
| **Migration Status** | Architecture reference | [MIGRATION-STATUS.md](MIGRATION-STATUS.md) |
| **Current Status** | Quick project status | [docs/02-progress-tracking/current-status.md](docs/02-progress-tracking/current-status.md) |
| **Progress Tracker** | Detailed progress | [docs/02-progress-tracking/progress-tracker.md](docs/02-progress-tracking/progress-tracker.md) |
| **Implementation Plan** | Master plan (12 phases) | [docs/implementation-plan.md](docs/implementation-plan.md) |
| **Build Verification** | Build status proof | [docs/build-verification.md](docs/build-verification.md) |

---

## By Your Role

### Developers
1. Read: [.vscode/rules/rulebook.md](.vscode/rules/rulebook.md)
2. Read: [MIGRATION-STATUS.md](MIGRATION-STATUS.md) -- Architecture patterns & conventions
3. Build: `dotnet build GRRADO.Microservices.sln`
4. Run: `dotnet run --project services/{ServiceName}/{ServiceName}.API/{ServiceName}.API.csproj`
5. Docs: `http://localhost:{port}/scalar/v1`

### Code Reviewers
1. Check: [.vscode/rules/pr-checklist-enforcement.md](.vscode/rules/pr-checklist-enforcement.md)
2. Reference: [.vscode/rules/rulebook.md](.vscode/rules/rulebook.md)
3. Verify: [docs/pr-checklist.md](docs/pr-checklist.md)

### Project Managers
1. Track: [docs/02-progress-tracking/progress-tracker.md](docs/02-progress-tracking/progress-tracker.md)
2. Review: [docs/implementation-plan.md](docs/implementation-plan.md)
3. Verify: [docs/build-verification.md](docs/build-verification.md)

---

## Next Steps

### Phase 4 Completion
- FluentValidation rules for all CQRS commands/queries
- RabbitMQ event consumers for cross-service communication
- EF Core migration strategy
- Unit and integration tests

### Phase 5: Roles & Permissions (60 hours) -- NEXT
- Role hierarchy (Super Admin -> App Admin -> Garage Admin -> Customer)
- JWT/Keycloak integration
- Authorization middleware
- Endpoint protection

### Phase 7: AI Chatbot (200 hours) -- STRATEGIC
- Azure AI Foundry (4 modes: text, voice, vision, deep thinking)
- Knowledge base RAG
- Custom ML models (Python)

---

**Project:** GRRADO Vehicle Service Portal
**Last Updated:** February 14, 2026
**Build:** 33 projects, 0 errors
**Architecture:** Microservices (.NET 10.0)
