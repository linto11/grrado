# Grrado - Vehicle Service Aggregator Platform - Progress Tracker

**Last Updated:** April 17, 2026
**Overall Status:** Phases 1-3 COMPLETE | Phase 4 IN PROGRESS -- Microservices Migration COMPLETE
**Architecture:** Microservices (.NET 10.0 current runtime) -- 7 services + YARP Gateway + 4 shared libraries
**Build Status:** 33 projects, 0 errors, 82 warnings | Solution: `GRRADO.Microservices.sln`
**Project Scope:** Backend-First Strategy: Portal APIs -> Role/Permission System -> CMS -> AI Chatbot -> Web Portals -> Mobile Apps
**Total Project Progress:** ~18% (approx 210 of 1,171 hours complete) -- Microservices migration adds significant completed work
**Approved Target Direction:** .NET 10 baseline restored + Liquibase-owned schema + Keycloak auth + Flutter web/mobile + Clean Architecture across all modules/languages

> Working tracker for active scope.
> For a shorter implementation snapshot, use `current-status.md`.
> Update rule: whenever we start or complete a milestone, this file is updated in the same working pass.

---

## Executive Summary

### Locked Delivery Decisions
- **Architecture Rule:** Clean Architecture is mandatory for every module, service, app, and future cross-language component
- **Database Rule:** Liquibase is the single schema authority; EF Core migrations are not part of the long-term workflow
- **Auth Target:** Keycloak remains the preferred identity and access platform
- **Client Direction:** Flutter Web + Flutter Mobile remain the intended product clients
- **Platform Upgrade:** .NET 10 baseline is restored and verified before broader feature expansion
- **Execution Style:** Stabilize backend foundation first, but keep demo readiness in view as we sequence work

### Project Evolution
- **Original Scope:** Web-based vehicle service portal (735 hours)
- **Expanded Scope:** Multi-platform garage and vehicle service aggregator (1,168 hours)
- **Major Milestone:** Monolith-to-microservices migration completed February 10, 2026
- **New Features Added:**
  - Advanced AI Chatbot (Azure AI Foundry: fast mode, thinking mode, audio, image describer)
  - 2 Mobile Apps (Customer + Admin) - Flutter
  - Unified Web Platform - Flutter Web
  - Headless CMS for multi-language content
  - Custom ML Models with Python (TensorFlow/PyTorch)
  - 4-Tier Role Hierarchy (Super Admin, App Admin, Garage Admin, Customer)
  - Real-time GPS-based garage discovery and booking

### Overall Status
| Metric | Value |
|--------|-------|
| **Phases Completed** | 3 of 12 (25%) |
| **Hours Completed** | ~210 / 1,171 (~18%) |
| **Current Phase** | Phase 4 - Backend API (Extended) |
| **Architecture** | Microservices (.NET 10 current baseline) |
| **Solution** | 33 projects, 0 errors, 82 warnings |
| **Services** | 7 microservices + 1 gateway |
| **Entities** | 18 across 7 services |
| **Source Files** | ~319 .cs files |
| **Priority Sequence** | 4 -> 5 -> 6 -> 7 (Chatbot AI) -> 10 (Web) -> 8,9 (Mobile) -> 11,12 (Test/Deploy) |

---

## Phase Overview (Priority Order)

| Phase | Name | Duration | Status | Progress | Priority |
|-------|------|----------|--------|----------|----------|
| 1 | Environment Setup | 5h | COMPLETE | 100% | N/A |
| 2 | Project Structure | 8h | COMPLETE | 100% | N/A |
| 3 | Database & Liquibase | 15h | COMPLETE | 100% | N/A |
| **4** | **Backend API (Extended)** | **135h** | **IN PROGRESS** | **~65%** | **#1 - CRITICAL** |
| **5** | **Roles & Permissions** | **60h** | **Pending** | **0%** | **#2 - GATES ALL** |
| **6** | **CMS** | **100h** | **Pending** | **0%** | **#3** |
| **7** | **AI Platform & Chatbot** | **200h** | **Pending** | **0%** | **#4 - STRATEGIC FOCUS** |
| **10** | **Web Portals (Flutter)** | **220h** | **Pending** | **0%** | **#5** |
| 8 | Mobile App - Customer (Flutter) | 180h | Pending | 0% | #6 |
| 9 | Mobile App - Admin (Flutter) | 100h | Pending | 0% | #7 |
| 11 | Integration & Testing | 120h | Pending | 0% | #8 |
| 12 | Deployment & DevOps | 60h | Pending | 0% | #9 |
| **TOTAL** | | **1,171h** | | **~18%** | **Backend-First Strategy** |

