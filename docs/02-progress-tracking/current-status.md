# GRRADO Vehicle Service Portal -- Project Status

**Status:** Microservices Migration Complete -- Phase 4 In Progress
**Date:** April 17, 2026
**Build Status:** 33 projects, 0 errors, 82 warnings
**Architecture:** Microservices (.NET 10.0 current runtime) with YARP API Gateway

> Live rule: this status file and `progress-tracker.md` should be updated as work starts/completes, not only at the end of a phase.

---

## Approved Direction

- **Architecture Rule:** Clean Architecture is mandatory for every module, in every language used in the project
- **Database Rule:** Liquibase is the long-term schema authority; EF Core migrations are not the target workflow
- **Auth Target:** Keycloak remains the preferred identity platform
- **Client Direction:** Flutter Web + Flutter Mobile remain the target product clients
- **Platform Upgrade:** .NET 10 baseline has been restored locally and verified with a full solution build
- **Delivery Bias:** Backend stabilization remains first priority, but we sequence work so a credible demo can emerge without rework

---

## What Has Been Done

### Phases 1-3 - COMPLETED
- **Phase 1:** Environment Setup (Docker, PostgreSQL, Redis, Keycloak)
- **Phase 2:** Project Structure (Clean Architecture layers)
- **Phase 3:** Database Design (18 entities, EF Core, soft-delete)

### Phase 4: Foundation (Sprint 1) - COMPLETED
- **Task 001:** Git branching strategy established (feature/4-foundation)
- **Task 002:** Keycloak realm setup -- DEFERRED to auth phase
- **Task 003:** Database schema aligned -- EF Core models (18 tables, int PKs, all FK/indexes)
- **Task 004:** NuGet validation -- 0 vulnerabilities
- **Task 005:** Dev environment verified -- PostgreSQL, Redis running

### Architecture Hardening - COMPLETED
- **CQRS Use Cases:** Full CQRS pattern (Create/GetAll/GetById/Update/Delete) for all 18 entities
- **Polly Resilience:** HTTP + Database resilience policies via Polly 8.4.1
- **AutoMapper Mappings:** Use case request/response types mapped for all entities
- **Error Codes:** Standardized `ErrorCodes` in shared application library
- **Middleware Pipeline:** CorrelationId, ExceptionHandling middleware in shared infrastructure

### Microservices Migration - COMPLETED (Feb 10, 2026)
- **Monolith decomposed** into 7 independent microservices + API Gateway
- **4 shared libraries** extracted (Domain, Abstractions, Application, Infrastructure)
- **Database-per-service** pattern implemented (7 separate PostgreSQL databases)
- **YARP API Gateway** configured with 19 reverse proxy routes on port 5100
- **RabbitMQ** integration for async inter-service communication
- **Old monolith fully removed** (6 directories + GRRADO.sln deleted)
- **New solution:** `GRRADO.Microservices.sln` with 33 projects, builds with 0 errors

### Platform Baseline - COMPLETED
- **.NET 10 SDK installed locally:** 10.0.202
- **global.json restored:** solution now targets `.NET 10`
- **Project baselines restored:** shared libraries, gateway, AppHost, and all 7 services target `.NET 10`
- **Package baselines restored:** EF Core/OpenAPI/shared extensions aligned back to .NET 10 package line
- **Verification complete:** `dotnet build GRRADO.Microservices.sln` succeeded with 0 errors
- **Docker runtime aligned:** `docker-compose.services.yml` now uses `.NET 10` runtime images and the same connection-string key/database names as the services

### Database Workflow Baseline - COMPLETED
- **Design-time factories added:** all 7 infrastructure projects can now generate schema scripts without depending on API startup projects
- **Liquibase structure created:** `app/server/database/liquibase/` now contains one baseline changelog set per service database
- **Baseline SQL generated:** `001-baseline.sql` files were bootstrapped from the current EF Core model for all 7 services

---

## Current Architecture

### Microservices (7 services + Gateway)

| Service | Port | Entities | Database |
|---------|------|----------|----------|
| API Gateway (YARP) | 5100 | -- | -- |
| UserService | 5101 | User | grrado_user_db |
| VehicleService | 5102 | Vehicle | grrado_vehicle_db |
| GarageService | 5103 | Garage, Service | grrado_garage_db |
| ServiceHistoryService | 5104 | ServiceHistory | grrado_service_history_db |
| ChatbotService | 5105 | ChatbotConversation, ChatbotMessage, AiImageAnalysis, ChatbotKnowledgeBase, AiUsageLog | grrado_chatbot_db |
| DiagnosticsService | 5106 | VehicleIssue, DiagnosticRule, ImageDiagnostic | grrado_diagnostics_db |
| LoggingService | 5107 | AuditLog, ErrorLog, ActivityLog, RequestResponseLog, ErrorMessage | grrado_logging_db |

