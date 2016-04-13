using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf
{
    using Baidu;
    using CacheStorage;
    using Core;
    using Ico;
    using OpenMusic.Services;
    using ViewModels;

    public class ApplicationContent
    {
        static ApplicationContent _default;

        public static ApplicationContent Instance
        {
            get
            {
                return _default;
            }
            set
            {
                _default = value;
            }
        }

        public static void Initialize()
        {
            _default = new ApplicationContent(Build);
        }

        public IocInjector Injector { get; private set; }

        public ApplicationContent(Func<IocInjector> injectorFactory)
        {
            Injector = injectorFactory.Invoke();
        }

        static IocInjector Build()
        {
            var injector = new IocInjector();
            injector.Register<IocInjector>(injector);
            injector.Register<IClient>(BaiduClient.Guest);
            injector.Register<ICacheStorageService, CacheStorageService>();
            injector.Register<IViewModelProvider, ViewModelProvider>();
            injector.Register<ServiceProvider>(BaiduClient.Guest.ServiceProvider);
            injector.Register<PlayEngine>(new PlayEngine());
            return injector;
        }
    }
}
