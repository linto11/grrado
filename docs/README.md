# 📚 GRRADO Documentation

[![License: Apache-2.0](https://img.shields.io/badge/License-Apache_2.0-green.svg)](LICENSE)
[![Documentation](https://img.shields.io/badge/Docs-Consolidated%202.0-blue)]()
[![Standards](https://img.shields.io/badge/Standards-Unified%20Rulebook-green)]()

**Status:** ✅ Fully Consolidated | ✅ All Files Kebab-Case | ✅ Unified Standards | Last Updated: January 31, 2026

---

## 🚀 START HERE

**👉 New to the project?** Start with the [master documentation index](../docs-index.md) at the workspace root.

**Key entry points:**
- **Quick Start (30 sec):** [quick-start.md](../quick-start.md)
- **Status Check (5 min):** [02-progress-tracking/current-status.md](02-progress-tracking/current-status.md)
- **Development Rules:** [.vscode/rulebook.md](../.vscode/rulebook.md) — **MANDATORY**
- **Master Plan:** [implementation-plan.md](../implementation-plan.md)
- **API Testing:** [how-to-run-and-test-api.md](../docs/how-to-run-and-test-api.md)

---

## 📖 Documentation Organization

This folder contains detailed reference material. For a quick overview, see:

### **At Workspace Root** (Top-level entry points)
- [.vscode/rulebook.md](../.vscode/rulebook.md) — Development standards & enforcement
- [quick-start.md](../quick-start.md) — 30-second quick start
- [02-progress-tracking/current-status.md](02-progress-tracking/current-status.md) — 5-minute status update
- [implementation-plan.md](../implementation-plan.md) — Master development plan
- [phase-4-rest-api-completion.md](../phase-4-rest-api-completion.md) — What's been built
- [build-verification.md](../build-verification.md) — Build status proof
- [docs-index.md](../docs-index.md) — Master documentation index

### **In docs/ folder**
- [how-to-run-and-test-api.md](how-to-run-and-test-api.md) — Complete API testing guide
- [pr-checklist.md](pr-checklist.md) — Code review enforcement
- **Phase-specific docs** → [03-phase-specific/](03-phase-specific/)
- **Requirements** → [01-requirements/](01-requirements/)
- **Progress tracking** → [02-progress-tracking/progress-tracker.md](02-progress-tracking/progress-tracker.md)

---

## 🎯 Quick Links

- **📋 Implementation Plan:** [../implementation-plan.md](../implementation-plan.md) ← Master development guide
- **📊 Progress Tracker:** [02-progress-tracking/progress-tracker.md](02-progress-tracking/progress-tracker.md) ← Single source of truth
- **🏗️ Phase Documentation:** [03-phase-specific/](03-phase-specific/) ← Detailed phase completions
- **💾 Database Design:** [03-phase-specific/phase-3-database-liquibase/](03-phase-specific/phase-3-database-liquibase/) ← Database schema & Liquibase
- **✅ Standards:** [../.vscode/rulebook.md](../.vscode/rulebook.md) ← **MANDATORY** development rules

## Tech Stack

**Backend:**
- .NET Core 9 (C#)
- Clean Architecture (Domain, Application, Infrastructure, API layers)
- Entity Framework Core 9 + PostgreSQL 16
- Redis (distributed caching with error message support)
- Liquibase (database version control)
- MediatR (CQRS pattern)
- FluentValidation (validation with error codes)
- AutoMapper (DTO mapping)

**Frontend:**
- Flutter (Unified Web + Mobile)
- Clean Architecture (Domain, Data, Presentation layers)
- Bloc/Cubit (State Management)
- Tailwind-inspired styling
- ngx-echarts (Angular version) → local_charts/community widgets (Flutter version)

**Infrastructure:**
- PostgreSQL 16 (database)
- Redis 7 (distributed caching)
- Liquibase (schema management)
- Keycloak (authentication/authorization)
- Docker & Docker Compose (containerization)
- Serilog (structured logging with correlation tracking)

**Development Tools:**
- VS Code (recommended IDE)
- .NET CLI 9
- Node.js 20 LTS
- npm / Angular CLI 19

## Project Status

**Phases Completed:** 1, 2, 3 (Environment, Architecture, Database)  
**Total Progress:** 21% (155 of 735 hours)  
**Current Phase:** 4 - Backend API Development (57% Foundation Complete)

| Phase | Status | Tasks | Time |
|-------|--------|-------|------|
| 1: Environment Setup | ✅ Complete | 7/7 | 5 hrs |
| 2: Project Structure | ✅ Complete | 13/13 | 8 hrs |
| 3: Database & Liquibase | ✅ Complete | 13/13 | 15 hrs |
| 4: Backend API | 🔄 In Progress | 8/14 | 55 hrs |
| 5: Frontend UI | ⏳ Pending | 0/10 | 30 hrs |
## Documentation

- **[implementation-plan.md](implementation-plan.md)** - Detailed implementation plan for all phases (start here for development)
- **[docs/02-progress-tracking/progress-tracker.md](docs/02-progress-tracking/progress-tracker.md)** - Task-by-task progress tracking
- **[docs/03-phase-specific/](docs/03-phase-specific/)** - Complete documentation for each phase
- **[docs/00-getting-started/](docs/00-getting-started/)** - Setup and getting started guides
- **[changelog.md](changelog.md)** - Version history and release notes
- **[code-of-conduct.md](code-of-conduct.md)** - Community guidelines
- **[contributing.md](contributing.md)** - Contribution guidelines

## Community

- **Issues:** Report bugs or request features via GitHub issues
- **Discussions:** Ask questions and share ideas
- **Contributing:** See [contributing.md](contributing.md)

## License

This project is licensed under the Apache License 2.0. See [LICENSE](LICENSE) for details.

---

**Last Updated:** January 18, 2026  
**Current Phase:** 4 - Backend API Development (57% Foundation)  
**Overall Progress:** 21% (155 of 735 hours)

## Latest Achievements (January 18, 2026)

✅ **Error Code Management System**
- JSON-based configuration with 32 error codes
- String code names (e.g., `USER_NAME_REQUIRED`) instead of GUIDs
- Redis distributed caching with 6-hour automatic refresh
- Code name to GUID resolution with O(1) dictionary lookup
- Hot reload support for runtime configuration updates

✅ **Architecture Foundation**
- Abstractions layer with 24 DTOs (Read/Create/Update)
- Repository + Unit of Work patterns
- AutoMapper with CQRS profile
- Serilog structured logging with correlation IDs
- Keycloak authentication services
- Layer-specific dependency injection

✅ **Validation System**
- FluentValidation with error codes
- 32 error codes mapped to use cases
- Result and ValidationError models
- 5 User validators with comprehensive rules

✅ **Database**
- 8 tables with soft-delete pattern
- 3,400+ seed records via Liquibase
- Composite indexes for performance
- Error message table with UseCase support

## Getting Started

### Prerequisites
- .NET Core 9 SDK
- Node.js 20 LTS
- PostgreSQL 16 (Docker)
- VS Code (recommended)
- Docker Desktop

### Setup (Phases 1-3 already complete)

```bash
# Clone repository
git clone <repo-url>
cd AI-ML-Project

# Start database
docker-compose up -d

# Verify database
psql -h localhost -U postgres -d vehicle_service_db -c "SELECT COUNT(*) FROM \"Users\";"
# Should show: 100 users

# Build backend
cd server
dotnet restore
dotnet build

# Build frontend
cd ../client
npm install
ng build
```

## Project Structure

```
AI-ML-Project/
├── app/                            # Applications (Backend + Frontend)
│   ├── app/server/                      # .NET Backend
│   ├── Domain/                      # Entity models
│   ├── Application/                 # Business logic
│   ├── Infrastructure/              # Data access & Liquibase
│   │   ├── Database/
│   │   │   └── liquibase/          # Schema migrations
│   │   ├── Data/                    # EF Core DbContext
│   │   └── Services/                # Infrastructure services
│   └── API/                         # REST API
│
│   └── app/client/                      # Angular Frontend
│   ├── src/app/
│   │   ├── core/                    # Services, interceptors
│   │   ├── shared/                  # UI components
│   │   └── features/                # Feature modules (8 entities)
│   └── styles.css                   # Tailwind CSS
│
├── scripts/
│   ├── database-setup/              # Database initialization
│   │   ├── init-db.sql
│   │   └── create_migration_user.sql
│   ├── seeding/                     # Manual seed data scripts
│   │   ├── seed-data-corrected.sql
│   │   ├── seed-data-final.sql
│   │   └── seed-sample-data.sql
│   ├── db-maintenance/              # Utility SQL (truncate, verify, health checks)
│   │   ├── check-seeded.sql
│   │   ├── test-query.sql
│   │   ├── truncate-tables.sql
│   │   └── verify-data.sql
│   └── utilities/
│       └── run-api.bat
│
├── docs/                            # Documentation
│   ├── 00-getting-started/
│   ├── 01-requirements/
│   ├── 02-progress-tracking/        # Task tracking
│   ├── 03-phase-specific/           # Phase documentation
│   └── 04-deployment-guides/
│
├── data/                            # CSV seed data
├── docker-compose.yml               # Docker services
└── implementation-plan.md           # THIS PLAN
```

## Manual Database Seeding

Use this when you need a lightweight dataset without running the full Liquibase seed pipeline.

1. **Start the database**
    - Bring up PostgreSQL using your preferred workflow (Docker Compose, `docker run`, or local install)
    - The default Docker container name is `vehicle-service-postgres`; confirm with `docker ps`
2. **Copy the script into the container**
    - `docker cp scripts/seeding/seed-data-corrected.sql vehicle-service-postgres:/tmp/seed-data.sql`
3. **Execute the seed script**
    - `docker exec -it vehicle-service-postgres psql -U postgres -d vehicle_service_db -f /tmp/seed-data.sql`
4. **Verify the insert counts**
    - The script ends with `SELECT COUNT(*)` statements for `Users`, `Vehicles`, `Garages`, `Services`, and `DiagnosticRules`
    - Re-run `docker exec -it vehicle-service-postgres psql -U postgres -d vehicle_service_db -c "SELECT COUNT(*) FROM ""Users"";"` if you want to double-check later

> `seed-data-corrected.sql` matches the current PostgreSQL schema (no `DeletedAt`/`FamilyType` columns) and is the recommended script. The other files in `scripts/seeding/` are archival references of earlier iterations.

Additional helpers live in `scripts/db-maintenance/`:
- `truncate-tables.sql` to clear all tables safely (schema stays intact)
- `verify-data.sql` / `test-query.sql` quick sanity checks
- `check-seeded.sql` validation query collection

Use these whenever you need to reset or inspect the database outside of Liquibase.

## Database Schema

**8 Tables:**
- **Users** (100 records) - Customer profiles
- **Vehicles** (650+ records) - Vehicle inventory
- **Garages** - Service provider locations
- **Services** - Service offerings by garage
- **VehicleIssues** - Reported issues
- **ServiceHistories** - Service appointments
- **DiagnosticRules** - AI diagnostic rules
- **ImageDiagnostics** - Image analysis results

**Features:**
- 12 composite indexes for performance
- 5 foreign key relationships
- Soft-delete pattern on all tables
- 3,400+ seed records via Liquibase

## Database Management

**Version Control:** Liquibase (not EF Core migrations)

```bash
# Check status
cd app/server/Infrastructure/Database
liquibase status

# Deploy schema and seed data
liquibase update

# View changelog
liquibase history
```

**Setup Scripts** (environment configuration only):
- `scripts/prerequisites/00-database-init/init-db.sql` - Creates database
- `scripts/prerequisites/00-database-init/create_migration_user.sql` - Creates migration user

## Development Workflow

### Backend (Phase 4)
```bash
cd app/server/API

# Build
dotnet build

# Run API
dotnet run

# Test
dotnet test
```

**API will be available at:** http://localhost:5000  
**Swagger UI:** http://localhost:5000/swagger

### Frontend (Phases 5+)
```bash
cd client

# Install dependencies
npm install

# Development server
ng serve

# Build
ng build
```

**Application will be available at:** http://localhost:4200

## Key Features

### Authentication
- OAuth 2.0 / OIDC via Keycloak
- Role-based access control (RBAC)
- Token refresh and session management

### API
- 32 REST endpoints (4 per entity)
- Full CRUD operations
- Soft-delete with restore
- File upload for images
- Search and filtering
- Pagination support

### UI
- Responsive design (mobile-first)
- Tailwind CSS styling
- Interactive charts (ngx-echarts)
- Data grids with sorting/filtering
- Modal dialogs for forms
- Image upload and preview

### Analytics
- Service volume trends
- Vehicle health metrics
- Garage performance
- Upcoming maintenance
- Dashboard with real-time updates

## Next Steps (Phase 4)

See [implementation-plan.md](implementation-plan.md) for detailed Phase 4 tasks:

1. Configure Keycloak authentication
2. Scaffold DbContext from database
3. Build repository pattern
4. Create DTOs and mappings
5. Implement service layer
6. Build REST API controllers
7. Add file upload endpoint
8. Create Swagger documentation

## Documentation
- Activation blocked? Allow for the session:
  ```pwsh
  Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
  ```
- Install errors? Upgrade pip then retry:
  ```pwsh
  python -m pip install --upgrade pip
  pip install -r _requirements.txt
  ```

## Contributing
See contributing.md and code-of-conduct.md. Open issues/PRs using the templates in .github/.

## License
Apache-2.0. See LICENSE.

