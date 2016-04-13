using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OpenMusic.Baidu
{
    using OpenMusic.Contents;

    public static class ContentConverter
    {
        public static C Convert<C>(IContentResult result)
        {
            ContentConverterAttribute attribute = result.GetType().GetTypeInfo().GetCustomAttribute<ContentConverterAttribute>();
            if (attribute != null)
                return (C)attribute.Convert(result);
            return default(C);
        }

        public static void Convert<C>(C content, IContentResult result)
        {
            ContentConverterAttribute attribute = result.GetType().GetTypeInfo().GetCustomAttribute<ContentConverterAttribute>();
            if (attribute != null)
                attribute.Convert(content as Content, result);
        }
    }

    public abstract class ContentConverter<C, R> : IContentConverter
        where C : Content
        where R : IContentResult
    {
        public abstract C Convert(R result);
        public abstract void Convert(C content, R result);

        public void Convert(Content content, object result)
        {
            this.Convert((C)content, (R)result);
        }

        public Content Convert(object result)
        {
            return this.Convert((R)result);
        }
    }
}
