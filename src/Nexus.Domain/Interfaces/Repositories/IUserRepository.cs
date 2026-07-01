using Nexus.Domain.Entityes.Aggregates.Tenant;
using Nexus.Domain.Interfaces.Common;

namespace Nexus.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User?> GetByUserNameAsync(Guid tenant, string userName, CancellationToken cancellationToken = default);
        Task<User?> GetByEmailAsync(Guid tenant, string email, CancellationToken cancellationToken = default);
        Task<IEnumerable<User>> GetByTenantAsync(Guid tenant, CancellationToken cancellationToken = default);
    }
}