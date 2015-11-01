using System;
using System.Web.Caching;

namespace qPatterns.Core.Storage
{
    [Serializable]
    public class CacheableItem
    {
        private object item;
        private CacheDependency cacheDependency;
        private DateTime absoluteExpiration;
        private TimeSpan slidingExpiration;
        private CacheItemPriority cacheItemPriority;
        private CacheItemRemovedCallback cacheItemRemovedCallback;

        public object Item
        {
            get
            {
                return item;
            }
        }

        public CacheDependency CacheDependency
        {
            get
            {
                return cacheDependency;
            }
        }

        public DateTime AbsoluteExpiration
        {
            get
            {
                return absoluteExpiration;
            }
        }

        public TimeSpan SlidingExpiration
        {
            get
            {
                return slidingExpiration;
            }
        }

        public CacheItemPriority CacheItemPriority
        {
            get
            {
                return cacheItemPriority;
            }
        }

        public CacheItemRemovedCallback CacheItemRemovedCallback
        {
            get
            {
                return cacheItemRemovedCallback;
            }
        }

        public CacheableItem(object item, CacheDependency cacheDependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority cacheItemPriority, CacheItemRemovedCallback cacheItemRemovedCallback)
        {
            item = item;
            cacheDependency = cacheDependency;
            absoluteExpiration = absoluteExpiration;
            slidingExpiration = slidingExpiration;
            cacheItemPriority = cacheItemPriority;
            cacheItemRemovedCallback = cacheItemRemovedCallback;
        }

        public CacheableItem(object item)
        {
            item = item;
            cacheDependency = (CacheDependency)null;
            absoluteExpiration = Cache.NoAbsoluteExpiration;
            slidingExpiration = Cache.NoSlidingExpiration;
            cacheItemPriority = CacheItemPriority.NotRemovable;
            cacheItemRemovedCallback = (CacheItemRemovedCallback)null;
        }
    }
}
