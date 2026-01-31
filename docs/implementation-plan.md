# Grrado - Vehicle Service Aggregator Platform - Implementation Plan

**Last Updated:** January 25, 2026  
**Overall Progress:** 9% (103 of 1,171 hours complete)  
**Current Phase:** Phases 1-3 ✅ COMPLETE | Phase 4 🔄 IN PROGRESS (Extended for Chatbot)  
**Strategy:** Backend-First with AI Chatbot Focus - Complete Portal & Chatbot APIs before Mobile/Web UIs

---

## Executive Summary

The Vehicle Service Portal follows a **backend-first strategy prioritizing the AI chatbot core**. The foundation is complete (environment, architecture, database). Phase 4 is extended to include chatbot database infrastructure, ensuring both portal APIs and chatbot backend are production-ready before UI development.

**Strategic Sequence:**
1. **Phase 4:** Backend APIs for portal + chatbot database infrastructure
2. **Phase 5:** Role/Permission system (gates everything else)
3. **Phase 6:** CMS (content for chatbot knowledge base)
4. **Phase 7:** AI Platform & Chatbot (4 modes: text, voice, image, deep thinking)
5. **Phase 10:** Web Portals (Flutter Web - priority over mobile)
6. **Phases 8-9:** Mobile Apps (customer + admin)
7. **Phases 11-12:** Testing & Deployment

**Key Stats:**
- ✅ **Complete:** Phases 1-3 (environment, architecture, database design)
- 🔄 **In Progress:** Phase 4 Backend APIs (Extended from 100h → 135h for chatbot)
- ⏳ **Next:** Complete Phase 4, then Phase 5 (Roles/Permissions)
- 🤖 **Strategic Focus:** AI Chatbot (200h) in Phase 7 - supports text, voice, image, deep thinking
- 📦 **Database:** 13 tables (8 core + 5 chatbot-specific) with 3,400+ seed records
- 🛠️ **Tech Stack:** .NET 9, PostgreSQL 16, Keycloak, Azure AI Foundry, Flutter (Web+Mobile)
- 🏗️ **Architecture:** Clean Architecture (Domain, Application, Infrastructure, API)

---

## Completed Work (Phases 1-3)

### ✅ Phase 1: Environment & Prerequisites (Complete)
**Completion Date:** January 11, 2026  
**Documentation:** [phase-1-environment-setup/README.md](docs/03-phase-specific/phase-1-environment-setup/README.md)

**Verified:**
- ✅ .NET Core 9 SDK (v10.0.101)
- ✅ Flutter SDK 3.x
- ✅ Python 3.11+ (for custom AI/ML development)
- ✅ Azure account for AI Foundry
- ✅ PostgreSQL 16 (Docker, port 5432)
- ✅ Keycloak (Docker, port 8080)
- ✅ Docker Desktop

### ✅ Phase 2: Project Structure & Configuration (Complete)
**Completion Date:** January 11, 2026  
**Documentation:** [phase-2-project-structure/README.md](docs/03-phase-specific/phase-2-project-structure/README.md)

**Backend Structure:**
```
app/server/
├── Domain/              (Entity models - clean architecture)
├── Application/         (Business logic services)
├── Infrastructure/      (Data access, Liquibase, external services)
└── API/                 (REST endpoints, middleware)
```

**Frontend Structure:**
```
app/client/
├── src/app/
│   ├── core/           (Services, interceptors, auth)
│   ├── shared/         (UI components, pipes, directives)
│   └── features/       (Feature modules - to be created)
├── public/             (Static assets)
└── styles.css          (Tailwind CSS configured)
```

**Installed:**
- ✅ Flutter SDK with Material Design 3
- ✅ Flutter community charts for data visualization
- ✅ Keycloak integration (authentication)

### ✅ Phase 3: Database Design & Setup (Complete)
**Completion Date:** January 11, 2026  
**Documentation:** [phase-3-database-liquibase/README.md](docs/03-phase-specific/phase-3-database-liquibase/README.md)

**Database Schema:**
- ✅ 8 tables (Users, Vehicles, Garages, Services, VehicleIssues, ServiceHistories, DiagnosticRules, ImageDiagnostics)
- ✅ 12 composite indexes for query performance
- ✅ 5 foreign key relationships with CASCADE/RESTRICT policies
- ✅ Soft-delete pattern on all tables
- ✅ Timestamp tracking (CreatedAt, UpdatedAt)

