using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

public class TokenCacheService
{
    private readonly MemoryCache _cache;

    public TokenCacheService()
    {
        _cache = new MemoryCache(new MemoryCacheOptions());
    }

    public void StoreToken(string accountId, string token, bool rememberMe)
    {
        var options = new MemoryCacheEntryOptions();
        if (rememberMe)
        {
            options.SlidingExpiration = TimeSpan.FromDays(7);
        }
        else
        {
            options.SlidingExpiration = TimeSpan.FromHours(24);
        }
        _cache.Set(accountId, token, options);
    }

    public bool ValidateToken(string accountId, string token)
    {
        if (_cache.TryGetValue(accountId, out string cachedToken))
        {
            return token == cachedToken;
        }
        return false;
    }

    public void InvalidateToken(string accountId)
    {
        _cache.Remove(accountId);
    }
}