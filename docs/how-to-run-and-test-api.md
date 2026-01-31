# How to Run & Test the GRRADO Vehicle Service Portal API

**Project Status:** ✅ Phase 4 REST API Layer COMPLETE  
**Last Updated:** January 25, 2026  
**Build Status:** ✅ 0 Errors, 2 Warnings (non-critical Swashbuckle version)

---

## Quick Start (5 Minutes)

### 1. Prerequisites Check
```powershell
# Check .NET version (should be 8.0+)
dotnet --version

# Check SQL Server (create test database or use LocalDB)
# You should have a database named GRRADO_DB or similar
```

### 2. Build the Project
```powershell
cd d:\_GRRADO\src\server\API
dotnet build
```

**Expected Output:**
```
Build succeeded.
2 Warning(s)
0 Error(s)
```

### 3. Run the API
```powershell
dotnet run
```

**Expected Output:**
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started
```

### 4. Access Swagger UI
Open browser: **http://localhost:5000/swagger/index.html**

---

## Available Endpoints (13 Controllers)

### Portal API Endpoints (Base URL: `http://localhost:5000/api/v1`)

#### Users Management
```
GET    /users              - List all users (paginated)
POST   /users              - Create new user
GET    /users/{id}         - Get user by ID
PUT    /users/{id}         - Update user
DELETE /users/{id}         - Delete user (soft-delete)
```

#### Garage Management
```
GET    /garages            - List all garages
POST   /garages            - Create new garage
GET    /garages/{id}       - Get garage by ID
PUT    /garages/{id}       - Update garage
DELETE /garages/{id}       - Delete garage
```

#### Vehicle Management
```
GET    /vehicles           - List all vehicles
POST   /vehicles           - Create new vehicle
GET    /vehicles/{id}      - Get vehicle by ID
PUT    /vehicles/{id}      - Update vehicle
DELETE /vehicles/{id}      - Delete vehicle
```

#### Vehicle Issues
```
GET    /vehicle-issues     - List all issues
POST   /vehicle-issues     - Create new issue
GET    /vehicle-issues/{id} - Get issue by ID
PUT    /vehicle-issues/{id} - Update issue
DELETE /vehicle-issues/{id} - Delete issue
```

#### Diagnostic Rules
```
GET    /diagnostic-rules   - List all rules
POST   /diagnostic-rules   - Create new rule
GET    /diagnostic-rules/{id} - Get rule by ID
PUT    /diagnostic-rules/{id} - Update rule
DELETE /diagnostic-rules/{id} - Delete rule
```

#### Image Diagnostics
```
GET    /image-diagnostics  - List all diagnostics
POST   /image-diagnostics  - Create new diagnostic
GET    /image-diagnostics/{id} - Get diagnostic by ID
PUT    /image-diagnostics/{id} - Update diagnostic
DELETE /image-diagnostics/{id} - Delete diagnostic
```

#### Service Histories
```
GET    /service-histories  - List all histories
POST   /service-histories  - Create new history
GET    /service-histories/{id} - Get history by ID
PUT    /service-histories/{id} - Update history
DELETE /service-histories/{id} - Delete history
```

#### Garage Services
```
GET    /garage-services    - List all garage services
POST   /garage-services    - Create new garage service
GET    /garage-services/{id} - Get garage service by ID
PUT    /garage-services/{id} - Update garage service
DELETE /garage-services/{id} - Delete garage service
```

### Chatbot API Endpoints (Base URL: `http://localhost:5000/api/v1/chatbot`)

#### Conversations
```
GET    /conversations      - List all conversations
POST   /conversations      - Create new conversation
GET    /conversations/{id} - Get conversation by ID
PUT    /conversations/{id} - Update conversation
DELETE /conversations/{id} - Delete conversation
```

#### Messages
```
GET    /messages           - List all messages
POST   /messages           - Create new message
GET    /messages/{id}      - Get message by ID
PUT    /messages/{id}      - Update message
DELETE /messages/{id}      - Delete message
```

#### Knowledge Base
```
GET    /knowledge-base     - List all KB items
POST   /knowledge-base     - Create new KB item
GET    /knowledge-base/{id} - Get KB item by ID
PUT    /knowledge-base/{id} - Update KB item
DELETE /knowledge-base/{id} - Delete KB item
```

#### Image Analyses
```
GET    /image-analyses     - List all analyses
POST   /image-analyses     - Create new analysis
GET    /image-analyses/{id} - Get analysis by ID
PUT    /image-analyses/{id} - Update analysis
DELETE /image-analyses/{id} - Delete analysis
```

