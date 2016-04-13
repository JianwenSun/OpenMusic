using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OpenMusic.Wpf.Converters
{
    public class DurationTimeSpanConverter : IValueConverter
    {
        static DurationTimeSpanConverter instance;
        public static DurationTimeSpanConverter Instance
        {
            get
            {
                return instance ?? (instance = new DurationTimeSpanConverter());
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";
            TimeSpan duration = (TimeSpan)value;
            return string.Format("{0}:{1}", duration.Minutes, string.Format("{0:D2}", duration.Seconds));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
