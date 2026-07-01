
using Nexus.Domain.Entityes.Aggregates.Personel;
using Nexus.Domain.Interfaces.Repositories;

namespace Nexus.Infrastructure.Persistence.Repositories
{
    public class ContractRepository(NexusDbContext dbContext) : Repository<Contract, int>(dbContext), IContractRepository {}
}