
using Nexus.Domain.Entityes.Aggregates.Personel;
using Nexus.Domain.Interfaces.Common;

namespace Nexus.Domain.Interfaces.Repositories
{
    public interface IStaffRepository : IRepository<Staff, Guid>
    {
        Task<IEnumerable<Staff>> GetByTenantAsync (Guid tenant, CancellationToken cancellationToken = default);
        Task<IEnumerable<Staff>> GetByNameAsync (Guid tenant,string legalName, CancellationToken cancellationToken = default);
        Task<Staff?> GetByEmailAsync (Guid tenant, string email, CancellationToken cancellationToken = default);
        Task<IEnumerable<Staff>> GetByDateOfJoiningAsync (Guid tenant, DateOnly dateOfJoining, CancellationToken cancellationToken = default);
        Task<IEnumerable<Staff>> GetByStatusAsync (Guid tenant, int statusId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Staff>> GetByPositionAsync (Guid tenant, int positionId, CancellationToken cancellationToken = default);
    }
}