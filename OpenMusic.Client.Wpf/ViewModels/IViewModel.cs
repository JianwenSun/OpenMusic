using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf.ViewModels
{
    using OpenMusic.Services;

    public interface IViewModel : INotifyPropertyChanged
    {
        ServiceProvider ServiceProvider { get; }
    }
}
