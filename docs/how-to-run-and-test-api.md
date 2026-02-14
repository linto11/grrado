# How to Run & Test the GRRADO Vehicle Service Portal API

**Project Status:** Phase 4 In Progress -- Microservices Migration Complete
**Last Updated:** February 14, 2026
**Build Status:** 33 projects, 0 errors
**Architecture:** Microservices (.NET 10.0) with YARP API Gateway

---

## Quick Start (5 Minutes)

### 1. Prerequisites Check
```powershell
# Check .NET version (should be 10.0+)
dotnet --version

# Ensure Docker is running (PostgreSQL, Redis, RabbitMQ)
docker compose -f d:\_GRRADO\src\docker-compose.yml up -d
```

### 2. Build the Solution
```powershell
cd d:\_GRRADO\src\app\server
dotnet build GRRADO.Microservices.sln
```

### 3. Run a Service (e.g., UserService)
```powershell
dotnet run --project services/UserService/UserService.API/UserService.API.csproj
```

### 4. Access Scalar API Docs
Open browser: **http://localhost:5101/scalar/v1**

---

## Microservices & Ports

| Service | Port | API Docs |
|---------|------|----------|
| API Gateway (YARP) | 5100 | Routes to all services |
| UserService | 5101 | http://localhost:5101/scalar/v1 |
| VehicleService | 5102 | http://localhost:5102/scalar/v1 |
| GarageService | 5103 | http://localhost:5103/scalar/v1 |
| ServiceHistoryService | 5104 | http://localhost:5104/scalar/v1 |
| ChatbotService | 5105 | http://localhost:5105/scalar/v1 |
| DiagnosticsService | 5106 | http://localhost:5106/scalar/v1 |
| LoggingService | 5107 | http://localhost:5107/scalar/v1 |

---

## Available Endpoints (18 entities, 90+ endpoints)

### Via Gateway (Base URL: `http://localhost:5100/api`)

CRUD pattern for all entities:
```
GET    /api/{Resource}           - List all (paginated)
POST   /api/{Resource}           - Create new
GET    /api/{Resource}/{id}      - Get by ID
PUT    /api/{Resource}/{id}      - Update
DELETE /api/{Resource}/{id}      - Soft delete
```

### Portal: `/api/Users`, `/api/Vehicles`, `/api/Garages`, `/api/Services`, `/api/ServiceHistories`
### Diagnostics: `/api/VehicleIssues`, `/api/DiagnosticRules`, `/api/ImageDiagnostics`
### Chatbot: `/api/ChatbotConversations`, `/api/ChatbotMessages`, `/api/AiImageAnalyses`, `/api/ChatbotKnowledgeBases`, `/api/AiUsageLogs`
### Logging: `/api/AuditLogs`, `/api/ErrorLogs`, `/api/ActivityLogs`, `/api/RequestResponseLogs`, `/api/ErrorMessages`

---

## Testing with PowerShell/cURL (via Gateway)

```powershell
# Get all users
curl -X GET "http://localhost:5100/api/Users"

# Create a new user
curl -X POST "http://localhost:5100/api/Users" `
  -H "Content-Type: application/json" `
  -d '{"name":"Jane Smith","email":"jane@example.com","phoneNumber":"555-1234","city":"New York"}'

# Get specific user
curl -X GET "http://localhost:5100/api/Users/1"

# Delete user (soft delete)
curl -X DELETE "http://localhost:5100/api/Users/1"
```

---

## Troubleshooting

### Build Fails
```powershell
dotnet clean GRRADO.Microservices.sln && dotnet restore GRRADO.Microservices.sln && dotnet build GRRADO.Microservices.sln
```

### Database Connection Failed
```powershell
docker compose -f d:\_GRRADO\src\docker-compose.yml up -d
docker ps  # verify containers are healthy
```

---

**Updated:** February 14, 2026 | **Architecture:** Microservices (.NET 10.0) | **Build:** 33 projects, 0 errors
