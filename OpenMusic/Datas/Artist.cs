using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Datas
{
    public class Artist : IArtist
    {
        public List<IAlbum> Albums { get; set; }
        public List<IVideo> Videos { get; set; }

        public string AlbumsTotal { get; set; }
        public string Aliasname { get; set; }
        public string Area { get; set; }
        public string ArtistId { get; set; }
        public string AvatarBig { get; set; }
        public string AvatarPictureMiddle { get; set; }
        public string AvatarPictureMini { get; set; }
        public string AvatarPictureS1000 { get; set; }
        public string AvatarPictureS500 { get; set; }
        public string AvatarPictureSmall { get; set; }
        public string Birthday { get; set; }
        public string BloodType { get; set; }
        public string Company { get; set; }
        public string Constellation { get; set; }
        public string Country { get; set; }
        public string Firstchar { get; set; }
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public int MVTotal { get; set; }
        public string Name { get; set; }
        public string SongsTotal { get; set; }
        public string Source { get; set; }
        public string Stature { get; set; }
        public string TranslateName { get; set; }
        public string Url { get; set; }
        public string Weight { get; set; }
        public object State { get; set; }

        public Artist()
        {
            this.Albums = new List<IAlbum>();
            this.Videos = new List<IVideo>();
        }
    }
}