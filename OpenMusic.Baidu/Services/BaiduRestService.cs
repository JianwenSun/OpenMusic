using OpenMusic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu.Services
{
    public class BaiduRestService
    {
        static Dictionary<IBaiduRestClient, BaiduRestService> Customs = new Dictionary<IBaiduRestClient, BaiduRestService>();

        public static BaiduRestService GetService(IBaiduRestClient client)
        {
            BaiduRestService service = null;
            if(!Customs.TryGetValue(client, out service))
            {
                service = new BaiduRestService(client);
                Customs.Add(client, service);
            }
            return service;
        }

        public event BaiduRestEventHandler Requested;

        public event BaiduRestEventHandler Responsed;

        public IBaiduRestClient Client { get; set; }

        private BaiduRestService(IBaiduRestClient client)
        {
            this.Client = client;
        }

        public void SendRequest(BaiduRestRequest request)
        {
            if (this.Requested != null)
                this.Requested(this, new BaiduRestEventArgs() { Client = this.Client, Request = request });
        }

        public void SendResponse(BaiduRestResponse response)
        {
            if (this.Responsed != null)
                this.Responsed(this, new BaiduRestEventArgs() { Client = this.Client, Request = response.Request, Response = response});
        }
    }
}
