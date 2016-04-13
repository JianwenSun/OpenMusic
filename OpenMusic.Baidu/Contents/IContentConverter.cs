using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu
{
    using OpenMusic.Contents;

    public interface IContentConverter
    {
        Content Convert(object result);
        void Convert(Content content, object result);
    }
}
