# Design Decisions

Choices made where the GearShare spec left room. One entry per decision: what was chosen, what else was considered, and why.

| # | Date | Decision | Alternatives | Why |
| --- | --- | --- | --- | --- |
| 1 | 2026-10-18 | Use controllers for the API | Minimal APIs | Controllers are still common in existing .NET codebases, and grouping endpoints by resource keeps 32 routes easy to navigate. |
| 2 | 2026-10-18 | Split the solution into `src/` and `tests/` with Api, Application, and Infrastructure projects | Single project | Keeps business rules free of web and database code so they can be unit tested on their own. References only point inward toward Application. |
| 3 | 2026-10-18 | PostgreSQL for the database | SQL Server, SQLite | Supports exclusion constraints on date ranges, which lets the database itself block overlapping reservations. Runs easily in Docker. |

## Open questions

Decisions still to make. Move each one into the table once settled.

- Token auth (JWT) or cookie auth?
- Out-of-range page size: return 400 or clamp to the limit?
- Should search for "cafe" match "café"?
- Built-in `BackgroundService` or Quartz.NET for scheduled jobs?
