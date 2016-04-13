using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf.CacheStorage
{
    public class CacheStorageService : ICacheStorageService
    {
        static Dictionary<IClient, ICacheStorage> cacheStorages = new Dictionary<IClient, ICacheStorage>();

        public static ICacheStorage GetCacheStorage(IClient client)
        {
            ICacheStorage cacheStorage = null;
            if(!cacheStorages.TryGetValue(client, out cacheStorage))
            {
                cacheStorage = new FileSystemCache(string.Format("{0}/OpenMusic/{1}",
                 Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), client.Id));
                cacheStorages.Add(client, cacheStorage);
            }
            return cacheStorage;
        }

        public IClient Client { get; private set; }

        public ICacheStorage CacheStorage { get; set; }

        public CacheStorageService(IClient client)
        {
            this.Client = client;
            this.CacheStorage = GetCacheStorage(Client);
        }
    }
}
