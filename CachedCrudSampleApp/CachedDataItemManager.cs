using CachedCrudLib;

namespace CachedCrudSampleApp {
    class CachedDataItemManager : CachedCrud<int, DataItem> {
        public static CachedDataItemManager Default = new CachedDataItemManager(new FixedExpirationCache(), new DataItemManager());

        public CachedDataItemManager(ICache cache, ICrud<int, DataItem> service)
            : base(cache, service) {
        }
    }
}