### Per-Service Clean Architecture (4 layers each)
```
XxxService/
├── XxxService.Domain/          # Entities implementing IEntity
├── XxxService.Application/     # CQRS handlers, DTOs, AutoMapper
├── XxxService.Infrastructure/  # DbContext, UnitOfWork, Repositories
└── XxxService.API/             # Controllers, Program.cs, middleware
```

### Shared Libraries (4 projects)
- **GRRADO.Shared.Domain** -- IEntity interface, integration events
- **GRRADO.Shared.Abstractions** -- IRepository<T>, IUnitOfWork, IEventPublisher/Subscriber
- **GRRADO.Shared.Application** -- Result<T> pattern, ErrorCodes
- **GRRADO.Shared.Infrastructure** -- BaseRepository<T>, BaseUnitOfWork, Polly, RabbitMQ, Middleware

### Solution Summary
- **33 projects** (7 services x 4 layers + 4 shared + 1 gateway)
- **18 entities** across 7 services
- **~319 .cs source files**
- **90+ CRUD endpoints** via CQRS (5 operations x 18 entities)

---

## Docker Infrastructure

```powershell
# Start all infrastructure
docker compose -f d:\_GRRADO\src\docker-compose.yml up -d
```

| Service | Image | Port | Purpose |
|---------|-------|------|---------|
| PostgreSQL 15 | postgres:15-alpine | 5433 | 7 service databases + Keycloak |
| Redis 7 | redis:7-alpine | 6379 | Distributed caching |
| RabbitMQ 3 | rabbitmq:3-management-alpine | 5672, 15672 | Async messaging |
| Keycloak | keycloak/keycloak:latest | 8080 | Identity/Auth (deferred) |

---

## Quick Start

### Option 1: Run Individual Service
```powershell
cd d:\_GRRADO\src\app\server
dotnet run --project services/UserService/UserService.API/UserService.API.csproj
```

### Option 2: Build Entire Solution
```powershell
cd d:\_GRRADO\src\app\server
dotnet build GRRADO.Microservices.sln
```

### API Documentation
- Each service exposes **Scalar API Reference** at `/scalar/v1`
- OpenAPI spec at `/openapi/v1.json`
- Gateway routes all traffic through `http://localhost:5100/api/*`

---

## Next Steps (Phase 4 Remaining Work)

| Category | Items |
|----------|-------|
| **Validation** | Verify validator coverage, pipeline behavior, and API error shape |
| **Authentication** | Keycloak JWT integration and middleware pipeline after backend baseline work |
| **Event Handling** | Finish and verify RabbitMQ event consumers for cross-service communication |
| **Database** | Review generated Liquibase baselines, run them locally, and verify schema parity |
| **Testing** | Start with integration tests for core service and gateway flows |
| **API Refinement** | Pagination, filtering, sorting on GetAll endpoints |

### Known Items
- All endpoints currently public (auth deferred to Phase 5/6)
- RabbitMQ infrastructure is wired and consumer scaffolding exists, but end-to-end verification is still pending
- FluentValidation is wired in the application pipeline and validator files exist, but coverage and behavior still need verification
- Liquibase is now the intended schema authority, but the runtime still needs to be aligned away from `EnsureCreated()` and other ad hoc bootstrapping
- The solution now builds on `.NET 10`, but dependency and warning cleanup is still needed (`AutoMapper`, `System.Security.Cryptography.Xml`, `NU1510`, and two `CS0108` warnings)

### Active Sequence
1. Keep the live docs and tracker aligned with actual engineering decisions
2. Review and validate the generated Liquibase baselines against the live service model
3. Verify validation, eventing, and startup flows
4. Add first integration tests
5. Complete Keycloak/JWT and then continue into RBAC

---

## Project Progress

| Phase | Name | Status | Progress |
|-------|------|--------|----------|
| 1 | Environment Setup | COMPLETE | 100% |
| 2 | Project Structure | COMPLETE | 100% |
| 3 | Database Design | COMPLETE | 100% |
| 4 | Backend API (Extended) | IN PROGRESS | ~65% |
| 5 | Roles & Permissions | Pending | 0% |
| 6 | CMS | Pending | 0% |
| 7 | AI Platform & Chatbot | Pending | 0% |
| 8-12 | Mobile, Web, Testing, Deployment | Pending | 0% |

---

**Project:** GRRADO Vehicle Service Portal
**Date:** February 14, 2026
