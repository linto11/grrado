# Quick Start

**Purpose:** very short entry point only.  
**Canonical runtime instructions:** [how-to-run-and-test-api.md](how-to-run-and-test-api.md)

---

## 30 Seconds

```powershell
cd D:\_GRRADO\src
docker compose -f D:\_GRRADO\src\docker-compose.yml up -d

cd D:\_GRRADO\src\app\server
dotnet build GRRADO.Microservices.sln
dotnet run --project services/UserService/UserService.API/UserService.API.csproj
```

Open:

```text
http://localhost:5101/scalar/v1
```

For the full runtime guide, testing options, gateway usage, and troubleshooting:

- [how-to-run-and-test-api.md](how-to-run-and-test-api.md)
