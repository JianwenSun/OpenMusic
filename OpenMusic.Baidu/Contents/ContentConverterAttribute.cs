using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu
{
    using OpenMusic.Contents;

    [AttributeUsage(AttributeTargets.Class)]
    public class ContentConverterAttribute : Attribute
    {
        public Type Converter { get; set; }

        public object Convert(object result)
        {
            if (this.Converter.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IContentConverter)))
            {
                IContentConverter converter = Activator.CreateInstance(this.Converter) as IContentConverter;
                return converter.Convert(result);
            }
            return null;
        }

        public void Convert(Content content, object result)
        {
            if (this.Converter.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IContentConverter)))
            {
                IContentConverter converter = Activator.CreateInstance(this.Converter) as IContentConverter;
                converter.Convert(content, result);
            }
        }
    }
}
