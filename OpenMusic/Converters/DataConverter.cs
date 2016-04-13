using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OpenMusic.Conveters
{
    public static class DataConverter
    {
        public static object Convert(object obj)
        {
            DataConverterAttribute attribute = obj.GetType().GetTypeInfo().GetCustomAttribute<DataConverterAttribute>();
            if (attribute != null)
                return attribute.Convert(obj);
            return null;
        }
    }

    public abstract class DataConverter<T, O> : IDataConverter
    {
        public object Convert(object obj)
        {
            return Convert((O)obj);
        }

        public abstract T Convert(O obj);
    }
}
