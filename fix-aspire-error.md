# Fix DCP/Dashboard Error in Visual Studio

## Error You're Getting
```
Property CliPath: The path to the DCP executable used for Aspire orchestration is required.; 
Property DashboardPath: The path to the Aspire Dashboard binaries is missing.
```

## Root Cause

.NET 9.0 stable Aspire requires either:
1. **Dashboard Standalone** (Microsoft's supported solution)
2. **DCP** (Distributed Cloud Platform) tools - not available in preview

## Recommended Fix: Use Dashboard Standalone

### Step 1: Install Aspire Dashboard Standalone
```powershell
dotnet tool install Aspire.Dashboard.Standalone --global
```

### Step 2: Start Dashboard in separate terminal
```powershell
# This opens http://localhost:18888
aspire-dashboard
```

### Step 3: Open Visual Studio and Run
- Open `GRRADO.Microservices.sln`
- Set `GRRADO.AppHost` as startup project
- **Press F5**

Dashboard will automatically detect and display all services.

**✅ This is the official Microsoft-supported approach for .NET preview**

## Alternative: Run Services Directly (No AppHost)

If you want to skip AppHost entirely, run all services individually:

```powershell
cd D:\_GRRADO\src

# Start infrastructure
docker-compose up -d

# Run all services (8 terminals, one per service)
.\app\server\run-services.ps1
```

This launches each service directly without Aspire orchestration.

## Alternative: Use Package Manager Console

For quick testing without installing Dashboard:

1. Open **Package Manager Console** (View > Other Windows > Package Manager Console)
2. Run:
   ```powershell
   $env:ASPIRE_ALLOW_UNSECURED_TRANSPORT = "false"
   # Then press F5
   ```

**Note**: This may still fail if Dashboard is truly required.

## Complete Setup Instructions

### Setup All Prerequisites
```powershell
cd D:\_GRRADO\src

# 1. Generate HTTPS certificates
.\generate-dev-certs.ps1

# 2. Start Docker infrastructure
docker-compose up -d

# 3. Install Dashboard (one-time)
dotnet tool install Aspire.Dashboard.Standalone --global

# 4. Verify everything
docker-compose ps  # Should show 4 containers UP
ls certs/aspnetapp.pfx  # Should exist
```

### Run from Visual Studio with Dashboard

#### Terminal 1: Start Dashboard
```powershell
aspire-dashboard
# Runs on http://localhost:18888
```

#### Terminal 2: Visual Studio
- Press F5
- Dashboard will show all services as they start
- Click on services to see logs and endpoints

## Port Reference

Once running, access services at:

| Service | HTTP | HTTPS | Dashboard Link |
|---------|------|-------|---|
| API Gateway | 5100 | 7100 | Gateway |
| User Service | 5101 | 7101 | user-service |
| Vehicle Service | 5102 | 7102 | vehicle-service |
| Garage Service | 5103 | 7103 | garage-service |
| ServiceHistory | 5104 | 7104 | service-history-service |
| Chatbot Service | 5105 | 7105 | chatbot-service |
| Diagnostics Service | 5106 | 7106 | diagnostics-service |
| Logging Service | 5107 | 7107 | logging-service |

## Troubleshooting Dashboard

### Dashboard not showing services
```powershell
# Verify AppHost is running
# Check Terminal 2 for error messages
# Ensure docker-compose containers are healthy
docker-compose ps
```

### Dashboard won't start
```powershell
# Check if port 18888 is already in use
netstat -ano | findstr :18888

# Kill existing process if needed
taskkill /PID <PID> /F

# Reinstall Dashboard
dotnet tool update Aspire.Dashboard.Standalone --global
```

### Services show as offline
- Verify docker infrastructure: `docker-compose ps`
- Check AppHost console for errors
- Verify certificates: `ls certs/aspnetapp.pfx`

## FAQ

**Q: Do I have to use Dashboard?**  
A: No. Use run-services.ps1 to start services directly without AppHost.

**Q: Can I use AppHost without Dashboard?**  
A: Not with .NET 10 preview - DCP or Dashboard is required by Aspire.

**Q: Will this work with final .NET 10 release?**  
A: Possibly not - await final release docs. Dashboard Standalone is future-proof.

**Q: Do I need both terminals running?**  
A: Yes - Dashboard in Terminal 1, VS (F5) in Terminal 2, AppHost runs in VS.
