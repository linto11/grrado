# Debugging with .NET Aspire AppHost

## Overview

The GRRADO backend now includes a **Aspire AppHost** that provides a unified debugging experience for all microservices. The AppHost orchestrates 8 .NET services (API Gateway + 7 microservices) while allowing external infrastructure (PostgreSQL, Redis, RabbitMQ, Keycloak) to run via docker-compose.

## Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                   Aspire AppHost (5100-5107)                │
│  ┌─────────────┬────────────┬────────────┬──────────────┐  │
│  │   Gateway   │   User     │  Vehicle   │    Garage    │  │
│  │   (5100)    │ Service    │  Service   │   Service    │  │
│  │             │  (5101)    │  (5102)    │   (5103)     │  │
│  └─────────────┴────────────┴────────────┴──────────────┘  │
│  ┌──────────────────────────────────────────────────────┐  │
│  │  Service History │ Chatbot │ Diagnostics │ Logging   │  │
│  │  Service (5104)  │ Service │  Service    │ Service   │  │
│  │                  │ (5105)  │  (5106)     │ (5107)    │  │
│  └──────────────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────────┘
           │
           ├─→ References external infrastructure
           │
┌──────────────────────────────────────────────────────────────┐
│         Docker-Compose Infrastructure (Separate)             │
│  ┌──────────────┬────────┬──────────┬──────────────┐        │
│  │ PostgreSQL   │ Redis  │ RabbitMQ │   Keycloak   │        │
│  │ (5433)       │(6379)  │(5672)    │   (8080)     │        │
│  └──────────────┴────────┴──────────┴──────────────┘        │
└──────────────────────────────────────────────────────────────┘
```

## Prerequisites

### 1. Install/Update Aspire Dashboard

The Aspire dashboard is required to view real-time service logs, metrics, and traces:

```powershell
dotnet tool update -g aspire
```

It will show in your terminal when running the AppHost.

### 2. Start Docker-Compose Infrastructure

**Important**: The AppHost does NOT manage infrastructure containers. You must start them separately:

```bash
# From the project root (d:\_GRRADO\src)
docker-compose up -d
```

Verify containers are running:

```bash
docker-compose ps
```

You should see:
- `grrado-postgres` (port 5433)
- `grrado-redis` (port 6379)
- `grrado-rabbitmq` (port 5672, 15672)
- `grrado-keycloak` (port 8080)

## Running the AppHost

### Option 1: F5 in VS Code

From the AppHost project in VS Code:

1. Set [app/server/AppHost/GRRADO.AppHost.csproj](app/server/AppHost/GRRADO.AppHost.csproj) as startup project
2. Press **F5** or click Debug → Start Debugging

This will:
- Launch the Aspire orchestration engine
- Start all 8 .NET services (gateway + 7 microservices)
- Open the Aspire dashboard in your browser

### Option 2: Command Line

```powershell
cd d:\_GRRADO\src\app\server

# Run AppHost (will start Aspire dashboard)
dotnet run --project AppHost/GRRADO.AppHost.csproj

# The terminal will show:
# Aspire dashboard running at http://localhost:18888
```

### Option 3: Run Individual Services (if needed)

For debugging a specific service without Aspire:

```powershell
# Example: Run UserService only
cd app/server/services/UserService/UserService.API
dotnet run
```

**Note**: Services will fail to connect to RabbitMQ/PostgreSQL unless docker-compose infrastructure is running.

## Using the Aspire Dashboard

Once the AppHost starts, it automatically opens the Aspire Dashboard at **http://localhost:18888** (or similar).

### Dashboard Features

#### 1. **Resources View**
- See all 8 services with status (Running/Stopped)
- Click service name → view logs in real-time
- Health status indicators

#### 2. **Logs**
- Real-time structured logging from all services
- Search by service name, log level, message
- Example search: `UserService Error` to find all errors in UserService

#### 3. **Traces**
- Distributed tracing across services (if implemented)
- See request flow: Gateway → UserService → Database

#### 4. **Endpoints**
- View service URLs and health check endpoints
- Click to open service documentation (Scalar UI)

#### 5. **Environment**
- View environment variables injected by Aspire
- Connection string values
- Port assignments

## Service Endpoints

Once running via Aspire, access services at:

| Service | Port | Health | Docs |
|---------|------|--------|------|
| **Gateway** | 5100 | `http://localhost:5100/health` | `http://localhost:5100/openapi/scalar/v1` |
| **UserService** | 5101 | `http://localhost:5101/health` | `http://localhost:5101/openapi/scalar/v1` |
| **VehicleService** | 5102 | `http://localhost:5102/health` | `http://localhost:5102/openapi/scalar/v1` |
| **GarageService** | 5103 | `http://localhost:5103/health` | `http://localhost:5103/openapi/scalar/v1` |
| **ServiceHistoryService** | 5104 | `http://localhost:5104/health` | `http://localhost:5104/openapi/scalar/v1` |
| **ChatbotService** | 5105 | `http://localhost:5105/health` | `http://localhost:5105/openapi/scalar/v1` |
| **DiagnosticsService** | 5106 | `http://localhost:5106/health` | `http://localhost:5106/openapi/scalar/v1` |
| **LoggingService** | 5107 | `http://localhost:5107/health` | `http://localhost:5107/openapi/scalar/v1` |

