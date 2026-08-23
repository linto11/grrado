# Folder Structure

**Purpose:** show the current repo layout without stale paths or old phase assumptions.  
**Last Updated:** April 17, 2026

---

## Workspace Layout

The broader workspace has three main areas:

```text
D:\_GRRADO\
├── docs\        # Product/business background documents (.docx)
├── Keycloak\    # Local Keycloak notes
└── src\         # Active code repository and active docs
```

Important rule:

- treat `D:\_GRRADO\src` as the real implementation repo
- treat `D:\_GRRADO\docs` as business/reference material, not live implementation instructions

---

## Active Repository Layout

```text
D:\_GRRADO\src\
├── app\
│   └── server\
│       ├── AppHost\
│       ├── gateway\
│       │   └── ApiGateway\
│       ├── services\
│       │   ├── ChatbotService\
│       │   ├── DiagnosticsService\
│       │   ├── GarageService\
│       │   ├── LoggingService\
│       │   ├── ServiceHistoryService\
│       │   ├── UserService\
│       │   └── VehicleService\
│       ├── shared\
│       │   ├── GRRADO.Shared.Abstractions\
│       │   ├── GRRADO.Shared.Application\
│       │   ├── GRRADO.Shared.Domain\
│       │   └── GRRADO.Shared.Infrastructure\
│       ├── GRRADO.Microservices.sln
│       ├── run-services.ps1
│       └── test-apis.ps1
├── docs\
├── docker-compose.yml
├── docker-compose.services.yml
├── init-databases.sql
├── README.md
└── .vscode\
```

---

## Documentation Layout

Inside `D:\_GRRADO\src\docs`:

```text
docs\
├── README.md
├── current-doc-set.md
├── how-to-run-and-test-api.md
├── implementation-plan.md
├── 00-getting-started\
├── 01-requirements\
├── 02-progress-tracking\
├── 03-phase-specific\
├── 04-deployment-guides\
├── 05-validation-system\
└── 06-changelogs\
```

How to interpret these folders:

- `00-getting-started/`
  current onboarding docs
- `01-requirements/`
  scope and requirements reference
- `02-progress-tracking/`
  current status and active backlog
- `03-phase-specific/`
  detailed phase notes, mostly reference material
- `04-deployment-guides/`
  specialized implementation/deployment notes
- `05-validation-system/`
  validation/error message reference
- `06-changelogs/`
  historical changelog entries

---

## Backend Structure

The active backend lives in `app/server`.

### Gateway

- `app/server/gateway/ApiGateway`
  public routing layer for service traffic

### Services

Each service follows the same 4-layer pattern:

```text
XxxService\
├── XxxService.API\
├── XxxService.Application\
├── XxxService.Domain\
└── XxxService.Infrastructure\
```

### Shared Projects

Cross-cutting code lives in:

- `app/server/shared/GRRADO.Shared.Domain`
- `app/server/shared/GRRADO.Shared.Abstractions`
- `app/server/shared/GRRADO.Shared.Application`
- `app/server/shared/GRRADO.Shared.Infrastructure`

### Orchestration

- `app/server/AppHost`
  local orchestration and debugging entry point

---

## Most Important Files

For day-to-day work, these are the files people should actually open first:

- `README.md`
- `docs/current-doc-set.md`
- `docs/00-getting-started/01-project-overview.md`
- `docs/02-progress-tracking/current-status.md`
- `docs/02-progress-tracking/progress-tracker.md`
- `docs/how-to-run-and-test-api.md`
- `.vscode/rules/rulebook.md`

---

## Avoid These Assumptions

Do not assume the following older structures are still current:

- monolith-era backend layout
- Node/React/Vue folder layouts from older planning docs
- Liquibase-only database ownership without checking current code and status docs
- missing uppercase file names referenced in older docs such as `PROGRESS-TRACKER.md` or `01-ALL-REQUIREMENTS.md`

When in doubt, trust the current repo structure and then update the docs to match it.
