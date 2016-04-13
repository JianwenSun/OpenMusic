using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Datas
{
    #region Json format

    /*{
        "bitrate_fee": "{\"0\":\"0|0\",\"1\":\"-1|-1\"}",
        "yyr_artist": "0",
        "songname": "12点 25分 (Wish List)",
        "artistname": "f(x)",
        "control": "0000000000",
        "songid": "260122773",
        "has_mv": "0",
        "encrypted_songid": "7507f81289509566ed685L"
    }*/

    #endregion

    public interface ISuggestionSong
    {
        /// <summary>
        /// song name
        /// </summary>
        string SongName { get; set; }

        /// <summary>
        /// artist name
        /// </summary>
        string ArtistName { get; set; }
        
        /// <summary>
        /// songid
        /// </summary>
        int SongId { get; set; }

        /// <summary>
        /// has mv
        /// </summary>
        bool HasMV { get; set; }
    }
}
