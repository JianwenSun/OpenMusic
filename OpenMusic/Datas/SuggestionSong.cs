using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Datas
{
    public class SuggestionSong : ISuggestionSong
    {
        public string ArtistName { get; set; }
        public bool HasMV { get; set; }
        public int SongId { get; set; }
        public string SongName { get; set; }
    }
}
