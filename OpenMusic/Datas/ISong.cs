using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Datas
{
    public interface ISong : IItem
    {
        List<ISongUrl> Urls { get; set; }

        string AlbumPicture { get; set; }
        string AlbumId { get; set; }
        string AlbumNumber { get; set; }
        string AlbumTitle { get; set; }
        string AllRate { get; set; }
        string Area { get; set; }
        string ArtistPicture { get; set; }
        string ArtistId { get; set; }
        string Author { get; set; }
        string BitRate { get; set; }
        string Country { get; set; }
        string FileFuration { get; set; }
        int HasMV { get; set; }
        int HasMobileMV { get; set; }
        string HighRate { get; set; }
        string Language { get; set; }
        string LrcLink { get; set; }
        string PictureBig { get; set; }
        string PictureHuge { get; set; }
        string PicturePremium { get; set; }
        string PictureRadio { get; set; }
        string PictureSinger { get; set; }
        string PictureSmall { get; set; }
        string PublishTime { get; set; }
        string SongId { get; set; }
        string SongSource { get; set; }
        string Title { get; set; }
    }
}