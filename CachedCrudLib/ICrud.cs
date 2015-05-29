
namespace CachedCrudLib {
    public interface ICrud<TKey, TData> {
        /// <summary>
        /// Creates a new item in the data store.
        /// </summary>
        /// <param name="obj">The object to add to the data store.</param>
        /// <returns>The key value of the object in the data store.</returns>
        TKey Create(TData obj);

        /// <summary>
        /// Returns an item from the data store for the given key.
        /// </summary>
        TData Read(TKey key);

        /// <summary>
        /// Updates an item in the data store with the given key and data.
        /// </summary>
        void Update(TKey key, TData obj);

        /// <summary>
        /// Removes an item from the data store with the given key.
        /// </summary>
        void Delete(TKey key);
    }
}
