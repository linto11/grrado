# Liquibase Baseline

This folder is the starting point for the database-first workflow in the microservices solution.

## Structure

- `user-service/`
- `vehicle-service/`
- `garage-service/`
- `service-history-service/`
- `chatbot-service/`
- `diagnostics-service/`
- `logging-service/`

Each service folder contains:

- `master-changelog.xml`
- `changelogs/001-baseline.sql`

## What These Files Are

The `001-baseline.sql` files were bootstrapped from the current EF Core model using `dotnet ef dbcontext script`.

That gives us a practical baseline without hand-writing the schema for all 7 service databases from scratch.

## Rule Going Forward

- Liquibase owns schema changes
- EF Core migrations are not part of the long-term workflow
- Future schema changes should be added as new Liquibase changelog files
- Do not regenerate the baseline once a database has started taking Liquibase changes in real use

## Local Example

Run Liquibase per service database, for example:

```powershell
liquibase `
  --url="jdbc:postgresql://localhost:5433/grrado_user_db" `
  --username=postgres `
  --password=postgres `
  --changeLogFile="D:/_GRRADO/src/app/server/database/liquibase/user-service/master-changelog.xml" `
  update
```

## Important Note

These baseline files should be treated as the bridge from the current code-first state into a database-first Liquibase workflow.

Before first real deployment with Liquibase, we should still review the generated SQL per service and confirm naming, constraints, indexes, and delete behaviors against the intended production model.
