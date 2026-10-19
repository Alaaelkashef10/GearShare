# GearShare

GearShare is an equipment lending API built with ASP.NET Core and PostgreSQL. Members reserve gear like cameras, tools, and camping equipment for date ranges, staff check items out and back in, and the system handles waitlists, late fees, maintenance, and reporting.

The interesting parts are the rules: no double bookings (even when two people reserve at the same moment), status changes that must happen in order, exact money math, and background jobs that never run the same work twice.

> **Status:** In progress. Currently working on Milestone 1 (Foundation).

## Tech stack

| Area | Choice |
| --- | --- |
| Runtime | .NET 10, C# 14 |
| API | ASP.NET Core Web API (controllers) |
| Database | PostgreSQL via EF Core and Npgsql |
| API docs | Microsoft.AspNetCore.OpenApi + Scalar |
| Tests | xUnit, WebApplicationFactory, Testcontainers |
| Local setup | Docker Compose |

## Project structure

```
GearShare/
  src/
    GearShare/                  Web API: controllers, startup, configuration
    GearShare.Application/      Business rules and use cases (no web or database code)
    GearShare.Infrastructure/   EF Core, migrations, database access
  tests/
    GearShare.UnitTests/        Fast tests for business rules
    GearShare.IntegrationTests/ Full API tests against a real PostgreSQL container
```

References only point inward: the API and Infrastructure depend on Application, and Application depends on nothing. That keeps the business rules testable without a web server or database.

## Getting started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- EF Core CLI: `dotnet tool install --global dotnet-ef`

### Run it locally

```bash
git clone <repo-url>
cd GearShare
docker compose up -d
dotnet ef database update --project src/GearShare.Infrastructure --startup-project src/GearShare
dotnet run --project src/GearShare
```

Then open the API docs at `https://localhost:<port>/scalar`.

> The Docker Compose file and first migration are part of Milestone 1. Until then, these steps are the target, not a working path.

### Run the tests

```bash
dotnet test
```

Integration tests start their own PostgreSQL container, so Docker must be running.

## Milestones

- [ ] **M1 Foundation:** solution layout, database, migrations, items and categories, search and paging
- [ ] **M2 Accounts and roles:** register, login, lockout, role checks, suspension
- [ ] **M3 Reservations:** create, change, cancel, database-level overlap protection
- [ ] **M4 Checkout, return, fees, maintenance**
- [ ] **M5 Waitlist, notifications, background jobs**
- [ ] **M6 Settings, reports, audit log, performance**

Each milestone is tagged in Git (`m1`, `m2`, ...) when it's done.

## Design decisions

Choices this project made where the spec left room, and why, are recorded in [DECISIONS.md](DECISIONS.md).
