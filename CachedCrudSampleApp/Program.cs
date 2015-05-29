using System;

namespace CachedCrudSampleApp {
    class Program {
        private static void Main(string[] args) {
            var mgr = CachedDataItemManager.Default;

            Console.WriteLine("CREATE and READ two records (from data store)");
            var itemA = mgr.Read(mgr.Create(new DataItem() {LastName = "Doe", FirstName = "John"})); 
            Console.WriteLine(itemA);
            var itemB = mgr.Read(mgr.Create(new DataItem() {LastName = "Doe", FirstName = "Jane"})); 
            Console.WriteLine(itemB);

            Console.WriteLine("\nREAD both again (from cache this time; no datastore access)");
            Console.WriteLine(mgr.Read(itemA.Id));
            Console.WriteLine(mgr.Read(itemB.Id));

            Console.WriteLine("\nUPDATE the second item");
            itemB.LastName = "Smith";
            mgr.Update(itemB.Id, itemB);

            Console.WriteLine("\nREAD both again (the first is in the cache, the second must be read from the data store because it was updated)");
            Console.WriteLine(mgr.Read(itemA.Id));
            Console.WriteLine(mgr.Read(itemB.Id));

            Console.WriteLine("Done");
        }
    }
}
