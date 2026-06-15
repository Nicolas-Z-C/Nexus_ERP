
using Microsoft.EntityFrameworkCore;
using Nexus.Domain.Entityes.Aggregates.Proyect;
using Nexus.Domain.Interfaces.Repositories;

namespace Nexus.Infrastructure.Persistence.Repositories
{
    public class AssignementRepository(NexusDbContext DbContext) : Repository<Assignement, Guid>(DbContext), IAssignementRepository
    {

        public async Task<IEnumerable<Assignement>> GetByTaskNameAsync(Guid tenant, string TaskName, CancellationToken cancellationToken = default)
        {
            var assignements = await _context.Assignements
                                .Where(x => x.TenantId == tenant && x.TaskName.Value == TaskName)
                                .ToListAsync(cancellationToken);

            return assignements;
        }

        public async Task<IEnumerable<Assignement>> GetByTenantAsync(Guid tenant, CancellationToken cancellationToken = default)
        {
            var assignements = await _context.Assignements
                                .Where(x => x.TenantId == tenant)
                                .ToListAsync(cancellationToken);

            return assignements;
        }

        public async Task<IEnumerable<Assignement>> GetByTaskStatus(Guid tenant, int taskStatusId, CancellationToken cancellationToken = default)
        {
            var assignements = await _context.Assignements
                                .Where(x => x.TenantId == tenant && x.TaskStatusID == taskStatusId)
                                .ToListAsync(cancellationToken);
            
            return assignements;
        }

        public async Task<IEnumerable<Assignement>> GetByPriority(Guid tenant, int priorityID, CancellationToken cancellationToken = default)
        {
            var assignements = await _context.Assignements
                                .Where(x => x.TenantId == tenant && x.PriorityID == priorityID)
                                .ToListAsync(cancellationToken);
            
            return assignements;
        }

        public async Task<IEnumerable<Assignement>> GetIfHasBeenReprogramed(Guid tenant, CancellationToken cancellationToken = default)
        {
            var assignements = await _context.Assignements
                                .Where(x => x.TenantId == tenant && x.ReprogrammedFlag == true)
                                .ToListAsync(cancellationToken);
            
            return assignements;
        }

        public async Task<IEnumerable<Assignement>> GetIfIsDelayed(Guid tenant, CancellationToken cancellationToken = default)
        {
           var assignements = await _context.Assignements
                                .Where(x => x.TenantId == tenant && x.OverdueFlag == true)
                                .ToListAsync(cancellationToken);
            
            return assignements; 
        }
    }
}