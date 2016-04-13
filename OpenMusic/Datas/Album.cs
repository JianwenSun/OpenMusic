using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Datas
{
    public class Album : IAlbum
    {
        public List<ISong> Songs { get; set; }

        public string AlbumId { get; set; }
        public string AllArtistId { get; set; }
        public string Area { get; set; }
        public string ArtistId { get; set; }
        public string Author { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string Hot { get; set; }
        public string Info { get; set; }
        public string Language { get; set; }
        public string PictureBig { get; set; }
        public string PictureRadio { get; set; }
        public string PictureS1000 { get; set; }
        public string PictureS500 { get; set; }
        public string PictureSmall { get; set; }
        public string ProductCompany { get; set; }
        public string PublishCompany { get; set; }
        public string PublishTime { get; set; }
        public string SongsTotal { get; set; }
        public object State { get; set; }
        public string StyleId { get; set; }
        public string Styles { get; set; }
        public string Title { get; set; }

        public Album()
        {
            this.Songs = new List<ISong>();
        }
    }
}