
using Microsoft.EntityFrameworkCore;
using Nexus.Domain.Entityes.Aggregates.Tenant;
using Nexus.Domain.Interfaces.Repositories;

namespace Nexus.Infrastructure.Persistence.Repositories
{
    public class TenantRepository(NexusDbContext DbContext) : Repository<Tenant,Guid>(DbContext), ITenantRepository
    {
        public async Task<IEnumerable<Tenant>> GetByComercialNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var tenantList = await _context.Tenants
                            .Where(x => x.TenantComercialName.Value == name)
                            .OrderBy(x => x.TenantComercialName)
                            .ToListAsync(cancellationToken);
            
            return tenantList;
        }

        public async Task<Tenant?> GetByTaxIdAsync(string taxid, CancellationToken cancellationToken = default)
        {
            var tenant = await _context.Tenants
                                .FirstOrDefaultAsync(x => x.TaxID.Value == taxid, cancellationToken);
            
            return tenant;
        }

        public async Task<Tenant?> GetByTenantEmail(string email, CancellationToken cancellationToken = default)
        {
            var tenant = await _context.Tenants
                            .FirstOrDefaultAsync(x => x.TenantEmail.Value == email, cancellationToken);
            
            return tenant;
        }

        public async Task<IEnumerable<Tenant>> GetByEconomicSectorAsync(int economicSector, CancellationToken cancellationToken = default)
        {
            var tenantList = await _context.Tenants
                                .Where(x => x.EconomicSectorID == economicSector)
                                .OrderBy(x => x.EconomicSector)
                                .ToListAsync(cancellationToken);

            return tenantList;
        }

        public async Task<IEnumerable<Tenant>> GetByLegalNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var tenantList = await _context.Tenants
                                    .Where(x => x.TenantEmail.Value == name)
                                    .OrderBy(x => x.LegalName)
                                    .ToListAsync(cancellationToken);

            return tenantList;
        }

        public async Task<IEnumerable<Tenant>> GetByCountry(int countryID, CancellationToken cancellationToken = default)
        {
            var tenantList = await _context.Tenants
                                    .Where(x => x.Country == countryID)
                                    .OrderBy(x => x.Country)
                                    .ToListAsync(cancellationToken);

            return tenantList;
        }
    }
}