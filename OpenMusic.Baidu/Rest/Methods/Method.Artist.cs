using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Baidu
{
    public class ArtistMethod : Method
    {
        public const string Prefix = "baidu.ting.artist";

        static ArtistMethod New
        {
            get { return new ArtistMethod(); }
        }

        #region Json Format
        /*
        {
          "songlist": [
            {
              "artist_id": "29",
              "all_artist_ting_uid": "7994",
              "all_artist_id": "29",
              "language": "\u7eaf\u97f3\u4e50",
              "publishtime": "2009-12-28",
              "album_no": "53",
              "versions": "\u4f34\u594f\/\u7eaf\u97f3\u4e50",
              "pic_big": "http:\/\/musicdata.baidu.com\/data2\/pic\/430814d968578b468f4d68417efcc159\/262032241\/262032241.jpg",
              "pic_small": "http:\/\/musicdata.baidu.com\/data2\/pic\/cb7f1a944d77056f1ddb04843c18bf73\/262032427\/262032427.jpg",
              "country": "\u6e2f\u53f0",
              "area": "1",
              "lrclink": "",
              "hot": "70162",
              "file_duration": "244",
              "del_status": "0",
              "resource_type": "0",
              "copy_type": "1",
              "relate_status": "0",
              "all_rate": "64,128,192,256,320",
              "has_mv_mobile": 1,
              "toneid": "600902000006889472",
              "song_id": "7316935",
              "title": "\u9f99\u5377\u98ce",
              "ting_uid": "7994",
              "author": "\u5468\u6770\u4f26",
              "album_id": "7311788",
              "album_title": "\u94a2\u7434\u604b\u66f2101",
              "is_first_publish": 0,
              "havehigh": 2,
              "charge": 0,
              "has_mv": 1,
              "learn": 1,
              "song_source": "web",
              "piao_id": "0",
              "korean_bb_song": "0",
              "resource_type_ext": "0",
              "mv_provider": "1000000000",
              "listen_total": "9596"
            }
          ],
          "songnums": "106",
          "havemore": 1,
          "error_code": 22000
        }
        */
        #endregion
        /// <summary>
        /// get song list
        /// </summary>
        /// <param name="tinguid"></param>
        /// <param name="artistid"></param>
        /// <param name="limits"></param>
        /// <param name="order"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ArtistMethod GetSongList(int tinguid, int? artistid, int limits, int order, int offset)
        {
            ArtistMethod artist = ArtistMethod.New;
            artist.Value = string.Format("{0}.getSongList", Prefix);
            artist.Parameters.Add(Parameter.Make("tinguid", tinguid.ToString()));
            artist.Parameters.Add(Parameter.Make("artistid", artistid == null? "(null)" : artistid.Value.ToString()));
            artist.Parameters.Add(Parameter.Make("limits", limits.ToString()));
            artist.Parameters.Add(Parameter.Make("order", order.ToString()));
            artist.Parameters.Add(Parameter.Make("offset", offset.ToString()));
            return artist;
        }

        #region Json Format

        /*{
          "albumlist": [
            {
              "album_id": "257454109",
              "author": "\u9648\u5955\u8fc5",
              "title": "Sleep Alone",
              "publishcompany": "\u73af\u7403\u5531\u7247",
              "prodcompany": "",
              "country": "\u6e2f\u53f0",
              "language": "\u82f1\u8bed",
              "songs_total": "1",
              "info": "",
              "styles": "\u6d41\u884c",
              "style_id": null,
              "publishtime": "2015-11-10",
              "artist_ting_uid": "1077",
              "all_artist_ting_uid": null,
              "gender": null,
              "area": null,
              "pic_small": "http:\/\/musicdata.baidu.com\/data2\/pic\/9604cfab6065188ab4a2360975950509\/257454128\/257454128.jpg",
              "pic_big": "http:\/\/musicdata.baidu.com\/data2\/pic\/21beae21eceac005231029fad55931dd\/257454123\/257454123.jpg",
              "hot": "28758",
              "favorites_num": null,
              "recommend_num": null,
              "artist_id": "87",
              "all_artist_id": "87",
              "pic_radio": "http:\/\/musicdata.baidu.com\/data2\/pic\/ab00f8229a11665e7d99b14903affaf5\/257454119\/257454119.jpg",
              "pic_s180": "http:\/\/musicdata.baidu.com\/data2\/pic\/2ce735f636bbfd94a8269d0943e0c5e5\/257454121\/257454121.jpg"
            }
          ],
          "albumnums": "110",
          "havemore": 1
        }*/

        #endregion
        /// <summary>
        /// get album list
        /// </summary>
        /// <param name="tinguid"></param>
        /// <param name="artistid"></param>
        /// <param name="limits"></param>
        /// <param name="order"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ArtistMethod GetAlbumList(int tinguid, int? artistid, int limits, int order, int offset)
        {
            ArtistMethod artist = ArtistMethod.New;
            artist.Value = string.Format("{0}.getAlbumList", Prefix);
            artist.Parameters.Add(Parameter.Make("tinguid", tinguid.ToString()));
            artist.Parameters.Add(Parameter.Make("artistid", artistid == null ? "(null)" : artistid.Value.ToString()));
            artist.Parameters.Add(Parameter.Make("limits", limits.ToString()));
            artist.Parameters.Add(Parameter.Make("order", order.ToString()));
            artist.Parameters.Add(Parameter.Make("offset", offset.ToString()));
            return artist;
        }

        public static ArtistMethod GetArtistMVList(int id, int page, int size, int usetinguid)
        {
            ArtistMethod artist = ArtistMethod.New;
            artist.Value = string.Format("{0}.getArtistMVList", Prefix);
            artist.Parameters.Add(Parameter.Make("id", id.ToString()));
            artist.Parameters.Add(Parameter.Make("page", page.ToString()));
            artist.Parameters.Add(Parameter.Make("usetinguid", usetinguid.ToString()));
            return artist;
        }


        #region Json Format

        /*
        {
          "artist": [
            {
              "ting_uid": "1025",
              "name": "\u674e\u5b87\u6625",
              "firstchar": "L",
              "gender": "1",
              "area": "0",
              "country": "\u4e2d\u56fd",
              "avatar_big": "http:\/\/musicdata.baidu.com\/data2\/pic\/138f4003010b70de881482c6ec895f03\/246707758\/246707758.jpg",
              "avatar_middle": "http:\/\/musicdata.baidu.com\/data2\/pic\/369fca7ee5d59ba4ecbe8eedcc83950b\/246707763\/246707763.jpg",
              "avatar_small": "http:\/\/musicdata.baidu.com\/data2\/pic\/4f6f6dc86f2172e5c3bc2119dd32341d\/246707808\/246707808.jpg",
              "avatar_mini": "http:\/\/musicdata.baidu.com\/data2\/pic\/073d9f36756f54edd189a5aef71803de\/246707811\/246707811.jpg",
              "albums_total": "38",
              "songs_total": "232",
              "artist_id": "1",
              "piao_id": "0"
            },
            {
              "ting_uid": "1026",
              "name": "\u5f20\u9753\u9896",
              "firstchar": "Z",
              "gender": "1",
              "area": "0",
              "country": "\u4e2d\u56fd",
              "avatar_big": "http:\/\/musicdata.baidu.com\/data2\/pic\/05bc6f6db83ed75e53ad6c7eeaf5517a\/246709972\/246709972.jpg",
              "avatar_middle": "http:\/\/musicdata.baidu.com\/data2\/pic\/f6a9c9f961c406104b3763d8f815abed\/246709976\/246709976.jpg",
              "avatar_small": "http:\/\/musicdata.baidu.com\/data2\/pic\/7a2d717c0a473a91090a069bfe2621e5\/246709984\/246709984.jpg",
              "avatar_mini": "http:\/\/musicdata.baidu.com\/data2\/pic\/5bc65fbe33d3a9899505ba979c6b0b6a\/246709985\/246709985.jpg",
              "albums_total": "47",
              "songs_total": "273",
              "artist_id": "2",
              "piao_id": "0"
            },
            {
              "ting_uid": "1027",
              "name": "\u80e1\u7075",
              "firstchar": "H",
              "gender": "1",
              "area": "0",
              "country": "\u4e2d\u56fd",
              "avatar_big": "http:\/\/musicdata.baidu.com\/data2\/pic\/119146258\/119146258.jpg",
              "avatar_middle": "http:\/\/musicdata.baidu.com\/data2\/pic\/119146265\/119146265.jpg",
              "avatar_small": "http:\/\/musicdata.baidu.com\/data2\/pic\/116050153\/116050153.jpg",
              "avatar_mini": "http:\/\/musicdata.baidu.com\/data2\/pic\/116050172\/116050172.jpg",
              "albums_total": "8",
              "songs_total": "73",
              "artist_id": "3",
              "piao_id": "0"
            },
            {
              "ting_uid": "1028",
              "name": "\u4f55\u6d01",
              "firstchar": "H",
              "gender": "1",
              "area": "0",
              "country": "\u4e2d\u56fd",
              "avatar_big": "http:\/\/musicdata.baidu.com\/data2\/pic\/246707559\/246707559.jpg",
              "avatar_middle": "http:\/\/musicdata.baidu.com\/data2\/pic\/246707565\/246707565.jpg",
              "avatar_small": "http:\/\/musicdata.baidu.com\/data2\/pic\/246707590\/246707590.jpg",
              "avatar_mini": "http:\/\/musicdata.baidu.com\/data2\/pic\/246707595\/246707595.jpg",
              "albums_total": "7",
              "songs_total": "91",
              "artist_id": "4",
              "piao_id": "0"
            },
            {
              "ting_uid": "1029",
              "name": "\u5468\u7b14\u7545",
              "firstchar": "Z",
              "gender": "1",
              "area": "0",
              "country": "\u4e2d\u56fd",
              "avatar_big": "http:\/\/musicdata.baidu.com\/data2\/pic\/65f9d4f188e2d8e9bb71b78a3648283f\/246710166\/246710166.jpg",
              "avatar_middle": "http:\/\/musicdata.baidu.com\/data2\/pic\/62f8c0853ef1a076afaf090ec942cccd\/246710171\/246710171.jpg",
              "avatar_small": "http:\/\/musicdata.baidu.com\/data2\/pic\/9073782ec532b3a5123fa1bc60c93b5a\/246710185\/246710185.jpg",
              "avatar_mini": "http:\/\/musicdata.baidu.com\/data2\/pic\/00ed3c85b5c6af484e7badbc36d4f6f6\/246710188\/246710188.jpg",
              "albums_total": "21",
              "songs_total": "140",
              "artist_id": "5",
              "piao_id": "0"
            }
          ],
          "nums": 2000,
          "noFirstChar": "",
          "havemore": 1
        }
        */

        #endregion</param>
        /// <summary>
        /// getlist
        /// </summary>
        /// <param name="order">
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="area"></param>
        /// <param name="tArtist"></param>
        /// <returns></returns>
        public static ArtistMethod GetList(int order, int limit, int offset, TArea area, TArtist tArtist)
        {
            ArtistMethod artist = ArtistMethod.New;
            artist.Value = string.Format("{0}.getList", Prefix);
            artist.Parameters.Add(Parameter.Make("order", order.ToString()));
            artist.Parameters.Add(Parameter.Make("limit", limit.ToString()));
            artist.Parameters.Add(Parameter.Make("offset", offset.ToString()));
            artist.Parameters.Add(Parameter.Make("area", ((int)area).ToString()));
            artist.Parameters.Add(Parameter.Make("sex", ((int)tArtist).ToString()));
            return artist;
        }
    }
}
