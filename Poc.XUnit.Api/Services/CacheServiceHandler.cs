using Microsoft.Extensions.Caching.Distributed;
using Poc.XUnit.Api.Contracts;
using Poc.XUnit.Api.Helpers;

namespace Poc.XUnit.Api.Services;

public sealed class CacheServiceHandler : ICacheService
{
    private readonly IDistributedCache _distributedCache;
    private readonly DistributedCacheEntryOptions _distributedCacheEntryOptions;

    public CacheServiceHandler(IDistributedCache distributedCache, DistributedCacheEntryOptions distributedCacheEntryOptions)
    {
        var options = new DistributedCacheEntryOptions();
        options.SetAbsoluteExpiration(TimeSpan.FromMinutes(20));

        _distributedCache = distributedCache;  
        _distributedCacheEntryOptions = options;
    }

    public async Task<TResult?> GetOrCreateAsync<TResult>(object key, Func<Task<TResult?>> function, CancellationToken cancellationToken)
    {
        var cacheResponse = await _distributedCache.GetCacheAsync<TResult>(key, cancellationToken);

        if (cacheResponse != null)
            return cacheResponse;

        var response = await function();

        await _distributedCache.SetCacheAsync(key, response, _distributedCacheEntryOptions, cancellationToken);

        return response;
    }
}