# Task 005: Local Development Environment Verification

**Task ID:** 005  
**Domain:** Foundation / Environment Setup  
**Estimated Time:** 5 minutes  
**Created:** 2026-02-01  
**Status:** ⏳ TODO  

---

## 📝 Description

Verify and validate the complete local development environment. Ensure all services are running, databases are accessible, and the API can be built and started successfully.

## 🎯 Acceptance Criteria

- [ ] PostgreSQL running and accessible on `localhost:5433`
- [ ] Redis running and accessible on `localhost:6379`
- [ ] Database `vehicle_service_db` exists and contains proper tables
- [ ] Connection strings in appsettings correct
- [ ] Logs directory exists at `app/server/API/logs/`
- [ ] API builds successfully: `dotnet build` (0 errors)
- [ ] API runs without startup errors: `dotnet run`
- [ ] Health check endpoint responds: `GET http://localhost:5100/api/v1/health`
- [ ] Scalar API docs accessible at `http://localhost:5100/scalar/v1`

## 📍 Files to Check/Create

- [app/server/API/appsettings.json](../../../../app/server/API/appsettings.json)
- [app/server/API/appsettings.Development.json](../../../../app/server/API/appsettings.Development.json)
- [app/server/API/Program.cs](../../../../app/server/API/Program.cs)
- [docker-compose.yml](../../../../docker-compose.yml)
- Logs directory: `app/server/API/logs/`

## 🔗 Dependencies

- Task 001: Git Branching
- Task 002: Keycloak Realm Setup
- Task 003: Database Schema Alignment
- Task 004: NuGet Package Validation

## ⚠️ Current Known Issues

- PostgreSQL port mismatch: appsettings says 5433 but migration errors show 5432
- Connection string may need verification
- Redis connection not tested (seeding disabled)
- ErrorMessageCacheRefreshService disabled due to DB connection issues

## ✅ Completion Checklist

### PostgreSQL Verification

- [ ] PostgreSQL service running:
  ```powershell
  # Windows: Check via Services or
  netstat -ano | findstr :5433
  
  # Docker: Check container
  docker ps | findstr postgres
  ```

- [ ] Test PostgreSQL connection:
  ```powershell
  psql -h localhost -p 5433 -U postgres
  Password: <postgres-password>
  ```

- [ ] Verify database exists:
  ```sql
  \l vehicle_service_db
  \d  # List all tables
  ```
  Expected: 13 portal tables + 5 chatbot tables = 18 total

- [ ] Test from .NET:
  ```powershell
  cd app/server/API
  dotnet ef dbcontext info
  ```
  Expected: Provider name: Npgsql.EntityFrameworkCore.PostgreSQL

### Redis Verification

- [ ] Redis service running:
  ```powershell
  # Windows: Check via Services or
  netstat -ano | findstr :6379
  
  # Docker: Check container
  docker ps | findstr redis
  ```

- [ ] Test Redis connection:
  ```powershell
  redis-cli ping
  ```
  Expected: `PONG`

- [ ] Verify Redis configuration in appsettings:
  ```json
  "Redis": {
    "ConnectionString": "localhost:6379"
  }
  ```

### Connection String Verification

- [ ] Check [appsettings.json](../../../../app/server/API/appsettings.json):
  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5433;Database=vehicle_service_db;Username=postgres;Password=<password>"
  }
  "Keycloak": {
    "Url": "http://localhost:8080",
    "Realm": "vehicle-service"
  }
  ```

- [ ] Verify ports match:
  - [ ] PostgreSQL: 5433
  - [ ] Redis: 6379
  - [ ] Keycloak: 8080
  - [ ] API Gateway: 5100

### Directory Structure Verification

- [ ] Logs directory exists:
  ```powershell
  Test-Path "app/server/API/logs"
  ```
  If not exists, create: `mkdir app/server/API/logs`

- [ ] Uploads directory exists:
  ```powershell
  Test-Path "app/server/API/uploads"
  ```
  If not exists, create: `mkdir app/server/API/uploads`

### Build Verification

- [ ] Navigate to API project:
  ```powershell
  cd app/server/API
  ```

- [ ] Clean build:
  ```powershell
  dotnet clean
  dotnet build
  ```
  Expected: Build succeeded (0 errors, 0 warnings)

- [ ] Verify no build warnings:
  Check output has 0 warnings

### Runtime Verification

- [ ] Start API:
  ```powershell
  dotnet run
  ```
  Expected output includes:
  ```
  info: Program[0]
        Starting GRRADO API...
  info: Microsoft.Hosting.Lifetime[14]
        Now listening on: http://localhost:5100
  ```

- [ ] Test health endpoint (in new PowerShell window):
  ```powershell
  Invoke-WebRequest http://localhost:5100/api/v1/health
  ```
  Expected: Status 200 OK

- [ ] Test Scalar API docs:
  Open browser: `http://localhost:5100/scalar/v1`
  Expected: See API endpoints listed

### Environment Variables Check

- [ ] No hardcoded secrets in appsettings:
  - [ ] `your-client-secret-here` replaced
  - [ ] Default passwords changed if not dev-only
  - [ ] No API keys in version control

## 📊 Progress Notes

