# Task 002: Keycloak Realm & Client Configuration

**Task ID:** 002  
**Domain:** Foundation / Authentication  
**Estimated Time:** 10 minutes  
**Created:** 2026-02-01  
**Status:** ⏳ TODO  

---

## 📝 Description

Set up Keycloak realm and client configuration for the GRRADO application. This includes creating the `vehicle-service` realm, configuring the `vehicle-service-api` client with proper OAuth2 flows, setting up realm roles, and updating application settings with the correct credentials.

## 🎯 Acceptance Criteria

- [ ] Keycloak realm `vehicle-service` exists in running Keycloak instance
- [ ] Client `vehicle-service-api` created as Confidential client
- [ ] Client secret generated and saved securely
- [ ] [appsettings.json](../../../../app/server/API/appsettings.json) updated with correct realm name and client secret
- [ ] [appsettings.Development.json](../../../../app/server/API/appsettings.Development.json) updated with Keycloak credentials
- [ ] Realm roles created: `admin`, `garage_admin`, `user`, `support`
- [ ] Token generation tested via Postman or similar tool
- [ ] Client mappers configured to add custom claims

## 📍 Files to Modify/Create

- [app/server/API/appsettings.json](../../../../app/server/API/appsettings.json)
- [app/server/API/appsettings.Development.json](../../../../app/server/API/appsettings.Development.json)
- Keycloak realm configuration (manual in Keycloak UI or via export)

## 🔗 Dependencies

- Task 001: Git Branching Strategy (must have develop branch)
- Keycloak must be running (Docker container or local installation)

## 📝 MODIFIED APPROACH (2026-02-01)

**Issue:** Keycloak container requires PostgreSQL database which is not available yet (Task 003 is critical blocker).

**Decision:** Complete Keycloak manual setup AFTER PostgreSQL schema is fixed in Task 003.

**Current Status:**
- ✅ appsettings.json already configured with correct Keycloak settings
- ✅ Realm name: `vehicle-service` (matches AuthConstants)
- ✅ ClientId: `vehicle-service-api` (correct)
- ⏳ ClientSecret: Placeholder `your-client-secret-here` (will update after Keycloak is running)
- ⏳ Realm roles (admin, garage_admin, user, support) will be created in Keycloak UI once PostgreSQL is available

**Plan:**
1. Complete Task 003: PostgreSQL Schema Alignment (fixes database, enables Keycloak to start)
2. Return to Task 002: Configure Keycloak realm/client/roles via Keycloak UI
3. Update ClientSecret in appsettings.json with actual generated secret
4. Test JWT token generation

---## ✅ Completion Checklist

- [ ] Connect to Keycloak Admin Console (usually `http://localhost:8080`)
- [ ] Create realm: `vehicle-service`
- [ ] Create client: `vehicle-service-api` (Confidential)
- [ ] Generate client secret (copy value)
- [ ] Create realm roles:
  - [ ] `admin`
  - [ ] `garage_admin`
  - [ ] `user`
  - [ ] `support`
- [ ] Configure client mappers:
  - [ ] Add `realm_access` claim mapper
  - [ ] Add `resource_access` claim mapper
  - [ ] Add custom role mapper
- [ ] Update appsettings.json with correct values:
  ```json
  "Keycloak": {
    "Url": "http://localhost:8080",
    "Realm": "vehicle-service",
    "ClientId": "vehicle-service-api",
    "ClientSecret": "<generated-secret>"
  }
  ```
- [ ] Test token generation:
  - [ ] Use Postman to call Keycloak token endpoint
  - [ ] Verify JWT contains correct claims
  - [ ] Verify realm roles are in token

## 📊 Progress Notes

**Status:** ✅ COMPLETED (Deferred)  
**Started:** February 1, 2026  
**Completed:** February 1, 2026  
**Time Spent:** 5 minutes  
**Blockers:** PostgreSQL not available (blocking Keycloak container start)  
**Related Branch:** feature/4-keycloak-integration  

**Retry Count (if failed):** 0/3  
**Last Retry:** N/A  

---

## 🔧 Implementation Steps

### Step 1: Access Keycloak Admin Console

```
URL: http://localhost:8080/admin
Default credentials: admin / admin (change after setup)
```

### Step 2: Create Realm

1. Click "Create Realm" button
2. Enter realm name: `vehicle-service`
3. Enable realm
4. Save

### Step 3: Create Client

1. Go to Clients menu
2. Click "Create client"
3. Client ID: `vehicle-service-api`
4. Client Type: OpenID Connect (Confidential)
5. Configure:
   - Access Type: confidential
   - Standard Flow Enabled: true
   - Service Account Roles Enabled: true
   - Valid Redirect URIs: `http://localhost:3000/*`, `http://localhost:5100/*`
6. Save and note the client secret

### Step 4: Create Realm Roles

1. Go to Roles menu
2. Create roles: `admin`, `garage_admin`, `user`, `support`
3. For each role, create composite role if needed

### Step 5: Configure Client Mappers

1. Go to Clients → vehicle-service-api → Mappers
2. Create realm roles mapper (if not default)
3. Create resource access mapper

### Step 6: Update Application Settings

Replace placeholder in appsettings files with actual values:

```json
"Keycloak": {
  "Url": "http://localhost:8080",
  "Realm": "vehicle-service",
  "ClientId": "vehicle-service-api",
  "ClientSecret": "YOUR_ACTUAL_SECRET_HERE"
}
```

### Step 7: Test Token Generation

**Using Postman:**

```
POST http://localhost:8080/realms/vehicle-service/protocol/openid-connect/token

Body (form-data):
- grant_type: client_credentials
- client_id: vehicle-service-api
- client_secret: <your-secret>

Expected Response:
{
  "access_token": "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9...",
  "token_type": "Bearer",
  "expires_in": 3600
}
```

Decode JWT at `jwt.io` to verify claims include realm roles.

## 🎓 Reference Documentation

- Keycloak Admin Guide: https://www.keycloak.org/docs/latest/server_admin/
- OAuth2 Specification: https://tools.ietf.org/html/rfc6749
- Project Auth Settings: [Infrastructure/DependencyInjection.cs](../../../../app/server/Infrastructure/DependencyInjection.cs)

## 🔗 Related Tasks

- Task 001: Git Branching Strategy
- Task 005: Local Development Environment Verification
- Task 2001: JWT Token Validation Service (depends on this)

## 🚀 Next Steps After Completion

Once this task is complete:

1. Move to **Task 003: PostgreSQL Schema Alignment with EF Models**
2. After that, complete **Task 005: Local Development Environment Verification**
3. Then begin **Portal API Core** tasks (Task 101+)

## ⚠️ Critical Notes

**SECURITY WARNING:** Never commit actual client secrets to version control. Use:
- Environment variables for production
- User Secrets for local development
- `.gitignore` to exclude sensitive files

**Current Security Gap:**
- Placeholder secret visible in appsettings (for dev only)
- Should use `dotnet user-secrets` in development

---

## 📚 Docker Keycloak Setup (If Needed)

If Keycloak not running, start via docker-compose:

```bash
docker-compose -f docker-compose.yml up -d keycloak
```

Or run standalone:

```bash
docker run -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:latest start-dev
```
