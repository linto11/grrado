# Project Overview

**Purpose:** describe the current GRRADO vision in a way that matches the codebase.  
**Last Updated:** April 17, 2026

---

## Product Vision

GRRADO is being built as a vehicle service aggregator platform.

The long-term product vision includes:

- customer vehicle profiles and service history
- garage discovery and service management
- diagnostics and issue tracking
- chatbot and AI-assisted workflows
- role-based admin and garage operations
- future web and mobile experiences

The important constraint is this:

- the codebase is still in a backend-first phase
- the current implementation focus is stabilizing and finishing the backend foundation before expanding into the larger product surface

---

## Current Implementation Reality

The active implementation repo is:

- `D:\_GRRADO\src`

The active backend solution is:

- `D:\_GRRADO\src\app\server\GRRADO.Microservices.sln`

What exists in code today:

- 7 microservices
- 1 YARP API gateway
- 4 shared libraries
- 18 entities
- CQRS handlers, DTO mappings, and controllers across services
- Docker-managed infrastructure for PostgreSQL, Redis, RabbitMQ, and Keycloak
- AppHost/Aspire support for orchestration and debugging

What is not finished yet:

- authentication and authorization closure
- database migration strategy clarity
- integration and unit tests
- full end-to-end verification of event consumers
- frontend, CMS, AI productization, and deployment phases

---

## Architecture Direction

The codebase currently follows a microservices architecture with clean architecture inside each service.

This is also a wider project rule:

- every module in any language must follow clean architecture
- language syntax may change, but dependency direction must not
- core business rules must stay isolated from infrastructure and delivery concerns

Current service layout:

- `UserService`
- `VehicleService`
- `GarageService`
- `ServiceHistoryService`
- `ChatbotService`
- `DiagnosticsService`
- `LoggingService`

Shared libraries:

- `GRRADO.Shared.Domain`
- `GRRADO.Shared.Abstractions`
- `GRRADO.Shared.Application`
- `GRRADO.Shared.Infrastructure`

The gateway lives in:

- `app/server/gateway/ApiGateway`

The orchestration entry point lives in:

- `app/server/AppHost`

---

## Delivery Strategy

To avoid overcomplication, the project should move in this order:

1. finish and stabilize Phase 4 backend work
2. settle one database migration/source-of-truth strategy
3. add tests and runtime verification
4. complete authentication and then RBAC
5. only then expand further into CMS, AI, web, and mobile work

This keeps us from building new features on top of an unclear backend foundation.

---

## What To Treat As Current

Use these docs first:

1. `README.md`
2. `docs/current-doc-set.md`
3. `docs/02-progress-tracking/current-status.md`
4. `docs/02-progress-tracking/progress-tracker.md`
5. `docs/how-to-run-and-test-api.md`

Use older planning material for context only:

- `docs/implementation-plan.md`
- `docs/03-phase-specific/phase-3-database-liquibase/*`
- `D:\_GRRADO\docs\*.docx`

---

## Short Working Summary

The right mental model for GRRADO right now is:

- product vision: broad platform
- implementation reality: backend-first microservices foundation
- immediate goal: reduce ambiguity, close Phase 4 gaps, and stabilize the system before adding more scope
