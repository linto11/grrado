# Running GRRADO AppHost from Visual Studio

## Prerequisites

1. **Docker Infrastructure Running**
   ```powershell
   cd D:\_GRRADO\src
   docker-compose up -d
   ```
   Verify with: `docker-compose ps`

2. **.NET 10.0 SDK Installed**
   ```powershell
   dotnet --version
   # Should show: 10.0.200-preview.0.26103.119 or similar
   ```

## Running from Visual Studio

### Step 1: Open Project
- Open **GRRADO.Microservices.sln** in Visual Studio
- Set startup project to **GRRADO.AppHost**

### Step 2: Configure Launch Settings (Already Done!)
- LaunchSettings.json has been updated with:
  - `ASPIRE_SKIP_DASHBOARD=true` - Skips dashboard requirement
  - `ASPIRE_ALLOW_UNSECURED_TRANSPORT=true` - Allows testing without SSL
  - `launchBrowser: false` - Prevents browser launch

### Step 3: Run
- Press **F5** or click the Run button
- Or use Debug > Start Debugging

### What Will Happen
1. AppHost will start and load all microservices
2. Services will be orchestrated by Aspire (or run standalone if DCP unavailable)
3. Check the output window for service startup messages
4. Services will attempt to connect to docker-compose infrastructure

## Troubleshooting

### Error: "CliPath: The path to the DCP executable is required"
**Solution**: This is expected with .NET 10 preview. The environment variables in launchSettings.json should handle this.

If still errors:
```powershell
# Run this in Package Manager Console in Visual Studio:
$env:ASPIRE_SKIP_DASHBOARD="true"
$env:ASPIRE_ALLOW_UNSECURED_TRANSPORT="true"
```

### Error: "Project file not found"
- Verify path resolution is correct
- Check that `docker-compose up -d` was run

### Services not connecting
- Ensure docker services are healthy: `docker-compose ps`
- Check service logs in output window

### Ports already in use
- Stop existing process: `netstat -ano | findstr :5100` (Windows)
- Kill process: `taskkill /PID <PID> /F`

## Running Individual Services (Alternative)

If AppHost causes issues, run services individually:

```powershell
# Terminal 1: API Gateway
cd app/server/gateway/ApiGateway
dotnet run --urls="http://localhost:5100"

# Terminal 2: User Service  
cd app/server/services/UserService/UserService.API
dotnet run --urls="http://localhost:5101"

# And so on for other services...
```

## Testing Service Communication

Once running:
```powershell
# Test Gateway health
Invoke-RestMethod http://localhost:5100/health

# Test other services
Invoke-RestMethod http://localhost:5101/health  # User Service
Invoke-RestMethod http://localhost:5102/health  # Vehicle Service
# ... etc
```

## Environment Variables Used

| Variable | Value | Purpose |
|----------|-------|---------|
| ASPNETCORE_ENVIRONMENT | Development | Load development config |
| ASPIRE_SKIP_DASHBOARD | true | Skip Aspire Dashboard startup |
| ASPIRE_ALLOW_UNSECURED_TRANSPORT | true | Allow HTTP without SSL |
| Services__* | http://service:port | Service discovery URLs |

## Next Steps

1. Run: `docker-compose up -d`
2. Press F5 in Visual Studio
3. Wait for services to start (check output window)
4. Test with `test-apis.ps1` script

If you continue having issues, run services individually using the PowerShell script instead:
```powershell
.\app\server\run-services.ps1
```
