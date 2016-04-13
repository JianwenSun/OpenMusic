using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Contents
{
    using OpenMusic.Datas;
    public class SongInfoContent : Content
    {
        public List<ISongUrl> Urls { get; set; }

        public ISong Item { get; set; }

        public SongInfoContent()
        {
            this.Urls = new List<ISongUrl>();
        }
    }
}
