using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Contents
{
    using OpenMusic.Datas;
    public class CatalogContent : Content
    {
        public List<IAlbum> Albums { get; set; }
        public List<IArtist> Artists { get; set; }
        public List<ISong> Songs { get; set; }

        public CatalogContent()
        {
            this.Albums = new List<IAlbum>();
            this.Artists = new List<IArtist>();
            this.Songs = new List<ISong>();
        }
    }
}
