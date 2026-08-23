#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Start all GRRADO microservices locally for development/testing
.DESCRIPTION
    Starts the API Gateway and all microservices in separate terminal windows
    Prerequisites:
    - .NET 10.0 SDK installed
    - Docker containers running (postgres, redis, rabbitmq, keycloak)
      Run: docker-compose up -d
.EXAMPLE
    .\run-services.ps1
#>

param(
    [switch]$NoWait = $false
)

$serverPath = "D:\_GRRADO\src\app\server"
$services = @(
    @{Name="API Gateway"; Port=5100; Path="gateway\ApiGateway\ApiGateway.csproj"},
    @{Name="User Service"; Port=5101; Path="services\UserService\UserService.API\UserService.API.csproj"},
    @{Name="Vehicle Service"; Port=5102; Path="services\VehicleService\VehicleService.API\VehicleService.API.csproj"},
    @{Name="Garage Service"; Port=5103; Path="services\GarageService\GarageService.API\GarageService.API.csproj"},
    @{Name="ServiceHistory Service"; Port=5104; Path="services\ServiceHistoryService\ServiceHistoryService.API\ServiceHistoryService.API.csproj"},
    @{Name="Chatbot Service"; Port=5105; Path="services\ChatbotService\ChatbotService.API\ChatbotService.API.csproj"},
    @{Name="Diagnostics Service"; Port=5106; Path="services\DiagnosticsService\DiagnosticsService.API\DiagnosticsService.API.csproj"},
    @{Name="Logging Service"; Port=5107; Path="services\LoggingService\LoggingService.API\LoggingService.API.csproj"}
)

Write-Host "============================================" -ForegroundColor Cyan
Write-Host "GRRADO Microservices Launcher" -ForegroundColor Cyan
Write-Host "============================================" -ForegroundColor Cyan
Write-Host ""

# Check if docker containers are running
Write-Host "Checking infrastructure services..." -ForegroundColor Yellow
$dockerStatus = docker-compose ps | Select-String "grrado-postgres"
if (-not $dockerStatus) {
    Write-Host "⚠️  Docker containers not running!" -ForegroundColor Red
    Write-Host "Run: docker-compose up -d" -ForegroundColor Yellow
    exit 1
}
Write-Host "✓ Docker infrastructure running" -ForegroundColor Green
Write-Host ""

# Start each service
Write-Host "Starting services..." -ForegroundColor Yellow
Write-Host ""

foreach ($service in $services) {
    $projectPath = Join-Path $serverPath $service.Path
    Write-Host "Starting $($service.Name) (port $($service.Port))..." -ForegroundColor Cyan
    
    # Start in new window
    Start-Process `
        -FilePath "dotnet" `
        -ArgumentList "run --project ""$projectPath"" --urls=`"http://localhost:$($service.Port)`"" `
        -WorkingDirectory $serverPath `
        -WindowStyle Normal `
        -PassThru:$true | Out-Null
    
    Start-Sleep -Milliseconds 500
}

Write-Host ""
Write-Host "✓ All services started!" -ForegroundColor Green
Write-Host ""
Write-Host "Access endpoints:" -ForegroundColor Cyan
Write-Host "  - API Gateway:          http://localhost:5100" -ForegroundColor White
Write-Host "  - User Service:         http://localhost:5101" -ForegroundColor White
Write-Host "  - Vehicle Service:      http://localhost:5102" -ForegroundColor White
Write-Host "  - Garage Service:       http://localhost:5103" -ForegroundColor White
Write-Host "  - ServiceHistory Service: http://localhost:5104" -ForegroundColor White
Write-Host "  - Chatbot Service:      http://localhost:5105" -ForegroundColor White
Write-Host "  - Diagnostics Service:  http://localhost:5106" -ForegroundColor White
Write-Host "  - Logging Service:      http://localhost:5107" -ForegroundColor White
Write-Host ""
Write-Host "Press any key to close this window..." -ForegroundColor Yellow
if (-not $NoWait) {
    Read-Host
}
