
using Microsoft.EntityFrameworkCore;
using Nexus.Domain.Entityes.Aggregates.Personel;
using Nexus.Domain.Interfaces.Repositories;

namespace Nexus.Infrastructure.Persistence.Repositories
{
    public class StaffRepository(NexusDbContext DbContext) : Repository<Staff, Guid>(DbContext), IStaffRepository
    {
        
        public async Task<IEnumerable<Staff>> GetByTenantAsync (Guid tenant, CancellationToken cancellationToken = default)
        {
            var staff = await _context.Staff
                        .Where(x => x.TenantId == tenant)
                        .ToListAsync(cancellationToken);
            
            return staff;
        }

        public async Task<IEnumerable<Staff>> GetByNameAsync (Guid tenant, string legalName, CancellationToken cancellationToken = default)
        {
            var staff = await _context.Staff
                        .Where(x => x.TenantId == tenant && x.LegalName.Value == legalName)
                        .ToListAsync(cancellationToken);
            
            return staff;
        }

        public async Task<Staff?> GetByEmailAsync (Guid tenant, string email, CancellationToken cancellationToken = default)
        {
            var staff = await _context.Staff
                        .FirstOrDefaultAsync(x => x.TenantId == tenant && x.Email.Value == email, cancellationToken);
            
            return staff;
        }

        public async Task<IEnumerable<Staff>> GetByDateOfJoiningAsync (Guid tenant, DateOnly dateOfJoining, CancellationToken cancellationToken = default)
        {
            var staff = await _context.Staff
                        .Where(x => x.TenantId == tenant && x.DateOfJoining == dateOfJoining)
                        .ToListAsync(cancellationToken);
            
            return staff;
        }

        public async Task<IEnumerable<Staff>> GetByStatusAsync (Guid tenant, int statusId, CancellationToken cancellationToken = default)
        {
            var staff = await _context.Staff
                        .Where(x => x.TenantId == tenant && x.StaffStatusID == statusId)
                        .ToListAsync(cancellationToken);
            
            return staff;  
        }

        public async Task<IEnumerable<Staff>> GetByPositionAsync (Guid tenant, int positionId, CancellationToken cancellationToken = default)
        {
            var staff = await _context.Staff
                        .Where(x => x.TenantId == tenant && x.PositionID == positionId)
                        .ToListAsync(cancellationToken);
            
            return staff; 
        }
    }
}