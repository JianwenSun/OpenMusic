using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OpenMusic.Wpf.Converters
{
    public class DisplayConverter : IValueConverter
    {
        static DisplayConverter instance;
        public static DisplayConverter Instance
        {
            get
            {
                return instance ?? (instance = new DisplayConverter());
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
            {
                FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
                if(fieldInfo != null)
                {
                    DisplayAttribute displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();
                    if (displayAttribute != null)
                        return displayAttribute.Name;
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
