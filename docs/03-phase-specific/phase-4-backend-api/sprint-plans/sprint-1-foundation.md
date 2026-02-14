# Sprint 1: Foundation - Tasks 001-005

**Sprint:** 1  
**Phase:** 4 - REST API Backend  
**Duration:** 50 minutes (1 day)  
**Start Date:** February 1, 2026  
**Target End Date:** February 1, 2026  
**Status:** ⏳ NOT STARTED  

---

## 🎯 Sprint Goal

Establish foundational infrastructure for Phase 4 development including git branching strategy, Keycloak authentication setup, database schema validation, and local development environment readiness.

---

## 📋 Sprint Tasks

### Task 001: Git Branching Strategy & Workflow Setup
**Estimated Time:** 10 minutes  
**Status:** ⏳ TODO  
**Dependency:** None (foundational)  
**Branch:** `feature/4-branching-strategy`  

**Deliverable:**
- ✅ Branching rules documented in `.vscode/rules/branching-rule.md`
- ✅ Settings updated in `.vscode/settings.json`
- ✅ `develop` branch created from `main`
- ✅ Branch protection configured

**Acceptance Criteria:**
- [ ] `.vscode/rules/branching-rule.md` readable and complete
- [ ] `.vscode/settings.json` references branching rules
- [ ] Feature branch naming convention understood: `feature/<phase>-<name>`
- [ ] All team members can create branches per convention

---

### Task 002: Keycloak Realm & Client Configuration
**Estimated Time:** 10 minutes  
**Status:** ⏳ TODO  
**Dependency:** Task 001 (feature branch required)  
**Branch:** `feature/4-keycloak-integration`  

**Deliverable:**
- ✅ Keycloak realm `vehicle-service` created
- ✅ Client `vehicle-service-api` configured as Confidential
- ✅ Client secret generated and saved
- ✅ Realm roles created: `admin`, `garage_admin`, `user`, `support`
- ✅ appsettings.json updated with valid credentials

**Acceptance Criteria:**
- [ ] Realm exists in Keycloak Admin Console
- [ ] Client secret in appsettings.json (not placeholder)
- [ ] Realm name matches appsettings
- [ ] Token generation tested via Postman
- [ ] All realm roles created

**Critical Issue Resolved:**
- ✅ Placeholder `your-client-secret-here` replaced with actual secret
- ✅ Realm name mismatch fixed (now consistent: `vehicle-service`)

---

### Task 003: PostgreSQL Schema Alignment with EF Models ⚠️ CRITICAL
**Estimated Time:** 10 minutes  
**Status:** ⏳ TODO  
**Dependency:** Task 001 (feature branch required)  
**Branch:** `feature/4-database-schema-alignment`  
**BLOCKER:** This task **MUST** complete before API development can proceed

**Deliverable:**
- ✅ All 8 portal tables have complete schema
- ✅ All 5 chatbot tables created
- ✅ Soft-delete columns: `DeletedAt`, `IsDeleted`
- ✅ Audit columns: `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy`, `DeletedBy`
- ✅ All 30+ database indexes created
- ✅ API endpoints return 200 (not 500)

**Acceptance Criteria:**
- [ ] Liquibase migrations run successfully (001 → 003)
- [ ] Schema validation passes (all tables & columns exist)
- [ ] Foreign key relationships verified
- [ ] Sample API endpoint responds: `GET /api/v1/users` → 200 OK
- [ ] No HTTP 500 errors in logs

**Critical Issue Resolved:**
- 🔴 **BLOCKER FIXED:** Missing `DeletedAt` column added
- 🔴 **BLOCKER FIXED:** Missing audit fields added
- 🔴 **BLOCKER FIXED:** All HTTP 500 errors caused by schema mismatch resolved

---

### Task 004: NuGet Package Validation & Installation
**Estimated Time:** 5 minutes  
**Status:** ⏳ TODO  
**Dependency:** Task 001 (feature branch required)  
**Branch:** `feature/4-nuget-validation`  

**Deliverable:**
- ✅ All packages restored successfully
- ✅ No version conflicts
- ✅ Build succeeds: `dotnet build` (0 errors)
- ✅ All JWT packages present
- ✅ All EF Core packages present
- ✅ All Serilog packages present
- ✅ All Polly packages present

**Acceptance Criteria:**
- [ ] `dotnet restore` completes without errors
- [ ] `dotnet build` succeeds (0 errors, 0 warnings)
- [ ] `dotnet list package` shows no conflicts
- [ ] `dotnet list package --vulnerable` shows no vulnerabilities

---

### Task 005: Local Development Environment Verification
**Estimated Time:** 5 minutes  
**Status:** ⏳ TODO  
**Dependency:** Tasks 001-003 (all services must be configured)  
**Branch:** `feature/4-environment-verification`  

**Deliverable:**
- ✅ PostgreSQL running on `localhost:5433`
- ✅ Redis running on `localhost:6379`
- ✅ Keycloak running on `localhost:8080`
- ✅ API builds and runs: `dotnet run`
- ✅ Health endpoint responds: `GET /api/v1/health` → 200
- ✅ Scalar API docs accessible: `http://localhost:5101/scalar/v1`
- ✅ Logs directory created and active

