
using Microsoft.EntityFrameworkCore;
using Nexus.Domain.Entityes.Aggregates.Tenant;
using Nexus.Domain.Interfaces.Repositories;

namespace Nexus.Infrastructure.Persistence.Repositories
{
    public class UserRepository(NexusDbContext Dbcontext) : Repository<User, Guid>(Dbcontext), IUserRepository
    {
        public async Task<User?> GetByUserNameAsync(Guid tenant, string userName, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users
                            .FirstOrDefaultAsync(x => x.UserName.Value == userName && x.TenantId == tenant, cancellationToken);


            return user;
        }

        public async Task<User?> GetByEmailAsync(Guid tenant, string email, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users
                            .FirstOrDefaultAsync(x => x.Email.Value == email && x.TenantId == tenant, cancellationToken);


            return user;
        }

        public async Task<IEnumerable<User>> GetByTenantAsync(Guid tenant, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users
                            .Where(x => x.TenantId == tenant)
                            .OrderBy(x => x.UserName)
                            .ToListAsync(cancellationToken);
            
            return user;
        }
    }
}