---

## Phase 4: Backend API Development -- IN PROGRESS

**Status:** ~65% Complete -- Microservices migration done, refinements remaining
**Original Duration:** 100h -> **Extended Duration:** 135h (added 35h for chatbot database support)
**Architecture:** Migrated from monolith to microservices (Feb 10, 2026)

### COMPLETED Items

#### Foundation (Sprint 1)
- [x] Git branching strategy established (feature/4-foundation)
- [x] Database schema aligned (18 tables, int PKs, all FK/indexes)
- [x] NuGet validation (0 vulnerabilities)
- [x] Dev environment verified (PostgreSQL, Redis running)

#### Architecture Hardening
- [x] CQRS Use Cases: Full pattern for all 18 entities (Create/GetAll/GetById/Update/Delete)
- [x] Polly Resilience: HTTP + Database policies (retry, circuit breaker, timeout, bulkhead)
- [x] AutoMapper Mappings: All entity DTOs mapped
- [x] Error Codes: Standardized ErrorCodes in shared library
- [x] Middleware Pipeline: CorrelationId + ExceptionHandling in shared infrastructure
- [x] Controller Segregation: One controller per entity

#### Chatbot Database Infrastructure
- [x] Create 5 chatbot domain entities (ChatbotConversation, ChatbotMessage, ChatbotKnowledgeBase, AiImageAnalysis, AiUsageLog)
- [x] Create 15 chatbot DTOs (Create/Read/Update for each entity)
- [x] Database indexes for chatbot query optimization

#### Microservices Migration (Feb 2026)
- [x] Decompose monolith into 7 independent microservices
- [x] Create 4 shared libraries (Domain, Abstractions, Application, Infrastructure)
- [x] Implement database-per-service pattern (7 PostgreSQL databases)
- [x] Configure YARP API Gateway (19 routes, port 5100)
- [x] Wire RabbitMQ event publishing infrastructure
- [x] Create per-service DbContext with soft-delete query filters
- [x] Implement per-service UnitOfWork (extends BaseUnitOfWork with Polly)
- [x] Create per-service repositories (IRepository<T> implementations)
- [x] Integration events defined (UserDeleted, VehicleDeleted, GarageDeleted, ServiceDeleted)
- [x] Per-service DependencyInjection.cs (AddXxxApplication + AddXxxInfrastructure)
- [x] Per-service Program.cs (Serilog, OpenApi, Scalar, middleware)
- [x] Per-service appsettings.json (connection strings, RabbitMQ config)
- [x] Solution file: GRRADO.Microservices.sln (33 projects, 0 errors)
- [x] Old monolith fully removed (API, Application, Domain, Infrastructure, Abstractions, Utility + GRRADO.sln)
- [x] Docker infrastructure: docker-compose.yml + init-databases.sql for 7 databases

#### Platform Baseline (.NET 10)
- [x] Install .NET SDK 10.0.202 locally for solution verification
- [x] Restore `global.json` and all service/shared project targets to `.NET 10`
- [x] Restore .NET 10 package baselines for EF Core, OpenAPI, and shared Microsoft.Extensions packages
- [x] Verify `GRRADO.Microservices.sln` builds successfully on .NET 10
- [x] Align `docker-compose.services.yml` runtime images and connection-string keys with the live `.NET 10` service configuration

#### Database Workflow Baseline
- [x] Add design-time DbContext factories for all 7 services so schema scripts can be generated from infrastructure projects
- [x] Bootstrap per-service Liquibase baseline changelogs from the current EF Core model
- [x] Define the canonical Liquibase folder structure under `app/server/database/liquibase`

### ACTIVE Execution Sequence
1. Replace ad hoc database bootstrapping with a Liquibase-owned workflow
2. Verify validators, event consumers, and service startup behavior
3. Add first integration tests for core demo-ready flows
4. Complete Keycloak/JWT wiring and then move into RBAC

### REMAINING Items (~35% of Phase 4)

