using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace OpenMusic.Baidu
{
    [Parameter(Key = "from")]
    public sealed class From : Parameter
    {
        public static From WebappMusic = new From("webapp_music");
        public static From QianQian = new From("qianqian") { Version = FromVersion.V2_1_0 };
        public static From IOS = new From("ios");

        public FromVersion Version { get; set; }

        private From(string value) : base(value) { }
    }
}
