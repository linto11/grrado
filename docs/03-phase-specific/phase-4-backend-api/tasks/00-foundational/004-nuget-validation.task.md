# Task 004: NuGet Package Validation & Installation

**Task ID:** 004  
**Domain:** Foundation / Dependencies  
**Estimated Time:** 5 minutes  
**Created:** 2026-02-01  
**Status:** ⏳ TODO  

---

## 📝 Description

Validate all NuGet packages are correctly installed across all projects in the GRRADO solution. Ensure there are no missing dependencies, version conflicts, or broken package references that would prevent compilation.

## 🎯 Acceptance Criteria

- [ ] All .csproj files have resolved package references (no red squiggles in IDE)
- [ ] `dotnet restore` completes successfully
- [ ] Solution builds without package-related errors: `dotnet build`
- [ ] No package version conflicts in bin/obj folders
- [ ] All required JWT/Auth packages present (System.IdentityModel.Tokens.Jwt 7.1.0+)
- [ ] All required EF Core packages present
- [ ] All required Serilog packages present
- [ ] All required Polly packages present

## 📍 Files to Modify/Create

- [app/server/GRRADO.sln](../../../../app/server/GRRADO.sln)
- [app/server/API/API.csproj](../../../../app/server/API/API.csproj)
- [app/server/Application/Application.csproj](../../../../app/server/Application/Application.csproj)
- [app/server/Infrastructure/Infrastructure.csproj](../../../../app/server/Infrastructure/Infrastructure.csproj)
- [app/server/Domain/Domain.csproj](../../../../app/server/Domain/Domain.csproj)
- [app/server/Abstractions/Abstractions.csproj](../../../../app/server/Abstractions/Abstractions.csproj)
- [app/server/Utility/Utility.csproj](../../../../app/server/Utility/Utility.csproj)

## 🔗 Dependencies

- Task 001: Git Branching (should have feature branch)
- .NET 9 SDK installed
- Visual Studio or VS Code with C# extension

## ⚠️ Known Package Issues

Based on codebase review:
- JWT token validation requires: `System.IdentityModel.Tokens.Jwt` 7.1.0+
- EF Core requires: `Microsoft.EntityFrameworkCore.PostgreSQL` 9.0.0+
- Serilog requires proper middleware configuration

## ✅ Completion Checklist

### Restore Phase

- [ ] Clean all bin/obj folders:
  ```powershell
  dotnet clean
  ```

- [ ] Restore packages:
  ```powershell
  dotnet restore
  ```
  Expected output: All packages restored successfully

- [ ] Verify no restore errors (check output for any red text)

### Validation Phase

- [ ] List solution packages:
  ```powershell
  dotnet list package
  ```
  Review for conflicts or outdated versions

- [ ] Check for vulnerable packages:
  ```powershell
  dotnet list package --vulnerable
  ```
  Should show: No vulnerable packages found

- [ ] Check for deprecated packages:
  ```powershell
  dotnet list package --deprecated
  ```
  Should show: No deprecated packages

### Compilation Phase

- [ ] Build entire solution (may take 2-3 minutes):
  ```powershell
  cd app/server
  dotnet build --no-restore
  ```
  Expected: Build succeeded (0 errors)

- [ ] Verify each project individually:
  - [ ] Domain: `dotnet build app/server/Domain/Domain.csproj`
  - [ ] Abstractions: `dotnet build app/server/Abstractions/Abstractions.csproj`
  - [ ] Infrastructure: `dotnet build app/server/Infrastructure/Infrastructure.csproj`
  - [ ] Application: `dotnet build app/server/Application/Application.csproj`
  - [ ] API: `dotnet build app/server/API/API.csproj`

### Required Packages Verification

- [ ] JWT packages (in Infrastructure or API):
  - System.IdentityModel.Tokens.Jwt 7.1.0+
  - Microsoft.IdentityModel.Tokens 7.1.0+
  - Verify: `dotnet list package | findstr "IdentityModel"`

- [ ] EF Core packages (in Infrastructure):
  - Microsoft.EntityFrameworkCore 9.0.0+
  - Microsoft.EntityFrameworkCore.PostgreSQL 9.0.0+
  - Microsoft.EntityFrameworkCore.Tools 9.0.0+