**Validation & Data Integrity:**
- [ ] Verify validator coverage, pipeline behavior, and API error response shape
- [ ] Add soft-delete filtering verification across all repositories
- [ ] Capture user info on delete operations (DeletedBy = current user)
- [ ] Implement pagination, filtering, sorting on GetAll endpoints

**Authentication (deferred to Phase 5):**
- [ ] Configure Keycloak realm and client setup
- [ ] Add JWT authentication middleware to API pipeline

**Event Handling:**
- [ ] Finish and verify RabbitMQ event consumers for cross-service communication
- [ ] Wire up integration event handlers (UserDeleted, VehicleDeleted, etc.)

**Database:**
- [ ] Review the generated Liquibase baseline SQL for each service before first real deployment
- [ ] Run Liquibase against local service databases and verify schema parity end to end
- [ ] Verify all foreign key relationships

**Testing:**
- [ ] Integration tests for core API endpoints and gateway flows
- [ ] Service-level integration tests for the most important entities
- [ ] Unit tests for CQRS handlers where they add value beyond integration coverage

**Infrastructure Refinement:**
- [ ] Implement file upload endpoint (/api/files/{fileName})
- [ ] Add health check endpoints across all services
- [ ] Configure CORS policies per service

---

## Current Architecture

### Microservices

```
d:\_GRRADO\src\app\server\
├── shared/                          # 4 shared libraries
│   ├── GRRADO.Shared.Domain/        # IEntity, integration events
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
└── GRRADO.Microservices.sln         # 33 projects
```

### Per-Service Pattern (4 layers per service)
```
XxxService/
├── XxxService.Domain/          # Entities implementing IEntity
├── XxxService.Application/     # CQRS commands/queries, DTOs, AutoMapper, DI
├── XxxService.Infrastructure/  # DbContext, UnitOfWork, Repositories, DI
└── XxxService.API/             # Controllers (IMediator), Program.cs, appsettings.json
```

### Docker Infrastructure
| Service | Port | Purpose |
|---------|------|---------|
| PostgreSQL 15 | 5433 | 7 service databases + Keycloak |
| Redis 7 | 6379 | Distributed caching |
| RabbitMQ 3 | 5672, 15672 | Async messaging + management UI |
| Keycloak | 8080 | Identity/Auth (deferred) |

---

## Technology Stack

### Backend (.NET 10 current baseline)
- .NET 10.0 baseline restored and verified with SDK 10.0.202
- Entity Framework Core 10.0.1 and Npgsql provider 10.0.0
- PostgreSQL 15 (database-per-service)
- Redis 7
- RabbitMQ 3 (inter-service messaging)
- YARP 2.1.0 (API Gateway)
- Keycloak (OAuth 2.0/OIDC -- deferred)
- Serilog (Structured logging)
- AutoMapper 12.0.1 (DTO mapping)
- MediatR 14.0.0 (CQRS pattern)
- FluentValidation 12.1.1 (Validation)
- Polly 8.4.1 (Resilience)
- Scalar 1.2.48 (OpenAPI documentation)

### Frontend (Flutter -- Planned)
- Flutter SDK 3.x (Unified Web + Mobile)
- Clean Architecture
- Bloc/Cubit (State Management)
- Material Design 3

### AI/ML Platform (Planned)
- Azure AI Foundry (Chatbot models)
- Python 3.11+ (Custom ML: TensorFlow/PyTorch, FastAPI, still following Clean Architecture boundaries)

### Current Warning Snapshot
- `AutoMapper` 12.0.1 is producing `NU1903` vulnerability warnings across multiple projects and should be upgraded in a focused dependency pass
- `Microsoft.EntityFrameworkCore.Design` brings in `System.Security.Cryptography.Xml` 9.0.0 vulnerability warnings in infrastructure projects and should be reviewed as part of the dependency cleanup pass
- `Microsoft.Extensions.Logging.Abstractions` and `Microsoft.Extensions.Http` in shared infrastructure produce `NU1510` pruning warnings and should be reviewed during the dependency cleanup pass
- `ChatbotUnitOfWork` and `LoggingUnitOfWork` both produce `CS0108` field-hiding warnings and should be cleaned up during infrastructure refinement

---

## Phase 5: Role-Based Access & Permissions -- PENDING

