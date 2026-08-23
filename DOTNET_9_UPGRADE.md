# .NET 10 Preview to .NET 9 Stable Downgrade

**Date:** February 15, 2026  
**Type:** Infrastructure Update  
**Scope:** SDK Version Management  
**Version:** Updated to .NET 9.0  

## Summary

Downgraded from .NET 10.0 preview to stable .NET 9.0 LTS release to ensure production-ready, stable development environment.

## Rationale

**Why Downgrade From .NET 10 Preview?**
- ✅ .NET 9 is stable, production-ready, and LTS (Long-Term Support)
- ❌ .NET 10 is preview - experimental features and frequent breaking changes expected
- ❌ Aspire Dashboard Standalone not readily available for .NET 10 preview
- ❌ Third-party package support incomplete for .NET 10 preview
- ❌ Higher risk of breaking changes before final release

**Why .NET 9 Specifically?**
- ✅ Latest stable .NET release (released November 2024)
- ✅ Full Aspire framework support
- ✅ Comprehensive package ecosystem support
- ✅ 18-month LTS support window
- ✅ Production-grade reliability

## Changes Made

### Configuration Files
- **global.json**: Updated SDK version from "10.0" to "9.0"
- All .csproj files: Target framework remains net9.0 (already configured)
- launchSettings.json: Path references automatically update with global.json

### Documentation
- Updated all build output references from net10.0 to net9.0
- Updated changelog entries to reflect .NET 9 as current baseline
- Updated start-here.md to specify .NET 9.0 as required SDK

## Installation Required

### Step 1: Uninstall .NET 10 Preview (Optional but Recommended)
```powershell
# List installed SDKs
dotnet --list-sdks

# Remove .NET 10 preview from system (via Control Panel or command line)
# Windows: Settings > Apps > Apps & features > Search for ".NET"
```

### Step 2: Install .NET 9 SDK

**Option A: Download from microsoft.com (Recommended)**
```
1. Visit: https://dotnet.microsoft.com/en-us/download/dotnet/9.0
2. Select your OS (Windows)
3. Download the **SDK** (not just Runtime)
4. Install and restart PowerShell
```

**Option B: Using Chocolatey (if installed)**
```powershell
choco install dotnet-sdk-9.0 --yes
```

**Option C: Using Windows Package Manager**
```powershell
winget install Microsoft.DotNet.SDK.9
```

### Step 3: Verify Installation
```powershell
dotnet --version
# Should show: 9.0.x or higher

dotnet --list-sdks
# Should show .NET 9 SDK available
```

### Step 4: Clean and Rebuild
```powershell
cd D:\_GRRADO\src\app\server

# Clean old build artifacts
dotnet clean GRRADO.Microservices.sln -q

# Restore packages
dotnet restore GRRADO.Microservices.sln

# Build solution
dotnet build GRRADO.Microservices.sln --no-restore
```

## Verification

After installation, verify everything works:

```powershell
cd D:\_GRRADO\src\app\server

# Check SDK version
dotnet --version
# ✅ Should show 9.x.x

# Build AppHost
dotnet build AppHost/GRRADO.AppHost.csproj -q
# ✅ Should succeed with 0 errors

# Verify all projects compile
dotnet build GRRADO.Microservices.sln -q
# ✅ Should succeed

# Run from Visual Studio
# ✅ Press F5 in Visual Studio
```

## All Affected Files

### Global Configuration
- ✅ global.json: "version": "9.0"

### Project Files (34 total)
All .csproj files already target net9.0:
- API Layer: ApiGateway, 7 microservices APIs
- Application Layer: 7 microservices + Shared
- Domain Layer: 7 microservices + Shared
- Infrastructure Layer: 7 microservices + Shared
- AppHost: Central orchestration

### Documentation
- ✅ build-verification.md: bin/Debug/net9.0 references
- ✅ phase-4-contracts-layer.md: Build output paths updated
- ✅ Changelog entries updated to reflect .NET 9
- ✅ 00-start-here.md: Already specified .NET 9

## Testing Checklist

- [ ] .NET 9 SDK installed and verified
- [ ] dotnet --version shows 9.x.x
- [ ] dotnet clean executed
- [ ] dotnet restore succeeded
- [ ] dotnet build succeeded (0 errors)
- [ ] AppHost builds successfully
- [ ] F5 in Visual Studio works
- [ ] run-services.ps1 launches services
- [ ] Docker infrastructure running
- [ ] All 8 services accessible

## Benefits

✅ **Stability**: Production-ready, not preview  
✅ **Support**: 18-month LTS support window  
✅ **Compatibility**: Full ecosystem support  
✅ **Performance**: Optimized for production  
✅ **Security**: Regular security updates included  
✅ **Tooling**: Full Aspire support without workarounds  

## Rollback (If Needed)

If you need to revert to .NET 10 preview:
```powershell
# Update global.json
# Change "version": "9.0" back to "version": "10.0"

# Reinstall .NET 10 SDK
# Rebuild: dotnet clean && dotnet build
```

## Next Steps

1. **Install .NET 9 SDK** (see Installation Required section above)
2. **Verify installation** (see Verification section)
3. **Run tests** (use Testing Checklist)
4. **Start development** with stable, production-ready framework

---

**Status:** ✅ Ready to Use  
**SDK Version:** 9.0 (Stable LTS)  
**Project Target:** net9.0 across all 34 projects  
**Support Window:** 18 months  

For any issues, refer to [FIX_ASPIRE_ERROR.md](../../FIX_ASPIRE_ERROR.md) or [SECURITY.md](../../SECURITY.md).
