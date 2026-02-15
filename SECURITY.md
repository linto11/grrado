# GRRADO Secure Development Guide

## Overview

GRRADO uses **HTTPS (SSL/TLS) for all communications** in both development and production environments. This document covers secure setup for local development, testing, and Docker deployments.

## Security Features

✅ **HTTPS-Only**: All API endpoints use HTTPS  
✅ **Self-Signed Certificates**: Generated for local development  
✅ **Service-to-Service Encryption**: Microservices communicate via HTTPS  
✅ **Certificate Management**: Automated certificate generation and management  
✅ **Environment Separation**: Different configs for Dev/Docker/Production  

---

## Quick Start

### 1. Generate Development Certificates

```powershell
# From project root (D:\_GRRADO\src)
.\generate-dev-certs.ps1
```

This creates:
- `certs/aspnetapp.pfx` - HTTPS certificate (password: cert-password)
- Automatically trusts the certificate in Windows certificate store

### 2. Run from Visual Studio (HTTPS)

```powershell
# Prerequisites:
# 1. Certificates generated (step above)
# 2. Docker infrastructure running:
docker-compose up -d

# Then:
# Open GRRADO.Microservices.sln in Visual Studio
# Set GRRADO.AppHost as startup project
# Press F5
```

**HTTPS Endpoints** (Visual Studio):
- API Gateway: `https://localhost:7100`
- User Service: `https://localhost:7101`
- Vehicle Service: `https://localhost:7102`
- Garage Service: `https://localhost:7103`
- ServiceHistory Service: `https://localhost:7104`
- Chatbot Service: `https://localhost:7105`
- Diagnostics Service: `https://localhost:7106`
- Logging Service: `https://localhost:7107`

### 3. Run from Docker (HTTPS)

```bash
# Start infrastructure
docker-compose up -d

# Generate certificates
.\generate-dev-certs.ps1

# Start all services
docker-compose -f docker-compose.services.yml up -d
```

**HTTPS Endpoints** (Docker):
- API Gateway: `https://localhost:7100`
- User Service: `https://localhost:7101`
- Vehicle Service: `https://localhost:7102`
- Garage Service: `https://localhost:7103`
- ServiceHistory Service: `https://localhost:7104`
- Chatbot Service: `https://localhost:7105`
- Diagnostics Service: `https://localhost:7106`
- Logging Service: `https://localhost:7107`

---

## Certificate Details

### Development Certificate

The development certificate is stored in:
```
D:\_GRRADO\src\certs/aspnetapp.pfx
```

**Properties:**
- Type: Self-signed X.509
- Algorithm: RSA-2048
- Password: `cert-password` (changeable)
- Valid for: Local HTTPS development
- CN (Common Name): `localhost`

### Certificate Password

Default: `cert-password`

To use a different password:
```powershell
.\generate-dev-certs.ps1 -CertPassword "MyCustomPassword"
```

Then update environment variable in:
- `launchSettings.json` → `ASPNETCORE_Kestrel__Certificates__Default__Password`
- `docker-compose.services.yml` → `ASPNETCORE_Kestrel__Certificates__Default__Password`

---

## Configuration by Environment

### Visual Studio (Development)

**File**: `app/server/AppHost/Properties/launchSettings.json`

```json
{
  "profiles": {
    "GRRADO.AppHost": {
      "applicationUrl": "https://localhost:7100;http://localhost:5100",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "ASPIRE_SKIP_DASHBOARD": "true",
        "ASPIRE_ALLOW_UNSECURED_TRANSPORT": "false"
      }
    }
  }
}
```

**Key Settings:**
- ✅ HTTPS on port 7100 (primary)
- ✅ HTTP on port 5100 (fallback, not recommended)
- ✅ `ASPIRE_ALLOW_UNSECURED_TRANSPORT: false` - Enforces secure comms

### Docker Deployment

**File**: `docker-compose.services.yml`

Each microservice includes:
```yaml
environment:
  ASPNETCORE_URLS: "https://+:7XXX;http://+:5XXX"
  ASPNETCORE_HTTPS_PORT: 7XXX
  ASPNETCORE_Kestrel__Certificates__Default__Path: /app/certs/aspnetapp.pfx
  ASPNETCORE_Kestrel__Certificates__Default__Password: "cert-password"

volumes:
  - ./certs:/app/certs:ro
```

**Key Settings:**
- ✅ HTTPS on port 7XXX (primary)
- ✅ HTTP on port 5XXX (fallback)
- ✅ Certificate mounted read-only into container
- ✅ Service-to-service comms via HTTPS

---

## Port Mappings

### Visual Studio (Local Ports)

| Service | HTTP | HTTPS | Purpose |
|---------|------|-------|---------|
| API Gateway | 5100 | 7100 | Entry point |
| User Service | 5101 | 7101 | User management |
| Vehicle Service | 5102 | 7102 | Vehicle data |
| Garage Service | 5103 | 7103 | Garage operations |
| ServiceHistory | 5104 | 7104 | Service records |
| Chatbot Service | 5105 | 7105 | AI conversations |
| Diagnostics | 5106 | 7106 | System diagnostics |
| Logging Service | 5107 | 7107 | Centralized logging |

### Docker Container Ports

Same as above - Docker network isolation ensures port uniqueness.

---

## Troubleshooting

### Certificate Issues

