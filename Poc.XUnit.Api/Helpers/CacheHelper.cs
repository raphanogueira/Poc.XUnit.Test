using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Poc.XUnit.Api.Helpers;

public static class CacheHelper
{
    public static async Task<TResult?> GetCacheAsync<TResult>(
        this IDistributedCache distributedCache,
        object key,
        CancellationToken cancellationToken)
    {
        var jsonKey = JsonSerializer.Serialize(key);

        var cacheResponse = await distributedCache.GetStringAsync(jsonKey, cancellationToken);

        return string.IsNullOrEmpty(cacheResponse) 
            ? default
            : JsonSerializer.Deserialize<TResult?>(cacheResponse, GetSerializerOptions());
    }

    public static async Task SetCacheAsync<TValue>(
        this IDistributedCache distributedCache,
        object key,
        TValue value,
        DistributedCacheEntryOptions options,
        CancellationToken cancellationToken)
    {
        var jsonKey = JsonSerializer.Serialize(key);
        var jsonValue = JsonSerializer.Serialize(value);

        await distributedCache.SetStringAsync(jsonKey, jsonValue, options, cancellationToken);
    }

    public static JsonSerializerOptions GetSerializerOptions()
    {
        return new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }
}