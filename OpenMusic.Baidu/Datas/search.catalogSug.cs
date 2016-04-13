using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu
{
    [DataContract]
    public class catalogSug : IContentResult
    {
        [DataMember]
        public List<_song> song { get; set; }
        [DataMember]
        public List<_album> album { get; set; }
        [DataMember]
        public List<_artist> artist { get; set; }
        [DataMember]
        public string order { get; set; }
        [DataMember]
        public int error_code { get; set; }

        public catalogSug()
        {
            this.song = new List<_song>();
            this.album = new List<_album>();
            this.artist = new List<_artist>();
        }

        /*
         "bitrate_fee": "{\"0\":\"0|0\",\"1\":\"0|0\"}",
          "yyr_artist": "0",
          "songname": "17岁",
          "artistname": "刘德华",
          "control": "0000000000",
          "songid": "1574366",
          "has_mv": "1",
          "encrypted_songid": "68061805de095684fae7L"
        */
        [DataContract]
        public class _song
        {
            [DataMember]
            public string bitrate_fee { get; set; }
            [DataMember]
            public string yyr_artist { get; set; }
            [DataMember]
            public string songname { get; set; }
            [DataMember]
            public string artistname { get; set; }
            [DataMember]
            public string control { get; set; }
            [DataMember]
            public string songid { get; set; }
            [DataMember]
            public string has_mv { get; set; }
            [DataMember]
            public string encrypted_songid { get; set; }
        }

        /*
        "albumname": "1997-2007跨世纪国语精选",
        "artistpic": "http:\/\/qukufile2.qianqian.com\/data2\/pic\/117455394\/117455394.jpg",
        "albumid": "7311420",
        "artistname": "陈奕迅"
        */
        [DataContract]
        public class _album
        {
            [DataMember]
            public string albumname { get; set; }
            [DataMember]
            public string artistpic { get; set; }
            [DataMember]
            public string albumid { get; set; }
            [DataMember]
            public string artistname { get; set; }
        }

        /*
        "yyr_artist": "0",
        "artistid": "90655619",
        "artistpic": "http:\/\/a.hiphotos.baidu.com\/ting\/abpic\/item\/63d0f703918fa0ec4cebb41d209759ee3d6ddbf6.jpg",
        "artistname": "19"
        */
        [DataContract]
        public class _artist
        {
            [DataMember]
            public string yyr_artist { get; set; }
            [DataMember]
            public string artistid { get; set; }
            [DataMember]
            public string artistpic { get; set; }
            [DataMember]
            public string artistname { get; set; }
        }
    }
}
