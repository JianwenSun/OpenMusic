using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu.Converters
{
    using OpenMusic.Conveters;
    using OpenMusic.Datas;

    public sealed class SongInforsConverter : DataConverter<ISong, songinfos>
    {
        public override ISong Convert(songinfos obj)
        {
            return new Song()
            {
                AlbumId = obj.album_id,
                AlbumPicture = obj.album_500_500,
                AlbumNumber = obj.album_no,
                AlbumTitle = obj.album_title,
                AllRate = obj.all_rate,
                Area = obj.area,
                ArtistId = obj.artist_id,
                ArtistPicture = obj.artist_500_500,
                Author = obj.author,
                BitRate = obj.bitrate,
                Country= obj.country,
                FileFuration = obj.file_duration,
                HasMobileMV = obj.has_mv_mobile,
                HasMV = obj.has_mv,
                Language = obj.language,
                LrcLink = obj.lrclink,
                PictureBig = obj.pic_big,
                PictureHuge = obj.pic_huge,
                PicturePremium = obj.pic_premium,
                PictureRadio = obj.pic_radio,
                PictureSinger = obj.pic_singer,
                PictureSmall = obj.pic_small,
                PublishTime = obj.publishtime,
                SongId = obj.song_id,
                SongSource = obj.song_source,
                Title = obj.title,
                State = obj,
            };
        }
    }
}
