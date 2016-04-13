
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu
{
    using OpenMusic.Baidu.Converters;
    using OpenMusic.Conveters;

    /*  "artist_id": "73330871",
        "author": "\u5f20\u4eae\u4eae",
        "ting_uid": "110936311",
        "avatar_middle": "http:\/\/qukufile2.qianqian.com\/data2\/pic\/247111636\/247111636.jpg",
        "album_num": 0,
        "song_num": 28,
        "country": "\u4e2d\u56fd",
        "artist_desc": "",
        "artist_source": "yyr" */

    [DataContract, DataConverter(Converter = typeof(ArtistConverter))]
    public class artist
    {
        public string artist_id { get; set; }
        [DataMember]
        public string author { get; set; }
        [DataMember]
        public string ting_uid { get; set; }
        [DataMember]
        public string avatar_middle { get; set; }
        [DataMember]
        public int album_num { get; set; }
        [DataMember]
        public int song_num { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string artist_desc { get; set; }
        [DataMember]
        public string artist_source { get; set; }

    }
}
