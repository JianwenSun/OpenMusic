using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf.ViewModels
{
    public interface IViewModelProvider
    {
        T GetViewModel<T>() where T : IViewModel;
        object GetViewModel(Type type);
    }
}
