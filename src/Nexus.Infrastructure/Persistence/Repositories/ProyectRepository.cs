
using Microsoft.EntityFrameworkCore;
using Nexus.Domain.Entityes.Aggregates.Proyect;
using Nexus.Domain.Interfaces.Repositories;

namespace Nexus.Infrastructure.Persistence.Repositories
{
    public class ProyectRepository(NexusDbContext DbContext) : Repository<Proyect, Guid>(DbContext) , IProyectRepository
    {
        public async Task<IEnumerable<Proyect>> GetByTenantAsync(Guid tenant, CancellationToken cancellationToken = default)
        {
            var proyects = await _context.Proyects
                            .Where(x => x.TenantId == tenant)
                            .ToListAsync(cancellationToken);
            
            return proyects;
        }

        public async Task<Proyect?> GetByProyectNameAsync (Guid tenant, string proyectName, CancellationToken cancellationToken = default)
        {
            var proyects = await _context.Proyects
                            .Where(x => x.TenantId == tenant && x.ProyectName.Value == proyectName)
                            .FirstOrDefaultAsync(cancellationToken);
            
            return proyects;
        }

        public async Task<IEnumerable<Proyect>> GetByDateOfStartAsync(Guid tenant, DateOnly startDate, CancellationToken cancellationToken = default)
        {
            var proyects = await _context.Proyects
                            .Where(x => x.TenantId == tenant && x.DateOfStart == startDate)
                            .ToListAsync(cancellationToken);
            
            return proyects;
        }

        public async Task<IEnumerable<Proyect>> GetByEstimatedDateOfReleaseAsync(Guid tenant, DateOnly estimatedDate, CancellationToken cancellationToken = default)
        {
           var proyects = await _context.Proyects
                            .Where(x => x.TenantId == tenant && x.EstimatedDateOfRelease == estimatedDate)
                            .ToListAsync(cancellationToken);
            
            return proyects; 
        }

        public async Task<IEnumerable<Proyect>> GetByStateAsync(Guid tenant, int proyectStateID, CancellationToken cancellationToken = default)
        {
           var proyects = await _context.Proyects
                            .Where(x => x.TenantId == tenant && x.ProyectStateID == proyectStateID)
                            .ToListAsync(cancellationToken);
            
            return proyects; 
        }
    }
}