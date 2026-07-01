
namespace Nexus.Application.abstractions
{
    public interface ICacheService
    {
        //Example of the entity in cache: "nexus:staff:tenant:{tenantId}"
        Task<T?> GetAsync<T>(string entity,double beta, CancellationToken cancellationToken = default); //Allows to get from the cache
        Task SetAsync<T>(string entity,T value,TimeSpan? expiry = null, bool Sliding = false, double delta = 1.0, CancellationToken cancellationToken = default); //Allows to set onto the cache
        Task RemoveAsync(string entity, CancellationToken cancellationToken = default); //Allows to delete from the cache (use after a modification of an entity by a command)
    }
}