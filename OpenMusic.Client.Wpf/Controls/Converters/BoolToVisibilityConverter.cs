using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace OpenMusic.Wpf.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        static BoolToVisibilityConverter instance;
        public static BoolToVisibilityConverter Instance
        {
            get
            {
                return instance ?? (instance = new BoolToVisibilityConverter() { Direction = true });
            }
        }

        static BoolToVisibilityConverter uinstance;
        public static BoolToVisibilityConverter UnInstance
        {
            get
            {
                return uinstance ?? (uinstance = new BoolToVisibilityConverter() { Direction = false });
            }
        }

        public bool Direction
        {
            get;
            set;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                return (bool)value && Direction ? Visibility.Visible : Visibility.Collapsed;
            }

            if (value == null)
                return Visibility.Visible;

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Visibility)
            {
                switch ((Visibility)value)
                {
                    case Visibility.Collapsed:
                        return !Direction;
                    case Visibility.Hidden:
                        return !Direction;
                    case Visibility.Visible:
                        return Direction;
                    default:
                        break;
                }
            }
            return false;
        }
    }
}
