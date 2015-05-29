using CachedCrudLib;

namespace CachedCrudSampleApp {
    /// <summary>
    /// Normally a Manager class would write to a database, web service, or other permanent data store.
    /// The DataStore class is used here to represent actions typically done with a database.
    /// </summary>
    class DataItemManager : ICrud<int, DataItem> {
        public int Create(DataItem obj) {
            var newKey = DataStore.Instance.Insert(obj);
            return newKey;
        }

        public DataItem Read(int key) {
            return DataStore.Instance.Select(key);
        }

        public void Update(int key, DataItem obj) {
            DataStore.Instance.Update(key, obj);
        }

        public void Delete(int key) {
            DataStore.Instance.Delete(key);
        }
    }
}
