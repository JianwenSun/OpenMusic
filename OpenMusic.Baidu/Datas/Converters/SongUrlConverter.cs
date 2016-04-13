using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu.Converters
{
    using OpenMusic.Datas;
    using OpenMusic.Conveters;

    public class SongUrlConverter : DataConverter<ISongUrl, url>
    {
        public override ISongUrl Convert(url obj)
        {
            return new SongUrl()
            {
                CanLoad = obj.can_load,
                FileBitRate = obj.file_bitrate,
                FileDuration = obj.file_duration,
                FileExtension = obj.file_extension,
                FileLink = obj.file_link,
                FileSize = obj.file_size,
                Free = obj.free,
                Hash = obj.hash,
                State = obj
            };
        }
    }
}
