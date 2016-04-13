using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Contents
{
    using OpenMusic.Datas;
    public class SongListInfoContent : Content
    {
        public List<ISong> Songs { get; set; }

        public string CollectNumber { get; set; }
        public string Describtion { get; set; }
        public string ListId { get; set; }
        public string ListenNumber { get; set; }
        public string PictureS300 { get; set; }
        public string PictureS500 { get; set; }
        public object State { get; set; }
        public string Tag { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public SongListInfoContent()
        {
            this.Songs = new List<ISong>();
        }
    }
}
