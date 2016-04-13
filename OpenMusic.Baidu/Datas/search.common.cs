using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu
{
    [DataContract, ContentConverter(Converter = typeof(SongContentConverter))]
    public class common : IContentResult
    {
        [DataMember]
        public string query { get; set; }
        [DataMember]
        public int is_artist { get; set; }
        [DataMember]
        public int is_album { get; set; }
        [DataMember]
        public string rs_words { get; set; }
        [DataMember]
        public _pages pages { get; set; }
        [DataMember]
        public List<song> song_list { get; set; }

        public common()
        {
            this.pages = new _pages();
            this.song_list = new List<song>();
        }

        public class _pages
        {
            public string total { get; set; }
            public string rn_num { get; set; }
        }
    }
}
