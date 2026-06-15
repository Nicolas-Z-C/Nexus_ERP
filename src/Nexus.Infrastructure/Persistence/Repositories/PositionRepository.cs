
using Nexus.Domain.Entityes.Aggregates.Personel;
using Nexus.Domain.Interfaces.Repositories;

namespace Nexus.Infrastructure.Persistence.Repositories
{
    public class PositionRepository(NexusDbContext dbContext) : Repository<Position, int>(dbContext), IPositionRepository {}
}