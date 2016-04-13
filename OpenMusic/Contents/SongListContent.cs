using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Contents
{
    using OpenMusic.Datas;
    public class SongListContent : Content
    {
        public int Total { get; set; }
        public int HaveMore { get; set; }

        public List<ISongList> SongLists { get; set; }

        public SongListContent()
        {
            this.SongLists = new List<ISongList>();
        }
    }
}
