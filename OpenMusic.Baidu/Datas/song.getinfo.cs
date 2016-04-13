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

    #region Json Format
    /*
    {
      "songurl": {
        "url": [
          {
            "file_bitrate": 128,
            "file_link": "http:\/\/yinyueshiting.baidu.com\/data2\/music\/134378936\/134378936.mp3?xcode=0d13055719b9b7a2ed47f60d337fa3fd",
            "file_extension": "mp3",
            "file_size": 3332482,
            "file_duration": 208,
            "song_file_id": 42822116,
            "show_link": "http:\/\/pan.baidu.com\/share\/link?shareid=1752147500\u0026uk=3495150420",
            "hash": "22e807c65dc485b030698e028dbbcee2fdf59ba1",
            "can_load": true,
            "can_see": 1,
            "is_udition_url": 1,
            "original": 0,
            "preload": 80,
            "down_type": 1,
            "replay_gain": "0.720001"
          },
          {
            "file_bitrate": 192,
            "file_link": "http:\/\/yinyueshiting.baidu.com\/data2\/music\/35417988\/35417988.mp3?xcode=0d13055719b9b7a2ed47f60d337fa3fd",
            "file_extension": "mp3",
            "file_size": 5033374,
            "file_duration": 207,
            "song_file_id": 35417988,
            "show_link": "",
            "hash": "05027ea98fd805eee3ee7f4b74693343146ab1bf",
            "can_load": true,
            "can_see": 1,
            "is_udition_url": 0,
            "original": 0,
            "preload": 120,
            "down_type": 0,
            "replay_gain": "0.449997"
          }
        ]
      },
      "songinfo": {
        "song_id": "0",
        "title": null,
        "ting_uid": "0",
        "artist_id": "0",
        "author": "",
        "album_id": "0",
        "album_title": "",
        "language": "",
        "pic_big": "",
        "pic_small": "",
        "country": "",
        "area": "",
        "publishtime": "",
        "album_no": "",
        "lrclink": "",
        "versions": "",
        "copy_type": "1",
        "file_duration": "",
        "hot": "",
        "charge": 0,
        "havehigh": 0,
        "all_artist_ting_uid": "",
        "is_first_publish": 0,
        "pic_premium": "",
        "pic_huge": "",
        "pic_singer": "",
        "has_mv": 0,
        "learn": 0,
        "song_source": "",
        "all_rate": "",
        "resource_type": "",
        "piao_id": "0",
        "korean_bb_song": "0",
        "resource_type_ext": "0",
        "mv_provider": "",
        "errcode": 200,
        "errmsg": "content not exist",
        "content": -2,
        "pic_radio": "",
        "has_mv_mobile": 0,
        "play_type": "",
        "original": 0,
        "original_rate": "",
        "toneid": "0",
        "bitrate": "128,192",
        "expire": 36000
      },
      "error_code": 22000
    }
    */
    #endregion

    [DataContract, ContentConverter(Converter = typeof(SongInfoContentConverter))]
    public class getinfo : IContentResult
    {
        [DataMember]
        public _songurl songurl { get; set; }

        [DataMember]
        public string error_code { get; set; }

        [DataMember]
        public songinfos songinfo { get; set; }

        public getinfo()
        {
            this.songinfo = new songinfos();
        }

        [DataContract]
        public class _songurl
        {
            [DataMember]
            public List<url> url { get; set; }

            public _songurl()
            {
                this.url = new List<url>();
            }
        }
    }
}
