using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Baidu
{
    [Parameter(Key = "format")]
    public sealed class Format : Parameter
    {
        public static Format Xml = new Format("xml");
        public static Format Json = new Format("json");

        private Format(string value) : base(value) { }
    }
}
