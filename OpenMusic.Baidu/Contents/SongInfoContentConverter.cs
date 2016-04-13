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
    public sealed class SongInfoContentConverter : ContentConverter<SongInfoContent, getinfo>
    {
        public override SongInfoContent Convert(getinfo result)
        {
            try
            {
                List<ISongUrl> urls = new List<ISongUrl>();
                if (result.songurl != null && result.songurl.url != null)
                {
                    urls = result.songurl.url.Select<url, ISongUrl>((o) =>
                    {
                        return (ISongUrl)DataConverter.Convert(o);
                    }).ToList();
                }

                SongInfoContent content = new SongInfoContent()
                {
                    Item = new SongInforsConverter().Convert(result.songinfo),
                    Urls = urls
                };

                content.Item.Urls = urls;
                return content;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public override void Convert(SongInfoContent content, getinfo result)
        {
            content.CopyFrom(this.Convert(result));
        }
    }
}