#### "Certificate not found"
```powershell
# Regenerate certificates
.\generate-dev-certs.ps1

# Verify certificate exists
ls certs/
```

#### "Certificate verification failed" in Docker
```bash
# Ensure certificate volume is mounted correctly
docker exec grrado-api-gateway ls -la /app/certs/

# Regenerate with correct password matching docker-compose.yml
.\generate-dev-certs.ps1
```

#### Browser certificate warning
**Expected behavior** - Self-signed certificates trigger browser warnings.

**Solutions:**
1. **Bypass** (Development only):
   - Click "Advanced" → "Proceed anyway"
   - Add exception to browser

2. **Trust System-wide** (Windows):
   - Run certificate generator script
   - Automatically installs in Windows Certificate Store

3. **HttpClient ignore (Testing)**:
   ```csharp
   var handler = new HttpClientHandler();
   handler.ClientCertificateOptions = ClientCertificateOption.Manual;
   handler.ServerCertificateCustomValidationCallback = 
       (httpRequestMessage, cert, certChain, policyErrors) => true;
   var client = new HttpClient(handler);
   ```

### HTTPS Connection Issues

#### "Connection refused"
```bash
# Verify services are running
docker-compose ps

# Check service logs
docker-compose logs api-gateway
```

#### "Port already in use"
```powershell
# Find process using port
netstat -ano | findstr :7100

# Kill process
taskkill /PID <PID> /F
```

#### "HTTPS not responding from Docker"
```bash
# Verify certificate is accessible inside container
docker exec grrado-api-gateway cat /app/certs/aspnetapp.pfx

# Check Kestrel configuration
docker exec grrado-api-gateway env | grep ASPNETCORE
```

---

## Testing Secure Endpoints

### Using PowerShell

```powershell
# Accept self-signed certificates
[System.Net.ServicePointManager]::ServerCertificateValidationCallback = {$true}

# Test HTTPS endpoint
$response = Invoke-RestMethod https://localhost:7100/health -SkipCertificateCheck

# Or with SkipCertificateCheck (PS 6.0+)
Invoke-RestMethod https://localhost:7100/health -SkipCertificateCheck
```

### Using curl

```bash
# Accept self-signed certificates
curl --insecure https://localhost:7100/health

# Or with certificate verification disabled
curl -k https://localhost:7100/health
```

### Using C# HttpClient

```csharp
var handler = new HttpClientHandler();
handler.ServerCertificateCustomValidationCallback = 
    (message, cert, chain, errors) => true; // Only for development!

using var client = new HttpClient(handler);
var response = await client.GetAsync("https://localhost:7100/health");
```

---

## Service-to-Service Communication

All microservices communicate via HTTPS:

**Configuration:**
```yaml
Services__UserService: "https://user-service:7101"
Services__VehicleService: "https://vehicle-service:7102"
# ... etc
```

**Docker Network:**
Services use Docker's internal DNS (`service-name:port`) within `grrado-network`.

---

## Production Deployment

For production, replace self-signed certificates with proper certificates:

1. **Install production certificate**:
   - Configure `ASPNETCORE_Kestrel__Certificates__Default__Path` to point to production cert
   - Use environment-specific configuration

2. **Certificate sources**:
   - Let's Encrypt (free, automated)
   - AWS Certificate Manager (AWS hosted)
   - Azure Key Vault (Azure hosted)
   - Corporate CA

3. **Update environment variables**:
   ```yaml
   ASPNETCORE_Kestrel__Certificates__Default__Path: /var/run/secrets/cert.pfx
   ASPNETCORE_Kestrel__Certificates__Default__Password: ${CERT_PASSWORD}
   ```

4. **Reference documentation**:
   - [ASP.NET Core Kestrel HTTPS](https://docs.microsoft.com/aspnet/core/fundamentals/servers/kestrel/endpoints)
   - [Let's Encrypt](https://letsencrypt.org)
   - [Azure Key Vault](https://docs.microsoft.com/azure/key-vault)

---

## Security Best Practices

✅ **Always use HTTPS** for API communication  
✅ **Regenerate certificates** when passwords change  
✅ **Never commit certificates** to version control  
✅ **Use strong passwords** for production certificates  
✅ **Monitor certificate expiration** dates  
✅ **Rotate certificates** regularly (annually minimum)  
✅ **Enable CORS carefully** - validate origins  
✅ **Validate all inputs** - even over HTTPS  
✅ **Use authentication** tokens (JWT, OAuth2)  
✅ **Encrypt sensitive data** at rest and in transit  

---

## Quick Reference

### Generate Certificates
```powershell
.\generate-dev-certs.ps1
```

### Run from Visual Studio
```powershell
# Terminal 1: Start infrastructure
docker-compose up -d

# Terminal 2: Press F5 in Visual Studio
```

### Run from Docker
```bash
docker-compose -f docker-compose.services.yml up -d
```

### Test Endpoint
```powershell
Invoke-RestMethod https://localhost:7100/health -SkipCertificateCheck
```

### View Certificate
```powershell
Get-PfxCertificate certs/aspnetapp.pfx
```

---

## Support

For issues or questions:
1. Check troubleshooting section above
2. Review service logs: `docker-compose logs [service-name]`
3. Verify certificates exist: `ls certs/`
4. Check environment variables: `docker exec [container] env`

---

**Last Updated**: February 15, 2026  
**Version**: 1.0  
**Status**: Secure Development Ready ✅
