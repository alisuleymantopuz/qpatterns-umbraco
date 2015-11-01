using System.Runtime.Remoting.Messaging;
using System.Web;

namespace qPatterns.Core.Storage
{
    public class HttpContextStorageStrategy : IStorageStrategy<string, CacheableItem>
    {
        public HttpContextStorageStrategy()
        {

        }

        public void Put(string key, CacheableItem value)
        {
            HttpContext current = HttpContext.Current;
            if (current != null)
                current.Items[(object)key] = (object)value;
            else
                CallContext.SetData(key, (object)value);
        }

        public CacheableItem Get(string key)
        {
            HttpContext current = HttpContext.Current;
            if (current == null)
                return CallContext.GetData(key) as CacheableItem;
            if (current.Items.Contains((object)key))
                return current.Items[(object)key] as CacheableItem;
            else
                return null;
        }

        public void Remove(string key)
        {
            HttpContext current = HttpContext.Current;
            if (current != null)
                current.Items.Remove((object)key);
            else
                CallContext.FreeNamedDataSlot(key);
        }
    }
}
