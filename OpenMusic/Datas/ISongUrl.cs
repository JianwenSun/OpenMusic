using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Datas
{
    public interface ISongUrl : IItem
    {
        bool CanLoad { get; set; }
        int FileBitRate { get; set; }
        int FileDuration { get; set; }
        string FileExtension { get; set; }
        string FileLink { get; set; }
        double FileSize { get; set; }
        string Free { get; set; }
        string Hash { get; set; }
    }
}