#### Usage Logs
```
GET    /usage-logs         - List all logs
POST   /usage-logs         - Create new log
GET    /usage-logs/{id}    - Get log by ID
PUT    /usage-logs/{id}    - Update log
DELETE /usage-logs/{id}    - Delete log
```

---

## Testing Methods

### Method 1: Swagger UI (Recommended - No Setup Required)

1. **Start the API:**
   ```powershell
   dotnet run
   ```

2. **Open Swagger:** http://localhost:5000/swagger/index.html

3. **Test an Endpoint:**
   - Click on any endpoint (e.g., `GET /api/v1/users`)
   - Click "Try it out" button
   - Click "Execute"
   - See response in "Response body" section

**Example Response:**
```json
{
  "success": true,
  "statusCode": 200,
  "message": "Operation successful",
  "data": [
    {
      "id": "123e4567-e89b-12d3-a456-426614174000",
      "firstName": "John",
      "lastName": "Doe",
      "email": "john@example.com",
      "role": "customer"
    }
  ],
  "errors": []
}
```

---

### Method 2: Using REST Client File (VSCode)

1. **Install Extension:** REST Client by Huachao Mao

2. **Open file:** [API.http](../../server/API/API.http)

3. **Click "Send Request"** above any request

**Example Request in API.http:**
```http
### Get all users
GET http://localhost:5000/api/v1/users?pageNumber=1&pageSize=10 HTTP/1.1
Accept: application/json
```

---

### Method 3: Using PowerShell/cURL

```powershell
# Get all users
curl -X GET "http://localhost:5000/api/v1/users" `
  -H "accept: application/json"

# Create a new user
curl -X POST "http://localhost:5000/api/v1/users" `
  -H "Content-Type: application/json" `
  -d '{
    "firstName": "Jane",
    "lastName": "Smith",
    "email": "jane@example.com",
    "role": "customer"
  }'

# Get specific user
curl -X GET "http://localhost:5000/api/v1/users/123e4567-e89b-12d3-a456-426614174000" `
  -H "accept: application/json"

# Update user
curl -X PUT "http://localhost:5000/api/v1/users/123e4567-e89b-12d3-a456-426614174000" `
  -H "Content-Type: application/json" `
  -d '{
    "firstName": "Jane",
    "lastName": "Doe",
    "email": "jane.doe@example.com"
  }'

# Delete user
curl -X DELETE "http://localhost:5000/api/v1/users/123e4567-e89b-12d3-a456-426614174000"
```

---

### Method 4: Using Postman

1. **Import OpenAPI Spec:**
   - Open Postman
   - Click "Import"
   - Enter URL: `http://localhost:5000/swagger/v1/swagger.json`
   - Click "Continue"

2. **Test Endpoints:**
   - All endpoints imported as collection
   - Modify parameters as needed
   - Click "Send"

---

## Sample API Requests

### Create a User
```http
POST http://localhost:5000/api/v1/users
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john@example.com",
  "phone": "555-1234",
  "role": "customer"
}
```

**Response:**
```json
{
  "success": true,
  "statusCode": 201,
  "message": "User created successfully",
  "data": {
    "id": "123e4567-e89b-12d3-a456-426614174000",
    "firstName": "John",
    "lastName": "Doe",
    "email": "john@example.com",
    "phone": "555-1234",
    "role": "customer"
  }
}
```

### Create a Garage
```http
POST http://localhost:5000/api/v1/garages
Content-Type: application/json

{
  "name": "Downtown Auto Repair",
  "city": "New York",
  "phone": "555-5678",
  "email": "info@downtown.com"
}
```

### Create a Chatbot Conversation
```http
POST http://localhost:5000/api/v1/chatbot/conversations
Content-Type: application/json

{
  "userId": "123e4567-e89b-12d3-a456-426614174000",
  "title": "Engine Diagnosis",
  "mode": "text"
}
```

### Add Message to Conversation
```http
POST http://localhost:5000/api/v1/chatbot/messages
Content-Type: application/json

{
  "conversationId": "456e7890-f12c-34e5-b678-539725285111",
  "content": "My engine is making a knocking sound",
  "role": "user"
}
```

---

## API Response Format

All endpoints follow this standard response format:

```json
{
  "success": true,                    // Operation success
  "statusCode": 200,                  // HTTP status code
  "message": "Operation successful",  // Human-readable message
  "data": {},                         // Response data (varies by endpoint)
  "errors": []                        // Validation errors (if any)
}
```

### Error Response Example
```json
{
  "success": false,
  "statusCode": 400,
  "message": "Validation failed",
  "data": null,
  "errors": [
    "Email is required",
    "Phone must be valid format"
  ]
}
```

---

## Query Parameters

