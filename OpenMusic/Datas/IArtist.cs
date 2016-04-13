using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Datas
{
    public interface IArtist : IItem
    {
        string AlbumsTotal { get; set; }
        string Aliasname { get; set; }
        string Area { get; set; }
        string ArtistId { get; set; }
        string AvatarBig { get; set; }
        string AvatarPictureMiddle { get; set; }
        string AvatarPictureSmall { get; set; }
        string AvatarPictureMini { get; set; }
        string AvatarPictureS1000 { get; set; }
        string AvatarPictureS500 { get; set; }
        string Birthday { get; set; }
        string BloodType { get; set; }
        string Company { get; set; }
        /// <summary>
        /// 星座
        /// </summary>
        string Constellation { get; set; }
        string Country { get; set; }
        string Firstchar { get; set; }
        string Gender { get; set; }
        string Introduction { get; set; }
        int MVTotal { get; set; }
        string Name { get; set; }
        string SongsTotal { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        string Source { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        string Stature { get; set; }
        /// <summary>
        /// 译名
        /// </summary>
        string TranslateName { get; set; }
        string Url { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        string Weight { get; set; }

        List<IAlbum> Albums { get; set; }
        List<IVideo> Videos { get; set; }
    }
}