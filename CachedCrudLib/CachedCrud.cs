
namespace CachedCrudLib {
    /// <typeparam name="K">Key type</typeparam>
    /// <typeparam name="T">Data type</typeparam>
    public class CachedCrud<K, T> : ICrud<K, T> where T : class {
        protected ICache _cache;
        protected ICrud<K, T> _service;

        public CachedCrud(ICache cache, ICrud<K, T> service) {
            _cache = cache;
            _service = service;
        }

        public K Create(T obj) {
            var k = _service.Create(obj);
            return k;
        }

        public T Read(K key) {
            string cacheKey = GetCacheKey(key);
            var obj = _cache.Get(cacheKey) as T;
            if (obj == null) {
                obj = _service.Read(key);

                if (obj != null) {
                    _cache.Insert(cacheKey, obj);
                }
            }
            return obj;
        }

        public void Update(K key, T obj) {
            string cacheKey = GetCacheKey(key);
            _cache.Remove(cacheKey);
            _service.Update(key, obj);
        }

        public void Delete(K key) {
            string cacheKey = GetCacheKey(key);
            _cache.Remove(cacheKey);
            _service.Delete(key);
        }

        public void ClearCache(K key) {
            string cacheKey = GetCacheKey(key);
            _cache.Remove(cacheKey);
        }

        public string GetCacheKey(K key) {
            return typeof(T).Name + ":" + key;
        }
    }
}
