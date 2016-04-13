using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Baidu
{
    public sealed class Server : Segment
    {
        public static Server RestServer = new Server("restserver");

        private Server(string name) : base(name) { }
    }
}
