# GRRADO Documentation

**Status:** Microservices Architecture | All Files Kebab-Case | Unified Standards | Last Updated: February 14, 2026

---

## START HERE

**New to the project?** Start with the [Migration Status](../MIGRATION-STATUS.md) for architecture reference.

**Key entry points:**
- **Quick Status (5 min):** [02-progress-tracking/current-status.md](02-progress-tracking/current-status.md)
- **Development Rules:** [../.vscode/rules/rulebook.md](../.vscode/rules/rulebook.md) -- **MANDATORY**
- **Architecture Reference:** [../MIGRATION-STATUS.md](../MIGRATION-STATUS.md)
- **Master Plan:** [implementation-plan.md](implementation-plan.md)
- **API Testing:** [how-to-run-and-test-api.md](how-to-run-and-test-api.md)

---

## Documentation Organization

### At Workspace Root (Top-level entry points)
- [.vscode/rules/rulebook.md](../.vscode/rules/rulebook.md) -- Development standards & enforcement
- [MIGRATION-STATUS.md](../MIGRATION-STATUS.md) -- Microservices architecture reference
- [02-progress-tracking/current-status.md](02-progress-tracking/current-status.md) -- Quick status update
- [implementation-plan.md](implementation-plan.md) -- Master development plan
- [build-verification.md](build-verification.md) -- Build status proof

### In docs/ folder
- [how-to-run-and-test-api.md](how-to-run-and-test-api.md) -- Complete API testing guide
- [pr-checklist.md](pr-checklist.md) -- Code review enforcement
- **Phase-specific docs** -> [03-phase-specific/](03-phase-specific/)
- **Requirements** -> [01-requirements/](01-requirements/)
- **Progress tracking** -> [02-progress-tracking/progress-tracker.md](02-progress-tracking/progress-tracker.md)

---

## Tech Stack

**Backend (Microservices):**
- .NET 10.0 (C#) -- 7 microservices + YARP API Gateway
- Clean Architecture per service (Domain, Application, Infrastructure, API)
- Entity Framework Core 10.0.1 + PostgreSQL 15 (database-per-service)
- Redis 7 (distributed caching)
- RabbitMQ 3 (inter-service messaging)
- MediatR 14.0.0 (CQRS pattern)
- FluentValidation 12.1.1 (validation)
- AutoMapper 12.0.1 (DTO mapping)
- Polly 8.4.1 (resilience)
- Serilog (structured logging)
- Scalar 1.2.48 (OpenAPI documentation)

**Frontend (Planned):**
- Flutter (Unified Web + Mobile)
- Clean Architecture (Domain, Data, Presentation layers)
- Bloc/Cubit (State Management)

**Infrastructure:**
- PostgreSQL 15 (7 databases, one per service)
- Redis 7 (distributed caching)
- RabbitMQ 3 (async messaging)
- Keycloak (authentication/authorization -- deferred)
- Docker & Docker Compose (containerization)
- YARP 2.1.0 (API Gateway, port 5100)

## Project Status

**Phases Completed:** 1, 2, 3 (Environment, Architecture, Database)
**Total Progress:** ~18% (~210 of 1,171 hours)
**Current Phase:** 4 - Backend API Development (~65% complete, microservices migration done)

| Phase | Status | Progress |
|-------|--------|----------|
| 1: Environment Setup | COMPLETE | 100% |
| 2: Project Structure | COMPLETE | 100% |
| 3: Database & Liquibase | COMPLETE | 100% |
| 4: Backend API (Extended) | IN PROGRESS | ~65% |
| 5-12: Roles, CMS, AI, Mobile, Web, Testing, Deploy | Pending | 0% |

## Architecture

```
app/server/
├── shared/                          # 4 shared libraries
│   ├── GRRADO.Shared.Domain/        # IEntity, integration events
│   ├── GRRADO.Shared.Abstractions/  # IRepository<T>, IUnitOfWork
│   ├── GRRADO.Shared.Application/   # Result<T>, ErrorCodes
│   └── GRRADO.Shared.Infrastructure/# BaseRepository, Polly, RabbitMQ, Middleware
├── gateway/
│   └── ApiGateway/                  # YARP reverse proxy (port 5100, 19 routes)
├── services/
│   ├── UserService/          (5101) # User
│   ├── VehicleService/       (5102) # Vehicle
│   ├── GarageService/        (5103) # Garage, Service
│   ├── ServiceHistoryService/(5104) # ServiceHistory
│   ├── ChatbotService/       (5105) # 5 entities
│   ├── DiagnosticsService/   (5106) # 3 entities
│   └── LoggingService/       (5107) # 5 entities
├── GRRADO.Microservices.sln         # 33 projects, 0 errors
│
├── docs/                            # Documentation
│   ├── 00-getting-started/
│   ├── 01-requirements/
│   ├── 02-progress-tracking/
│   ├── 03-phase-specific/
│   └── 04-deployment-guides/
│
├── infrastructure/                  # Infrastructure config & tools
├── docker-compose.yml               # Docker services
└── init-databases.sql               # Per-service database creation
```

## Getting Started

### Prerequisites
- .NET 10.0 SDK
- Docker Desktop
- PostgreSQL 15 (via Docker)
- VS Code (recommended)

### Setup

```powershell
# Start infrastructure
docker compose -f d:\_GRRADO\src\docker-compose.yml up -d

# Build all 33 projects
cd d:\_GRRADO\src\app\server
dotnet build GRRADO.Microservices.sln

# Run a service (e.g., UserService)
dotnet run --project services/UserService/UserService.API/UserService.API.csproj

# API docs at: http://localhost:5101/scalar/v1
```

## Development Workflow

### Backend
```powershell
cd d:\_GRRADO\src\app\server

# Build entire solution
dotnet build GRRADO.Microservices.sln

# Run individual service
dotnet run --project services/UserService/UserService.API/UserService.API.csproj

# Run gateway
dotnet run --project gateway/ApiGateway/ApiGateway.csproj
```

**Gateway:** http://localhost:5100 (routes to all services)
**Per-service API docs:** http://localhost:{port}/scalar/v1

## Key Features

### API
- 90+ REST endpoints (5 per entity x 18 entities)
- Full CRUD operations via CQRS (MediatR)
- Soft-delete with audit trail
- Result<T> pattern for error handling
- Pagination support

### Infrastructure
- Database-per-service isolation
- RabbitMQ event-driven communication
- Polly resilience (retry, circuit breaker, timeout, bulkhead)
- Correlation ID tracking across services
- Serilog structured logging

## Documentation

- **[implementation-plan.md](implementation-plan.md)** - Master plan for all 12 phases
- **[02-progress-tracking/progress-tracker.md](02-progress-tracking/progress-tracker.md)** - Detailed progress tracking
- **[03-phase-specific/](03-phase-specific/)** - Phase documentation
- **[00-getting-started/](00-getting-started/)** - Setup guides
- **[../MIGRATION-STATUS.md](../MIGRATION-STATUS.md)** - Architecture reference & conventions

## Contributing

See contributing.md and code-of-conduct.md.

## License

Apache-2.0. See LICENSE.

---

**Last Updated:** February 14, 2026
**Current Phase:** 4 - Backend API (~65%)
**Architecture:** Microservices (.NET 10.0), 33 projects, 0 errors
