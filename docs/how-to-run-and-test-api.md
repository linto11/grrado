# How To Run And Test The API

**Canonical runtime guide**  
**Last Updated:** April 17, 2026

Use this file as the single source of truth for running and testing the current backend.

---

## Prerequisites

- .NET 9 SDK
- Docker Desktop
- Access to `D:\_GRRADO\src`

Build status verified on April 17, 2026:

- `GRRADO.Microservices.sln` builds with 0 errors and 2 warnings

---

## Quick Start

```powershell
# 1. Start infrastructure
cd D:\_GRRADO\src
docker compose -f D:\_GRRADO\src\docker-compose.yml up -d

# 2. Build backend
cd D:\_GRRADO\src\app\server
dotnet build GRRADO.Microservices.sln

# 3. Run one service
dotnet run --project services/UserService/UserService.API/UserService.API.csproj

# 4. Open Scalar
# http://localhost:5101/scalar/v1
```

---

## Infrastructure

Start shared infrastructure first:

```powershell
cd D:\_GRRADO\src
docker compose -f D:\_GRRADO\src\docker-compose.yml up -d
docker compose -f D:\_GRRADO\src\docker-compose.yml ps
```

This brings up:

- PostgreSQL on `5433`
- Redis on `6379`
- RabbitMQ on `5672` and `15672`
- Keycloak on `8080`

---

## Build

```powershell
cd D:\_GRRADO\src\app\server
dotnet build GRRADO.Microservices.sln
```

---

## Run Options

### Run one service

```powershell
cd D:\_GRRADO\src\app\server
dotnet run --project services/UserService/UserService.API/UserService.API.csproj
```

### Run the gateway

```powershell
cd D:\_GRRADO\src\app\server
dotnet run --project gateway/ApiGateway/ApiGateway.csproj
```

### Run all services with the script

```powershell
cd D:\_GRRADO\src\app\server
.\run-services.ps1
```

### Run with AppHost / Aspire

For AppHost and Visual Studio orchestration, use:

- `docs/00-getting-started/04-aspire-debugging.md`

---

## Ports

| Service | Port |
|---------|------|
| API Gateway | 5100 |
| UserService | 5101 |
| VehicleService | 5102 |
| GarageService | 5103 |
| ServiceHistoryService | 5104 |
| ChatbotService | 5105 |
| DiagnosticsService | 5106 |
| LoggingService | 5107 |

Per-service docs are available at:

```text
http://localhost:{port}/scalar/v1
```

---

## Test The API

### Scalar UI

1. Run a service.
2. Open `http://localhost:{port}/scalar/v1`.
3. Use the interactive endpoint tester.

### PowerShell or curl via gateway

```powershell
# Start the gateway first, then call through port 5100
curl -X GET "http://localhost:5100/api/Users"

curl -X POST "http://localhost:5100/api/Users" `
  -H "Content-Type: application/json" `
  -d '{"name":"Jane Smith","email":"jane@example.com","phoneNumber":"555-1234","city":"New York"}'
```

### Direct service calls

```powershell
curl -X GET "http://localhost:5101/api/Users"
```

---

## Troubleshooting

### Build fails

```powershell
cd D:\_GRRADO\src\app\server
dotnet clean GRRADO.Microservices.sln
dotnet restore GRRADO.Microservices.sln
dotnet build GRRADO.Microservices.sln
```

### Infrastructure is not reachable

```powershell
cd D:\_GRRADO\src
docker compose -f D:\_GRRADO\src\docker-compose.yml ps
docker compose -f D:\_GRRADO\src\docker-compose.yml logs postgres
docker compose -f D:\_GRRADO\src\docker-compose.yml logs rabbitmq
```

### Port is already in use

```powershell
netstat -ano | findstr :5101
taskkill /PID <PID> /F
```

---

## Related Docs

- `README.md`
- `docs/current-doc-set.md`
- `docs/02-progress-tracking/current-status.md`
- `docs/00-getting-started/04-aspire-debugging.md`
