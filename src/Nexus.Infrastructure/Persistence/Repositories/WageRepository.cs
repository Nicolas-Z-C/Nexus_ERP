
using Nexus.Domain.Entityes.Aggregates.Personel;
using Nexus.Domain.Interfaces.Repositories;

namespace Nexus.Infrastructure.Persistence.Repositories
{
    public class WageRepository(NexusDbContext DbContext) : Repository<Wage, int>(DbContext), IWageRepository {}
}