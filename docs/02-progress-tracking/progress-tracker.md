# Grrado - Vehicle Service Aggregator Platform - Progress Tracker

**Last Updated:** January 25, 2026 - 2:45 PM  
**Overall Status:** Phases 1-3 ✅ COMPLETE | Phase 4 🔄 IN PROGRESS - REST API Layer ✅ COMPLETE  
**Project Scope:** Backend-First Strategy: Portal APIs → Role/Permission System → CMS → AI Chatbot (All 4 Modes) → Web Portals → Mobile Apps  
**Clean Architecture:** ✅ Mandated for all Backend (.NET) and Frontend (Flutter) projects
**Strategic Focus:** Complete backend & chatbot AI core FIRST, then web frontend, then mobile apps  
**Total Project Progress:** 15% (175 of 1,171 hours complete) - Phase 4 REST API layer now complete, Swagger UI ready

---

## 📊 Executive Summary

### Project Evolution
- **Original Scope:** Web-based vehicle service portal (735 hours)
- **Expanded Scope:** Multi-platform garage and vehicle service aggregator (1,168 hours)
- **New Features Added:**
  - 🤖 Advanced AI Chatbot (Azure AI Foundry: fast mode, thinking mode, audio, image describer)
  - 📱 2 Mobile Apps (Customer + Admin) - Flutter
  - 🌐 Unified Web Platform - Flutter Web
  - 🎨 Headless CMS for multi-language content
  - 🧠 Custom ML Models with Python (TensorFlow/PyTorch)
  - 🔐 4-Tier Role Hierarchy (Super Admin, App Admin, Garage Admin, Customer)
  - 📊 Real-time GPS-based garage discovery and booking

### Overall Status
| Metric | Value |
|--------|-------|
| **Phases Completed** | 3 of 12 (25%) |
| **Hours Completed** | 103 / 1,171 (9%) |
| **Current Phase** | Phase 4 - Backend API (Extended for Chatbot) |
| **Team Size** | 4 developers (targeting 7 for full scope) |
| **Timeline** | 10 months estimated |
| **Build Status** | ✅ 0 Errors, 0 Warnings |
| **Priority Sequence** | 4 → 5 → 6 → 7 (Chatbot AI) → 10 (Web) → 8,9 (Mobile) → 11,12 (Test/Deploy) |

---

## 🎯 Phase Overview (NEW PRIORITY ORDER)

| Phase | Name | Duration | Status | Progress | Priority |
|-------|------|----------|--------|----------|----------|
| 1 | Environment Setup | 5h | ✅ Complete | 100% | N/A |
| 2 | Project Structure | 8h | ✅ Complete | 100% | N/A |
| 3 | Database & Liquibase | 15h | ✅ Complete | 100% | N/A |
| **4** | **Backend API (Extended)** | **135h** | **🔄 In Progress** | **55%** | **#1 - CRITICAL** |
| **5** | **Roles & Permissions** | **60h** | **⏳ Pending** | **0%** | **#2 - GATES ALL** |
| **6** | **CMS** | **100h** | **⏳ Pending** | **0%** | **#3** |
| **7** | **AI Platform & Chatbot** | **200h** | **⏳ Pending** | **0%** | **#4 - STRATEGIC FOCUS** |
| **10** | **Web Portals (Flutter)** | **220h** | **⏳ Pending** | **0%** | **#5** |
| 8 | Mobile App - Customer (Flutter) | 180h | ⏳ Pending | 0% | #6 |
| 9 | Mobile App - Admin (Flutter) | 100h | ⏳ Pending | 0% | #7 |
| 11 | Integration & Testing | 120h | ⏳ Pending | 0% | #8 |
| 12 | Deployment & DevOps | 60h | ⏳ Pending | 0% | #9 |
| **TOTAL** | | **1,171h** | | **9%** | **Backend-First Strategy** |

---

## Phase 4: Backend API Development 🔄 IN PROGRESS (EXTENDED FOR CHATBOT)

**Status:** 🔄 58% Complete - Foundation & Chatbot Infrastructure (19/33 items)  
**Original Duration:** 100h → **Extended Duration:** 135h (added 35h for chatbot database support)
**Completion Target:** End of Month 1 (January 31, 2026)
**Strategic Importance:** CRITICAL - Foundation for Portal APIs AND AI Chatbot

