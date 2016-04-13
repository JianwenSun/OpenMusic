using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Datas
{
    public class SuggestionArtist : ISuggestionArtist
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string ArtistPicture { get; set; }
    }
}
