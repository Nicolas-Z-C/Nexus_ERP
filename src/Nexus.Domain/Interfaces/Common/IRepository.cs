
namespace Nexus.Domain.Interfaces.Common
{
    public interface IRepository<TEntity, Tid> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(Tid id, CancellationToken cancellationToken = default);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}