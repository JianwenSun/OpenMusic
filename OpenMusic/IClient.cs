using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic
{
    public interface IClient
    {
        string Id { get; set; }
        string Password { get; set; }

        IServiceProvider ServiceProvider { get; set; }
    }
}