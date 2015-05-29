
namespace CachedCrudLib {
    public interface ICache {
        object Get(string cacheKey);
        void Insert(string cacheKey, object obj);
        void Remove(string cacheKey);
    }
}
