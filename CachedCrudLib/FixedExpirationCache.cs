using System;
using System.Runtime.Caching;

namespace CachedCrudLib {
    public class FixedExpirationCache : ICache {
        private readonly TimeSpan _defaultExpiration = TimeSpan.FromMinutes(5);

        public FixedExpirationCache() {
        }

        public FixedExpirationCache(TimeSpan defaultExpiration) {
            _defaultExpiration = defaultExpiration;
        }

        public object Get(string cacheKey) {
            return MemoryCache.Default.Get(cacheKey);
        }

        public void Insert(string cacheKey, object obj) {
            Insert(cacheKey, obj, _defaultExpiration);
        }

        public void Insert(string cacheKey, object obj, TimeSpan expiration) {
            MemoryCache.Default.Add(cacheKey, obj, new CacheItemPolicy() {AbsoluteExpiration = DateTimeOffset.Now.Add(expiration)});
        }

        public void Remove(string cacheKey) {
            MemoryCache.Default.Remove(cacheKey);
        }
    }
}
