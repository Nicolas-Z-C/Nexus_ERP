# Nexus ERP

Sistema de Gestión Empresarial (ERP) Multi-Tenant diseñado bajo principios de
Arquitectura Limpia (Clean Architecture) y Desarrollo Orientado al Dominio (DDD).
Este proyecto busca centralizar la operación de múltiples empresas en una única
plataforma robusta, escalable y segura.

## 🚧 Estado del proyecto

En desarrollo activo — **Fase 1: MVP**

## 🛠️ Tech Stack

| Categoría | Tecnología |
|---|---|
| Lenguaje | C# (.NET 9) |
| Arquitectura | Clean Architecture + DDD |
| Frontend | Blazor Web App (Interactive Server/Auto) |
| Persistencia | Entity Framework Core + SQL Server |
| Infraestructura | Docker & Docker Compose |
| Control de versiones | Git + Gitflow |

## 📋 Requisitos previos

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server) o Docker para levantar el contenedor
- [Docker & Docker Compose](https://www.docker.com/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o [JetBrains Rider](https://www.jetbrains.com/rider/)
- [git-flow](https://github.com/nvie/gitflow) instalado en Git

## 🚀 Instalación

> El proyecto se encuentra en la etapa de definición de dominio.
> Las instrucciones de instalación completas estarán disponibles al finalizar la estructura base.

```bash
# 1. Clonar el repositorio
git clone https://github.com/tu-usuario/nexus-erp.git
cd nexus-erp

# 2. Inicializar git flow
git flow init

# 3. Cambiar a develop
git checkout develop
```

## 🏛️ Estructura del proyecto (Clean Architecture)

Nexus/
├── src/
│   ├── Nexus.Domain/          # Entidades, Value Objects, interfaces del dominio
│   ├── Nexus.Application/     # Casos de uso, DTOs, servicios de aplicación
│   ├── Nexus.Infrastructure/  # EF Core, repositorios, servicios externos
│   └── Nexus.Web/             # Blazor Web App (presentación)
├── tests/
│   ├── Nexus.Domain.Tests/
│   └── Nexus.Application.Tests/
├── docker-compose.yml
└── README.md

## 📌 Roadmap

- [ ] Planificación y normalización de base de datos
- [ ] Estructura base del proyecto (Clean Architecture)
- [ ] Definición del dominio inicial
- [ ] Creación de las entidades **Tenant** y **Usuario**
- [ ] Creación de las entidades de catálogo (Países, Regiones, Ciudades)
- [ ] Módulo de Personal (CRUD de empleados)
- [ ] Módulo de Inventario (CRUD de productos y stock)

## 🤝 Contribución

Este es un proyecto personal. El flujo de trabajo sigue la metodología **Gitflow**:

- Las nuevas funcionalidades se desarrollan en ramas `feature/*`
- Los cambios se integran a `develop` mediante Pull Requests
- Las versiones estables se publican en `main` mediante ramas `release/*`

## 📄 Licencia

Este proyecto está bajo la licencia [MIT](LICENSE).