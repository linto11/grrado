#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Test API communication between GRRADO microservices
.DESCRIPTION
    Tests endpoint connectivity and basic health checks
.EXAMPLE
    .\test-apis.ps1
#>

$services = @(
    @{Name="API Gateway"; Url="http://localhost:5100/health"; Port=5100},
    @{Name="User Service"; Url="http://localhost:5101/health"; Port=5101},
    @{Name="Vehicle Service"; Url="http://localhost:5102/health"; Port=5102},
    @{Name="Garage Service"; Url="http://localhost:5103/health"; Port=5103},
    @{Name="ServiceHistory Service"; Url="http://localhost:5104/health"; Port=5104},
    @{Name="Chatbot Service"; Url="http://localhost:5105/health"; Port=5105},
    @{Name="Diagnostics Service"; Url="http://localhost:5106/health"; Port=5106},
    @{Name="Logging Service"; Url="http://localhost:5107/health"; Port=5107}
)

Write-Host "============================================" -ForegroundColor Cyan
Write-Host "GRRADO API Communication Test" -ForegroundColor Cyan
Write-Host "============================================" -ForegroundColor Cyan
Write-Host ""

Write-Host "Testing service endpoints..." -ForegroundColor Yellow
Write-Host ""

$allHealthy = $true
$results = @()

foreach ($service in $services) {
    Write-Host "Testing $($service.Name)..." -NoNewline
    
    try {
        $response = Invoke-RestMethod -Uri $service.Url -Method GET -TimeoutSec 5 -ErrorAction Stop
        Write-Host " ✓ OK" -ForegroundColor Green
        $results += @{Service=$service.Name; Status="✓ Healthy"; StatusCode=200}
    }
    catch {
        $statusCode = $_.Exception.Response.StatusCode.Value__
        $errorMsg = $_.Exception.Message
        Write-Host " ✗ Failed ($errorMsg)" -ForegroundColor Red
        $results += @{Service=$service.Name; Status="✗ Unreachable"; StatusCode=$statusCode}
        $allHealthy = $false
    }
    
    Start-Sleep -Milliseconds 200
}

Write-Host ""
Write-Host "============================================" -ForegroundColor Cyan
Write-Host "Test Results" -ForegroundColor Cyan
Write-Host "============================================" -ForegroundColor Cyan
Write-Host ""

$results | Format-Table -AutoSize

Write-Host ""
if ($allHealthy) {
    Write-Host "✓ All services are healthy and communicating!" -ForegroundColor Green
}
else {
    Write-Host "✗ Some services are not responding. Check logs:" -ForegroundColor Red
    Write-Host "  docker-compose logs [service-name]" -ForegroundColor Yellow
    Write-Host "  or check service terminal windows" -ForegroundColor Yellow
}

Write-Host ""
Write-Host "Testing service-to-service communication..." -ForegroundColor Yellow
Write-Host ""

# Example: Test if gateway can reach user service (adjust based on actual API structure)
Write-Host "Gateway attempting to reach User Service..." -NoNewline
try {
    $response = Invoke-RestMethod -Uri "http://localhost:5100/api/users" -Method GET -TimeoutSec 5 -ErrorAction Stop
    Write-Host " ✓ Connected" -ForegroundColor Green
}
catch {
    # Expected if endpoint doesn't exist, just checking connectivity
    if ($_.Exception.Response.StatusCode.Value__ -eq 404) {
        Write-Host " ✓ Reachable (404 - endpoint not implemented)" -ForegroundColor Green
    }
    else {
        Write-Host " ✗ Failed ($($_.Exception.Message))" -ForegroundColor Red
    }
}

Write-Host ""
Write-Host "Test complete!" -ForegroundColor Cyan
