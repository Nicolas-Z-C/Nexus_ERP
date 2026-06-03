
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Nexus.Domain.Entityes.CatalogEntityes.Geography;

namespace Nexus.Infrastructure.Persistence
{
    public class NexusDbContext : DbContext
    {
        public NexusDbContext(DbContextOptions<NexusDbContext> options) : base(options) {}

        public DbSet<City>  Cities => Set<City>();
        public DbSet<Region> Regions => Set<Region>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Continent> Continents => Set<Continent>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

/*
To-DO -> Hacer las entidades de soporte y soporte de los enums
*/