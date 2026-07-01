# Nexus ERP

Multi-Tenant Enterprise Resource Planning (ERP) system designed under the principles of
Clean Architecture and Domain-Driven Design (DDD).
This project aims to centralize the operations of multiple companies in a single
robust, scalable, and secure platform.

## 🚧 Project Status

Actively in development — **Phase 1: MVP**

## 🛠️ Tech Stack

| Category | Technology |
|---|---|
| Language | C# (.NET 9) |
| Architecture | Clean Architecture + DDD |
| Frontend | Blazor Web App (Interactive Server/Auto) |
| Persistence | Entity Framework Core + SQL Server |
| Infrastructure | Docker & Docker Compose |
| Version Control | Git + Gitflow |

## 📋 Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server) or Docker to spin up the container
- [Docker & Docker Compose](https://www.docker.com/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [JetBrains Rider](https://www.jetbrains.com/rider/)
- [git-flow](https://github.com/nvie/gitflow) installed in Git

## 🚀 Installation

> The project is currently in the domain definition stage.
> Full installation instructions will be available once the base structure is complete.

```bash
# 1. Clone the repository
git clone https://github.com/your-username/nexus-erp.git
cd nexus-erp

# 2. Initialize git flow
git flow init

# 3. Switch to develop
git checkout develop
``` 

## 🏛️ Project Structure (Clean Architecture)

```
Nexus/
├── src/
│   ├── Nexus.Domain/          # Entities, Value Objects, domain interfaces
│   ├── Nexus.Application/     # Use cases, DTOs, application services
│   ├── Nexus.Infrastructure/  # EF Core, repositories, external services
│   └── Nexus.Web/             # Blazor Web App (presentation)
├── tests/
│   ├── Nexus.Domain.Tests/
│   └── Nexus.Application.Tests/
├── docker-compose.yml
└── README.md
```

## 📌 Roadmap

- [ x ] Database planning and normalization
- [ x ] Base project structure (Clean Architecture)
- [ x ] Creation of initial catalog entities (Countries, Regions, Cities)
- [ x ] Creation of **Tenant** and **User** entities
- [ x ] Creation of **Project** and **Staff** entities
- [ x ] Unit testing of the 3 main entities and their behavior with child entities
- [ x ] Make the infrastructure for the Db of every entity (Dbconfig and Db Context)
- [ x ] Make the infrastructure for the Db of every entity (Repositories)
- [ ] Make the Redis implementation for the cache
- [ ] Make the Landing Page for the users
- [ ] Staff Module (employee CRUD)
- [ ] Inventory Module (product and stock CRUD)

## 🤝 Contributing

This is a personal project. The workflow follows the **Gitflow** methodology:

- New features are developed in `feature/*` branches
- Changes are merged into `develop` via Pull Requests
- Stable versions are published to `main` via `release/*` branches

## 📄 License

This project is licensed under the [MIT](LICENSE) license.
