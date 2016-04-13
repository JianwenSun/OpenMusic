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
       "content": "",
       "copy_type": "1",
       "toneid": "0",
       "info": "",
       "all_rate": "24,64,128,192,256,320",
       "resource_type": 0,
       "relate_status": 0,
       "has_mv_mobile": 0,
       "song_id": "72100710",
       "title": "12",
       "ting_uid": "49997284",
       "author": "The 1975",
       "album_id": "72100621",
       "album_title": "The 1975",
       "is_first_publish": 0,
       "havehigh": 2,
       "charge": 1,
       "has_mv": 0,
       "learn": 0,
       "song_source": "web",
       "piao_id": "0",
       "korean_bb_song": "0",
       "resource_type_ext": "0",
       "mv_provider": "0000000000",
       "artist_id": "34211061",
       "all_artist_id": "34211061",
       "lrclink": "",
       "data_source": 0,
       "cluster_id": 0
       */
    #endregion

    [DataContract]
    public class song
    {
        [DataMember]
        public string content { get; set; }
        [DataMember]
        public string copy_type { get; set; }
        [DataMember]
        public string toneid { get; set; }
        [DataMember]
        public string info { get; set; }
        [DataMember]
        public string all_rate { get; set; }
        [DataMember]
        public int resource_type { get; set; }
        [DataMember]
        public int relate_status { get; set; }
        [DataMember]
        public int has_mv_mobile { get; set; }
        [DataMember]
        public string song_id { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string appendix { get; set; }
        [DataMember]
        public string ting_uid { get; set; }
        [DataMember]
        public string author { get; set; }
        [DataMember]
        public string album_id { get; set; }
        [DataMember]
        public string album_title { get; set; }
        [DataMember]
        public int is_first_publish { get; set; }
        [DataMember]
        public int havehigh { get; set; }
        [DataMember]
        public int charge { get; set; }
        [DataMember]
        public int has_mv { get; set; }
        [DataMember]
        public int learn { get; set; }
        [DataMember]
        public string song_source { get; set; }
        [DataMember]
        public string piao_id { get; set; }
        [DataMember]
        public string korean_bb_song { get; set; }
        [DataMember]
        public string resource_type_ext { get; set; }
        [DataMember]
        public string mv_provider { get; set; }
        [DataMember]
        public string artist_id { get; set; }
        [DataMember]
        public string all_artist_id { get; set; }
        [DataMember]
        public string lrclink { get; set; }
        [DataMember]
        public int data_source { get; set; }
        [DataMember]
        public int cluster_id { get; set; }
    }
}
