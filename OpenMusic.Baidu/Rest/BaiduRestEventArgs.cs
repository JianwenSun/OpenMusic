using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu
{
    public class BaiduRestEventArgs : EventArgs
    {
        public IBaiduRestClient Client { get; set; }
        public BaiduRestRequest Request { get; set; }
        public BaiduRestResponse Response { get; set; }
    }
}
