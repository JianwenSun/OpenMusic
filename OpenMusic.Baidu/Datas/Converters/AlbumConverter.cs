using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu.Converters
{
    using OpenMusic.Conveters;
    using OpenMusic.Datas;

    public sealed class AlbumConverter : DataConverter<IAlbum, album>
    {
        public override IAlbum Convert(album obj)
        {
            return new Album()
            {
                AlbumId = obj.album_id,
                ArtistId = obj.artist_id,
                AllArtistId = obj.all_artist_id,
                Hot = obj.hot.ToString(),
                Author = obj.author,
                PublishCompany = obj.company,
                PictureSmall = obj.pic_small,
                PublishTime = obj.publishtime,
                Title = obj.title,
            };
        }
    }
}
