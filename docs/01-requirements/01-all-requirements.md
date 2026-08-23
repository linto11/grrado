# All Project Requirements - Vehicle Service Aggregator Platform

**Created:** January 11, 2026
**Last Updated:** February 14, 2026
**Architecture:** Microservices (.NET 9.0) -- 7 services + YARP Gateway
**Current Phase:** Phase 4 In Progress (~65%)
**Overall Progress:** ~18% (~210 of 1,171 hours)

---

This file contains the original project task breakdown. The project scope has been significantly expanded since initial creation.

**Note:** The project has evolved from the original 11-phase/101-task plan to a 12-phase/1,171-hour microservices architecture. For the most current task tracking, see:
→ **[progress-tracker.md](../02-progress-tracking/progress-tracker.md)**

The phases below reflect the **original scope**. Phases 5-11 have been redefined (see progress tracker for current definitions).

---

## Quick Summary by Phase

| Phase | Name | Status | Tasks | Complete |
|-------|------|--------|-------|----------|
| 1 | Environment Setup | ✅ Complete | 7 | 7/7 |
| 2 | Project Structure | ✅ Complete | 12 | 12/12 |
| 3 | Database Design | 🔄 In Progress | 13 | 12/13 |
| 4 | Backend API | ⏳ Blocked | 14 | 0/14 |
| 5 | Frontend Setup | ⏳ Blocked | 10 | 0/10 |
| 6 | CRUD Grids | ⏳ Blocked | 10 | 0/10 |
| 7 | Image Handling | ⏳ Blocked | 4 | 0/4 |
| 8 | Dashboard | ⏳ Blocked | 7 | 0/7 |
| 9 | UI Styling | ⏳ Blocked | 5 | 0/5 |
| 10 | Testing | ⏳ Blocked | 11 | 0/11 |
| 11 | Deployment | ⏳ Blocked | 8 | 0/8 |

**TOTAL:** 101 tasks | **31 Complete** | **31% Progress**

---

## Phase 1: Environment Setup ✅ (7/7 - 100%)

All prerequisites and development environment installed:

1. ✅ Install .NET 9.0 SDK (v9.0.100)
2. ✅ Install Node.js (LTS) and npm (v20.11.1, npm 10.2.4)
3. ✅ Install PostgreSQL database server (via Docker - port 5432)
4. ✅ Install Angular CLI 19 globally (v19.2.19)
5. ✅ Set up Docker (running, containers started)
6. ✅ Set up Keycloak server (via Docker - port 8080, initializing)
7. ✅ Verify all installations and versions

---

## Phase 2: Project Structure ✅ (12/12 - 100%)

All folder structures, projects, and configurations created:

1. ✅ Create `/server` folder (.NET Core 10 project)
2. ✅ Create `/client` folder (Angular 19 project)
3. ✅ Initialize .NET Core 10 solution with clean architecture (Domain, Application, Infrastructure, API)
4. ✅ Initialize Angular 19 project with standalone components
5. ✅ Configure Tailwind CSS styling with custom Shadcn-inspired components
6. ✅ Install Shadcn-inspired components (Button, Card, Input, Modal, Table)
7. ✅ Install ngx-echarts for charts (v19 compatible)
8. ✅ Create folder structure for `/uploads/images/` in API project
9. ✅ Verify both .NET and Angular projects build successfully

---

## Phase 3: Database Design & Setup 🔄 (12/13 - 92%)

**Status:** In Progress - Liquibase CLI deployment remaining  
**Estimated Completion:** 30-60 minutes

### Schema & Infrastructure (Complete)
1. ✅ Create database schema in PostgreSQL (9 tables, 12 indexes, 5 FKs)
2. ✅ Implement soft-delete pattern on all entities
3. ✅ Create composite indexes for performance optimization
4. ✅ Establish referential integrity relationships

### Liquibase Framework (Complete)
5. ✅ Set up Liquibase directory structure (`/server/API/liquibase/`)
6. ✅ Create master-changelog.xml (orchestrator for all versions)
7. ✅ Create 001-initial-schema.xml (schema DDL - 8 tables, 12 indexes)
8. ✅ Create 002-seed-data.xml (data insertion references)
9. ✅ Configure liquibase.properties (PostgreSQL connection)
10. ✅ Generate 8 SQL seed files from CSV data (3,400+ records)

### Documentation (Complete)
11. ✅ Write liquibase/README.md (300+ line comprehensive guide)
12. ✅ Create project documentation (implementation summaries and cheat sheets)

### Remaining (Next Steps)
13. [ ] Install Liquibase CLI and deploy schema

---

## Phase 4: Backend API Development ⏳ (0/14 - 0%)

**Status:** Blocked - Waiting for Phase 3 completion  
**Estimated Time:** 40 hours

