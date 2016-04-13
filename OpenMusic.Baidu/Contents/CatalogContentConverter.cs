using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu
{
    using OpenMusic.Contents;
    using OpenMusic.Conveters;
    using OpenMusic.Datas;
    using OpenMusic.Extends;

    public sealed class CatalogContentConverter : ContentConverter<CatalogContent, merge>
    {
        public override CatalogContent Convert(merge result)
        {
            CatalogContent content = new CatalogContent();
            content.Albums.AddRange(result.result.album_info.album_list.Select<album, IAlbum>((o) =>
            {
                return (Album)DataConverter.Convert(o);
            }));
            content.Artists.AddRange(result.result.artist_info.artist_list.Select<artist, IArtist>((o) =>
            {
                return (Artist)DataConverter.Convert(o);
            }));
            content.Songs.AddRange(result.result.song_info.song_list.Select<song, ISong>((o) =>
            {
                return (Song)DataConverter.Convert(o);
            }));
            return content;
        }

        public override void Convert(CatalogContent content, merge result)
        {
            content.CopyFrom(this.Convert(result));
        }
    }
}
