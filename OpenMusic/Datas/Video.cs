using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Datas
{
    public class Video : IVideo
    {
        public string AliasTitle { get; set; }
        public string AllArtistId { get; set; }
        public string Artist { get; set; }
        public string ArtistId { get; set; }
        public string Provider { get; set; }
        public string PublishTime { get; set; }
        public object State { get; set; }
        public string SubTitle { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public string VideoId { get; set; }
    }
}