1. [ ] Configure Keycloak authentication (OAuth 2.0/OIDC)
2. [ ] Build authentication service layer (token validation, RBAC, user context)
3. [ ] Create base repository pattern (generic repo, soft-delete filtering)
4. [ ] Implement DTOs for all 8 entities (Request/Response, Create/Update/Detail)
5. [ ] Create service layer with business validation
6. [ ] Build REST API controllers (GET, POST, PUT, DELETE, PATCH restore)
7. [ ] Implement server-side pagination (skip, take parameters)
8. [ ] Implement dual-search functionality (name + description)
9. [x] Implement SkiaSharp for thumbnail generation (200x200px) - Zero vulnerabilities
10. [ ] Create file upload endpoint (/api/upload)
11. [ ] Create timezone utility class and conversion methods
12. [ ] Add soft-delete filtering and visibility toggle
13. [ ] Capture user info on delete operations
14. [ ] Test API with 3,400+ seed records

---

## Phase 5: Frontend UI Setup ⏳ (0/10 - 0%)

**Status:** Blocked - Waiting for Phase 4 API completion  
**Estimated Time:** 30 hours

1. [ ] Initialize Angular feature modules (Dashboard + 8 entities + Shared)
2. [ ] Configure Keycloak/OIDC integration (OAuth 2.0 flow)
3. [ ] Create authentication service (login/logout, token management, user profile)
4. [ ] Build HTTP interceptor (token injection, error handling, logging)
5. [ ] Implement route guards (authentication, role-based access)
6. [ ] Create navigation & layout (sidebar, header, responsive mobile layout)
7. [ ] Create timezone detection service (browser timezone, conversion utilities)
8. [ ] Create API service (generic HTTP methods, type-safe responses)
9. [ ] Build reusable grid component (DataTable with pagination, search, sorting)
10. [ ] Build reusable modal component (create/edit forms, dialogs)

---

## Phase 6: CRUD Grids & Forms ⏳ (0/10 - 0%)

**Status:** Blocked - Waiting for Phase 5 completion  
**Estimated Time:** 50 hours  
**Scope:** For all 8 entities (Users, Vehicles, Garages, Services, ServiceHistories, VehicleIssues, DiagnosticRules, ImageDiagnostics)

1. [ ] Create list/grid views (columns, pagination, sorting, search, soft-delete toggle)
2. [ ] Create detail/read-only views (all fields, back button, edit action)
3. [ ] Create add/create forms (validation, required indicators, error handling)
4. [ ] Create edit/update forms (pre-populated data, validation, error handling)
5. [ ] Create delete confirmations (soft-delete dialogs, confirmation/cancel)
6. [ ] Create restore functionality (show for deleted items, restore dialogs)
7. [ ] Implement grid features (DataTables-like pagination, multi-column sorting, global search)
8. [ ] Implement form features (reactive validation, error display, success/error notifications)
9. [ ] Add soft-delete visibility toggle (hide/show deleted records)
10. [ ] Test all CRUD operations (Create, Read, Update, Delete, Restore)

---

## Phase 7: Image Diagnostics Special Handling ⏳ (0/4 - 0%)

**Status:** Blocked - Waiting for Phase 6 completion  
**Estimated Time:** 15 hours

1. [ ] File upload input in forms (drag-and-drop, type/size validation, preview)
2. [ ] Thumbnail display in grid (200x200px, clickable, loading placeholder)
3. [ ] Full image display (modal/lightbox, full resolution, download button)
4. [ ] Image preview/download functionality (proper MIME types, filename handling)

---

## Phase 8: Analytics Dashboard ⏳ (0/7 - 0%)

**Status:** Blocked - Waiting for Phase 5 completion  
**Estimated Time:** 20 hours

1. [ ] Service Volume Trend (line chart - 12 months, ngx-echarts, tooltips)
2. [ ] Vehicle Health Summary (gauge charts, average mileage, fuel type distribution)
3. [ ] Upcoming Maintenance (table view - 30 days, priority indicators, links)
4. [ ] Garage Performance (bar chart - top 10 garages, service count, ratings)
5. [ ] Dashboard controls (refresh button, date range filter, entity filter)
6. [ ] Timezone support (user timezone display, conversion utilities, timezone indicator)
7. [ ] Styling (Tailwind grid, Shadcn cards, consistent colors, responsive design)

---

## Phase 9: UI Styling & Responsive Design ⏳ (0/5 - 0%)

**Status:** Blocked - Waiting for Phase 8 completion  
**Estimated Time:** 20 hours

