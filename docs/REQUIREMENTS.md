# Habitool Requirements & Architecture

This document elaborates on **Step 1** of the manifest: defining application requirements and overall architecture. It covers both functional and non-functional requirements, and includes diagrams illustrating the software components and Azure infrastructure.

---

## Functional Requirements

1. **User Management**
   - Users can register, log in, and manage their profile.
   - Authentication uses JWT tokens. 
   - Identity management using Entra.
   - Password reset and account recovery flows.

2. **Habit Lifecycle**
   - Users can create, read, update, and delete habits.
   - Each habit includes title, description, frequency (daily/weekly/etc.), start date, and whether it's a good or bad habit.
   - Habits belong to authenticated users; data isolation per user.

3. **Daily Logging**
   - Users can log completion of habits with timestamps.
   - Support for editing and deleting log entries.
   - Batch entry for marking multiple habits in one action.

4. **Streak & Progress Tracking**
   - System computes current and best streaks automatically.
   - Visual indicators for habit status (on track, missed, broken).
   - Ability to view historical logs and calendar view.

5. **Statistics & Insights**
   - Provide completion rates, trend graphs, and habit analytics.
   - Generate AI-driven suggestions (e.g., "you perform better on weekends").

8. **Security & Privacy**
   - All API calls require authentication; sensitive data encrypted at rest and in transit.
   - Follow GDPR-style privacy principles: users can request data export or deletion.
   - All Azure resources should follow best security practices including zero-trust and minimal RBAC roles.

9. **Admin & Monitoring (future)**
   - Administrative dashboard for usage metrics, error reports, and user management.


## Non-Functional Requirements

- **Performance**: API response times <200ms under typical load; scalable to thousands of users.
- **Scalability**: Use Cosmos DB and Azure App Service with auto-scale rules.
- **Availability**: Target 99.95% uptime; deploy across multiple Azure regions.
- **Security**: HTTPS everywhere, OWASP Top 10 protections, use Azure Key Vault for secrets.
- **Maintainability**: Code must be modular, self-documenting, and covered by automated tests.
- **Deployability**: Infrastructure reproducible via Bicep; CI/CD pipelines handle build/test/deploy, including measurement of code coverage for automated tests.
- **Observability**: Application Insights for telemetry, custom metrics, and alerts.
- **Cost-efficiency**: Use serverless or consumption tiers where appropriate, leverage Cosmos DB autoscale.

---

## Proposed Architecture

The architecture splits into two logical layers: **backend services** running on Azure App Service and **frontend** as a Blazor WebAssembly application served from Azure Storage (static website). Data is stored in Cosmos DB. Additional services such as Application Insights and Key Vault provide monitoring and secret management.

### Logical Component Diagram

```mermaid
flowchart LR
    subgraph UserDevices[User Devices]
        Browser["Browser (Blazor WASM)"]
    end

    subgraph Frontend[Blazor WebAssembly]
        Browser -->|HTTP(S) API| APIEndpoints
    end

    subgraph Backend[ASP.NET Core API]
        APIEndpoints["API Controllers"] --> Services["Business Services"]
        Services --> Repos["Repositories"]
    end

    subgraph Data[Azure Cosmos DB]
        Repos -->|reads/writes| Cosmos[("Cosmos DB Containers")]
    end

    subgraph Infra[Azure Infrastructure]
        APIEndpoints -->|logs| AppInsights["Application Insights"]
        APIEndpoints -->|secrets| KeyVault["Azure Key Vault"]
    end
```

### Infrastructure Diagram

```mermaid
flowchart TB
    subgraph Azure
        subgraph Network[VNet (optional)]
            AppService["App Service Plan + API App"]
            Storage["Storage Account (Static Site)"]
            Cosmos["Cosmos DB Account"]
            KeyVault["Key Vault"]
            AppInsights["Application Insights"]
        end
    end

    Browser -.-> Storage
    Browser --> AppService
    AppService --> Cosmos
    AppService --> KeyVault
    AppService --> AppInsights

    style Storage fill:#f9f,stroke:#333,stroke-width:1px
    style AppService fill:#afa,stroke:#333,stroke-width:1px
    style Cosmos fill:#ff9,stroke:#333,stroke-width:1px
    style KeyVault fill:#9af,stroke:#333,stroke-width:1px
    style AppInsights fill:#faa,stroke:#333,stroke-width:1px
``` 

These diagrams help visualize both the software components and how they map onto Azure resources.

---
