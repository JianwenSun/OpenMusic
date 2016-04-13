using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu
{
    using Converters;

    /*
        "album_id": "130208313",
        "author": "12 Stones",
        "hot": 35,
        "title": "We Are One",
        "artist_id": "1462775",
        "all_artist_id": "1462775",
        "company": "\u73af\u7403\u5531\u7247",
        "publishtime": "2014-12-08",
        "album_desc": "",
        "pic_small": "http:\/\/qukufile2.qianqian.com\/data2\/pic\/130209152\/130209152.jpg"
    */

    [DataContract, ContentConverter(Converter = typeof(AlbumConverter))]
    public class album
    {
        [DataMember]
        public string album_id { get; set; }
        [DataMember]
        public string author { get; set; }
        [DataMember]
        public int hot { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string artist_id { get; set; }
        [DataMember]
        public string all_artist_id { get; set; }
        [DataMember]
        public string company { get; set; }
        [DataMember]
        public string publishtime { get; set; }
        [DataMember]
        public string album_desc { get; set; }
        [DataMember]
        public string pic_small { get; set; }
    }
}
