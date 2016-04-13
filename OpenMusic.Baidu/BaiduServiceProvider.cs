using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OpenMusic.Baidu
{
    using OpenMusic.Services;

    public class BaiduServiceProvider : ServiceProvider
    {
        static Dictionary<Type, Type> _dic = new Dictionary<Type, Type>();

        static BaiduServiceProvider()
        {
            CollectServices();
        }

        static void CollectServices()
        {
            foreach (var type in typeof(BaiduServiceProvider).GetTypeInfo().Assembly.ExportedTypes)
            {
                ServiceAttribute serviceAttribute = type.GetTypeInfo().GetCustomAttribute<ServiceAttribute>();
                if(serviceAttribute != null)
                {
                    _dic.Add(serviceAttribute.ServiceType, serviceAttribute.ServiceImpType);
                }
            }
        }

        public BaiduServiceProvider(IClient client) : base(client)
        {
            foreach (var keyPair in _dic)
            {
                this.Services.Add(keyPair.Key, (IService)Activator.CreateInstance(keyPair.Value, client));
            }
        }

        public override object GetService(Type serviceType)
        {
            IService service = null;
            if(this.Services.TryGetValue(serviceType, out service))
            {
                return service;
            }
            return null;
        }

        public override T GetService<T>()
        {
            return (T)this.GetService(typeof(T));
        }
    }
}
