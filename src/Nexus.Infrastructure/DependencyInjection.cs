using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nexus.Domain.Interfaces.Repositories;
using Nexus.Application.abstractions;
using Nexus.Infrastructure.caching;
using Nexus.Infrastructure.Persistence;
using Nexus.Infrastructure.Persistence.Repositories;

namespace Nexus.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //Persistence

            services.AddDbContext<NexusDbContext>(options =>
                options.UseSqlServer(
                    configuration["CONNECTION_STRING"]));
            
            //Repos

            services.AddScoped<IProyectRepository, ProyectRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IWageRepository, WageRepository>();
            services.AddScoped<IAssignementRepository, AssignementRepository>();

            //Cache

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["REDIS_CONNECTION"];
                options.InstanceName = "Nexus:";
            });

            services.AddScoped<ICacheService, RedisCacheService>();

            return services;
        }
    }
}