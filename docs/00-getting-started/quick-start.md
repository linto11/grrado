# Quick Start Guide - GRRADO Vehicle Service Portal API

**Status:** Phase 4 In Progress -- Microservices Migration Complete
**Build:** 33 projects, 0 errors
**Date:** February 14, 2026

---

## 30-Second Quick Start

```powershell
# 1. Start infrastructure
docker compose -f d:\_GRRADO\src\docker-compose.yml up -d

# 2. Build all services
cd d:\_GRRADO\src\app\server
dotnet build GRRADO.Microservices.sln

# 3. Run a service (e.g., UserService)
dotnet run --project services/UserService/UserService.API/UserService.API.csproj

# 4. Open API docs
# http://localhost:5101/scalar/v1
```

**The service is now running and ready to test.**

---

## What You Can Test Right Now

### 7 Microservices (18 entities, 90+ endpoints)

| Service | Port | Entities |
|---------|------|----------|
| UserService | 5101 | Users |
| VehicleService | 5102 | Vehicles |
| GarageService | 5103 | Garages, Services |
| ServiceHistoryService | 5104 | ServiceHistories |
| ChatbotService | 5105 | ChatbotConversations, ChatbotMessages, AiImageAnalyses, ChatbotKnowledgeBases, AiUsageLogs |
| DiagnosticsService | 5106 | VehicleIssues, DiagnosticRules, ImageDiagnostics |
| LoggingService | 5107 | AuditLogs, ErrorLogs, ActivityLogs, RequestResponseLogs, ErrorMessages |

### API Gateway
- **Port 5100** routes to all services via YARP reverse proxy
- Run: `dotnet run --project gateway/ApiGateway/ApiGateway.csproj`

---

## Simple First Test

### Using Scalar API Reference (Easiest)

1. **Start a service:**
   ```powershell
   cd d:\_GRRADO\src\app\server
   dotnet run --project services/UserService/UserService.API/UserService.API.csproj
   ```

2. **Open Scalar:** http://localhost:5101/scalar/v1

3. **Browse and test endpoints interactively**

### Using PowerShell

```powershell
# Via gateway (start gateway first)
curl -X GET "http://localhost:5100/api/Users"

# Or directly to service
curl -X GET "http://localhost:5101/api/Users"

# Create a user
curl -X POST "http://localhost:5100/api/Users" `
  -H "Content-Type: application/json" `
  -d '{"name":"John Doe","email":"john@example.com","phoneNumber":"555-1234","city":"New York"}'
```

---

## Complete Documentation

| Document | Purpose |
|----------|---------|
| **Run & Test Guide** | [how-to-run-and-test-api.md](how-to-run-and-test-api.md) |
| **Architecture Reference** | [../../MIGRATION-STATUS.md](../../MIGRATION-STATUS.md) |
| **Implementation Plan** | [../implementation-plan.md](../implementation-plan.md) |
| **Progress Tracker** | [../02-progress-tracking/progress-tracker.md](../02-progress-tracking/progress-tracker.md) |

---

## Architecture

```
d:\_GRRADO\src\app\server\
├── gateway/ApiGateway/          # YARP reverse proxy (port 5100)
├── services/                    # 7 microservices (ports 5101-5107)
├── shared/                      # 4 shared libraries
└── GRRADO.Microservices.sln     # 33 projects, 0 errors
```

## System Requirements

- .NET 10.0 SDK
- Docker Desktop (PostgreSQL 15, Redis 7, RabbitMQ 3)

---

**Project:** GRRADO Vehicle Service Portal
**Last Updated:** February 14, 2026
