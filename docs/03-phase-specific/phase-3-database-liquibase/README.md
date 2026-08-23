# Phase 3 Database Docs

**Status:** historical/reference material  
**Last Updated:** April 17, 2026

---

## Important Caution

This folder documents the original Phase 3 database plan, which was centered on a database-first Liquibase workflow.

Use these docs for background and prior reasoning, not as the live implementation source of truth.

Why this matters:

- the current codebase and later status docs indicate schema creation/runtime behavior has evolved beyond the original Phase 3 plan
- the repo still needs one clearly agreed database migration/source-of-truth strategy
- until that decision is formalized, do not assume Liquibase alone reflects the live backend state

---

## What This Folder Is Still Good For

- understanding the original relational model
- understanding the intended seed-data approach
- reviewing the historical database-first design direction
- recovering earlier migration ideas if we decide to formalize a migration strategy later

---

## What To Use First Instead

Before using these docs, read:

1. `../../current-doc-set.md`
2. `../../00-getting-started/01-project-overview.md`
3. `../../02-progress-tracking/current-status.md`
4. `../../02-progress-tracking/progress-tracker.md`

Then use this folder only if you need older design context.

---

## Files In This Folder

- `phase-03-liquibase-starter.md`
  historical quick-start for the original Liquibase approach
- `phase-03-liquibase-implementation.md`
  historical technical details of that same approach

---

## Recommended Next Step

If we want to fully remove database ambiguity, create one current canonical database strategy document later that answers:

- what owns schema changes
- how local databases should be created
- how migrations are applied
- how schema drift is detected
- how seed data should be handled in development
