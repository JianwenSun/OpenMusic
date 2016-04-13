using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace OpenMusic.Datas
{
    public class SongList : ISongList
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
    }
}