- [ ] Serilog packages (in API/Infrastructure):
  - Serilog 3.0.0+
  - Serilog.AspNetCore 8.0.0+
  - Serilog.Sinks.File 5.0.0+

- [ ] Polly packages (in Infrastructure):
  - Polly 8.0.0+

- [ ] AutoMapper (in Application):
  - AutoMapper 12.0.0+
  - AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.0+

## 📊 Progress Notes

**Status:** ⏳ TODO  
**Started:** Not yet  
**Completed:** N/A  
**Time Spent:** N/A  
**Blockers:** None  
**Related Branch:** feature/4-nuget-validation  

**Retry Count (if failed):** 0/3  
**Last Retry:** N/A  

---

## 🔧 Implementation Steps

### Step 1: Environment Check

Verify .NET SDK version:
```powershell
dotnet --version
# Expected: 9.0.x
```

### Step 2: Clean and Restore

```powershell
cd app/server

# Clean all build artifacts
dotnet clean

# Restore packages
dotnet restore
```

### Step 3: Full Solution Build

```powershell
dotnet build
```

Expected output:
```
Microsoft (R) Build Engine version ...
Build succeeded.
```

### Step 4: Package Audit

```powershell
# List all packages with versions
dotnet list package

# Check for vulnerabilities
dotnet list package --vulnerable

# Check for deprecated packages
dotnet list package --deprecated
```

### Step 5: Fix Any Issues

If packages missing or conflicting:

**Option A: Update single package**
```powershell
dotnet add API/API.csproj package System.IdentityModel.Tokens.Jwt --version 7.1.0
```

**Option B: Update all packages to latest compatible**
```powershell
dotnet list package --outdated
dotnet add API/API.csproj package Microsoft.EntityFrameworkCore --upgrade
```

**Option C: Clean nuget cache and restore**
```powershell
dotnet nuget locals all --clear
dotnet restore
```

### Step 6: Final Verification

```powershell
dotnet build
dotnet test  # If test projects exist
```

## 🎓 Reference Documentation

- NuGet Package Management: https://learn.microsoft.com/en-us/nuget/
- .NET Dependency Management: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-list-package
- GRRADO Project Structure: [docs/00-getting-started/02-folder-structure.md](../../00-getting-started/02-folder-structure.md)

## 🔗 Related Tasks

- Task 001: Git Branching
- Task 003: Database Schema Alignment (can be done in parallel)
- Task 005: Local Development Environment Verification
- Task 101: User Service - CRUD Base Layer (depends on this)

## 🚀 Next Steps After Completion

Once this task is complete:

1. Move to **Task 005: Local Development Environment Verification**
2. Then all foundational tasks are complete
3. Then begin **Portal API Core** tasks (Task 101+)

## 🎓 Quick Reference

### Common Package Issues & Solutions

**Issue: Package restore fails**
```
Solution: Clear NuGet cache
dotnet nuget locals all --clear
dotnet restore
```

**Issue: Version conflict between packages**
```
Solution: Review .csproj files and align versions
Edit .csproj files to match versions
dotnet restore
```

**Issue: ProjectReference circular dependency**
```
Solution: Review project structure
Ensure correct Clean Architecture layer dependencies
Domain → Abstractions → Application → Infrastructure → API
```

---

## 📚 Package Details by Project

### API.csproj (Should reference)
- Serilog, Serilog.AspNetCore, Serilog.Sinks.File
- Swashbuckle.AspNetCore (Swagger)
- Microsoft.AspNetCore.* packages

### Infrastructure.csproj (Should reference)
- Microsoft.EntityFrameworkCore.PostgreSQL
- Microsoft.EntityFrameworkCore.Tools
- Polly
- System.IdentityModel.Tokens.Jwt

### Application.csproj (Should reference)
- AutoMapper, AutoMapper.Extensions.Microsoft.DependencyInjection
- References to Domain, Abstractions

### Domain.csproj (Should reference)
- Minimal external dependencies (pure domain entities)

### Abstractions.csproj (Should reference)
- No external dependencies (only interfaces)
