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
        "can_load": true,
        "can_see": 1,
        "down_type": 0,
        "file_bitrate": 64,
        "file_duration": 208,
        "file_extension": "mp3",
        "file_link": "http:\/\/yinyueshiting.baidu.com\/data2\/music\/42822293\/42822293.mp3?xcode=9a3f8ace86b21f8485f6fb12ebde0b01",
        "file_size": 1665970,
        "free": 1,
        "hash": "7eb557bab03a343dfdb911f7e37291e28011a9ef",
        "is_udition_url": 0,
        "original": 0,
        "preload": 40,
        "replay_gain": "0.690002",
        "show_link": "",
        "song_file_id": 42822293
    */
    #endregion

    [DataContract, DataConverter(Converter = typeof(SongUrlConverter))]
    public class url
    {
        [DataMember]
        public bool can_load { get; set; }
        [DataMember]
        public int can_see { get; set; }
        [DataMember]
        public int down_type { get; set; }
        [DataMember]
        public int file_bitrate { get; set; }
        [DataMember]
        public int file_duration { get; set; }
        [DataMember]
        public string file_extension { get; set; }
        [DataMember]
        public string file_link { get; set; }
        [DataMember]
        public double file_size { get; set; }
        [DataMember]
        public string free { get; set; }
        [DataMember]
        public string hash { get; set; }
        [DataMember]
        public int is_udition_url { get; set; }
        [DataMember]
        public int original { get; set; }
        [DataMember]
        public int preload { get; set; }
        [DataMember]
        public string replay_gain { get; set; }
        [DataMember]
        public string show_link { get; set; }
        [DataMember]
        public int song_file_id { get; set; }
    }
}
