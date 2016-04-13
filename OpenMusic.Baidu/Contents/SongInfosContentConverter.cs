using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OpenMusic.Baidu
{
    using OpenMusic.Datas;
    using OpenMusic.Contents;
    using OpenMusic.Baidu.Converters;
    using OpenMusic.Conveters;
    using OpenMusic.Extends;
    public sealed class SongInfosContentConverter : ContentConverter<SongInfoContent, getinfos>
    {
        public override SongInfoContent Convert(getinfos result)
        {
            SongInfoContent content = new SongInfoContent()
            {
                Item = new SongInforsConverter().Convert(result.songinfo),
                Urls = result.songurl.url.Select<url, ISongUrl>((o) => 
                {
                    return (ISongUrl)DataConverter.Convert(o);
                }).ToList()
            };

            return content;
        }

        public override void Convert(SongInfoContent content, getinfos result)
        {
            content.CopyFrom(this.Convert(result));
        }
    }
}
