using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu
{
    public class BaiduClient : Client, IBaiduClient
    {
        public static BaiduClient Guest { get; set; }

        static BaiduClient()
        {
            Guest = new BaiduClient("Guest", string.Empty);
        }

        public IBaiduRestClient RestClient { get; set; }

        public override IServiceProvider ServiceProvider { get; set; }

        public BaiduClient(string id, string password) : base(id, password)
        {
            this.RestClient = new BaiduRestClient(this);
            this.ServiceProvider = new BaiduServiceProvider(this);
        }
    }
}
