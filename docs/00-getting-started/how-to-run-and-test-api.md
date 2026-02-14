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

All endpoints follow the CRUD pattern:
```
GET    /api/{Resource}           - List all (paginated)
POST   /api/{Resource}           - Create new
GET    /api/{Resource}/{id}      - Get by ID
PUT    /api/{Resource}/{id}      - Update
DELETE /api/{Resource}/{id}      - Soft delete
```

### Portal Entities
- `/api/Users` -> UserService (5101)
- `/api/Vehicles` -> VehicleService (5102)
- `/api/Garages` -> GarageService (5103)
- `/api/Services` -> GarageService (5103)
- `/api/ServiceHistories` -> ServiceHistoryService (5104)

### Diagnostics Entities
- `/api/VehicleIssues` -> DiagnosticsService (5106)
- `/api/DiagnosticRules` -> DiagnosticsService (5106)
- `/api/ImageDiagnostics` -> DiagnosticsService (5106)

### Chatbot Entities
- `/api/ChatbotConversations` -> ChatbotService (5105)
- `/api/ChatbotMessages` -> ChatbotService (5105)
- `/api/AiImageAnalyses` -> ChatbotService (5105)
- `/api/ChatbotKnowledgeBases` -> ChatbotService (5105)
- `/api/AiUsageLogs` -> ChatbotService (5105)

### Logging Entities
- `/api/AuditLogs` -> LoggingService (5107)
- `/api/ErrorLogs` -> LoggingService (5107)
- `/api/ActivityLogs` -> LoggingService (5107)
- `/api/RequestResponseLogs` -> LoggingService (5107)
- `/api/ErrorMessages` -> LoggingService (5107)

---

## Testing Methods

### Method 1: Scalar API Reference (Recommended)

1. **Run a service:**
   ```powershell
   cd d:\_GRRADO\src\app\server
   dotnet run --project services/UserService/UserService.API/UserService.API.csproj
   ```

2. **Open Scalar:** http://localhost:5101/scalar/v1

3. **Test an Endpoint:**
   - Browse available endpoints
   - Click "Try it out" on any endpoint
   - Execute and see response

---

### Method 2: Using PowerShell/cURL (via Gateway)

```powershell
# Start gateway first
dotnet run --project gateway/ApiGateway/ApiGateway.csproj

# Get all users
curl -X GET "http://localhost:5100/api/Users"

# Create a new user
curl -X POST "http://localhost:5100/api/Users" `
  -H "Content-Type: application/json" `
  -d '{
    "name": "Jane Smith",
    "email": "jane@example.com",
    "phoneNumber": "555-1234",
    "city": "New York"
  }'

# Get specific user
curl -X GET "http://localhost:5100/api/Users/1"

# Delete user (soft delete)
curl -X DELETE "http://localhost:5100/api/Users/1"
```

---

### Method 3: Using Postman

1. **Import OpenAPI Spec:**
   - Open Postman
   - Click "Import"
   - Enter URL: `http://localhost:5101/openapi/v1.json`
   - Click "Continue"

2. **Test Endpoints:**
   - All endpoints imported as collection
   - Click "Send"

---

## Troubleshooting

### Service Port Already in Use
```powershell
netstat -ano | findstr :5101
taskkill /PID <PID> /F
```

### Database Connection Failed
- Ensure Docker containers are running: `docker compose -f d:\_GRRADO\src\docker-compose.yml up -d`
- Check PostgreSQL is healthy: `docker ps`

### Build Fails
```powershell
dotnet clean GRRADO.Microservices.sln
dotnet restore GRRADO.Microservices.sln
dotnet build GRRADO.Microservices.sln
```

---

## Support & Documentation

- **API Documentation:** http://localhost:{port}/scalar/v1
- **Architecture Reference:** [../../MIGRATION-STATUS.md](../../MIGRATION-STATUS.md)
- **Rulebook:** [../../.vscode/rules/rulebook.md](../../.vscode/rules/rulebook.md)

---

**Updated:** February 14, 2026
**Build Status:** 33 projects, 0 errors
**Architecture:** Microservices (.NET 10.0)
