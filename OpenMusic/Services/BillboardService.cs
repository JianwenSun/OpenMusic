using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Services
{
    public abstract class BillboardService : Service, IBillboardService
    {
        public BillboardService(IClient client) : base(client) { }
    }
}