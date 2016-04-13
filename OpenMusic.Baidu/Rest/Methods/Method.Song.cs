using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu
{
    public class SongMethod : Method
    {
        public const string Prefix = "baidu.ting.song";

        static SongMethod New
        {
            get { return new SongMethod(); }
        }

        #region Json format

        /*{"songurl": {
            "url": [
              {
                "show_link": "",
                "down_type": 0,
                "original": 0,
                "free": 1,
                "replay_gain": "0.690002",
                "song_file_id": 42822293,
                "file_size": 1665970,
                "file_extension": "mp3",
                "file_duration": 208,
                "can_see": 1,
                "can_load": true,
                "preload": 40,
                "file_bitrate": 64,
                "file_link": "http:\/\/yinyueshiting.baidu.com\/data2\/music\/42822293\/42822293.mp3?xcode=6b33a701d30e174660e85653b43f0cf4",
                "is_udition_url": 0,
                "hash": "7eb557bab03a343dfdb911f7e37291e28011a9ef"
              },
              {
                "show_link": "http:\/\/pan.baidu.com\/share\/link?shareid=1752147500&uk=3495150420",
                "down_type": 1,
                "original": 0,
                "free": 1,
                "replay_gain": "0.720001",
                "song_file_id": 42822116,
                "file_size": 3332482,
                "file_extension": "mp3",
                "file_duration": 208,
                "can_see": 1,
                "can_load": true,
                "preload": 80,
                "file_bitrate": 128,
                "file_link": "http:\/\/yinyueshiting.baidu.com\/data2\/music\/134378936\/134378936.mp3?xcode=6b33a701d30e174660e85653b43f0cf4",
                "is_udition_url": 1,
                "hash": "22e807c65dc485b030698e028dbbcee2fdf59ba1"
              }
            ]
          },
          "error_code": 22000,
          "songinfo": {
            "resource_type_ext": "0",
            "pic_huge": "http:\/\/c.hiphotos.baidu.com\/ting\/pic\/item\/5ab5c9ea15ce36d3b8af5c1138f33a87e950b16c.jpg",
            "resource_type": "2",
            "del_status": "1",
            "album_1000_1000": "http:\/\/c.hiphotos.baidu.com\/ting\/pic\/item\/5ab5c9ea15ce36d3b8af5c1138f33a87e950b16c.jpg",
            "pic_singer": "",
            "album_500_500": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/c8ea15ce36d3d539d896d0e23887e950352ab06c.jpg",
            "havehigh": 2,
            "piao_id": "0",
            "song_source": "web",
            "korean_bb_song": "0",
            "compose": "Tedder",
            "toneid": "0",
            "area": "2",
            "original_rate": "",
            "bitrate": "64,128,192,256,320,24,819",
            "artist_500_500": "http:\/\/musicdata.baidu.com\/data2\/pic\/246937325\/246937325.jpg",
            "multiterminal_copytype": "02",
            "has_mv": 1,
            "file_duration": "207",
            "album_title": "Apologize",
            "sound_effect": "0",
            "title": "Apologize",
            "high_rate": "320",
            "pic_radio": "http:\/\/musicdata.baidu.com\/data2\/pic\/117455229\/117455229.jpg",
            "is_first_publish": 0,
            "hot": "8911",
            "language": "英语",
            "lrclink": "http:\/\/musicdata.baidu.com\/data2\/lrc\/247606898\/Apologize.lrc",
            "distribution": "0000000000,0000000000,0000000000,0000000000,0000000000,0000000000,0000000000,1111110000,1111110000,0000000000",
            "relate_status": "0",
            "learn": 0,
            "play_type": 0,
            "pic_big": "http:\/\/musicdata.baidu.com\/data2\/pic\/117455259\/117455259.jpg",
            "pic_premium": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/c8ea15ce36d3d539d896d0e23887e950352ab06c.jpg",
            "artist_480_800": "http:\/\/musicdata.baidu.com\/data2\/pic\/105447859\/105447859.jpg",
            "aliasname": "",
            "country": "欧美",
            "artist_id": "1138",
            "album_id": "8059245",
            "original": 0,
            "compress_status": "0",
            "versions": "",
            "expire": 36000,
            "ting_uid": "381293",
            "artist_1000_1000": "http:\/\/musicdata.baidu.com\/data2\/pic\/246937314\/246937314.jpg",
            "all_artist_id": "1138",
            "artist_640_1136": "http:\/\/musicdata.baidu.com\/data2\/pic\/105447856\/105447856.jpg",
            "publishtime": "2007-11-05",
            "charge": 1,
            "copy_type": "1",
            "songwriting": "Tedder",
            "share_url": "http:\/\/music.baidu.com\/song\/s\/53067af96f08564d8307",
            "author": "OneRepublic",
            "has_mv_mobile": 1,
            "all_rate": "24,64,128,192,256,320,flac",
            "pic_small": "http:\/\/musicdata.baidu.com\/data2\/pic\/117455287\/117455287.jpg",
            "album_no": "2",
            "song_id": "8059247",
            "is_charge": "1"
          }
        }*/

        #endregion
        /// <summary>
        /// get song info
        /// </summary>
        /// <param name="songid"></param>
        /// <returns></returns>
        /// AES 加密 E
        public static SongMethod GetInfos(string songid)
        {
            SongMethod song = SongMethod.New;
            song.Value = string.Format("{0}.getInfos", Prefix);
            song.Parameters.Add(Parameter.Make("songid", songid));
            song.Parameters.Add(Parameter.Make("e", string.Empty));
            return song;
        }

        #region Json format

        /*{"songurl": {
            "url": [
              {
                "file_bitrate": 128,
                "file_link": "http:\/\/yinyueshiting.baidu.com\/data2\/music\/134378936\/134378936.mp3?xcode=59cfc380f0eb0bbf5fa4084c7da1aa86",
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
                "file_link": "http:\/\/yinyueshiting.baidu.com\/data2\/music\/35417988\/35417988.mp3?xcode=59cfc380f0eb0bbf5fa4084c7da1aa86",
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
        }*/

        #endregion
        /// <summary>
        /// get song infos
        /// </summary>
        /// <param name="songid"></param>
        /// <returns></returns>
        public static SongMethod GetInfo(string songid)
        {
            SongMethod song = SongMethod.New;
            song.Value = string.Format("{0}.getInfo", Prefix);
            song.Parameters.Add(Parameter.Make("songid", songid));
            return song;
        }
    }
}
