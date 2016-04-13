using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Baidu
{
    public sealed class Version : Segment
    {
        public static Version V1 = new Version("V1");
        public static Version V2 = new Version("V2");

        private Version(string name) : base(name) { }
    }
}