**Acceptance Criteria:**
- [ ] All 3 services verified running
- [ ] All connection strings correct
- [ ] API startup has no errors
- [ ] Health endpoint returns 200
- [ ] Scalar API docs load successfully
- [ ] Logs being written to `app/server/API/logs/`

---

## 📊 Sprint Status

```
Sprint 1 Progress

Tasks Completed:    0/5 (0%)
Time Completed:     0/50 minutes (0%)
Status:             ⏳ NOT STARTED

Blockers:           PostgreSQL schema missing (Task 003)
Critical Path:      001 → 002,003,004 → 005
```

---

## 🎯 Success Criteria

Sprint 1 is COMPLETE when:

- [ ] All 5 tasks marked ✅ COMPLETED
- [ ] All task status files updated
- [ ] All 5 feature branches merged to develop
- [ ] All 5 changelog entries created
- [ ] Build succeeds: `dotnet build` (0 errors)
- [ ] API runs: `dotnet run` (no startup errors)
- [ ] Health check passes: `GET /api/v1/health` → 200
- [ ] All services running (PostgreSQL, Redis, Keycloak)
- [ ] No critical blockers remaining

---

## 📅 Execution Timeline

**Recommended Day 1 Schedule:**

```
Morning (1-2 hours):
├─ 00:00-00:10  Task 001: Git Branching Setup
├─ 00:10-00:20  Task 002: Keycloak Configuration
├─ 00:20-00:30  Task 003: Database Schema Alignment
├─ 00:30-00:35  Task 004: NuGet Validation
└─ 00:35-00:40  Task 005: Environment Verification

Buffer:         10 minutes for troubleshooting
TOTAL TIME:     ~50 minutes (+ debugging)
```

---

## 🔧 Pre-Sprint Checklist

Before starting Sprint 1, verify:

- [ ] Git repository cloned and up-to-date
- [ ] VS Code or Visual Studio opened at repository root
- [ ] PowerShell or terminal ready
- [ ] `.vscode/rules/branching-rule.md` created ✅
- [ ] `.vscode/settings.json` updated ✅
- [ ] Task files created (001-005) ✅
- [ ] All services available (Docker Desktop running if using containers)

---

## 🚫 Critical Blockers

### Blocker 1: PostgreSQL Schema Missing Columns (Task 003)

**Status:** ⏳ BLOCKING ALL API DEVELOPMENT  
**Symptom:** API endpoints return HTTP 500  
**Root Cause:** Schema missing `DeletedAt`, audit fields  
**Solution:** Run Liquibase migrations completely  

**Impact:**
- Cannot test API endpoints without fix
- All Portal API tasks blocked
- Database connection tests fail

**Resolution in Task 003:**
- [ ] Run Liquibase migrations 001-003
- [ ] Verify schema matches EF models
- [ ] Test API endpoint returns 200

### Blocker 2: Keycloak Not Configured (Task 002)

**Status:** ⏳ BLOCKING AUTH TASKS  
**Symptom:** Token validation fails, no realm/client  
**Root Cause:** Keycloak realm/client not created  
**Solution:** Set up realm and client in Keycloak Admin Console  

**Impact:**
- Cannot validate JWT tokens
- Auth tasks (2001-2008) blocked
- OAuth2 flows not configured

**Resolution in Task 002:**
- [ ] Create realm: `vehicle-service`
- [ ] Create client: `vehicle-service-api`
- [ ] Update ClientSecret in appsettings

---

## 🚀 Next Sprint

**Sprint 2: Portal API - User Management (Tasks 101-104)**
- Depends on: Sprint 1 COMPLETE
- Duration: 40 minutes (1 day)
- Deliverable: First working REST API with User CRUD

---

## 📝 Daily Standup Template

Use this template for daily team standup:

```markdown
## Sprint 1 - Day 1 Standup

**Completed Today:**
- [ ] Task 001: [Status]
- [ ] Task 002: [Status]
- [ ] Task 003: [Status] ⚠️ CRITICAL
- [ ] Task 004: [Status]
- [ ] Task 005: [Status]

**In Progress:**
- [ ] Task ###: [Description]

**Blockers:**
- [ ] [Blocker Description] - ETA Fix: [Date/Time]

**Plan for Tomorrow:**
- [ ] Sprint 2: Portal API - User Management

**Metrics:**
- Tasks Completed: X/5
- Build Status: [PASS/FAIL]
- Test Status: [PASS/FAIL]
```

---

## 📚 Reference Documentation

- **Branching Strategy:** `.vscode/rules/branching-rule.md`
- **Task Details:** `tasks/00-foundational/`
- **Project Status:** `docs/02-progress-tracking/current-status.md`
- **Architecture Guide:** `docs/00-getting-started/01-project-overview.md`

---

## 🔗 Related Documents

- [Completion Log](./completion-log.md) - Track task progress
- [Blockers & Risks](./blockers-and-risks.md) - Risk register
- [Sprint 2 Plan](./sprint-2-user-api.md) - Next sprint