### Pagination (All List Endpoints)
```
?pageNumber=1&pageSize=10
```

**Example:**
```
GET http://localhost:5000/api/v1/users?pageNumber=1&pageSize=25
```

### Search/Filter (Future Enhancement)
```
?search=John&sortBy=createdAt&sortOrder=desc
```

---

## HTTP Status Codes

| Code | Meaning | Example |
|------|---------|---------|
| 200 | Success | GET, PUT request succeeded |
| 201 | Created | POST request created resource |
| 204 | No Content | DELETE succeeded |
| 400 | Bad Request | Validation failed |
| 404 | Not Found | Resource not found |
| 500 | Server Error | Unexpected error |

---

## Logs & Debugging

### Log Files Location
```
d:\_GRRADO\src\server\API\logs\
```

### Log Levels
- **Debug:** Detailed diagnostic information
- **Information:** General operation info
- **Warning:** Something unexpected
- **Error:** Error occurred but app continues
- **Fatal:** Error occurred, app may fail

### View Real-time Logs
When running with `dotnet run`, logs appear in console:
```
info: GRRADO.API.Program[0]
      Starting application...
info: GRRADO.API.Middleware.CorrelationIdMiddleware[0]
      Processing request: correlation-id-abc123
```

---

## Troubleshooting

### Port 5000 Already in Use
```powershell
# Find what's using port 5000
netstat -ano | findstr :5000

# Kill the process
taskkill /PID <PID> /F

# Or run on different port
dotnet run --urls="http://localhost:5001"
```

### Database Connection Failed
- Check if SQL Server is running
- Verify connection string in [appsettings.Development.json](../../server/API/appsettings.Development.json)
- Ensure database exists (GRRADO_DB)
- Run migrations: `dotnet ef database update`

### Swagger UI Not Loading
- Clear browser cache (Ctrl+Shift+Delete)
- Try incognito window
- Check API is running: `http://localhost:5000/health`

### Build Fails with NuGet Errors
```powershell
# Clear NuGet cache
dotnet nuget locals all --clear

# Restore packages
dotnet restore

# Build again
dotnet build
```

---

## Project Structure

```
app/server/
├── API/
│   ├── Controllers/           # 13 REST controllers
│   │   ├── UsersController.cs
│   │   ├── GaragesController.cs
│   │   ├── VehiclesController.cs
│   │   ├── ... (8 portal controllers)
│   │   └── Chatbot/           # 5 chatbot controllers
│   ├── Program.cs             # Startup configuration
│   ├── API.http               # REST client examples
│   └── Configuration/         # Swagger setup
│
├── Application/
│   ├── Services/              # 13 business logic services
│   ├── Mapping/               # AutoMapper profiles
│   └── DTOs/                  # All request/response objects
│
├── Domain/
│   ├── Entities/              # 13 entity classes
│   └── Abstractions/          # IEntity interface
│
└── Infrastructure/
    ├── Persistance/           # Database & Unit of Work
    ├── Services/              # Service implementations
    └── DependencyInjection.cs # Registration
```

---

## Next Steps

### Phase 5: Role-Based Access & Permissions
- Add `[Authorize]` attributes to all endpoints
- Implement role validation (Super Admin, App Admin, Garage Admin, User)
- Add permission-based access control

### Phase 6: Content Management System
- Extend API with CMS controllers
- Add media upload handling
- Implement template management

### Phase 7: AI Chatbot Integration
- Connect to Azure OpenAI API
- Implement conversation logic
- Add voice & image processing

---

## Support & Documentation

- **API Documentation:** http://localhost:5000/swagger/index.html
- **Project Docs:** [GRRADO Documentation](../README.md)
- **Phase 4 Summary:** [REST API Completion](../03-phase-specific/phase-4-backend-api/03-rest-api-completion-summary.md)
- **Implementation Plan:** [implementation-plan.md](../implementation-plan.md)
- **Rulebook:** [rulebook.md](../../.vscode/rulebook.md)

---

## Performance Notes

### Pagination
- Default page size: 10
- Recommended page size: 25-50
- Maximum page size: 100 (enforced)

### Database Queries
- All queries optimized with soft-delete filtering
- Includes `.AsNoTracking()` for read-only operations
- Composite indexes on frequently queried columns

### Caching (Future Phase)
- Response caching configured
- Redis cache available (not yet integrated)
- Static cache for diagnostic rules (120-second TTL)

---

**Created:** January 25, 2026  
**Updated:** January 25, 2026 - 10:30 AM  
**Build Status:** ✅ Successful (0 errors, 2 non-critical warnings)  
**API Ready:** ✅ Production Ready for Testing

