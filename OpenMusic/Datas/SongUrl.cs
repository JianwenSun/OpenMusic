using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Datas
{
    public class SongUrl : ISongUrl
    {
        public bool CanLoad { get; set; }
        public int FileBitRate { get; set; }
        public int FileDuration { get; set; }
        public string FileExtension { get; set; }
        public string FileLink { get; set; }
        public double FileSize { get; set; }
        public string Free { get; set; }
        public string Hash { get; set; }
        public object State { get; set; }
    }
}