### ✅ Completed Items (19/33)
- [x] Create Abstractions layer with proper folder structure
- [x] Implement all 8 entity DTOs (24 DTOs: Read + Create + Update) - **Core Entities**
- [x] Configure AutoMapper with DomainToDtoProfile (24 mappings)
- [x] Implement generic repository pattern with soft-delete support
- [x] Implement Unit of Work pattern with transaction management
- [x] Configure Serilog structured logging (per-layer + consolidated + error-only sinks)
- [x] Create CorrelationIdMiddleware for end-to-end request tracking
- [x] Build Keycloak authentication services (token validation, user context)
- [x] Create layer-specific Dependency Injection files
- [x] Organize IEntity in Domain/Abstractions folder
- [x] Install required NuGet packages (Serilog, AutoMapper, JWT, HttpClient)
- [x] Implement Error Code Management with JSON Configuration (strings + Redis caching)
- [x] Implement Polly resilience framework (HTTP, Azure AI, Keycloak, Database policies)
- [x] Implement comprehensive database logging infrastructure with background queue processing
- [x] **NEW - Create Chatbot Domain Entities** (5 entities: ChatbotConversation, ChatbotMessage, ChatbotKnowledgeBase, AiImageAnalysis, AiUsageLog)
- [x] **NEW - Create Chatbot DTOs** (15+ DTOs for all chatbot entities - Create/Read/Update)
- [x] **NEW - Create Liquibase Migration** (003-create-chatbot-tables.xml with 5 tables + 17 indexes)
- [x] **NEW - Update Master Changelog** (master-changelog.xml includes chatbot migration)
- [x] Documented lightweight SQL seeding workflow and relocated manual scripts to `scripts/seeding`

### ⏳ Pending Items (15/33) - 45% Remaining

**Portal API Core (45 hours):**
- [ ] Create 8 Application Services layer (business logic for all portal entities)
- [ ] Build 8 REST API Controllers with CRUD endpoints
- [ ] Configure Keycloak realm and client setup
- [ ] Add JWT authentication middleware to API pipeline
- [ ] Implement image file serving endpoint (/api/files/{fileName})
- [ ] Add soft-delete filtering to all repository queries
- [ ] Capture user info on delete operations (DeletedBy = current user)

**Chatbot Backend Foundation (35 hours - NEW):**
- [ ] Add DbSets for 5 new chatbot tables to AppDbContext
- [ ] Create AutoMapper profiles for chatbot DTOs
- [ ] Create repositories for chatbot entities (ChatbotConversationRepository, etc.)
- [ ] Implement conversation management service
- [ ] Implement knowledge base search service (basic)
- [ ] Create stubs for Azure AI service integrations (OpenAI, Speech, Vision, Search, Prompt Flow)
- [ ] Implement Azure AI resilience policies in Polly
- [ ] Create AiUsageLog service for tracking API calls
- [ ] Add database indexes for chatbot query optimization

**Database Updates (5 hours):**
- [ ] Run Liquibase migrations to create chatbot tables
- [ ] Verify all foreign key relationships
- [ ] Create any additional indexes for chatbot queries
- [ ] Test soft-delete functionality on all new tables

**📁 Documentation:** [phase-4-backend-api/01-architecture-and-infrastructure.md](../03-phase-specific/phase-4-backend-api/01-architecture-and-infrastructure.md)

### 🛡️ Polly Resilience Framework Implementation Details

**Completed:** January 18, 2026 (10 hours)

**Architecture:** Single consolidated DependencyInjection.cs with all policies

**Policies Implemented:**

#### HTTP Integration Policies
- **Retry Policy** - Exponential backoff (100ms → 5s, 3 attempts)
- **Circuit Breaker** - Prevents cascading failures (threshold: 5, timeout: 30s)
- **Timeout Policy** - Request timeout enforcement (30s)
- **HTTP Resilience** - Combined retry + circuit breaker + timeout

#### Service-Specific Policies
- **Azure AI Services** - Azure-specific retry with rate limit handling (429 status)
- **Keycloak Policy** - Auth-specific retry (2 attempts) with circuit breaker
- **Integration Services** - External API timeout & retry policies

