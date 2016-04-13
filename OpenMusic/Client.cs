using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic
{
    public abstract class Client : IClient
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public abstract IServiceProvider ServiceProvider { get; set; }

        public Client(string id, string password)
        {
            this.Id = id;
            this.Password = password;
        }
    }
}