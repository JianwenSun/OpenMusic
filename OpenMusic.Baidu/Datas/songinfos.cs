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
    */

    /* property in songinfo no in songinfos
        "all_artist_ting_uid": "",
        "content": -2,
        "errcode": 200,
        "errmsg": "content not exist",
        "mv_provider": "",
    */
    #endregion

    [DataContract, DataConverter(Converter = typeof(SongInforsConverter))]
    public class songinfos
    {
        [DataMember]
        public string album_1000_1000 { get; set; }
        [DataMember]
        public string album_500_500 { get; set; }
        [DataMember]
        public string album_id { get; set; }
        [DataMember]
        public string album_no { get; set; }
        [DataMember]
        public string album_title { get; set; }
        [DataMember]
        public string aliasname { get; set; }
        [DataMember]
        public string all_artist_id { get; set; }
        [DataMember]
        public string all_artist_ting_uid { get; set; }
        [DataMember]
        public string all_rate { get; set; }
        [DataMember]
        public string area { get; set; }
        [DataMember]
        public string artist_1000_1000 { get; set; }
        [DataMember]
        public string artist_480_800 { get; set; }
        [DataMember]
        public string artist_500_500 { get; set; }
        [DataMember]
        public string artist_640_1136 { get; set; }
        [DataMember]
        public string artist_id { get; set; }
        [DataMember]
        public string author { get; set; }
        [DataMember]
        public string bitrate { get; set; }
        [DataMember]
        public int charge { get; set; }
        [DataMember]
        public int content { get; set; }
        [DataMember]
        public string compose { get; set; }
        [DataMember]
        public string compress_status { get; set; }
        [DataMember]
        public string copy_type { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string del_status { get; set; }
        [DataMember]
        public string distribution { get; set; }
        [DataMember]
        public int errcode { get; set; }
        [DataMember]
        public string errmsg { get; set; }
        [DataMember]
        public int expire { get; set; }
        [DataMember]
        public string file_duration { get; set; }
        [DataMember]
        public int has_mv { get; set; }
        [DataMember]
        public int has_mv_mobile { get; set; }
        [DataMember]
        public int havehigh { get; set; }
        [DataMember]
        public string high_rate { get; set; }
        [DataMember]
        public string hot { get; set; }
        [DataMember]
        public string is_charge { get; set; }
        [DataMember]
        public int is_first_publish { get; set; }
        [DataMember]
        public string korean_bb_song { get; set; }
        [DataMember]
        public string language { get; set; }
        [DataMember]
        public int learn { get; set; }
        [DataMember]
        public string lrclink { get; set; }
        [DataMember]
        public string multiterminal_copytype { get; set; }
        [DataMember]
        public string mv_provider { get; set; }
        [DataMember]
        public int original { get; set; }
        [DataMember]
        public string original_rate { get; set; }
        [DataMember]
        public string piao_id { get; set; }

        [DataMember]
        public string pic_big { get; set; }

        [DataMember]
        public string pic_huge { get; set; }
        [DataMember]
        public string pic_premium { get; set; }
        [DataMember]
        public string pic_radio { get; set; }
        [DataMember]
        public string pic_singer { get; set; }
        [DataMember]
        public string pic_small { get; set; }
        /// <summary>
        /// maybe {null}
        /// </summary>
        [DataMember]
        public int? play_type { get; set; }
        [DataMember]
        public string publishtime { get; set; }
        [DataMember]
        public string relate_status { get; set; }
        [DataMember]
        public string resource_type { get; set; }
        [DataMember]
        public string resource_type_ext { get; set; }
        [DataMember]
        public string share_url { get; set; }
        [DataMember]
        public string song_id { get; set; }
        [DataMember]
        public string song_source { get; set; }
        [DataMember]
        public string songwriting { get; set; }
        [DataMember]
        public string sound_effect { get; set; }
        [DataMember]
        public string ting_uid { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string toneid { get; set; }
        [DataMember]
        public string versions { get; set; }
    }
}
