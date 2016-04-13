using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu
{

    [DataContract]
    public class suggestion : IContentResult
    {
        [DataMember]
        public string query { get; set; }
        [DataMember]
        public List<string> suggestion_list { get; set; }

        public suggestion()
        {
            this.suggestion_list = new List<string>();
        }
    }
}
