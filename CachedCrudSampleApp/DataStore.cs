using System;
using System.Collections.Generic;

namespace CachedCrudSampleApp {
    /// <summary>
    /// DataStore is a singleton array meant to act a little like a database, and is used in the sample app as a data store. 
    /// Generally the DataItemManager would read/write directly to a database, web service, or other permanent store.
    /// </summary>
    class DataStore {
        public static readonly DataStore Instance = new DataStore();
        private readonly List<DataItem> _store = new List<DataItem>();
 
        private DataStore() {
        }

        public int Insert(DataItem data) {
            int newId;
            lock (_store) {
                newId = _store.Count;
                data.Id = newId;
                _store.Add(data);
            }
            Console.WriteLine("DataStore: Insert {0}", newId);
            return newId;
        }

        public void Update(int id, DataItem data) {
            Console.WriteLine("DataStore: Update {0}", id);
            _store[id] = data;
        }

        public DataItem Select(int id) {
            Console.WriteLine("DataStore: Select {0}", id);
            return _store[id];
        }

        public void Delete(int id) {
            Console.WriteLine("DataStore: Delete {0}", id);
            _store[id] = null;
        }
    }
}
