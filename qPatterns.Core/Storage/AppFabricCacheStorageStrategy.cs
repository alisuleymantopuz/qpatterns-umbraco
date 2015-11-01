using Microsoft.ApplicationServer.Caching;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;

namespace qPatterns.Core.Storage
{
    public class AppFabricCacheStorageStrategy : IStorageStrategy<string, CacheableItem>
    {
        public CoreConfiguration CoreConfiguration { get; private set; }

        public DataCacheFactory Factory { get; private set; }

        public DataCache Cache { get; private set; }

        public AppFabricCacheStorageStrategy(CoreConfiguration coreConfiguration)
        {
            CoreConfiguration = coreConfiguration;
            Initialize();
        }


        private void Initialize()
        {
            if (string.IsNullOrEmpty(CoreConfiguration.AppFabricCacheHostName))
                throw new ConfigurationErrorsException("AppFabricCacheHostName should be declared in configuration for AppFabric Caching to work.");
            if (!CoreConfiguration.AppFabricCachePortNumber.HasValue)
                throw new ConfigurationErrorsException("AppFabricCachePortNumber should be declared in configuration for AppFabric Caching to work.");

            List<DataCacheServerEndpoint> list1 = new List<DataCacheServerEndpoint>();
            list1.Add(new DataCacheServerEndpoint(CoreConfiguration.AppFabricCacheHostName, CoreConfiguration.AppFabricCachePortNumber.Value));

            List<DataCacheServerEndpoint> list2 = list1;
            DataCacheFactoryConfiguration factoryConfiguration = new DataCacheFactoryConfiguration();
            factoryConfiguration.Servers = list2;
            factoryConfiguration.LocalCacheProperties = new DataCacheLocalCacheProperties();

            DataCacheFactoryConfiguration configuration = factoryConfiguration;
            int num = (int)DataCacheClientLogManager.ChangeLogLevel(TraceLevel.Off);
            Factory = new DataCacheFactory(configuration);
            Cache = Factory.GetCache("default");
            Cache.CreateRegion(CoreConfiguration.AppFabricCacheRegionForApplication);
        }


        public void Put(string key, CacheableItem value)
        {
            Cache.Put(key, (object)value, CoreConfiguration.AppFabricCacheRegionForApplication);
        }

        public CacheableItem Get(string key)
        {
            return (CacheableItem)Cache.Get(key, CoreConfiguration.AppFabricCacheRegionForApplication);
        }

        public void Remove(string key)
        {
            Cache.Remove(key, CoreConfiguration.AppFabricCacheRegionForApplication);
        }
    }
}
