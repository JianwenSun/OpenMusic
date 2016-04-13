using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Contents
{
    using OpenMusic.Datas;

    public class AlbumContent : Content
    {
        public List<IAlbum> Items { get; set; }

        public AlbumContent()
        {
            this.Items = new List<IAlbum>();
        }
    }
}