#### Database Policies
- **Database Bulkhead** - Connection limiting (50 parallel, 100 queue depth)
- **Database Retry** - Handles deadlocks, connection timeouts, transient failures
- **Database Timeout** - Query timeout enforcement (60s, pessimistic strategy)
- **Database Resilience** - Combined retry + timeout + bulkhead

**Files:**
- [PollyConstants.cs](../../server/Application/Common/Constants/PollyConstants.cs) - Configuration constants
- [PollyPolicies.cs](../../server/Infrastructure/Integration/Resilience/PollyPolicies.cs) - Policy implementations
- [DependencyInjection.cs](../../server/Infrastructure/DependencyInjection.cs) - DI registration (lines 91-136)

**Benefits:**
✅ Resilient HTTP communication with automatic retries  
✅ Prevents cascading failures via circuit breaker  
✅ Protects database from connection exhaustion  
✅ Handles Azure AI rate limiting automatically  
✅ Centralized configuration and monitoring  
✅ Zero vulnerabilities (Polly 8.4.1)

---

## 🤖 Phase 4 Extension: Chatbot Database Infrastructure (NEW)

**Status:** ✅ Completed - January 25, 2026  
**Scope:** 5 new tables + 17 indexes + 15+ DTOs + 5 domain entities  
**Hours:** 35 (extends Phase 4 from 100h to 135h)

### Database Schema (5 New Tables)

| Table | Purpose | Rows | Indexes |
|-------|---------|------|---------|
| **ChatbotConversations** | AI conversation sessions per user | 0-1M | 3 (user_id, started_at, is_deleted) |
| **ChatbotMessages** | Individual messages within conversations | 0-10M | 4 (conversation_id, user_id, created_at, is_deleted) |
| **ChatbotKnowledgeBase** | Knowledge base Q&A for RAG retrieval | 0-100K | 4 (category, is_training, priority, is_deleted) |
| **AiImageAnalyses** | Vision API results for uploaded images | 0-500K | 4 (message_id, user_id, analysis_type, is_deleted) |
| **AiUsageLogs** | Azure AI service call tracking | 0-1M | 4 (user_id, service_name, created_at, is_deleted) |

### Domain Entities Created
- `ChatbotConversation.cs` - Session management, cost tracking, satisfaction ratings
- `ChatbotMessage.cs` - Message storage, intent recognition, confidence scores, thinking mode support
- `ChatbotKnowledgeBase.cs` - Knowledge base items, embeddings, training data, effectiveness tracking
- `AiImageAnalysis.cs` - Image analysis results, damage detection, parts identification, recommendations
- `AiUsageLog.cs` - API usage logging, token tracking, cost tracking, quota management

### DTOs Created (15 Total)
- ChatbotConversation: ChatbotConversationDto, CreateChatbotConversationRequest, UpdateChatbotConversationRequest
- ChatbotMessage: ChatbotMessageDto, CreateChatbotMessageRequest, UpdateChatbotMessageRequest
- ChatbotKnowledgeBase: ChatbotKnowledgeBaseDto, CreateChatbotKnowledgeBaseRequest, UpdateChatbotKnowledgeBaseRequest
- AiImageAnalysis: AiImageAnalysisDto, CreateAiImageAnalysisRequest, UpdateAiImageAnalysisRequest
- AiUsageLog: AiUsageLogDto, CreateAiUsageLogRequest, UpdateAiUsageLogRequest

### Key Design Features
✅ Soft-delete support on all tables  
✅ Audit columns (CreatedAt, UpdatedAt, DeletedAt, DeletedBy)  
✅ Foreign key relationships with CASCADE delete for conversation hierarchy  
✅ Composite indexes for fast filtering (user_id, created_at, is_deleted)  
✅ Support for 4 chatbot modes (text, voice, image, deep-thinking)  
✅ JSON columns for complex data (thinking process, detected objects, recommendations)  
✅ Cost & token tracking for each interaction  
✅ Knowledge base effectiveness scoring & training data flagging  
✅ Rate limiting quota tracking for Azure AI services  

### Next Steps in Phase 4
1. Add DbSets to AppDbContext for all 5 new tables
2. Create AutoMapper profiles for chatbot DTOs
3. Implement repository & service layer for chatbot entities
4. Create Azure AI integration layer (stubs for production Phase 7)
5. Extend Polly policies for Azure AI services
6. Run Liquibase migration: `003-create-chatbot-tables.xml`