1. [ ] Apply Tailwind CSS globally (base styles, utilities, custom theme, dark mode)
2. [ ] Use Shadcn components (Button, Input, Dialog, Table, Card for consistency)
3. [ ] Mobile-first responsive design (mobile, tablet, desktop breakpoints)
4. [ ] Test on multiple devices (mobile, tablet, desktop; Chrome, Firefox, Safari, Edge)
5. [ ] Accessibility features (ARIA labels, keyboard navigation, focus indicators, WCAG AA compliance)

---

## Phase 10: Integration & Testing ⏳ (0/11 - 0%)

**Status:** Blocked - Waiting for Phase 9 completion  
**Estimated Time:** 30 hours  
**Test Data:** 3,400+ pre-seeded records

1. [ ] Authentication testing (Keycloak login, token refresh, RBAC, logout, session timeout)
2. [ ] CRUD operations (Create, Read, Update, Delete, Restore all 8 entities)
3. [ ] Soft-delete functionality (hidden by default, toggle shows deleted, restore works)
4. [ ] Search functionality (global search, name search with highlighting, description search)
5. [ ] Pagination testing (page size selector, next/previous, jump to page, total count)
6. [ ] File operations (image upload success, thumbnail generation, download, large files)
7. [ ] Dashboard KPIs (chart data accuracy, timezone conversion, refresh updates, filters)
8. [ ] Timezone conversion (UTC↔User timezone, cross-timezone ops, DST handling)
9. [ ] Role-based access control (admin permissions, user permissions, unauthorized blocked)
10. [ ] Error handling (400, 401, 403, 404, 500, timeout handling)
11. [ ] Load testing (3,400+ records pagination, grid/chart rendering performance)

---

## Phase 11: Deployment & Documentation ⏳ (0/8 - 0%)

**Status:** Blocked - Waiting for Phase 10 completion  
**Estimated Time:** 20 hours  
**Final Phase:** Prepare for production deployment

1. [ ] Create deployment scripts (Docker build backend/frontend, Docker Compose, env vars, DB migration)
2. [ ] Create system requirements documentation (CPU, RAM, disk, browser support)
3. [ ] Set up PostgreSQL backup strategy (automated daily backups, 30-day retention, restore procedures)
4. [ ] Create API documentation (Scalar/OpenAPI, all 32 endpoints, examples, error codes)
5. [ ] Create Angular documentation (component guide, service docs, routing, state management)
6. [ ] Create deployment guide (step-by-step, pre/post-deployment checklist, verification, rollback)
7. [ ] Create user guide (entity management, search/pagination, image uploads, dashboard)
8. [ ] Set up monitoring & logging (error logging, performance monitoring, database monitoring, alerts)

---

## Project Timeline

| Metric | Value |
|--------|-------|
| **Completed Time** | ~95 hours (Phases 1-3 partial) |
| **Remaining Time** | ~640 hours (Phases 4-11) |
| **Total Project Time** | ~735 hours (~4.5 months full-time) |
| **Current Progress** | 31% |

---

## Database Schema (Phase 3)

**8 Tables with relationships:**
- Users
- Vehicles  
- VehicleIssues
- DiagnosticRules
- ImageDiagnostics
- Garages
- Services
- ServiceHistories

**Test Data:** 3,400+ seed records across all tables

---

## Key Technologies

- **Backend:** .NET 9.0, Entity Framework Core 9.0.1, MediatR 14.0.0 (CQRS)
- **Architecture:** Microservices (7 services + YARP API Gateway)
- **Frontend:** Flutter (Unified Web + Mobile), Material Design 3, Bloc/Cubit
- **AI/ML:** Azure AI Foundry (chatbot models integration) + Python 3.11+ (custom ML development)
- **Database:** PostgreSQL 15 (database-per-service, 7 databases)
- **Messaging:** RabbitMQ 3 (async inter-service communication)
- **Caching:** Redis 7 (distributed caching)
- **Authentication:** Keycloak OAuth 2.0/OIDC (deferred to Phase 5)
- **Resilience:** Polly 8.4.1 (retry, circuit breaker, timeout, bulkhead)
- **API Docs:** OpenAPI + Scalar 1.2.48
- **CMS:** Headless CMS with multi-language support (Phase 6)

---

## For Detailed Task Tracking

→ See **[progress-tracker.md](../02-progress-tracking/progress-tracker.md)** for:
- Complete checklist with expanded scope (1,168 hours)
- Task status tracking
- Time estimates per phase
- Dependencies and blockers
- Current phase details

→ See **[comprehensive-project-plan.md](../00-getting-started/comprehensive-project-plan.md)** for:
- Complete platform specifications
- 4-tier role hierarchy details
- AI chatbot and ML platform features
- Mobile app specifications
- CMS and content management details

---

*Last Updated: February 14, 2026*
*Source: Progress Tracker (Comprehensive)*
