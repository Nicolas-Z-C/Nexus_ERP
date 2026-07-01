using MediatR;
using Nexus.Application.abstractions;

using System.Diagnostics;

namespace Nexus.Application.common.behaviours
{
    public class CachingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest: IRequest<TResponse>
    {
        private readonly ICacheService _cache;
        public CachingBehaviour(ICacheService cache) => _cache = cache;

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (request is not ICacheableQuery cacheableQuery)
                return await next();

            var cached = await _cache.GetAsync<TResponse>(cacheableQuery.CacheKey, cacheableQuery.beta, cancellationToken);

            if(cached != null)
                return cached;

            var start = Stopwatch.GetTimestamp();
            var response = await next();
            var delta = Stopwatch.GetElapsedTime(start).TotalSeconds;

            await _cache.SetAsync(
                cacheableQuery.CacheKey,
                response,
                cacheableQuery.Expiry,
                cacheableQuery.UseSliding,
                delta,
                cancellationToken);
            
            return response;
        }
    }
}