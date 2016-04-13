using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Contents
{
    using OpenMusic.Datas;
    public class SongContent : Content
    {
        public string Name { get; set; }
        public int Total { get; set; }

        public List<ISong> Items { get; set; }

        public SongContent()
        {
            this.Items = new List<ISong>();
        }
    }
}
