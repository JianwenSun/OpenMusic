using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Services
{
    /// <summary>
    /// Service
    /// </summary>
    public abstract class Service : IService
    {
        public IClient Client { get; set; }

        public Service(IClient client)
        {
            this.Client = client;
        }
    }
}
