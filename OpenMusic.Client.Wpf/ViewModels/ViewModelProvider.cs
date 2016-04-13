using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf.ViewModels
{
    using Ico;

    public class ViewModelProvider : IViewModelProvider
    {
        public IocInjector IocInjector { get; private set; }

        public ViewModelProvider(IocInjector iocInjector)
        {
            this.IocInjector = iocInjector;
        }

        public T GetViewModel<T>() where T : IViewModel
        {
            this.IocInjector.Register<T, T>();
            return this.IocInjector.Resolve<T>();
        }

        public object GetViewModel(Type type)
        {
            this.IocInjector.Register(type);
            return this.IocInjector.Resolve(type);
        }
    }
}
