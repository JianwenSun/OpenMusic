using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OpenMusic.Wpf.Ioc
{
    using Ico;
    using ViewModels;

    public class IocInjectorConverter : IValueConverter
    {
        static IocInjectorConverter instance;
        public static IocInjectorConverter Instance
        {
            get { return instance ?? (instance = new IocInjectorConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IocInjector iocInjector = value as IocInjector;
            if(iocInjector != null)
            {
                IViewModelProvider viewModelProvider = iocInjector.Resolve<IViewModelProvider>();
                if (viewModelProvider != null)
                    return viewModelProvider.GetViewModel(parameter as Type);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
