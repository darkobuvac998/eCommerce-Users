using eCommerce.Users.Application.Abstractions;
using eCommerce.Users.Application.Shared;
using eCommerce.Users.Infrastructure.Options;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace eCommerce.Users.Infrastructure.Services;

public sealed class CacheService : ICacheService
{
    private readonly IDistributedCache _distributedCache;
    private readonly RedisOptions _redisOptions;
    private readonly DistributedCacheEntryOptions? _distributedCacheEntryOptions;
    private readonly JsonSerializerSettings? _jsonSerializerSettings;

    public CacheService(IDistributedCache distributedCache, IOptions<RedisOptions> redisOptions)
    {
        _distributedCache = distributedCache;
        if (redisOptions.Value != null)
        {
            _redisOptions = redisOptions.Value;
        }

        _distributedCacheEntryOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_redisOptions!.CacheExpiration)
        };

        _jsonSerializerSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new PrivateResolver()
        };
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var cacheResult = await _distributedCache.GetStringAsync(key, cancellationToken);

        if (string.IsNullOrEmpty(cacheResult))
        {
            return default;
        }

        return JsonConvert.DeserializeObject<T>(cacheResult);
    }

    public async Task SetAsync<T>(
        string key,
        T value,
        CancellationToken cancellationToken = default
    )
    {
        await _distributedCache.SetStringAsync(
            key,
            JsonConvert.SerializeObject(value, _jsonSerializerSettings),
            _distributedCacheEntryOptions!,
            cancellationToken
        );
    }

    public async Task SetAsync<T>(
        string key,
        T value,
        TimeSpan timeSpan = default,
        CancellationToken cancellationToken = default
    )
    {
        await _distributedCache.SetStringAsync(
            key,
            JsonConvert.SerializeObject(value, _jsonSerializerSettings),
            new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = timeSpan },
            cancellationToken
        );
    }
}