---

## Phase 5: Role-Based Access & Permissions ⏳ PENDING

**Status:** ⏳ Not Started  
**Duration:** 60 hours  
**Team:** 2 backend developers

### Scope
- [ ] Role hierarchy implementation (Super Admin → App Admin → Garage Admin → User)
- [ ] Permissions table & role-permission mapping (50+ permissions)
- [ ] Custom authorization attributes & middleware
- [ ] Impersonation feature with audit trail
- [ ] API endpoint protection by role

**📁 Documentation:** [Comprehensive Project Plan - Phase 5](../00-getting-started/COMPREHENSIVE-PROJECT-PLAN.md#phase-5-role-based-access--permissions-new)

---

## Phase 6: Content Management System ⏳ PENDING

**Status:** ⏳ Not Started  
**Duration:** 100 hours  
**Team:** 2 developers

### Scope
- [ ] CMS database schema (pages, media, banners, templates)
- [ ] Backend API (CRUD, media upload, localization)
- [ ] Admin UI with WYSIWYG editor (TinyMCE)
- [ ] Media library browser
- [ ] Multi-language support
- [ ] Version control & publish workflow

**📁 Documentation:** [Comprehensive Project Plan - Phase 6](../00-getting-started/COMPREHENSIVE-PROJECT-PLAN.md#phase-6-content-management-system-new)

---

## Phase 7: AI Platform & Chatbot (Azure AI Foundry + Python) ⏳ PENDING

**Status:** ⏳ Not Started  
**Duration:** 200 hours  
**Team:** 3 developers (2 backend + 1 AI specialist)

### Scope
- [ ] **Azure AI Foundry Setup**
  - [ ] Configure Azure AI Foundry workspace
  - [ ] Set up chatbot models:
    - [ ] Fast mode chatbot
    - [ ] Deep thinking mode chatbot
    - [ ] Audio/voice chatbot
    - [ ] Image describer AI model
  - [ ] Configure model deployment and versioning
  - [ ] Set up Azure AI Search (knowledge base RAG)
  - [ ] Configure content safety and moderation

- [ ] **Python Custom ML Platform**
  - [ ] Set up Python FastAPI service
  - [ ] Dataset upload & management
  - [ ] Custom model training pipeline (TensorFlow/PyTorch)
  - [ ] Hyperparameter tuning
  - [ ] Model evaluation & deployment
  - [ ] Analytics dashboard
  - [ ] Integration with .NET backend

- [ ] **Advanced AI Chatbot Integration**
  - [ ] 💬 Text chat mode
  - [ ] 🎤 Voice chat mode (speech-to-text/text-to-speech)
  - [ ] 🧠 Deep thinking mode (complex diagnostics)
  - [ ] 📸 Image analysis mode (damage assessment)
  - [ ] Knowledge base management
  - [ ] Context management & conversation history
  - [ ] Cost tracking & rate limiting

- [ ] **Frontend Components**
  - [ ] Chat UI (web + mobile)
  - [ ] Voice recording & playback
  - [ ] Image upload & preview
  - [ ] Thinking indicators
  - [ ] Conversation history

**📁 Documentation:** [Comprehensive Project Plan - Phase 7](../00-getting-started/COMPREHENSIVE-PROJECT-PLAN.md#phase-7-ai-platform--chatbot-new)

---

## Phase 8: Mobile App - Customer (Flutter) ⏳ PENDING

**Status:** ⏳ Not Started  
**Duration:** 180 hours  
**Team:** 2 mobile developers

### Scope
- [ ] Flutter project setup (Clean Architecture)
- [ ] Authentication (Keycloak + biometric)
- [ ] Vehicle management
- [ ] Garage discovery (GPS + map integration)
- [ ] Service booking flow
- [ ] Real-time service tracking
- [ ] AI chatbot integration (all 4 modes)
- [ ] Payment integration
- [ ] Push notifications
- [ ] Service history

**📁 Documentation:** [Comprehensive Project Plan - Phase 8](../00-getting-started/COMPREHENSIVE-PROJECT-PLAN.md#phase-8-mobile-app---customer-new)

---

## Phase 9: Mobile App - Admin (Flutter) ⏳ PENDING

**Status:** ⏳ Not Started  
**Duration:** 100 hours  
**Team:** 2 mobile developers

### Scope
- [ ] Flutter project setup (Clean Architecture)
- [ ] Dashboard & quick stats
- [ ] Appointment management
- [ ] Customer communication
- [ ] Status updates & photo upload
- [ ] AI chatbot assistant
- [ ] Push notifications & real-time updates

**📁 Documentation:** [Comprehensive Project Plan - Phase 9](../00-getting-started/COMPREHENSIVE-PROJECT-PLAN.md#phase-9-mobile-app---admin-new)

---

## Phase 10: Web Portals (Flutter Web) ⏳ PENDING

**Status:** ⏳ Not Started  
**Duration:** 220 hours  
**Team:** 3 frontend developers

### Scope
- [ ] **Super Admin Portal** (30h)
  - [ ] System configuration dashboard
  - [ ] Admin user management
  - [ ] Audit logs & impersonation UI

- [ ] **Application Admin Portal** (80h)
  - [ ] CMS dashboard
  - [ ] User & garage management
  - [ ] AI platform management
  - [ ] Analytics & reports

- [ ] **Garage Admin Portal** (70h)
  - [ ] Service & appointment management
  - [ ] Staff & inventory management
  - [ ] Financial reports
  - [ ] AI chatbot integration

- [ ] **Customer Portal** (40h)
  - [ ] Garage discovery & booking
  - [ ] Service history
  - [ ] AI chatbot integration

**📁 Documentation:** [Comprehensive Project Plan - Phase 10](../00-getting-started/COMPREHENSIVE-PROJECT-PLAN.md#phase-10-web-portals-new)

---

## Phase 11: Integration & Testing ⏳ PENDING

**Status:** ⏳ Not Started  
**Duration:** 120 hours  
**Team:** 4 developers + QA

### Scope
- [ ] End-to-end integration testing
- [ ] Mobile app testing (iOS + Android)
- [ ] Web portal testing (all browsers)
- [ ] AI chatbot accuracy testing
- [ ] Performance testing
- [ ] Security testing & penetration testing
- [ ] User acceptance testing

**📁 Documentation:** [Comprehensive Project Plan - Phase 11](../00-getting-started/COMPREHENSIVE-PROJECT-PLAN.md#phase-11-integration--testing-new)

---

## Phase 12: Deployment & DevOps ⏳ PENDING

**Status:** ⏳ Not Started  
**Duration:** 60 hours  
**Team:** 2 DevOps engineers

### Scope
- [ ] Azure infrastructure setup
- [ ] CI/CD pipelines (GitHub Actions)
- [ ] Kubernetes configuration
- [ ] Monitoring & alerting (Application Insights)
- [ ] Backup strategies
- [ ] App store submission (iOS + Android)

**📁 Documentation:** [Comprehensive Project Plan - Phase 12](../00-getting-started/COMPREHENSIVE-PROJECT-PLAN.md#phase-12-deployment--devops-new)

---

## 📈 Quick Stats

| Metric | Value |
|--------|-------|
| **Total Phases** | 12 |
| **Completed Phases** | 3 (25%) |
| **In Progress Phases** | 1 (Phase 4) |
| **Pending Phases** | 8 |
| **Total Tasks** | ~250 (estimated) |
| **Completed Tasks** | 40+ |
| **Build Status** | ✅ 0 Errors, 0 Vulnerabilities |
| **Security Status** | ✅ Zero Known Vulnerabilities |
| **Image Processing** | ✅ SkiaSharp 2.88.8 (zero vulnerabilities) |

---

## 🎉 Recent Achievements (January 18, 2026)

### Phase 4 Foundation Complete
- ✅ 24 DTOs created with CQRS pattern
- ✅ AutoMapper configured with 24 mappings
- ✅ Serilog structured logging with correlation tracking
- ✅ Keycloak authentication infrastructure complete
- ✅ Repository + UnitOfWork patterns implemented
- ✅ Layer-specific DI configuration
- ✅ JSON-based error code configuration system with string names
- ✅ Redis distributed caching for error messages (6-hour refresh)
- ✅ SkiaSharp 2.88.8 image processing (replaced vulnerable SixLabors.ImageSharp)
- ✅ Comprehensive architecture documentation created

### Security & Quality
- ✅ Zero vulnerabilities achieved (migrated from ImageSharp to SkiaSharp)
- ✅ All documentation updated to reflect current state
- ✅ 4 GitHub commits pushed successfully

### Planning & Documentation
- ✅ Comprehensive Project Plan created (COMPREHENSIVE-PROJECT-PLAN.md)
- ✅ Expanded scope documented (CMS, AI, Mobile Apps)
- ✅ Azure AI Foundry integration plan
- ✅ Advanced AI Chatbot specifications (text + voice + vision + deep thinking)
- ✅ Database schema expansion (17 new tables)
- ✅ Cost estimation ($173K first year)
- ✅ Timeline planning (10 months)

---

## 🎯 Next Milestone: Complete Phase 4

**Target:** End of Month 1

### Remaining Tasks
1. Create Application Services layer (8 services)
2. Build REST API Controllers (8 controllers)
3. Configure Keycloak realm
4. Add JWT authentication middleware
5. Implement file upload endpoint
6. Add soft-delete filtering
7. Capture user info on delete operations

**Estimated Hours:** 45 hours remaining

---

## 📊 Technology Stack Summary

### Backend (.NET Core 9)
- ✅ .NET Core 9 (Clean Architecture)
- ✅ Entity Framework Core 9
- ✅ PostgreSQL 16
- ✅ Redis 7
- ✅ Keycloak (OAuth 2.0/OIDC)
- ✅ Liquibase (Database versioning)
- ✅ SkiaSharp 2.88.8 (Image processing)
- ✅ Serilog (Structured logging)
- ✅ AutoMapper (DTO mapping)
- ✅ MediatR (CQRS pattern)
- ✅ FluentValidation (Validation)
- ✅ Polly (Resilience)

### Frontend (Flutter)
- ✅ Flutter SDK 3.x (Unified Web + Mobile)
- ✅ Clean Architecture (Domain, Data, Presentation)
- ✅ Bloc/Cubit (State Management)
- ✅ Material Design 3
- ✅ Dio (HTTP client)
- ✅ GetIt (Dependency Injection)
- ⏳ Modular package structure (auth, ui, data, domain, core)

### AI/ML Platform
- ⏳ **Azure AI Foundry** (Chatbot model integration)
  - Fast mode chatbot
  - Deep thinking mode chatbot
  - Audio/voice chatbot
  - Image describer AI model
- ⏳ **Python 3.11+** (Custom AI/ML development)
  - TensorFlow / PyTorch (Custom model training)
  - FastAPI (ML model serving API)
  - OpenCV (Image processing)
  - NLTK / spaCy (NLP)
  - Scikit-learn (Traditional ML)
  - Pandas & NumPy (Data processing)

### Infrastructure
- ✅ Docker & Docker Compose
- ⏳ Azure Cloud Services (AI Foundry)
- ⏳ Kubernetes (Production deployment)

---

## �️ Logging Infrastructure Implementation (January 18, 2026)

**Status:** ✅ COMPLETE (10 hours)

### Overview
Implemented enterprise-grade database logging system with background queue processing to ensure:
- **Sequential Order:** All logs written to database in exact FIFO order
- **Non-Blocking:** Logging doesn't impact request performance
- **Efficient:** Single background thread, no thread pool overhead
- **Traceable:** Correlation IDs enable full request journey tracking

### Architecture

**New Utility Project** - Reusable infrastructure layer
- Location: `app/server/Utility`
- Dependencies: Domain only (can be used by any layer)
- Exports: Logging interfaces and queue infrastructure

**Queue-Based Processing** - System Design
```
Request Flow:
1. Request → CorrelationIdMiddleware (extract/generate ID)
2. Logging Service → ILoggingQueue.EnqueueAsync() (non-blocking)
3. Background Thread → LoggingQueueService (sequential processing)
4. Database → Final persistence (ordered, atomic)
```

### Key Components

**1. ILoggingQueue Interface** - Thread-safe FIFO queue
- Bounded Channel (capacity: 1000 items)
- Non-blocking enqueue with backpressure
- Async/await throughout

**2. Log Types** (All queued for sequential processing)
- **AuditLog** - Data changes (Create/Update/Delete) with snapshots
- **ErrorLog** - Exceptions with full stack traces
- **RequestResponseLog** - Complete HTTP request/response (TEXT fields, no truncation)
- **ActivityLog** - User activities (Login, Export, Search, etc.)

**3. Logging Services** (Infrastructure layer)
- `IAuditLogService` - Data change tracking
- `IErrorLogService` - Exception logging
- `IRequestResponseLogService` - Request/response capture
- `IActivityLogService` - User activity logging

**4. LoggingQueueService** - Hosted Background Service
- Runs throughout application lifetime
- Dequeues items sequentially (FIFO)
- Creates scoped DbContext per item
- Graceful shutdown with CancellationToken

### Database Schema (4 Tables with Indexes)

```sql
audit_logs
├── Index: entity_type, entity_id, performed_by, action
├── Index: created_at DESC (for time-range queries)
└── GIN Index: metadata (for correlation ID searches)

error_logs
├── Index: error_code, severity, request_id, user_id
└── Index: created_at DESC

request_response_logs
├── Index: request_id, endpoint, http_method, user_id
├── Index: created_at DESC
└── Index: response_status_code (for error analysis)

activity_logs
├── Index: user_id, activity_type, resource_type
├── Index: created_at DESC
└── GIN Index: metadata (for correlation ID searches)
```

**Features:**
- Soft-delete columns (is_deleted, deleted_at, deleted_by)
- TEXT columns for request/response bodies (unlimited size)
- JSONB metadata for correlation IDs
- Timestamps with UTC timezone

### Middleware Chain

1. **CorrelationIdMiddleware** - First in chain
   - Extracts X-Correlation-ID from headers or generates GUID
   - Format: `yyyyMMddHHmmss-{GUID}`
   - Stores in HttpContext.Items and Serilog LogContext

2. **RequestResponseLoggingMiddleware** - Second in chain
   - Captures complete request/response
   - Measures ResponseTimeMs with Stopwatch
   - Queues log item

3. **ExceptionHandlingMiddleware** - Third in chain
   - Global exception handler
   - Logs error with full context
   - Returns standardized error response

### Correlation ID Flow

```
Client Request
    ↓
CorrelationIdMiddleware: "20260118145032-a1b2c3d4e5f6g7h8"
    ↓
HttpContext.Items["CorrelationId"] (available to all layers)
    ↓
Request executed (audit logs, errors, activity)
    ↓
All logs include: correlationId in metadata JSONB
    ↓
Query example:
SELECT * FROM audit_logs 
WHERE metadata->>'CorrelationId' = '20260118145032-a1b2c3d4e5f6g7h8'
ORDER BY created_at ASC;
```

### Project Structure

```
Domain/Entities/
├── AuditLog.cs
├── ErrorLog.cs
├── RequestResponseLog.cs
└── ActivityLog.cs

Utility/
├── Abstractions/Logging/
│   ├── IAuditLogService.cs
│   ├── IErrorLogService.cs
│   ├── IRequestResponseLogService.cs
│   └── IActivityLogService.cs
└── Integration/Logging/Queue/
    ├── ILoggingQueue.cs
    ├── LoggingQueue.cs
    └── LogItem.cs (base + 4 derived types)

Infrastructure/
├── Integration/Logging/
│   ├── AuditLogService.cs
│   ├── ErrorLogService.cs
│   ├── RequestResponseLogService.cs
│   ├── ActivityLogService.cs
│   └── LoggingQueueService.cs (BackgroundService)
├── Persistance/DBContext/
│   └── VehicleServiceDbContext.cs (4 new DbSets)
└── DependencyInjection.cs (service registrations)

API/
├── Middleware/
│   ├── CorrelationIdMiddleware.cs
│   ├── RequestResponseLoggingMiddleware.cs
│   └── ExceptionHandlingMiddleware.cs
└── Program.cs (middleware pipeline + utility DI)

API/liquibase/changelogs/sql/
└── 003-logging-schema.sql (complete schema with indexes)
```

### Dependency Injection Setup

```csharp
// In Infrastructure.DependencyInjection.cs
services.AddSingleton<ILoggingQueue, LoggingQueue>();
services.AddScoped<IAuditLogService, AuditLogService>();
services.AddScoped<IErrorLogService, ErrorLogService>();
services.AddScoped<IRequestResponseLogService, RequestResponseLogService>();
services.AddScoped<IActivityLogService, ActivityLogService>();
services.AddHostedService<LoggingQueueService>();

// In Program.cs
app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();
builder.Services.AddUtilityServices();
```

### Usage Examples

**Audit Logging:**
```csharp
public class UpdateVehicleHandler : IRequestHandler<UpdateVehicleCommand>
{
    private readonly IAuditLogService _auditLogService;
    private readonly IHttpContextAccessor _contextAccessor;

    public async Task Handle(UpdateVehicleCommand command)
    {
        var correlationId = _contextAccessor.HttpContext?.Items["CorrelationId"]?.ToString();
        await _auditLogService.LogUpdateAsync(
            entityType: "Vehicle",
            entityId: command.VehicleId,
            oldValues: JsonConvert.SerializeObject(existingVehicle),
            newValues: JsonConvert.SerializeObject(command),
            changedFields: JsonConvert.SerializeObject(changedFields),
            userId: _userContext.UserId,
            ipAddress: _contextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString(),
            userAgent: _contextAccessor.HttpContext?.Request.Headers["User-Agent"].ToString(),
            correlationId: correlationId
        );
    }
}
```

### Performance Impact

- **Request Path:** Non-blocking (ValueTask, no await on critical path)
- **Queue Processing:** Background thread (separate from request threads)
- **Database Inserts:** Sequential, atomic (one item at a time)
- **Memory:** Bounded queue (max 1000 items at 1-2KB each ≈ 2MB)
- **Throughput:** ~1000-5000 logs/second (depends on DB hardware)

### Build Status
✅ All 6 projects compile successfully
- Domain, Abstractions, Application, Utility, Infrastructure, API
- 0 errors, 0 warnings

---

| Category | Estimated | Status |
|----------|-----------|--------|
| **Development** | $154,800 | ⏳ In Progress |
| **Infrastructure (Year 1)** | $17,400 | ⏳ Pending |
| **One-Time Costs** | $1,174 | ⏳ Pending |
| **Total First Year** | **$173,374** | |

**Current Spend:** ~$15,000 (Phases 1-4 partial)

---

## 🚀 Timeline

**Start Date:** January 11, 2026  
**Current Date:** January 18, 2026  
**Projected Completion:** November 2026 (10 months)

### Monthly Breakdown
- **Month 1** (Jan): Phase 4 remaining | Frontend Migration Setup ✅
- **Month 2** (Feb): Phase 5 - Roles & Permissions
- **Month 3** (Mar): Phase 6 - CMS
- **Month 4-5** (Apr-May): Phase 7 - AI Platform
- **Month 6-7** (Jun-Jul): Phase 8 - Customer App + Phase 10 (parallel)
- **Month 8** (Aug): Phase 9 - Admin App + Phase 10 (remaining)
- **Month 9** (Sep): Phase 11 - Integration & Testing
- **Month 10** (Oct): Phase 12 - Deployment + Buffer

---

## 📝 Notes & Decisions

### January 18, 2026
- **Decision:** Expanded project scope to full garage and vehicle service aggregator platform
- **Decision:** Migrated frontend from Angular to Flutter (unified web + mobile)
- **Decision:** Tech stack finalized:
  - Backend: .NET Core 9
  - Frontend: Flutter (web + iOS + Android)
  - AI/ML: Azure AI Foundry (chatbot models) + Python 3.11+ (custom ML)
- **Decision:** Azure AI Foundry for chatbot model integration:
  - Fast mode chatbot
  - Deep thinking mode chatbot
  - Audio/voice chatbot
  - Image describer AI model
- **Decision:** Python for custom AI/ML development (TensorFlow, PyTorch, FastAPI)
- **Decision:** Migrated from SixLabors.ImageSharp to SkiaSharp for zero vulnerabilities
- **Decision:** 4-tier role hierarchy (Super Admin → App Admin → Garage Admin → Customer)
- **Action Required:** Stakeholder approval for expanded scope and budget

### Key Risks
- Azure AI costs may exceed estimates with high usage
- Mobile app development may require specialized expertise
- AI model training accuracy dependent on quality datasets
- Timeline assumes 4-7 developers available throughout project

---

**📁 For detailed phase information, see:** [Comprehensive Project Plan](../00-getting-started/COMPREHENSIVE-PROJECT-PLAN.md)

**Next Milestone:** Complete Application Services and Controllers

