using Nexus.Domain.Entityes.Aggregates.Proyect;
using Nexus.Domain.Interfaces.Common;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Interfaces.Repositories
{
    public interface IProyectRepository : IRepository<Proyect, Guid>
    {
        Task<IEnumerable<Proyect>> GetByTenantAsync(Guid tenant, CancellationToken cancellationToken = default);
        Task<Proyect?> GetByProyectNameAsync (Guid tenant, string proyectName, CancellationToken cancellationToken = default);
        Task<IEnumerable<Proyect>> GetByDateOfStartAsync(Guid tenant, DateOnly startDate, CancellationToken cancellationToken = default);
        Task<IEnumerable<Proyect>> GetByEstimatedDateOfReleaseAsync(Guid tenant, DateOnly estimatedDate, CancellationToken cancellationToken = default);
        Task<IEnumerable<Proyect>> GetByStateAsync(Guid tenant, int proyectStateID, CancellationToken cancellationToken = default);
    }
}