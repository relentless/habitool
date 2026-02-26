# Habitool Development Manifest

A high‑level checklist to track major milestones while building the Habitool application. Tasks are intentionally broad so you can focus on progress without getting lost in details.

1. **Define Requirements & Architecture** – agree on functional and non‑functional requirements, sketch the high‑level system design and data model.
2. **Set Up Solution & Projects** – create the .NET solution with API, Blazor WebAssembly, and test projects; configure dependencies.
3. **Provision Azure Infrastructure** – author Bicep templates for Cosmos DB, App Services, Storage, Key Vault, Application Insights and deploy a baseline environment.
4. **Implement Core Backend API** – build the ASP.NET Core API with authentication, habit management, logging, and basic analytics; include unit tests.
5. **Implement Blazor Frontend** – create key UI pages (dashboard, habit list, log entry, statistics) with components and state handling; add frontend tests.
6. **Establish Testing Strategy** – ensure unit, integration and end‑to‑end tests are in place and coverage goals are defined.
7. **Configure CI/CD Pipelines** – set up GitHub Actions (or preferred tooling) to build, test and publish both API and web projects automatically.
8. **Deploy to Azure Environments** – roll out DEV, STAGE and PROD using the Bicep templates and published artifacts; verify connectivity.
9. **Document & Communicate** – maintain architecture docs, API guides, deployment instructions and a user manual.
10. **Perform QA & Launch Prep** – complete security reviews, performance testing, user acceptance testing, and prepare a go‑live checklist.
11. **Go Live & Monitor** – launch the app, configure monitoring/alerts, and collect initial user feedback.
12. **Post‑Launch Maintenance** – handle bug fixes, performance tuning, and plan future enhancements such as mobile clients or social features.

---

**Usage Notes**

- Mark items as **in‑progress** or **complete** directly in this file.
- Refer to specific steps when asking Copilot for code generation (e.g. "Step 4: scaffold authentication endpoints").
- Adjust or split tasks as needed once you dive into implementation.

---

**Status Summary**

- **Total major tasks**: 12
- **Completed**: 1 (Requirements & Architecture – 2026‑02‑26)
- **Remaining**: 11

---


**Step 1 has been completed.** (completed on 2026-02-26)

## How to Use This Manifest

1. **At the start of each task**: Mark it as in-progress before starting work
2. **Upon completion**: Check off the ☑️ checkbox and optionally add completion date
3. **For blocking issues**: Add them to the "Blockers" section and resolve before proceeding
4. **Regular reviews**: Update this manifest weekly to track progress
5. **With Copilot**: Reference specific phase and task numbers when asking for help
   - Example: "Phase 3.2 - Generate the API endpoints scaffolding with unit test stubs"
