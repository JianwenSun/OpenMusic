using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu.Converters
{
    using OpenMusic.Conveters;
    using OpenMusic.Datas;
    using System.Collections.ObjectModel;
    public sealed class SongListConverter : DataConverter<ISongList, gedanInfo>
    {
        public override ISongList Convert(gedanInfo obj)
        {
            return new SongList()
            {
                CollectNumber = obj.collectnum,
                Describtion = obj.desc,
                ListId = obj.listid,
                ListenNumber = obj.listenum,
                PictureS300 = obj.pic_300,
                PictureS500 = obj.pic_500,
                Tag = obj.tag,
                Title = obj.title,
                Url = obj.url,
                State = obj,
                Songs = obj.content.Select<gedanInfo._song, ISong>((o) =>
                {
                    return new Song()
                    {
                        AlbumId = o.album_id,
                        AlbumTitle = o.album_title,
                        AllRate = o.all_rate,
                        HasMobileMV = o.has_mv_mobile,
                        HasMV = o.has_mv,
                        SongId = o.song_id,
                        SongSource = o.song_source,
                        Title = o.title,
                        State = o
                    };
                }).ToList()
            };
        }
    }
}
