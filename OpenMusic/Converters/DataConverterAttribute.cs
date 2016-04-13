using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OpenMusic.Conveters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DataConverterAttribute : Attribute
    {
        public Type Converter { get; set; }

        public object Convert(object obj)
        {
            if (this.Converter.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IDataConverter)))
            {
                IDataConverter converter = Activator.CreateInstance(this.Converter) as IDataConverter;
                return converter.Convert(obj);
            }

            return null;
        }
    }
}
