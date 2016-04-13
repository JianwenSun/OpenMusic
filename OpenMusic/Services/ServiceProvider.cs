using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Services
{
    public abstract class ServiceProvider : IServiceProvider
    {
        public Dictionary<Type, IService> Services = new Dictionary<Type, IService>();

        public IClient Client { get; private set; }

        public ServiceProvider(IClient client)
        {
            this.Client = client;
        }

        public abstract object GetService(Type serviceType);

        public abstract T GetService<T>();
    }
}
