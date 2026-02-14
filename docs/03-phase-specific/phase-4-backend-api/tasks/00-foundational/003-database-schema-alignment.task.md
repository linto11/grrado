# Task 003: PostgreSQL Schema Alignment with EF Models

**Task ID:** 003  
**Domain:** Foundation / Database  
**Estimated Time:** 10 minutes  
**Created:** 2026-02-01  
**Status:** ⏳ TODO  

---

## 📝 Description

Align PostgreSQL database schema with Entity Framework Core models. This is a **CRITICAL BLOCKER** preventing all API testing. The current schema is missing essential columns (`DeletedAt`, audit fields) causing HTTP 500 errors on all endpoints.

## 🎯 Acceptance Criteria

- [ ] All 8 portal entity tables have correct columns matching EF models
- [ ] All soft-delete columns exist: `DeletedAt`, `IsDeleted`
- [ ] All audit columns exist: `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy`, `DeletedBy`
- [ ] All 5 chatbot tables created with proper schema
- [ ] All foreign key relationships verified
- [ ] All 30+ database indexes exist and are optimized
- [ ] Build succeeds: `dotnet build` (0 errors)
- [ ] Database connection test passes: `dotnet ef dbcontext info`
- [ ] Sample API endpoint returns 200 (not 500)

## 📍 Files to Modify/Create

- Database: PostgreSQL `vehicle_service_db`
- Liquibase migrations: `app/server/API/liquibase/`
  - [001-initial-schema.xml](../../../../app/server/API/liquibase/001-initial-schema.xml)
  - [002-create-indexes.xml](../../../../app/server/API/liquibase/002-create-indexes.xml)
  - [003-create-chatbot-tables.xml](../../../../app/server/API/liquibase/003-create-chatbot-tables.xml)
- EF Models: `app/server/Domain/Entities/`

## 🔗 Dependencies

- Task 001: Git Branching (must have feature branch)
- PostgreSQL must be running on `localhost:5433`
- Task 005 prerequisite (but can be done in parallel)

## ⚠️ Critical Issue

**Current Problem:**
```
CRITICAL BLOCKER: PostgreSQL schema missing columns
- Missing: DeletedAt, FamilyType, audit fields
- Result: HTTP 500 errors on all endpoints
- Root Cause: Incomplete or outdated Liquibase migrations
```

**Sample Error:**
```
Database exception: column "DeletedAt" of relation "users" does not exist
Endpoint: GET /api/v1/users
Response: HTTP 500 Internal Server Error
```

## ✅ Completion Checklist

### Pre-Migration Validation

- [ ] Verify PostgreSQL running: `psql -U postgres -d vehicle_service_db -c "SELECT version();"`
- [ ] Backup current database (if has data)
- [ ] Review current schema vs. EF models
- [ ] List current tables: `SELECT table_name FROM information_schema.tables WHERE table_schema='public';`

### Migration Execution

- [ ] Run Liquibase migrations:
  ```bash
  liquibase --changeLogFile=001-initial-schema.xml update
  liquibase --changeLogFile=002-create-indexes.xml update
  liquibase --changeLogFile=003-create-chatbot-tables.xml update
  ```
  OR via .NET:
  ```powershell
  dotnet ef database update
  ```

### Post-Migration Validation

- [ ] Verify all portal tables exist:
  ```sql
  SELECT table_name FROM information_schema.tables 
  WHERE table_schema='public' AND table_name IN (
    'users', 'garages', 'vehicles', 'vehicle_issues', 
    'diagnostic_rules', 'image_diagnostics', 'service_histories', 'garage_services'
  );
  ```

- [ ] Verify all chatbot tables exist:
  ```sql
  SELECT table_name FROM information_schema.tables 
  WHERE table_schema='public' AND table_name IN (
    'chatbot_conversations', 'chatbot_messages', 'chatbot_knowledge_base',
    'ai_image_analyses', 'ai_usage_logs'
  );
  ```

- [ ] Verify soft-delete columns on each table:
  ```sql
  SELECT column_name FROM information_schema.columns 
  WHERE table_name='users' AND column_name IN ('DeletedAt', 'IsDeleted');
  ```

- [ ] Verify audit columns:
  ```sql
  SELECT column_name FROM information_schema.columns 
  WHERE table_name='users' AND column_name IN (
    'CreatedAt', 'UpdatedAt', 'CreatedBy', 'UpdatedBy', 'DeletedBy'
  );
  ```

