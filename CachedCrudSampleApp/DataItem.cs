
namespace CachedCrudSampleApp {
    class DataItem {
        public int Id;
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public override string ToString() {
            return string.Format("{0}: {1}, {2}", Id, LastName, FirstName);
        }
    }
}
