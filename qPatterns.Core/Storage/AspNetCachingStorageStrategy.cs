using System.Web;
using System.Web.Caching;

namespace qPatterns.Core.Storage
{
    public class AspNetCachingStorageStrategy : IStorageStrategy<string, CacheableItem>
    {
        private readonly Cache items;

        public AspNetCachingStorageStrategy()
        {
            items = HttpRuntime.Cache;
        }

        public void Put(string key, CacheableItem value)
        {
            items.Insert(key, (object)value, value.CacheDependency, value.AbsoluteExpiration, value.SlidingExpiration, value.CacheItemPriority, value.CacheItemRemovedCallback);
        }

        public CacheableItem Get(string key)
        {
            return items[key] as CacheableItem;
        }

        public void Remove(string key)
        {
            items.Remove(key);
        }
    }
}
