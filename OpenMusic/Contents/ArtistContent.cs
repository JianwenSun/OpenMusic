using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Contents
{
    using OpenMusic.Datas;
    public class ArtistContent : Content
    {
        public List<IArtist> Items { get; set; }

        public ArtistContent()
        {
            this.Items = new List<IArtist>();
        }
    }
}
