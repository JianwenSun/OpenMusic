using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf.ViewModels
{
    using OpenMusic.Services;

    public abstract class BaseViewModel : IViewModel
    {
        public static bool IsInDesineMode
        {
            get { return System.ComponentModel.DesignerProperties.GetIsInDesignMode(App.Current.MainWindow); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ServiceProvider ServiceProvider { get; private set; }

        public BaseViewModel(ServiceProvider serviceProvier)
        {
            this.ServiceProvider = serviceProvier;
        }

        protected void RasiePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
