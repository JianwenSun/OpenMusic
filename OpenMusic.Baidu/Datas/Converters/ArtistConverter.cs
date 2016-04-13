using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu.Converters
{
    using OpenMusic.Conveters;
    using OpenMusic.Datas;

    public sealed class ArtistConverter : DataConverter<IArtist, artist>
    {
        public override IArtist Convert(artist obj)
        {
            return new Artist()
            {
                AlbumsTotal = obj.album_num.ToString(),
                ArtistId = obj.artist_id,
                AvatarPictureMiddle = obj.avatar_middle,
                Source = obj.artist_source,
                SongsTotal = obj.song_num.ToString(),
                Country = obj.country,
                Name = obj.author,
            };
        }
    }
}
