using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Datas
{
    public class Song : ISong
    {
        public string AlbumId { get; set; }
        public string AlbumNumber { get; set; }
        public string AlbumPicture { get; set; }
        public string AlbumTitle { get; set; }
        public string AllRate { get; set; }
        public string Area { get; set; }
        public string ArtistId { get; set; }
        public string ArtistPicture { get; set; }
        public string Author { get; set; }
        public string BitRate { get; set; }
        public string Country { get; set; }
        public string FileFuration { get; set; }
        public int HasMobileMV { get; set; }
        public int HasMV { get; set; }
        public string HighRate { get; set; }
        public string Language { get; set; }
        public string LrcLink { get; set; }
        public string PictureBig { get; set; }
        public string PictureHuge { get; set; }
        public string PicturePremium { get; set; }
        public string PictureRadio { get; set; }
        public string PictureSinger { get; set; }
        public string PictureSmall { get; set; }
        public string PublishTime { get; set; }
        public string SongId { get; set; }
        public string SongSource { get; set; }
        public object State { get; set; }
        public string Title { get; set; }
        public List<ISongUrl> Urls { get; set; }

        public Song()
        {
            this.Urls = new List<ISongUrl>();
        }
    }
}