**Status:** ⏳ TODO  
**Started:** Not yet  
**Completed:** N/A  
**Time Spent:** N/A  
**Blockers:** Services must be running  
**Related Branch:** feature/4-environment-verification  

**Retry Count (if failed):** 0/3  
**Last Retry:** N/A  

---

## 🔧 Implementation Steps

### Step 1: Start Services

**Option A: Using Docker Compose**
```powershell
cd <repo-root>
docker-compose up -d postgres redis
# Keycloak startup: docker-compose up -d keycloak
```

**Option B: Using Docker Commands**
```powershell
# PostgreSQL
docker run --name postgres -p 5433:5432 -e POSTGRES_PASSWORD=postgres -d postgres:15

# Redis
docker run --name redis -p 6379:6379 -d redis:latest

# Keycloak
docker run --name keycloak -p 8080:8080 \
  -e KEYCLOAK_ADMIN=admin \
  -e KEYCLOAK_ADMIN_PASSWORD=admin \
  -d quay.io/keycloak/keycloak:latest start-dev
```

**Option C: Local Installation**
```powershell
# Windows: Use SQL Server Management Studio + local Redis
# Or: Use Chocolatey
choco install postgresql redis
```

### Step 2: Initialize Database

```powershell
# Apply migrations (if not done in Task 003)
cd app/server/API
dotnet ef database update
```

### Step 3: Verify Connectivity

```powershell
# Test PostgreSQL
psql -h localhost -p 5433 -U postgres -c "SELECT version();"

# Test Redis
redis-cli ping

# Test Keycloak
curl http://localhost:8080/health
```

### Step 4: Configure Application Settings

Edit [appsettings.Development.json](../../../../app/server/API/appsettings.Development.json):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5433;Database=vehicle_service_db;Username=postgres;Password=postgres"
  },
  "Keycloak": {
    "Url": "http://localhost:8080",
    "Realm": "vehicle-service",
    "ClientId": "vehicle-service-api",
    "ClientSecret": "your-actual-secret"
  },
  "Redis": {
    "ConnectionString": "localhost:6379"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Debug"
    }
  }
}
```

### Step 5: Build and Run

```powershell
cd app/server/API

# Build
dotnet build

# Run
dotnet run
```

Expected startup logs:
```
info: Program[0]
      Starting GRRADO API
info: Program[0]
      Configuring Serilog
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5100
```

### Step 6: Test Endpoints

```powershell
# Test health endpoint
$response = Invoke-WebRequest http://localhost:5100/api/v1/health
Write-Host $response.StatusCode  # Should be 200
Write-Host $response.Content     # Should have health status

# Test Scalar
Start-Process http://localhost:5100/scalar/v1

# Test an API endpoint (try GET /api/v1/users)
Invoke-WebRequest http://localhost:5100/api/v1/users
```

### Step 7: Verify Logs

```powershell
# Check log files created
Get-ChildItem app/server/API/logs/

# Tail log file (PowerShell 7+)
Get-Content app/server/API/logs/*.txt -Tail 10
```

## 🎓 Troubleshooting Guide

### PostgreSQL Connection Issues

**Error:** `Could not connect to server: Connection refused`

**Solution:**
```powershell
# Check if PostgreSQL running
docker ps | grep postgres

# If not running, start it
docker run --name postgres -p 5433:5432 -e POSTGRES_PASSWORD=postgres -d postgres:15

# Verify port
netstat -ano | findstr :5433
```

### Redis Connection Issues

**Error:** `Cannot connect to Redis at localhost:6379`

**Solution:**
```powershell
# Check if Redis running
docker ps | grep redis

# If not running, start it
docker run --name redis -p 6379:6379 -d redis:latest

# Test connection
redis-cli ping
```

### API Won't Start

**Error:** `Unable to connect to the underlying database for migration`

**Solution:**
1. Verify PostgreSQL running on correct port
2. Check connection string in appsettings
3. Run migrations manually first
4. Check logs in `app/server/API/logs/`

### Scalar API Docs Not Loading

**Error:** `http://localhost:5100/scalar/v1` returns 404

**Solution:**
1. Verify Microsoft.AspNetCore.OpenApi NuGet installed
2. Check Program.cs has OpenAPI/Scalar configuration
3. Verify app.MapScalarApiReference() in pipeline
4. Check OpenAPI is configured: `builder.Services.AddOpenApi()`

## 🔗 Related Tasks

- Task 001: Git Branching
- Task 002: Keycloak Setup
- Task 003: Database Schema
- Task 004: NuGet Packages

## 🚀 Next Steps After Completion

Once this task is complete:

1. All foundational tasks (001-005) are COMPLETE
2. Begin **Task 101: User Service - CRUD Base Layer**
3. Portal API Core development starts

---

## 📝 Post-Verification Checklist

Final verification before moving to API development:

- [ ] `dotnet build` succeeds (0 errors)
- [ ] `dotnet run` starts without errors
- [ ] PostgreSQL responsive: `psql` connection works
- [ ] Redis responsive: `redis-cli ping` returns `PONG`
- [ ] API endpoint responds: `GET /api/v1/health` → 200
- [ ] Scalar API docs load: `http://localhost:5100/scalar/v1`
- [ ] Logs directory has activity: `app/server/API/logs/*.log`
- [ ] No startup exceptions in console or log files