**Liquibase Setup:**
- ✅ Directory structure in `app/server/Infrastructure/Database/liquibase/`
- ✅ master-changelog.xml (orchestrator)
- ✅ 001-initial-schema.xml (416 lines DDL)
- ✅ 002-seed-data.xml (45 lines, orchestrates 8 seed files)
- ✅ 8 SQL seed files (3,400+ records)
- ✅ liquibase.properties (PostgreSQL connection config)

**Documentation Created:**
- ✅ Liquibase Starter Guide (6,200+ characters)
- ✅ Liquibase Implementation Guide (14,500+ characters)
- ✅ Database Setup Scripts Guide (cleaned up, essentials only)

**Cleanup Completed:**
- ✅ Removed EF Core Migrations folder (Liquibase is single source of truth)
- ✅ Removed utility SQL scripts (kept only init-db.sql and create_migration_user.sql)
- ✅ Clean separation: Setup scripts (environment) vs. Liquibase (schema)

---

## Next Work: Phases 4-12 (NEW PRIORITY ORDER)

### 🎯 Phase 4: Backend API Development (Extended) - CRITICAL PRIORITY
**Original Duration:** 100 hours → **Extended Duration:** 135 hours  
**Status:** 55% Complete (18/33 items)  
**Target Completion:** End of Month 1 (January 31, 2026)  
**Dependencies:** ✅ Complete (Phases 1-3)  
**Team:** 2 backend developers  
**Strategic Importance:** Foundation for BOTH Portal APIs AND AI Chatbot  
**Documentation:** [progress-tracker.md](docs/02-progress-tracking/progress-tracker.md#phase-4-backend-api-development)

#### Phase 4 Scope - 2 Tracks:

**Track A: Portal API Core (100 hours from original scope - 45h remaining)**

**Step 4.1: Keycloak Authentication (8h)**
- [ ] Configure Keycloak realm (vehicle-service-portal)
- [ ] Create client application in Keycloak
- [ ] Set up OAuth 2.0 / OIDC configuration
- [ ] Test authentication flow
- [ ] Create auth service in Application layer
- [ ] Implement JWT validation middleware

**Step 4.2: Repository Pattern & Data Access (12h)**
- [ ] Add DbSets for 8 core entities to AppDbContext
- [ ] Create generic repository interface and implementation
- [ ] Implement soft-delete filtering in repository
- [ ] Add query methods for common searches
- [ ] Configure EF Core in Dependency Injection
- [ ] Create unit of work pattern for transactions

**Step 4.3: Service Layer (Business Logic) (12h)**
- [ ] Create service interface and implementation for each entity (8 services)
- [ ] Implement CRUD operations in service layer
- [ ] Add business validation and error handling
- [ ] Implement timezone utilities for date conversions
- [ ] Add user context capture for audit trails

**Step 4.4: REST API Controllers (8h)**
- [ ] Create REST endpoints for all 8 core entities
- [ ] Implement GET (list with pagination, detail), POST (create), PUT (update), DELETE (soft-delete), PATCH (restore)
- [ ] Add OpenAPI/Swagger documentation
- [ ] Implement pagination, filtering, sorting

**Step 4.5: File Upload & Image Management (5h)**
- [x] Create file upload endpoint (/api/upload) - DONE
- [x] Implement SkiaSharp for thumbnail generation - DONE
- [ ] Create file serving endpoint (/api/files/{id})
- [ ] Implement image deletion & cleanup
- [ ] Add image versioning support

---

**Track B: Chatbot Backend Infrastructure (35 hours - NEW extension)**

**Step 4.6: Chatbot Database Schema (5h)**
- [x] Create 5 domain entities (ChatbotConversation, ChatbotMessage, ChatbotKnowledgeBase, AiImageAnalysis, AiUsageLog)
- [x] Create 15+ chatbot DTOs (Create/Read/Update for each entity)
- [x] Create Liquibase migration (003-create-chatbot-tables.xml)
- [ ] Run migration to create tables & indexes
- [ ] Verify foreign key relationships

**Step 4.7: Chatbot DbContext & Repositories (8h)**
- [ ] Add DbSets for all 5 chatbot tables to AppDbContext
- [ ] Create repositories for each chatbot entity
- [ ] Implement conversation retrieval with soft-delete filtering
- [ ] Create knowledge base query repository with priority/effectiveness sorting
- [ ] Add image analysis query methods

**Step 4.8: Chatbot Services & Business Logic (10h)**
- [ ] Create ConversationManagementService (create, retrieve, end conversation)
- [ ] Create ChatbotMessageService (store/retrieve messages with context)
- [ ] Create KnowledgeBaseService (search, retrieve, rank by effectiveness)
- [ ] Create ImageAnalysisService (store analysis results, retrieve recommendations)
- [ ] Create AiUsageTrackingService (log API calls, track tokens, calculate costs)

**Step 4.9: Azure AI Integration Stubs (8h)**
- [ ] Create Azure OpenAI service interface & stub (for Phase 7)
- [ ] Create Azure Speech service interface & stub (for Phase 7)
- [ ] Create Azure Vision service interface & stub (for Phase 7)
- [ ] Create Azure Search service interface & stub (for Phase 7)
- [ ] Create Azure Prompt Flow service interface & stub (for Phase 7)
- [ ] Extend Polly policies with Azure AI-specific retry/circuit breaker/rate limit policies

**Step 4.10: Chatbot API Controllers (4h)**
- [ ] Create ConversationController (/api/chatbot/conversations)
- [ ] Create MessageController (/api/chatbot/messages)
- [ ] Create KnowledgeBaseController (/api/knowledge-base)
- [ ] Create ImageAnalysisController (/api/chatbot/images)
- [ ] Create UsageController (/api/chatbot/usage - admin only)

---

#### Phase 4 Deliverables:

**✅ Already Delivered (18/33 items):**
- ✅ Abstractions layer with proper folder structure
- ✅ 24 core entity DTOs + 15 chatbot DTOs (39 total)
- ✅ AutoMapper configuration with 39 mappings
- ✅ Generic repository pattern with soft-delete
- ✅ Unit of Work pattern with transactions
- ✅ Serilog structured logging infrastructure
- ✅ CorrelationIdMiddleware
- ✅ Keycloak auth services
- ✅ Error Code Management system
- ✅ Polly resilience framework
- ✅ Database logging infrastructure
- ✅ 5 chatbot domain entities
- ✅ 15+ chatbot DTOs
- ✅ Liquibase migration for chatbot tables (003-create-chatbot-tables.xml)
- ✅ Updated master-changelog.xml

**⏳ To Deliver (15/33 items):**
- [ ] 8 core Application Services
- [ ] 8 REST API Controllers (core)
- [ ] Keycloak realm configuration
- [ ] JWT middleware in API pipeline
- [ ] 5 Chatbot Services (conversation, message, KB, image, usage)
- [ ] 5 Chatbot Controllers
- [ ] Azure AI service stubs (5 services)
- [ ] File serving endpoint
- [ ] Database migration execution
- [ ] Integration tests for APIs

---

### Phase 5: Role-Based Access & Permissions ⏳ PENDING

**Duration:** 60 hours
- [ ] Implement dual-search (name + description search)
- [ ] Add sorting capabilities
- [ ] Implement filtering by entity properties
- [ ] Add soft-delete visibility toggle

**Step 4.8: Testing & Verification**
- [ ] Test all endpoints with 3,400+ seed data
- [ ] Verify authentication works (Keycloak)
- [ ] Verify authorization (role-based access)
- [ ] Test pagination with large datasets
- [ ] Test file upload and thumbnail generation
- [ ] Run .NET build verification

#### Phase 4 Deliverables:
- ✅ Complete REST API (32 endpoints)
- ✅ Authentication integration
- ✅ Repository pattern implementation
- ✅ Service layer with business logic
- ✅ File upload functionality
- ✅ Swagger API documentation

#### Phase 4 Success Criteria:
- [ ] All 14 tasks completed
- [ ] API builds without errors
- [ ] All endpoints callable and working
- [ ] Swagger UI accessible at /swagger
- [ ] Authentication flow verified

---

### Phase 5: Roles & Permissions System
**Estimated Time:** 60 hours  
**Dependencies:** Phase 4 (Backend API must be complete)  
**Status:** ⏳ Pending

**Overview:** Implement comprehensive 4-tier role hierarchy with impersonation capabilities.

**Tasks:**
- [ ] Implement Super Admin role and permissions
- [ ] Implement Application Admin role with CMS access
- [ ] Implement Garage Admin role with dashboard access
- [ ] Implement Customer role with mobile-first features
- [ ] Build impersonation system with audit trails
- [ ] Create role-based route guards
- [ ] Implement permission checking middleware
- [ ] Add 2FA for admin roles
- [ ] Build user management interfaces
- [ ] Test all role-based access scenarios

---

### Phase 6: Content Management System (CMS)
**Estimated Time:** 100 hours  
**Dependencies:** Phase 5 (Roles & Permissions)  
**Status:** ⏳ Pending

**Overview:** Build headless CMS for managing web and mobile content.

**Tasks:**
- [ ] Design CMS database schema
- [ ] Create CMS API endpoints
- [ ] Build WYSIWYG editor interface
- [ ] Implement media library (images, videos, documents)
- [ ] Add multi-language content support
- [ ] Create version control for content
- [ ] Build publish/draft workflow
- [ ] Implement SEO settings
- [ ] Create template management
- [ ] Test content delivery to web and mobile

---

### Phase 7: AI Platform & Chatbot Integration (Azure AI Foundry + Python)
**Estimated Time:** 200 hours  
**Dependencies:** Phase 6 (CMS)  
**Status:** ⏳ Pending

**Overview:** Integrate Azure AI Foundry for chatbot models and build Python-based custom ML services.

**Tasks:**
- [ ] Set up Azure AI Foundry integration
- [ ] Configure chatbot models in Azure AI Foundry
  - [ ] Fast mode chatbot
  - [ ] Deep thinking mode chatbot
  - [ ] Audio/voice chatbot
  - [ ] Image describer AI model
- [ ] Design chatbot database schema (conversations, messages, knowledge base)
- [ ] Implement text-based chatbot integration
- [ ] Add voice interaction capabilities (speech-to-text/text-to-speech)
- [ ] Integrate computer vision for image analysis
- [ ] Set up Python FastAPI service for custom ML models
- [ ] Build custom ML model training pipeline (TensorFlow/PyTorch)
- [ ] Create model deployment and versioning system
- [ ] Implement A/B testing for models
- [ ] Build AI analytics dashboard
- [ ] Create knowledge base management
- [ ] Integrate Azure AI Foundry and Python services with .NET backend
- [ ] Test all chatbot modes (fast, thinking, audio, image)

---

### Phase 8: Mobile App - Customer (Flutter)
**Estimated Time:** 180 hours  
**Dependencies:** Phase 7 (AI Platform)  
**Status:** ⏳ Pending

**Overview:** Build customer-facing mobile app for iOS and Android.

**Tasks:**
- [ ] Set up Flutter mobile project structure
- [ ] Implement Clean Architecture for mobile
- [ ] Create vehicle management screens
- [ ] Build GPS-based garage discovery
- [ ] Implement real-time booking system
- [ ] Add service tracking with notifications
- [ ] Integrate AI chatbot
- [ ] Implement digital payment wallet
- [ ] Create service history and reminders
- [ ] Add VIN scanner functionality
- [ ] Build user profile management
- [ ] Test on iOS and Android devices

---

### Phase 9: Mobile App - Admin (Flutter)
**Estimated Time:** 100 hours  
**Dependencies:** Phase 8 (Customer Mobile App)  
**Status:** ⏳ Pending

**Overview:** Build admin mobile app for Application Admins and Garage Admins.

**Tasks:**
- [ ] Create admin mobile app structure
- [ ] Build appointment management interface
- [ ] Implement quick status updates
- [ ] Add photo upload functionality
- [ ] Create voice memo feature
- [ ] Build performance dashboard
- [ ] Implement emergency alerts
- [ ] Add garage management tools
- [ ] Create inventory management interface
- [ ] Test admin workflows

---

### Phase 10: Web Portals (Flutter Web)
**Estimated Time:** 220 hours  
**Dependencies:** Phase 9 (Admin Mobile App)  
**Status:** ⏳ Pending

**Overview:** Build unified Flutter web portals for all user roles.

**Tasks:**
- [ ] Convert Flutter mobile to responsive web
- [ ] Build Super Admin portal
- [ ] Create Application Admin portal with CMS
- [ ] Build Garage Admin dashboard
- [ ] Create Customer web portal
- [ ] Implement analytics dashboards
- [ ] Add financial reporting
- [ ] Create inventory management
- [ ] Build user management interfaces
- [ ] Implement impersonation UI
- [ ] Test across browsers
- [ ] Optimize for desktop experience

---

### Phase 11: Integration & Testing
**Estimated Time:** 120 hours  
**Dependencies:** Phase 10 (Web Portals)  
**Status:** ⏳ Pending

**Test Coverage:**
- [ ] End-to-end authentication flows
- [ ] Role-based access control
- [ ] All CRUD operations across platforms
- [ ] AI chatbot functionality (all modes)
- [ ] CMS content delivery
- [ ] Mobile app features (iOS + Android)
- [ ] Web portal features
- [ ] Real-time notifications
- [ ] Payment processing
- [ ] GPS and location services
- [ ] Image uploads and diagnostics
- [ ] ML model predictions
- [ ] Performance testing with large datasets
- [ ] Security penetration testing
- [ ] Accessibility compliance

---

### Phase 12: Deployment & DevOps
**Estimated Time:** 60 hours  
**Dependencies:** Phase 11 (Testing)  
**Status:** ⏳ Pending

**Tasks:**
- [ ] Set up Azure cloud infrastructure
- [ ] Configure CI/CD pipelines
- [ ] Implement Docker containerization
- [ ] Set up Kubernetes orchestration
- [ ] Configure auto-scaling
- [ ] Implement monitoring and alerting
- [ ] Set up backup and disaster recovery
- [ ] Create deployment documentation
- [ ] Configure CDN for media delivery
- [ ] Set up SSL certificates
- [ ] Implement rate limiting
- [ ] Create user documentation
- [ ] Build admin training materials

---

## Architecture & Key Decisions

### Clean Architecture Layers

```
┌─────────────────────────────────────────┐
│         API Layer (Controllers)          │
│  - REST endpoints, Swagger, Middleware   │
└──────────────────┬──────────────────────┘
                   │ depends on
┌──────────────────▼──────────────────────┐
│     Application Layer (Services)         │
│  - Business logic, DTOs, Mappings        │
└──────────────────┬──────────────────────┘
                   │ depends on
┌──────────────────▼──────────────────────┐
│    Infrastructure Layer (Data Access)    │
│  - EF Core DbContext, Liquibase, Repos  │
└──────────────────┬──────────────────────┘
                   │ depends on
┌──────────────────▼──────────────────────┐
│       Domain Layer (Entities)            │
│  - Pure models, no dependencies          │
└─────────────────────────────────────────┘
```

### Database-First Approach
- **Tool:** Liquibase (not EF Core migrations)
- **Location:** `app/server/Infrastructure/Database/liquibase/`
- **Setup Scripts:** `scripts/prerequisites/00-database-init/` (environment only)
- **Philosophy:** Schema versions tracked independently from code

### Frontend Architecture
- **Framework:** Flutter (Unified Web + Mobile)
- **Architecture:** Clean Architecture (Domain, Data, Presentation)
- **State Management:** Bloc/Cubit pattern
- **Styling:** Material Design 3
- **Charts:** Community charts packages
- **Auth:** Keycloak OAuth 2.0 / OIDC
- **Platforms:** Web, iOS, Android from single codebase

---

## Getting Started (For Implementation)

### Prerequisites Check
```bash
# Verify Phases 1-3 are complete
cd /path/to/grrado

# Check backend project
cd server
dotnet build  # Should succeed

# Check frontend project
cd ../client
flutter pub get   # Should succeed
flutter build web # Should succeed

# Check database
cd ../..
docker-compose up -d
# Wait 30s, then verify:
psql -h localhost -U postgres -d vehicle_service_db -c "SELECT COUNT(*) FROM \"Users\";"
```

### Phase 4 Implementation Order

1. **First:** Deploy Liquibase (if not done)
   ```bash
   cd app/server/Infrastructure/Database
   liquibase update
   ```

2. **Second:** Scaffold DbContext
   ```bash
   cd app/server/Infrastructure
   dotnet ef dbcontext scaffold "Host=localhost;Port=5432;Database=vehicle_service_db;Username=postgres;Password=postgres" Npgsql.EntityFrameworkCore.PostgreSQL -o Models -c VehicleServiceContext --force
   ```

3. **Third:** Configure Keycloak
   - Access http://localhost:8080
   - Admin console: admin/admin
   - Create realm "vehicle-service-portal"
   - Create client application

4. **Fourth:** Build repository pattern and services

5. **Fifth:** Create REST API controllers

6. **Sixth:** Test all endpoints

---

## Documentation References

| Document | Purpose |
|----------|---------|
| [README.md](README.md) | Project overview |
| [comprehensive-project-plan.md](docs/00-getting-started/comprehensive-project-plan.md) | Complete platform specifications |
| [CHANGELOG.md](CHANGELOG.md) | Version history |
| [docs/00-getting-started/](docs/00-getting-started/) | Setup guides |
| [docs/02-progress-tracking/progress-tracker.md](docs/02-progress-tracking/progress-tracker.md) | Detailed task tracking |
| [docs/03-phase-specific/](docs/03-phase-specific/) | Phase-by-phase documentation |
| [docs/03-phase-specific/phase-3-database-liquibase/](docs/03-phase-specific/phase-3-database-liquibase/) | Liquibase guides & schema |
| [scripts/prerequisites/00-database-init/README.md](scripts/prerequisites/00-database-init/README.md) | Database initialization |

---

## Project Statistics

| Metric | Value |
|--------|-------|
| **Total Scope** | 1,168 hours (~9 months with 3-4 developers) |
| **Completed** | 103 hours (9%) |
| **Remaining** | 1,065 hours (91%) |
| **Phases** | 12 (Environment → Deployment) |
| **Database Tables** | 8 core + 5 planned (chatbot, ML, payments, notifications, reviews) |
| **Seed Records** | 3,400+ |
| **API Endpoints** | 32+ (expandable for new features) |
| **Platforms** | Web, iOS, Android (unified Flutter) |
| **User Roles** | 4-tier hierarchy (Super Admin, App Admin, Garage Admin, Customer) |
| **AI Features** | Multi-modal chatbot, image diagnostics, ML training platform |

---

## Key Contacts & Resources

**Project Team:**
- Database: See Phase 3 documentation
- Backend: See Phase 4 plan  
- Frontend (Flutter): See Phases 8-10 plan
- AI/ML: See Phase 7 plan
- CMS: See Phase 6 plan

**External Documentation:**
- [.NET Documentation](https://learn.microsoft.com/dotnet/)
- [Flutter Documentation](https://flutter.dev/docs)
- [Python Documentation](https://docs.python.org/3/)
- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [TensorFlow Documentation](https://www.tensorflow.org/api_docs)
- [PyTorch Documentation](https://pytorch.org/docs/)
- [FastAPI Documentation](https://fastapi.tiangolo.com/)
- [Liquibase Documentation](https://docs.liquibase.com/)
- [PostgreSQL Documentation](https://www.postgresql.org/docs/)
- [Keycloak Documentation](https://www.keycloak.org/documentation)

---

## Next Steps for Copilot

**When implementing Phase 4:**
1. Reference [docs/03-phase-specific/phase-3-database-liquibase/](docs/03-phase-specific/phase-3-database-liquibase/) for database schema
2. Follow clean architecture layer dependencies
3. Create Application Services for business logic
4. Build REST API controllers
5. Use `liquibase update` to deploy schema before scaffolding DbContext
6. Test endpoints with Swagger UI
7. Document all APIs with OpenAPI annotations

**When implementing Phases 5-12:**
1. Reference [comprehensive-project-plan.md](docs/00-getting-started/comprehensive-project-plan.md) for complete specifications
2. Follow Flutter Clean Architecture patterns
3. Implement role-based access control carefully
4. Test AI features thoroughly
5. Ensure mobile responsiveness
6. Implement proper error handling
7. Test with 3,400+ seed records

---

**Last Updated:** January 18, 2026  
**Status:** Phases 1-3 Complete ✅ | Phase 4 In Progress 🔄 (71% Foundation)  
**Next Review:** After Phase 4 completion

