#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Generate development SSL certificates for GRRADO microservices
.DESCRIPTION
    Creates self-signed certificates for local HTTPS development
    Certificates are stored in ./certs directory
.PARAMETER CertPassword
    Password for the certificate (default: cert-password)
.EXAMPLE
    .\generate-dev-certs.ps1
    .\generate-dev-certs.ps1 -CertPassword "MySecurePassword"
#>

param(
    [string]$CertPassword = "cert-password"
)

$ErrorActionPreference = "Stop"
$certDir = "D:\_GRRADO\src\certs"

Write-Host "============================================" -ForegroundColor Cyan
Write-Host "GRRADO Development Certificate Generator" -ForegroundColor Cyan
Write-Host "============================================" -ForegroundColor Cyan
Write-Host ""

# Check if dotnet is installed
Write-Host "Checking for .NET SDK..." -ForegroundColor Yellow
try {
    $dotnetVersion = dotnet --version
    Write-Host "OK .NET SDK found: $dotnetVersion" -ForegroundColor Green
} catch {
    Write-Host "ERROR: .NET SDK not found" -ForegroundColor Red
    exit 1
}
Write-Host ""

# Create certs directory
if (-not (Test-Path $certDir)) {
    Write-Host "Creating certificates directory..." -ForegroundColor Yellow
    New-Item -ItemType Directory -Path $certDir -Force | Out-Null
    Write-Host "OK Created: $certDir" -ForegroundColor Green
} else {
    Write-Host "OK Certificates directory exists: $certDir" -ForegroundColor Green
}
Write-Host ""

# Generate self-signed certificate
Write-Host "Generating self-signed certificate..." -ForegroundColor Yellow
$certPath = Join-Path $certDir "aspnetapp.pfx"
$certCerPath = Join-Path $certDir "aspnetapp.crt"

# Remove existing certificates
if (Test-Path $certPath) {
    Remove-Item $certPath -Force
    Write-Host "  Removed existing certificate" -ForegroundColor Gray
}

if (Test-Path $certCerPath) {
    Remove-Item $certCerPath -Force
    Write-Host "  Removed existing .crt file" -ForegroundColor Gray
}

Write-Host ""
Write-Host "Generating HTTPS certificate..." -NoNewline
try {
    & dotnet dev-certs https -ep $certPath -p $CertPassword --trust | Out-Null
    Write-Host " OK" -ForegroundColor Green
} catch {
    Write-Host " ERROR" -ForegroundColor Red
    Write-Host "Failed to generate certificate: $_" -ForegroundColor Red
    exit 1
}

Write-Host ""

# Verify certificate
if (Test-Path $certPath) {
    $certInfo = Get-Item $certPath
    Write-Host "OK Certificate created successfully" -ForegroundColor Green
    Write-Host "  Path: $certPath" -ForegroundColor Gray
    Write-Host "  Size: $($certInfo.Length) bytes" -ForegroundColor Gray
} else {
    Write-Host "ERROR Failed to create certificate" -ForegroundColor Red
    exit 1
}

Write-Host ""
Write-Host "============================================" -ForegroundColor Cyan
Write-Host "Certificate Setup Complete!" -ForegroundColor Cyan
Write-Host "============================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Next steps:" -ForegroundColor Cyan
Write-Host "1. Run from Visual Studio: Press F5" -ForegroundColor White
Write-Host "2. Run from Docker:" -ForegroundColor White  
Write-Host "   docker-compose -f docker-compose.services.yml up -d" -ForegroundColor White
Write-Host ""
Write-Host "Access services via HTTPS:" -ForegroundColor Cyan
Write-Host "  - API Gateway:            https://localhost:7100" -ForegroundColor White
Write-Host "  - User Service:           https://localhost:7101" -ForegroundColor White
Write-Host "  - Vehicle Service:        https://localhost:7102" -ForegroundColor White
Write-Host "  - Garage Service:         https://localhost:7103" -ForegroundColor White
Write-Host "  - ServiceHistory Service: https://localhost:7104" -ForegroundColor White
Write-Host "  - Chatbot Service:        https://localhost:7105" -ForegroundColor White
Write-Host "  - Diagnostics Service:    https://localhost:7106" -ForegroundColor White
Write-Host "  - Logging Service:        https://localhost:7107" -ForegroundColor White
Write-Host ""
Write-Host "Note: Browsers may warn about self-signed certificates." -ForegroundColor Yellow
Write-Host "This is normal for development. Bypass warnings or disable cert validation in tests." -ForegroundColor Yellow
Write-Host ""
