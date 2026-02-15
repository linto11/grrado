# Running GRRADO Microservices

## Prerequisites

- .NET 10.0 SDK installed
- Docker and Docker Compose installed
- All code compiles successfully: `dotnet build`

## Infrastructure Services

First, start the infrastructure services (PostgreSQL, Redis, RabbitMQ, Keycloak):

```bash
cd D:\_GRRADO\src
docker-compose up -d
```

This starts:
- **PostgreSQL** (port 5433) - Database
- **Redis** (port 6379) - In-memory cache
- **RabbitMQ** (port 5672, management 15672) - Message broker
- **Keycloak** (port 8080) - Identity provider

Verify services are healthy:
```bash
docker-compose ps
```

## Running All Microservices

### Option 1: Using the launch script (Windows PowerShell)

```powershell
cd D:\_GRRADO\src\app\server
.\run-services.ps1
```

This starts all services in separate terminal windows:
- API Gateway (port 5100)
- User Service (port 5101)
- Vehicle Service (port 5102)
- Garage Service (port 5103)
- ServiceHistory Service (port 5104)
- Chatbot Service (port 5105)
- Diagnostics Service (port 5106)
- Logging Service (port 5107)

### Option 2: Running services individually

Start each service in a separate terminal:

```bash
# API Gateway
cd D:\_GRRADO\src\app\server\gateway\ApiGateway
dotnet run --urls="http://localhost:5100"

# User Service
cd D:\_GRRADO\src\app\server\services\UserService\UserService.API
dotnet run --urls="http://localhost:5101"

# And so on for other services...
```

## Testing API Communication

Once services are running, test the gateway:

```powershell
# PowerShell
Invoke-RestMethod http://localhost:5100/health

# Or using curl
curl http://localhost:5100/health
```

## Docker Containerization

For complete containerized deployment, use the docker-compose services file:

```bash
docker-compose -f docker-compose.services.yml up
```

**Note**: Individual Dockerfiles need to be created in each service directory.

## Troubleshooting

### Services don't start
- Ensure Docker infrastructure is running: `docker-compose ps`
- Check that ports 5100-5107 are not in use
- Verify .NET 10 SDK is installed: `dotnet --version`

### Database connection errors
- Ensure PostgreSQL is healthy: `docker-compose logs postgres`
- Check database credentials in service configuration
- Verify init-databases.sql ran successfully

### Redis/RabbitMQ connection errors
- Check service health: `docker-compose ps`
- Verify hostnames: services use `redis` and `rabbitmq` (not localhost)

## Environment Configuration

Services read configuration from:
- Environment variables (prefixed with `ConnectionStrings__`, `RabbitMQ__`, etc.)
- `appsettings.json` and `appsettings.Docker.json`
- Keycloak for authentication

## Logs

Logs are stored in:
- Development: `app/server/logs/` (categorized by layer)
- Docker: Available via `docker-compose logs [service-name]`

## Next Steps

1. ✓ Services compile successfully
2. ✓ Infrastructure services running
3. Test API communication between services
4. Create individual service Dockerfiles
5. Set up complete Docker deployment
6. Configure Aspire orchestration (optional)