- [ ] Verify indexes created:
  ```sql
  SELECT indexname FROM pg_indexes WHERE schemaname='public' LIMIT 30;
  ```
  (Should return 30+ indexes)

- [ ] Test EF Core connectivity:
  ```powershell
  cd app/server/API
  dotnet ef dbcontext info
  ```
  Expected: `Provider name: Npgsql.EntityFrameworkCore.PostgreSQL`

### API Endpoint Testing

- [ ] Build API: `dotnet build` (0 errors)
- [ ] Run API: `dotnet run` (should start without errors)
- [ ] Test endpoint: `GET http://localhost:5100/api/v1/users`
  - [ ] Expected: HTTP 200 (not 500)
  - [ ] Expected: Empty array `[]` (no data yet)
  - [ ] Expected: No database errors in logs

## 📊 Progress Notes

**Status:** ⏳ TODO  
**Started:** Not yet  
**Completed:** N/A  
**Time Spent:** N/A  
**Blockers:** PostgreSQL must be running  
**Related Branch:** feature/4-database-schema-alignment  

**Retry Count (if failed):** 0/3  
**Last Retry:** N/A  

---

## 🔧 Implementation Steps

### Option A: Using Liquibase (Recommended)

1. **Install Liquibase** (if not installed):
   ```bash
   # Via Chocolatey (Windows)
   choco install liquibase
   
   # Or download from: https://www.liquibase.org/get-started/quickstart
   ```

2. **Verify Liquibase:
   ```bash
   liquibase --version
   ```

3. **Configure Liquibase properties** (`app/server/API/liquibase/liquibase.properties`):
   ```
   url=jdbc:postgresql://localhost:5433/vehicle_service_db
   username=postgres
   password=your-postgres-password
   driver=org.postgresql.Driver
   ```

4. **Run migrations in order:**
   ```bash
   cd app/server/API/liquibase
   
   liquibase --changeLogFile=001-initial-schema.xml update
   liquibase --changeLogFile=002-create-indexes.xml update
   liquibase --changeLogFile=003-create-chatbot-tables.xml update
   ```

5. **Verify status:**
   ```bash
   liquibase status
   ```

### Option B: Using EF Core Migrations

1. **Navigate to API project:**
   ```powershell
   cd app/server/API
   ```

2. **Apply all pending migrations:**
   ```powershell
   dotnet ef database update
   ```

3. **Verify by listing migrations:**
   ```powershell
   dotnet ef migrations list
   ```

### Option C: Manual SQL (Last Resort)

If migrations fail, review and manually run SQL from migration files in this order:
1. `001-initial-schema.xml` → Create all tables
2. `002-create-indexes.xml` → Add indexes
3. `003-create-chatbot-tables.xml` → Add chatbot tables

## 🎓 Reference Documentation

- Entity Framework Core: [app/server/Domain/Entities/](../../../../app/server/Domain/Entities/)
- Liquibase Migrations: [app/server/API/liquibase/](../../../../app/server/API/liquibase/)
- Database Design: [docs/03-phase-specific/phase-3-database-liquibase/](../phase-3-database-liquibase/)
- EF DbContext: [Infrastructure/Persistence/AppDbContext.cs](../../../../app/server/Infrastructure/Persistence/AppDbContext.cs)

## 🔗 Related Tasks

- Task 001: Git Branching
- Task 004: NuGet Package Validation (should be done in parallel)
- Task 005: Local Development Environment Verification
- Task 101: User Service - CRUD Base Layer (depends on this)

## 🚀 Next Steps After Completion

Once this task is complete:

1. Move to **Task 004: NuGet Package Validation**
2. Then **Task 005: Local Development Environment Verification**
3. Then begin **Task 101: User Service - CRUD Base Layer**

## ⚠️ Troubleshooting

**Problem:** Database connection fails with authentication error
```
password authentication failed for user "postgres"
```
**Solution:**
- Verify PostgreSQL running: `psql -U postgres`
- Check connection string in appsettings
- Verify port (should be 5433, not 5432)
- Reset PostgreSQL password if needed

**Problem:** Liquibase can't find driver
```
Error: Could not create liquibase.database.Database instance
```
**Solution:**
- Verify driver JAR in Liquibase lib folder
- Or use EF Core migrations instead

**Problem:** Table already exists error
```
ERROR: relation "users" already exists
```
**Solution:**
- Drop database and recreate: `DROP DATABASE vehicle_service_db;`
- Then rerun migrations from scratch
- OR use Liquibase rollback first
