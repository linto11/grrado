# Grrado - Vehicle Service Aggregator Platform

[![License: Apache-2.0](https://img.shields.io/badge/License-Apache_2.0-green.svg)](LICENSE)
[![Tech Stack](https://img.shields.io/badge/stack-.NET%209%20%7C%20Flutter%20%7C%20Python%20%7C%20PostgreSQL%2016%20%7C%20Redis-blue)](#tech-stack)
[![Progress](https://img.shields.io/badge/Progress-9%25%20(103%2F1168%20hrs)-brightgreen)](#project-status)

**Enterprise-grade, multi-platform garage and vehicle service aggregator** that connects vehicle owners with service providers through intelligent automation, AI-powered diagnostics, and comprehensive management tools.

**Status:** Phases 1-3 Complete ✅ | Phase 4 In Progress 🔄 (71% Foundation)

## Project Overview

**Grrado** is a comprehensive garage and vehicle service aggregator platform that revolutionizes how vehicle owners connect with service providers. The platform offers:

### 🎯 Core Platform Features
- **Multi-Platform Access:** Unified Flutter web and mobile apps (iOS/Android)
- **4-Tier Role System:** Super Admin, Application Admin, Garage Admin, and Customers
- **Service Aggregation:** Connect customers with hundreds of garage service providers
- **Real-Time Booking:** GPS-based garage discovery, live availability, and instant booking
- **Service Tracking:** Real-time status updates, push notifications, and progress monitoring
- **Digital Payments:** Integrated payment processing and invoice generation

### 🤖 AI-Powered Intelligence
- **Advanced AI Chatbot:** Multi-modal assistance with voice, text, vision, and deep reasoning
- **Image Diagnostics:** AI-powered vehicle issue detection from photos
- **Predictive Analytics:** ML models for maintenance prediction and service recommendations
- **Azure AI Foundry:** Enterprise-grade AI infrastructure and model training platform

### 🎨 Content & Management
- **Headless CMS:** Multi-language content management for web and mobile
- **Admin Portal:** Comprehensive dashboard for operations team
- **Garage Dashboard:** Service provider management, scheduling, and analytics
- **Customer Portal:** Vehicle management, service history, and booking interface

### 📊 Business Intelligence
- **Advanced Analytics:** Revenue tracking, service trends, customer insights
- **Performance Metrics:** Garage ratings, mechanic efficiency, customer satisfaction
- **Financial Reports:** Commission tracking, tax reports, accounting integrations
- **Inventory Management:** Parts tracking, low stock alerts, supplier management

## Quick Links

- **📋 Comprehensive Project Plan:** [COMPREHENSIVE-PROJECT-PLAN.md](docs/00-getting-started/COMPREHENSIVE-PROJECT-PLAN.md) ← Complete feature specifications
- **📋 Implementation Plan:** [IMPLEMENTATION_PLAN.md](IMPLEMENTATION_PLAN.md) ← Master development guide for Copilot
- **📊 Progress Tracker:** [docs/02-progress-tracking/progress-tracker.md](docs/02-progress-tracking/progress-tracker.md) ← Single source of truth
- **🏗️ Phase Documentation:** [docs/03-phase-specific/](docs/03-phase-specific/) ← Detailed phase completions
- **💾 Database Design:** [docs/03-phase-specific/phase-3-database-liquibase/](docs/03-phase-specific/phase-3-database-liquibase/) ← Database schema & Liquibase

## Tech Stack

**Backend (.NET Core 9):**
- C# with Clean Architecture (Domain, Application, Infrastructure, API layers)
- Entity Framework Core 9 + PostgreSQL 16
- Redis 7 (distributed caching with error message support)
- Liquibase (database version control)
- MediatR (CQRS pattern)
- FluentValidation (validation with error codes)
- AutoMapper (DTO mapping)
- Polly (resilience and fault tolerance)

**Frontend (Flutter):**
- Flutter SDK (Unified Web + Mobile for iOS/Android)
- Clean Architecture (Domain, Data, Presentation layers)
- Bloc/Cubit (State Management)
- Material Design 3
- Dio (HTTP client)
- GetIt (Dependency Injection)

**AI/ML (Python):**
- Python 3.11+
- FastAPI (ML model serving API)
- TensorFlow / PyTorch (ML model training)
- Scikit-learn (Traditional ML algorithms)
- Pandas & NumPy (Data processing)
- OpenCV (Image processing for diagnostics)
- NLTK / spaCy (Natural language processing for chatbot)
- Jupyter Notebooks (Model experimentation)

**Infrastructure:**
- PostgreSQL 16 (primary database)
- Redis 7 (distributed caching)
- Liquibase (schema management)
- Keycloak (authentication/authorization)
- Docker & Docker Compose (containerization)
- Serilog (structured logging with correlation tracking)

## Project Status

**Phases Completed:** 1, 2, 3 (Environment, Architecture, Database)  
**Total Progress:** 9% (103 of 1,168 hours)  
**Current Phase:** 4 - Backend API Development (71% Foundation Complete)

| Phase | Status | Progress | Time |
|-------|--------|----------|------|
| 1: Environment Setup | ✅ Complete | 100% | 5 hrs |
| 2: Project Structure | ✅ Complete | 100% | 8 hrs |
| 3: Database & Liquibase | ✅ Complete | 100% | 15 hrs |
| 4: Backend API (Clean Arch) | 🔄 In Progress | 71% | 100 hrs |
| 5: Roles & Permissions | ⏳ Pending | 0% | 60 hrs |
| 6: Content Management System | ⏳ Pending | 0% | 100 hrs |
| 7: AI Platform & Chatbot | ⏳ Pending | 0% | 200 hrs |
| 8: Mobile App - Customer (Flutter) | ⏳ Pending | 0% | 180 hrs |
| 9: Mobile App - Admin (Flutter) | ⏳ Pending | 0% | 100 hrs |
| 10: Web Portals (Flutter Web) | ⏳ Pending | 0% | 220 hrs |
| 11: Integration & Testing | ⏳ Pending | 0% | 120 hrs |
| 12: Deployment & DevOps | ⏳ Pending | 0% | 60 hrs |
| **TOTAL** | | **9%** | **1,168 hrs** |
## Documentation

- **[COMPREHENSIVE-PROJECT-PLAN.md](docs/00-getting-started/COMPREHENSIVE-PROJECT-PLAN.md)** - Complete platform specifications and all features
- **[IMPLEMENTATION_PLAN.md](IMPLEMENTATION_PLAN.md)** - Detailed implementation plan for all phases (start here for development)
- **[docs/02-progress-tracking/progress-tracker.md](docs/02-progress-tracking/progress-tracker.md)** - Task-by-task progress tracking
- **[docs/03-phase-specific/](docs/03-phase-specific/)** - Complete documentation for each phase
- **[CHANGELOG.md](CHANGELOG.md)** - Version history and release notes
- **[CODE_OF_CONDUCT.md](CODE_OF_CONDUCT.md)** - Community guidelines
- **[CONTRIBUTING.md](CONTRIBUTING.md)** - Contribution guidelines

## Community

- **Issues:** Report bugs or request features via GitHub issues
- **Discussions:** Ask questions and share ideas
- **Contributing:** See [CONTRIBUTING.md](CONTRIBUTING.md)

## License

This project is licensed under the Apache License 2.0. See [LICENSE](LICENSE) for details.

---

**Last Updated:** January 18, 2026  
**Current Phase:** 4 - Backend API Development (71% Foundation)  
**Overall Progress:** 9% (103 of 1,168 hours)

## Latest Achievements (January 18, 2026)

✅ **Frontend Migration to Flutter**
- Migrated from Angular to unified Flutter for web + mobile
- Clean Architecture implementation for Flutter
- Updated coding standards (Rulebook v1.1)

✅ **Error Code Management System**
- JSON-based configuration with 32 error codes
- String code names (e.g., `USER_NAME_REQUIRED`) instead of GUIDs
- Redis distributed caching with 6-hour automatic refresh
- Code name to GUID resolution with O(1) dictionary lookup
- Hot reload support for runtime configuration updates

✅ **Polly Resilience Framework**
- HTTP integration policies (retry, circuit breaker, timeout)
- Azure AI integration resilience
- Keycloak authentication resilience
- Database operation policies
- Comprehensive error handling and fault tolerance

✅ **Architecture Foundation**
- Abstractions layer with 24 DTOs (Read/Create/Update)
- Repository + Unit of Work patterns
- AutoMapper with CQRS profile
- Serilog structured logging with correlation IDs
- Keycloak authentication services
- Layer-specific dependency injection
- Database logging infrastructure with background queue processing

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
- Flutter SDK 3.x
- Python 3.11+
- PostgreSQL 16 (Docker)
- VS Code (recommended)
- Docker Desktop

### Setup (Phases 1-3 already complete)

```bash
# Clone repository
git clone https://github.com/linto11/grrado.git
cd grrado

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
flutter pub get
flutter build web
```

## Project Structure

```
grrado/
├── server/                          # .NET Backend
│   ├── Domain/                      # Entity models
│   ├── Application/                 # Business logic
│   ├── Infrastructure/              # Data access & Liquibase
│   │   ├── Database/
│   │   │   └── liquibase/          # Schema migrations
│   │   ├── Data/                    # EF Core DbContext
│   │   └── Services/                # Infrastructure services
│   └── API/                         # REST API
│
├── client/                          # Flutter Frontend (Web + Mobile)
│   ├── web/
│   │   └── consumer/                # Customer mobile/web app
│   └── shared/                      # Shared Flutter packages
│       ├── auth/                    # Authentication
│       ├── ui/                      # UI components
│       ├── data/                    # Data layer
│       ├── core/                    # Core utilities
│       └── domain/                  # Domain models
│
├── scripts/
│   └── database-setup/              # Database initialization
│       ├── init-db.sql
│       └── create_migration_user.sql
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
└── IMPLEMENTATION_PLAN.md           # THIS PLAN
```

## Database Schema

**8 Core Tables:**
- **Users** (100 records) - Customer profiles with role management
- **Vehicles** (650+ records) - Vehicle inventory with maintenance tracking
- **Garages** - Service provider locations with ratings and services
- **Services** - Service offerings by garage with pricing
- **VehicleIssues** - Reported issues with AI diagnostic support
- **ServiceHistories** - Service appointments and completion records
- **DiagnosticRules** - AI diagnostic rules and patterns
- **ImageDiagnostics** - Image analysis results and recommendations

**Additional Tables (Planned):**
- **ChatbotConversations** - AI chatbot conversation history
- **ChatbotMessages** - Individual chatbot messages
- **ChatbotKnowledgeBase** - AI knowledge repository
- **MLModels** - Trained ML model metadata
- **Notifications** - Push notifications and alerts
- **Payments** - Transaction records
- **Reviews** - Customer reviews and ratings

**Features:**
- 12 composite indexes for performance
- 5 foreign key relationships
- Soft-delete pattern on all tables
- 3,400+ seed records via Liquibase
- Audit trails with timestamps

## Database Management

**Version Control:** Liquibase (not EF Core migrations)

```bash
# Check status
cd server/Infrastructure/Database
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
cd server/API

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
flutter pub get

# Development server (web)
flutter run -d chrome

# Build for web
flutter build web

# Build for mobile
flutter build apk  # Android
flutter build ios  # iOS
```

**Application will be available at:** http://localhost:8080 (or as specified)

## Key Features

### User Experience
- **Multi-Platform Access:** Unified Flutter experience across web, iOS, and Android
- **GPS-Based Discovery:** Find nearby garages with real-time availability
- **Real-Time Booking:** Instant appointment scheduling with live calendar
- **Service Tracking:** Push notifications for appointment updates and service progress
- **Digital Wallet:** Integrated payment processing and invoice management
- **Multi-Language Support:** Localized content and interface

### Authentication & Authorization
- OAuth 2.0 / OIDC via Keycloak
- 4-tier role-based access control (RBAC)
- Impersonation capabilities with audit trails
- Token refresh and session management
- Two-factor authentication (2FA) for admins

### API & Backend
- 32+ REST endpoints with full CRUD operations
- Soft-delete with restore functionality
- File upload for images with thumbnail generation
- Search, filtering, and pagination support
- Error code management with Redis caching
- Polly resilience patterns for fault tolerance
- Structured logging with correlation IDs

### AI & Machine Learning
- **Advanced Chatbot:** Multi-modal AI assistant (text, voice, vision, deep reasoning)
- **Image Diagnostics:** Computer vision for vehicle issue detection
- **Predictive Maintenance:** ML models for service predictions
- **Model Training Platform:** Custom model training and deployment
- **Azure AI Foundry:** Enterprise AI infrastructure

### Content Management
- **Headless CMS:** Multi-language content management
- **Media Library:** Images, videos, and documents
- **WYSIWYG Editor:** Rich text editing with version control
- **Template Management:** Email and notification templates
- **SEO Optimization:** Meta tags and search engine optimization

### Business Intelligence
- **Analytics Dashboard:** Service trends, revenue, and customer insights
- **Performance Metrics:** Garage ratings, mechanic efficiency, satisfaction scores
- **Financial Reports:** Revenue breakdown, commissions, tax reports
- **Inventory Management:** Parts tracking, low stock alerts
- **Export Capabilities:** PDF, Excel, and accounting software integration

### Mobile Features (Customer App)
- Vehicle management with VIN scanner
- GPS-based garage discovery
- Real-time booking and tracking
- AI chatbot assistance
- Push notifications
- Digital payment wallet
- Service history and reminders

### Mobile Features (Admin App)
- Appointment management
- Quick status updates
- Photo uploads
- Voice memos
- Emergency alerts
- Performance dashboard

## Next Steps (Phase 4)

See [IMPLEMENTATION_PLAN.md](IMPLEMENTATION_PLAN.md) for detailed Phase 4 tasks:

1. Complete Application Services layer (business logic for 8 entities)
2. Build REST API Controllers (CRUD endpoints)
3. Configure Keycloak realm and client setup
4. Add JWT authentication middleware to API pipeline
5. Test all endpoints with seed data
6. Document APIs with Swagger/OpenAPI

**Upcoming Phases:**
- **Phase 5:** Roles & Permissions System (60 hrs)
- **Phase 6:** Headless CMS Implementation (100 hrs)
- **Phase 7:** AI Platform & Chatbot Integration (200 hrs)
- **Phase 8-10:** Mobile & Web Apps with Flutter (500 hrs)
- **Phase 11-12:** Integration, Testing & Deployment (180 hrs)

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
See CONTRIBUTING.md and CODE_OF_CONDUCT.md. Open issues/PRs using the templates in .github/.

## License
Apache-2.0. See LICENSE.
