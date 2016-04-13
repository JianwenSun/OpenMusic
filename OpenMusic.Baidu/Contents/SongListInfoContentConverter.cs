using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OpenMusic.Baidu
{
    using OpenMusic.Contents;
    using OpenMusic.Conveters;
    using OpenMusic.Datas;
    using OpenMusic.Extends;

    public sealed class SongListInfoContentConverter : ContentConverter<SongListInfoContent, gedanInfo>
    {
        public override SongListInfoContent Convert(gedanInfo result)
        {
            return new SongListInfoContent()
            {
                CollectNumber = result.collectnum,
                Describtion = result.desc,
                ListId = result.listid,
                ListenNumber = result.listenum,
                PictureS300 = result.pic_300,
                PictureS500 = result.pic_500,
                Tag = result.tag,
                Title = result.title,
                Url = result.url,
                Songs = result.content.Select<gedanInfo._song, ISong>((o) => 
                {
                    return new Song()
                    {
                        AlbumId = o.album_id,
                        AlbumTitle = o.album_title,
                        AllRate = o.all_rate,
                        Author = o.author,
                        HasMobileMV = o.has_mv_mobile,
                        HasMV = o.has_mv,
                        HighRate = o.high_rate,
                        SongId = o.song_id,
                        SongSource = o.song_source,
                        Title = o.title,
                        State = o
                    };
                }).ToList(),
                State = result
            };
        }

        public override void Convert(SongListInfoContent content, gedanInfo result)
        {
            content.CopyFrom(this.Convert(result));
        }
    }
}
