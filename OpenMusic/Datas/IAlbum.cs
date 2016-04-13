using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Datas
{
    public interface IAlbum : IItem
    {
        List<ISong> Songs { get; set; }

        string AlbumId { get; set; }
        string AllArtistId { get; set; }
        string Area { get; set; }
        string ArtistId { get; set; }
        string Author { get; set; }
        string Country { get; set; }
        string Gender { get; set; }
        string Hot { get; set; }
        string Info { get; set; }
        string Language { get; set; }
        string PictureBig { get; set; }
        string PictureSmall { get; set; }
        string PictureRadio { get; set; }
        string PictureS1000 { get; set; }
        string PictureS500 { get; set; }
        string ProductCompany { get; set; }
        string PublishCompany { get; set; }
        string PublishTime { get; set; }
        string SongsTotal { get; set; }
        string StyleId { get; set; }
        string Styles { get; set; }
        string Title { get; set; }
    }
}