using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Contents
{
    using OpenMusic.Datas;
    public class CatalogSuggestionContent : Content
    {
        public List<ISuggestionAlbum> Albums { get; set; }
        public List<ISuggestionArtist> Artists { get; set; }
        public List<ISuggestionSong> Songs { get; set; }

        public CatalogSuggestionContent()
        {
            this.Albums = new List<ISuggestionAlbum>();
            this.Artists = new List<ISuggestionArtist>();
            this.Songs = new List<ISuggestionSong>();
        }
    }
}
