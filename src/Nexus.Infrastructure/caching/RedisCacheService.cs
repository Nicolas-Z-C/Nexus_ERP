
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Nexus.Application.abstractions;

namespace Nexus.Infrastructure.caching
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;
        public RedisCacheService(IDistributedCache cache) => _cache = cache;

        public async Task<T?> GetAsync<T>(
            string entity,
            double beta = 1.0,
            CancellationToken cancellationToken = default)
        {
            
            var cache = await _cache.GetAsync(entity, cancellationToken);
            if(cache == null)
                return default;

            var entry = Deserialize<CacheEntry<T>>(cache);
            if(entry == null)
                return default;

            var ttlRemaining = (entry.Expiry - DateTimeOffset.UtcNow).TotalSeconds;

            if(ShouldRecompute(ttlRemaining, beta, entry.Delta))
                return default;
            
            var result = Deserialize<T>(cache);

            return result;
        }

        public async Task SetAsync<T>(
            string entity,
            T value,
            TimeSpan? expiry = null,
            bool Sliding = false,
            double delta = 1.0,
            CancellationToken cancellationToken = default)
        {

            var baseExpiry = expiry ??  TimeSpan.FromMinutes(10);
            var finalExpiry = AddJitter(baseExpiry);

            var entry = new CacheEntry<T>
            {
                Value = value,
                Delta = delta,
                Expiry = DateTimeOffset.UtcNow.Add(finalExpiry)
            };
            var options = new DistributedCacheEntryOptions();

            if (Sliding)
            {
                options.SlidingExpiration = finalExpiry;
                options.AbsoluteExpirationRelativeToNow = finalExpiry * 10;
            }
            else
            {
                options.AbsoluteExpirationRelativeToNow = finalExpiry;
            }

             await _cache.SetAsync(entity,Serialize(options), cancellationToken);
        }

        public async Task RemoveAsync(string entity, CancellationToken cancellationToken = default)
        {
            await _cache.RemoveAsync(entity, cancellationToken);
        }

        //helper methods for serialize and de-serialize

        private static byte[] Serialize<T>(T value) => JsonSerializer.SerializeToUtf8Bytes(value);

        private static T? Deserialize<T>    (byte[] value) => JsonSerializer.Deserialize<T>(value);

        //helper methods for jittering, Xfetch

        private static TimeSpan AddJitter(TimeSpan expiry)
        {
            var jitter = expiry.TotalSeconds * 0.2 * Random.Shared.NextDouble();
            return expiry.Add(TimeSpan.FromSeconds(jitter));
        }

        private bool ShouldRecompute(double ttlRemaining, double beta, double delta)
        {
            var random = -Math.Log(Random.Shared.NextDouble());
            return random * beta * delta >= ttlRemaining;
        }

        internal sealed class CacheEntry<T>
        {
            public T Value {get; set;} = default!;
            public double Delta {get; set;} //Computed time
            public DateTimeOffset Expiry {get; set;} // when the ttl should expire
        }
    }
}