**Status:** Not Started
**Duration:** 60 hours
**Scope:**
- [ ] Role hierarchy (Super Admin -> App Admin -> Garage Admin -> User)
- [ ] Permissions table & role-permission mapping (50+ permissions)
- [ ] Custom authorization attributes & middleware
- [ ] Impersonation feature with audit trail
- [ ] API endpoint protection by role

---

## Phase 6: Content Management System -- PENDING

**Status:** Not Started
**Duration:** 100 hours
**Scope:**
- [ ] CMS database schema (pages, media, banners, templates)
- [ ] Backend API (CRUD, media upload, localization)
- [ ] Admin UI with WYSIWYG editor
- [ ] Multi-language support
- [ ] Version control & publish workflow

---

## Phase 7: AI Platform & Chatbot -- PENDING

**Status:** Not Started
**Duration:** 200 hours
**Scope:**
- [ ] Azure AI Foundry Setup (4 chatbot modes: text, voice, vision, deep thinking)
- [ ] Python Custom ML Platform (FastAPI, TensorFlow/PyTorch)
- [ ] Advanced AI Chatbot Integration
- [ ] Frontend Components (Chat UI, voice, image upload)

---

## Phases 8-12 -- PENDING

| Phase | Name | Duration | Scope |
|-------|------|----------|-------|
| 8 | Mobile App - Customer (Flutter) | 180h | Vehicle mgmt, garage discovery, booking, AI chatbot |
| 9 | Mobile App - Admin (Flutter) | 100h | Dashboard, appointments, customer comms |
| 10 | Web Portals (Flutter Web) | 220h | 4 portals: Super Admin, App Admin, Garage Admin, Customer |
| 11 | Integration & Testing | 120h | E2E, performance, security, UAT |
| 12 | Deployment & DevOps | 60h | Azure, CI/CD, Kubernetes, monitoring |

---

## Quick Stats

| Metric | Value |
|--------|-------|
| **Total Phases** | 12 |
| **Completed Phases** | 3 (25%) |
| **In Progress Phases** | 1 (Phase 4) |
| **Pending Phases** | 8 |
| **Microservices** | 7 + 1 gateway |
| **Shared Libraries** | 4 |
| **Total Projects** | 33 |
| **Total Entities** | 18 |
| **Source Files** | ~319 .cs |
| **Build Status** | 0 Errors, 0 Warnings |

---

## Recent Achievements (February 2026)

### Microservices Migration Complete (Feb 10, 2026)
- Monolith decomposed into 7 independent microservices
- YARP API Gateway configured (19 routes)
- Database-per-service pattern (7 PostgreSQL databases)
- RabbitMQ integration for async messaging
- 4 shared libraries extracted
- 33-project solution compiling with 0 errors
- Old monolith fully removed

### Previous Achievements (January 2026)
- CQRS pattern implemented for all 18 entities
- Polly resilience framework (HTTP + Database)
- AutoMapper + FluentValidation wired
- Chatbot database infrastructure (5 entities, 15 DTOs)
- Enterprise logging infrastructure (background queue processing)
- Error code management system

---

## Cost Estimates

| Category | Estimated | Status |
|----------|-----------|--------|
| **Development** | $154,800 | In Progress |
| **Infrastructure (Year 1)** | $17,400 | Pending |
| **One-Time Costs** | $1,174 | Pending |
| **Total First Year** | **$173,374** | |

---

## Timeline

**Start Date:** January 11, 2026
**Current Date:** February 14, 2026
**Projected Completion:** November 2026 (10 months)

---

## Key Decisions

### February 2026
- **Decision:** Migrate from monolith to microservices architecture
- **Decision:** Implement database-per-service pattern for true data isolation
- **Decision:** Use YARP as API Gateway (reverse proxy)
- **Decision:** Upgrade from .NET 9 to .NET 10.0
- **Decision:** Add RabbitMQ for async inter-service communication

### January 2026
- **Decision:** Expanded project scope to full garage and vehicle service aggregator platform
- **Decision:** Migrated frontend from Angular to Flutter (unified web + mobile)
- **Decision:** Azure AI Foundry for chatbot model integration
- **Decision:** Python for custom AI/ML development
- **Decision:** 4-tier role hierarchy

---

**Next Milestone:** Complete Phase 4 remaining items (validation, event handling, testing)
