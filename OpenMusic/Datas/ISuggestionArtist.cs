using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Datas
{

    /*{
        "yyr_artist": "0",
        "artistid": "106143770",
        "artistpic": "http:\/\/a.hiphotos.baidu.com\/ting\/abpic\/item\/0d338744ebf81a4cf4797c84d52a6059252da630.jpg",
        "artistname": "15＆"
    }*/

    /// <summary>
    /// suggest artist
    /// </summary>
    public interface ISuggestionArtist
    {
        /// <summary>
        /// artistid
        /// </summary>
        int ArtistId { get; set; }

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
