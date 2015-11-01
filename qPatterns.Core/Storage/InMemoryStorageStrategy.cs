using System.Collections;

namespace qPatterns.Core.Storage
{
    public class InMemoryStorageStrategy : IStorageStrategy<string, CacheableItem>
    {
        private static Hashtable items;

        static InMemoryStorageStrategy()
        {
            items = Hashtable.Synchronized(new Hashtable());
        }

        public InMemoryStorageStrategy()
        {

        }

        public void Put(string key, CacheableItem value)
        {
            items[(object)key] = (object)value;
        }

        public CacheableItem Get(string key)
        {
            CacheableItem cacheItem = (CacheableItem)null;
            if (items.ContainsKey((object)key))
                cacheItem = (CacheableItem)items[(object)key];
            return cacheItem;
        }

        public void Remove(string key)
        {
            if (!items.ContainsKey((object)key))
                return;
            items.Remove((object)key);
        }
    }
}
