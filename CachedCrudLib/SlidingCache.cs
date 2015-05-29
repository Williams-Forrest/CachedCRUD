using System;
using System.Runtime.Caching;

namespace CachedCrudLib {
    public class SlidingCache : ICache {
        private readonly TimeSpan _defaultExpiration = TimeSpan.FromMinutes(5);

        public SlidingCache() {
        }

        public SlidingCache(TimeSpan defaultExpiration) {
            _defaultExpiration = defaultExpiration;
        }

        public object Get(string cacheKey) {
            return MemoryCache.Default.Get(cacheKey);
        }

        public void Insert(string cacheKey, object obj) {
            Insert(cacheKey, obj, _defaultExpiration);
        }

        public void Insert(string cacheKey, object obj, TimeSpan expiration) {
            MemoryCache.Default.Add(cacheKey, obj, new CacheItemPolicy() {SlidingExpiration = expiration});
        }

        public void Remove(string cacheKey) {
            MemoryCache.Default.Remove(cacheKey);
        }
    }
}
