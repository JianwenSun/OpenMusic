using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace OpenMusic.Baidu
{
    [Parameter(Key = "version")]
    public sealed class FromVersion : Parameter
    {
        public static FromVersion V2_1_0 = new FromVersion("2.1.0");

        private FromVersion(string value) : base(value) { }
    }
}