### Example Requests

```bash
# Check gateway health
curl http://localhost:5100/health

# Call an API via gateway
curl http://localhost:5100/api/Users

# Call a service directly
curl http://localhost:5101/api/Users

# View OpenAPI documentation
# Open in browser: http://localhost:5100/openapi/scalar/v1
```

## Development Workflow

### 1. **Edit Code**
- Modify service code in `app/server/services/`
- Aspire automatically detects changes (if running with watch mode)

### 2. **Debug**
- Set breakpoints in VS Code
- Request hits breakpoint
- Step through code

### 3. **View Logs**
- Open Aspire Dashboard
- Click service → Logs
- Search or filter logs in real-time

### 4. **Test Integration**
- Call gateway: `http://localhost:5100/api/...`
- Trace request through services in dashboard
- Check distributed tracing

## Troubleshooting

### Issue: Services won't start

**Symptom**: Services show as "Failed" in Aspire dashboard

**Solution**:
1. Verify docker-compose infrastructure is running:
   ```bash
   docker-compose ps
   ```
2. Check service logs in Aspire dashboard
3. Ensure connection strings in `appsettings.json` match docker-compose ports (localhost:5433 for postgres, etc.)

### Issue: "Connection refused" errors

**Symptom**: Services can't connect to PostgreSQL/Redis/RabbitMQ

**Solution**:
1. Check docker-compose is running: `docker-compose ps`
2. Verify ports are correct in [init-databases.sql](../../../init-databases.sql):
   - PostgreSQL: `localhost:5433`
   - Redis: `localhost:6379`
   - RabbitMQ: `localhost:5672`

### Issue: Aspire dashboard won't open

**Symptom**: Terminal says "Dashboard running at..." but browser doesn't open

**Solution**:
1. Manually open: `http://localhost:18888`
2. If that doesn't work, check port conflicts: `netstat -ano | findstr :18888`
3. Kill conflicting process if needed

### Issue: Changes to code don't reload

**Symptom**: Modified code still runs old version

**Solution**:
1. Stop AppHost (Ctrl+C in terminal)
2. Run `dotnet build` to ensure compilation is fresh
3. Restart AppHost: `dotnet run --project AppHost/GRRADO.AppHost.csproj`

## Differences from docker-compose-only approach

| Aspect | Docker-Compose Only | Aspire AppHost |
|--------|-------------------|-----------------|
| **Service Orchestration** | Manual `dotnet run` per service | Unified Aspire dashboard |
| **Logging** | Individual terminal windows | Single Aspire dashboard |
| **Port Management** | Must track manually | Aspire handles (5100-5107) |
| **Health Checks** | Manual via curl | Visual in dashboard |
| **Infrastructure** | Containers managed | Must run separately (docker-compose up) |
| **Distributed Tracing** | Not configured | Enabled via Aspire |
| **Environment Variables** | Manual setup | Aspire injects automatically |

## Production vs Development

- **Development** (Aspire): Use AppHost for unified debugging and testing
- **Production**: Use docker-compose for full orchestration (services + infrastructure)
  ```bash
  # Add service containers to docker-compose.yml for production
  # Rebuild service Docker images and push to registry
  # Run: docker-compose -f docker-compose.prod.yml up
  ```

## Next Steps

- **Add database seeding**: Create [AppHost/init-databases.sql](./AppHost/init-databases.sql) migration
- **Configure Aspire components**: Add Redis/PostgreSQL health checks to AppHost
- **Write integration tests**: Use Aspire for test orchestration
- **Implement distributed tracing**: Add OpenTelemetry to services

## References

- [Microsoft Aspire Documentation](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview)
- [Aspire GitHub Repository](https://github.com/dotnet/aspire)
- [YARP Gateway Configuration](../../gateway/ApiGateway/appsettings.json#L2)
- [Service Health Checks](../services/UserService/UserService.API/Program.cs#L30)
