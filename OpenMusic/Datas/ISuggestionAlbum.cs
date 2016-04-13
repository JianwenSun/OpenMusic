using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Datas
{

    /*{
        "albumname": "1997-2007跨世纪国语精选",
        "artistpic": "http:\/\/qukufile2.qianqian.com\/data2\/pic\/117455394\/117455394.jpg",
        "albumid": "7311420",
        "artistname": "陈奕迅"
    }*/

    /// <summary>
    /// suggest album
    /// </summary>
    public interface ISuggestionAlbum
    {
        /// <summary>
        /// albumid
        /// </summary>
        int AlbumId { get; set; }

        /// <summary>
        /// albumname
        /// </summary>
        string AlbumName { get; set; }

        /// <summary>
        /// artist name
        /// </summary>
        string ArtistName { get; set; }

        /// <summary>
        /// artist picture
        /// </summary>
        string ArtistPicture { get; set; }
    }
}
