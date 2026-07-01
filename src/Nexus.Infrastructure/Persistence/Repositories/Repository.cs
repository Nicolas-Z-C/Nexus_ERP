using Nexus.Domain.Interfaces.Common;

namespace Nexus.Infrastructure.Persistence.Repositories
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {
        protected readonly NexusDbContext _context;

        protected Repository(NexusDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
           return await _context.Set<TEntity>()
                        .FindAsync([id!], cancellationToken); 
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<TEntity>()
                    .AddAsync(entity);
        }
    }
}