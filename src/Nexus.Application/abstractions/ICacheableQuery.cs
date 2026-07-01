namespace Nexus.Application.abstractions
{
    public interface ICacheableQuery
    {
        string CacheKey {get;} //The key that will be used to store the data in redis
        TimeSpan? Expiry {get;} //TTL
        bool UseSliding {get;} //sliding capability
        double beta {get;} //XFecth
    }
}