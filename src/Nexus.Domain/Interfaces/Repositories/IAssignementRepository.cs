
using Nexus.Domain.Entityes.Aggregates.Proyect;
using Nexus.Domain.Interfaces.Common;

namespace Nexus.Domain.Interfaces.Repositories
{
    public interface IAssignementRepository : IRepository<Assignement, Guid>
    {
        Task<IEnumerable<Assignement>> GetByTaskNameAsync(Guid tenant, string TaskName, CancellationToken cancellationToken = default);
        Task<IEnumerable<Assignement>> GetByTenantAsync(Guid tenant, CancellationToken cancellationToken = default);
        Task<IEnumerable<Assignement>> GetByTaskStatus(Guid tenant, int taskStatusId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Assignement>> GetByPriority(Guid tenant, int priorityID, CancellationToken cancellationToken = default);
        Task<IEnumerable<Assignement>> GetIfHasBeenReprogramed(Guid tenant, CancellationToken cancellationToken = default);
        Task<IEnumerable<Assignement>> GetIfIsDelayed(Guid tenant, CancellationToken cancellationToken = default);
    }
}