
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Nexus.Domain.Entityes.Aggregates.Personel;
using Nexus.Domain.Entityes.Aggregates.Proyect;
using Nexus.Domain.Entityes.Aggregates.Tenant;
using Nexus.Domain.Entityes.CatalogEntityes.Geography;
using Nexus.Domain.Entityes.CatalogEntityes.ID;
using Nexus.Domain.Entityes.CatalogEntityes.Inventory;
using Nexus.Domain.Entityes.CatalogEntityes.Personel;
using Nexus.Domain.Entityes.Common;
using Nexus.Domain.Entityes.EnumSupportEntities;
using Nexus.Domain.Entityes.Support;

namespace Nexus.Infrastructure.Persistence
{
    public class NexusDbContext : DbContext
    {
        public NexusDbContext(DbContextOptions<NexusDbContext> options) : base(options) {}

        //Catalog Entities

        //-Geography
        public DbSet<City>  Cities => Set<City>();
        public DbSet<Region> Regions => Set<Region>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Continent> Continents => Set<Continent>();
        //-ID
        public DbSet<IDType> IDTypes => Set<IDType>();
        //-Inventory
        public DbSet<ObjectType> ObjectTypes => Set<ObjectType>();
        //-Personel
        public DbSet<Hierarchy> Hierarchies => Set<Hierarchy>();
        //Enums
        public DbSet<ContractTypeEntity> ContractTypes => Set<ContractTypeEntity>();
        public DbSet<EconomicSectorEntity> EconomicSectors => Set<EconomicSectorEntity>();
        public DbSet<PersonalStatusEntity> PersonalStatuses => Set<PersonalStatusEntity>();
        public DbSet<ProyectStatusEntity> ProyectStatuses => Set<ProyectStatusEntity>();
        public DbSet<TaskStatusEntity> TaskStatuses => Set<TaskStatusEntity>();
        //SupportEntities
        public DbSet<MovementType> MovementTypes => Set<MovementType>();
        public DbSet<Priority> Priorities => Set<Priority>();
        public DbSet<RemunerationType> RemunerationTypes => Set<RemunerationType>();

        //Aggregates
        //-Personel
        public DbSet<Staff> Staff => Set<Staff>();
        public DbSet<Contract> Contracts => Set<Contract>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<Wage> Wages => Set<Wage>();
        //-Proyect
        public DbSet<Assignement> Assignements => Set<Assignement>();
        public DbSet<Proyect> Proyects => Set<Proyect>();
        //-Tenant
        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if(entry.State == EntityState.Modified)
                    entry.Entity.Update();
            }

        return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

