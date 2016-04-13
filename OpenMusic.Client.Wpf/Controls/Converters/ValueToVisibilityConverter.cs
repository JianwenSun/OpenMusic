using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace OpenMusic.Wpf.Converters
{
    public class ValueToVisibilityConverter : IValueConverter
    {
        static ValueToVisibilityConverter instance;
        public static ValueToVisibilityConverter Instance
        {
            get
            {
                return instance ?? (instance = new ValueToVisibilityConverter());
            }
        }

        static ValueToVisibilityConverter uninstance;
        public static ValueToVisibilityConverter UnInstance
        {
            get
            {
                return uninstance ?? (uninstance = new ValueToVisibilityConverter() { NoEqual = true });
            }
        }

        public bool NoEqual
        {
            get;
            set;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (NoEqual)
            {
                if (!value.Equals(parameter)) return Visibility.Visible;
                return Visibility.Collapsed;
            }
            else
            {
                if (value.Equals(parameter)) return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
