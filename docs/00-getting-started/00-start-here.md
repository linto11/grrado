# Start Here

**Purpose:** orient anyone resuming work on GRRADO without sending them through stale planning paths.  
**Last Updated:** April 17, 2026

---

## First Five Minutes

Read these files in order:

1. [../../README.md](../../README.md)
2. [../current-doc-set.md](../current-doc-set.md)
3. [01-project-overview.md](01-project-overview.md)
4. [02-folder-structure.md](02-folder-structure.md)
5. [../02-progress-tracking/current-status.md](../02-progress-tracking/current-status.md)
6. [../02-progress-tracking/progress-tracker.md](../02-progress-tracking/progress-tracker.md)
7. [../../.vscode/rules/rulebook.md](../../.vscode/rules/rulebook.md)

That gives you the repo overview, current reality, remaining work, and the mandatory engineering rules.

---

## What To Trust

For live implementation decisions:

- Trust `current-status.md` for the short summary
- Trust `progress-tracker.md` for active scope and sequencing
- Trust the codebase over older planning docs if there is any mismatch

For historical context only:

- `implementation-plan.md`
- older phase planning docs
- root-level product `.docx` files in `D:\_GRRADO\docs`

---

## Current Project Reality

- Active repo: `D:\_GRRADO\src`
- Active backend solution: `app/server/GRRADO.Microservices.sln`
- Architecture: 7 microservices + YARP gateway + 4 shared libraries
- Current phase: Phase 4 backend completion and stabilization
- Build status verified on April 17, 2026: builds with 0 errors and 2 warnings

---

## When You Need More Detail

- Runtime and API testing: [../how-to-run-and-test-api.md](../how-to-run-and-test-api.md)
- Requirements and scope: [../01-requirements/](../01-requirements/)
- Phase-specific context: [../03-phase-specific/](../03-phase-specific/)
- Workspace-wide doc map: [../README.md](../README.md)
