
using Nexus.Domain.Entityes.Aggregates.Tenant;
using Nexus.Domain.Interfaces.Common;

namespace Nexus.Domain.Interfaces.Repositories
{
    public interface ITenantRepository : IRepository<Tenant, Guid>
    {
        Task<IEnumerable<Tenant>> GetByComercialNameAsync(string name, CancellationToken cancellationToken = default);
        Task<Tenant?> GetByTaxIdAsync(string taxid, CancellationToken cancellationToken = default);
        Task<Tenant?> GetByTenantEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<IEnumerable<Tenant>> GetByEconomicSectorAsync(int economicSector, CancellationToken cancellationToken = default);
        Task<IEnumerable<Tenant>> GetByLegalNameAsync(string name, CancellationToken cancellationToken = default);
        Task<IEnumerable<Tenant>> GetByCountry(int countryID, CancellationToken cancellationToken = default);
    }
}