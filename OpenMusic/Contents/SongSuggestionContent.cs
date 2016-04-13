using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Contents
{
    public class SongSuggestionContent : Content
    {
        public string Query { get; set; }
        public List<string> Items { get; set; }

        public SongSuggestionContent()
        {
            this.Items = new List<string>();
        }
    }
}
