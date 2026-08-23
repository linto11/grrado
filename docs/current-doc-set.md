# GRRADO Current Doc Set

**Purpose:** reduce confusion by making it clear which docs are current, which docs are reference-only, and where to start before implementation work.

**Last Updated:** April 17, 2026

---

## Source Of Truth

Use these files first when deciding what to build or how to work in the repo:

1. `README.md`
   Repo-level overview and the fastest path to the backend solution.
2. `docs/00-getting-started/01-project-overview.md`
   Current product and implementation overview aligned to the repo.
3. `docs/00-getting-started/02-folder-structure.md`
   Accurate repo and docs map.
4. `docs/02-progress-tracking/current-status.md`
   Best short summary of where the implementation stands right now.
5. `docs/02-progress-tracking/progress-tracker.md`
   Working backlog and remaining Phase 4 scope.
6. `docs/how-to-run-and-test-api.md`
   Runtime and API testing guide.
7. `.vscode/rules/rulebook.md`
   Mandatory coding and structure rules.

If one of these documents conflicts with an older planning document, prefer the file above and then verify against the codebase.

---

## Reference Only

These docs are still useful, but they should not be treated as the live implementation source of truth:

- `docs/implementation-plan.md`
  High-level roadmap and historical planning context. Some sections predate the microservices migration.
- `docs/03-phase-specific/phase-3-database-liquibase/*`
  Historical database planning and migration notes. Useful for context, but the current repo still needs a single clarified database migration strategy.
- `D:\_GRRADO\docs\*.docx`
  Product and business background from the workspace root. Good for vision and scope, not for current implementation status.

---

## Current Reality Snapshot

These are the current project signals that matter most:

- Active code repo: `D:\_GRRADO\src`
- Active backend solution: `D:\_GRRADO\src\app\server\GRRADO.Microservices.sln`
- Architecture in code: 7 microservices + YARP gateway + 4 shared libraries
- Current phase: Phase 4 backend stabilization and completion
- Build status verified on April 17, 2026: solution builds with 0 errors and 2 warnings
- Validation work is already in progress in code
- Event consumer scaffolding is already present in code
- Auth, tests, and database migration strategy still need closure

---

## Working Reading Order

For anyone joining the project or resuming work:

1. `README.md`
2. `docs/current-doc-set.md`
3. `docs/00-getting-started/01-project-overview.md`
4. `docs/00-getting-started/02-folder-structure.md`
5. `docs/02-progress-tracking/current-status.md`
6. `docs/02-progress-tracking/progress-tracker.md`
7. `.vscode/rules/rulebook.md`
8. `docs/how-to-run-and-test-api.md`

Only after that, open older planning docs if you need extra context.

---

## Documentation Rules Going Forward

- Update `docs/02-progress-tracking/current-status.md` when implementation reality changes.
- Update `docs/02-progress-tracking/progress-tracker.md` when scope or sequencing changes.
- Keep `docs/implementation-plan.md` as roadmap/reference unless we explicitly decide to fully rewrite it.
- Do not use root-level product `.docx` files as implementation instructions.
- When docs and code disagree, verify the code and then update the current docs.
