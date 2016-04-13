using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Baidu
{
    /// <summary>
    /// M.Search
    /// </summary>
    public class SearchMethod : Method
    {
        public const string Prefix = "baidu.ting.search";

        static SearchMethod New
        {
            get { return new SearchMethod(); }
        }


        #region suggestion json format

        /*{
          "song": [
            {
              "bitrate_fee": "{\"0\":\"0|0\",\"1\":\"0|0\"}",
              "yyr_artist": "0",
              "songname": "17岁",
              "artistname": "刘德华",
              "control": "0000000000",
              "songid": "1574366",
              "has_mv": "1",
              "encrypted_songid": "68061805de095684fae7L"
            },
            {
              "bitrate_fee": "{\"0\":\"0|0\",\"1\":\"-1|-1\"}",
              "yyr_artist": "0",
              "songname": "12点 25分 (Wish List)",
              "artistname": "f(x)",
              "control": "0000000000",
              "songid": "260122773",
              "has_mv": "0",
              "encrypted_songid": "7507f81289509566ed685L"
            }
          ],
          "album": [
            {
              "albumname": "1997-2007跨世纪国语精选",
              "artistpic": "http:\/\/qukufile2.qianqian.com\/data2\/pic\/117455394\/117455394.jpg",
              "albumid": "7311420",
              "artistname": "陈奕迅"
            },
            {
              "albumname": "1990-1994 钻石金选集",
              "artistpic": "http:\/\/qukufile2.qianqian.com\/data2\/pic\/037d5592ebe8d7e302db40447cc68868\/262005306\/262005306.jpg",
              "albumid": "2462488",
              "artistname": "孟庭苇"
            }
          ],
          "order": "artist,song,album",
          "error_code": 22000,
          "artist": [
            {
              "yyr_artist": "0",
              "artistid": "90655619",
              "artistpic": "http:\/\/a.hiphotos.baidu.com\/ting\/abpic\/item\/63d0f703918fa0ec4cebb41d209759ee3d6ddbf6.jpg",
              "artistname": "19"
            },
            {
              "yyr_artist": "0",
              "artistid": "167524054",
              "artistpic": "http:\/\/qukufile2.qianqian.com\/data2\/pic\/48b92d840b32f343983cfd7bc7525188\/254920172\/254920172.jpg",
              "artistname": "1931女子偶像组合"
            }
          ]
        }*/

        /// <summary>
        /// Catalog suggestion with songs, albums, artists
        /// </summary>
        /// <param name="query"></param>
        /// <returns> the colleciton of song,album and artist </returns>
        #endregion
        public static SearchMethod CatalogSug(string query)
        {
            SearchMethod search = SearchMethod.New;
            search.Value = string.Format("{0}.catalogSug", Prefix);
            search.Parameters.Add(Parameter.Make("query", query));
            return search;
        }

        #region suggest json format

        /*
        {
          "query": "\u5c0f\u82f9\u679c",
          "suggestion_list": [ "\u7b77\u5b50\u5144\u5f1f \u5c0f\u82f9\u679c", "T-ara,\u7b77\u5b50\u5144\u5f1f \u5c0f\u82f9\u679c (Little Apple)", "\u7b77\u5b50\u5144\u5f1f \u5c0f\u82f9\u679c\uff08\u65b0\u5e74Remix\u7248\uff09", "\u8c2d\u548f\u9e9f \u5c0f\u82f9\u679c", "\uff2d\uff23\u5a1c\u5a1c \u5c0f\u82f9\u679c", "\u4f24\u611f\u4e00\u54e5 \u5c0f\u82f9\u679c", "DJ Lee3 \u5c0f\u82f9\u679c", "\u4ffa\u9171 \u5c0f\u82f9\u679c", "\u674e\u54f2\u5e0c \u5c0f\u82f9\u679c", "\u5fae\u84dd\u6d77 \u5c0f\u82f9\u679c" ]
        }
        */

        #endregion

        /// <summary>
        /// suggestion
        /// </summary>
        /// <param name="query"></param>
        /// <returns>only suggest message string.</returns>
        public static SearchMethod Suggestion(string query)
        {
            SearchMethod search = SearchMethod.New;
            search.Value = string.Format("{0}.suggestion", Prefix);
            search.Parameters.Add(Parameter.Make("query", query));
            return search;
        }

        #region common json format

        /*
        {
          "query": "\u5c0f\u82f9\u679c",
          "is_artist": 0,
          "is_album": 0,
          "rs_words": "",
          "pages": {
            "total": "149",
            "rn_num": "30"
          },
          "song_list": [
            {
              "title": "\u003Cem\u003E\u5c0f\u82f9\u679c\u003C\/em\u003E",
              "song_id": "120125029",
              "author": "\u7b77\u5b50\u5144\u5f1f",
              "artist_id": "57520",
              "all_artist_id": "57520",
              "album_title": "\u8001\u7537\u5b69\u4e4b\u731b\u9f99\u8fc7\u6c5f \u7535\u5f71\u539f\u58f0",
              "appendix": "",
              "album_id": "121556956",
              "lrclink": "\/data2\/lrc\/240885272\/240885272.lrc",
              "resource_type": "0",
              "content": "",
              "relate_status": 0,
              "havehigh": 2,
              "copy_type": "0",
              "all_rate": "24,64,128,192,256,320,flac",
              "has_mv": 1,
              "has_mv_mobile": 1,
              "mv_provider": "1100000000",
              "charge": 0,
              "toneid": "0",
              "info": "\u7535\u5f71\u300a\u8001\u7537\u5b69\u4e4b\u731b\u9f99\u8fc7\u6c5f\u300b2014\u63d2\u66f2",
              "data_source": 0,
              "learn": 1
            },
            {
              "title": "\u003Cem\u003E\u5c0f\u82f9\u679c\u003C\/em\u003E (Little Apple)",
              "song_id": "124671589",
              "author": "T-ara,\u7b77\u5b50\u5144\u5f1f",
              "artist_id": "5417677",
              "all_artist_id": "5417677,57520",
              "album_title": "Little Apple",
              "appendix": "",
              "album_id": "124671593",
              "lrclink": "\/data2\/lrc\/238976174\/238976174.lrc",
              "resource_type": "2",
              "content": "",
              "relate_status": 0,
              "havehigh": 2,
              "copy_type": "0",
              "all_rate": "24,64,128,192,256,320",
              "has_mv": 0,
              "has_mv_mobile": 0,
              "mv_provider": "0000000000",
              "charge": 0,
              "toneid": "0",
              "info": "",
              "data_source": 0,
              "learn": 0
            }
          ]
        }
        */

        #endregion
        /// <summary>
        /// common search 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>only songs</returns>
        public static SearchMethod Common(string query, int pageNumber, int? pageSize)
        {
            SearchMethod search = SearchMethod.New;
            search.Value = string.Format("{0}.common", Prefix);
            search.Parameters.Add(Parameter.Make("query", query));
            search.Parameters.Add(Parameter.Make("page_no", pageNumber.ToString()));
            if(pageSize.HasValue)
                search.Parameters.Add(Parameter.Make("page_size", pageSize.ToString()));
            return search;
        }


        #region merge json format
        
        /*{
          "error_code": 22000,
          "result": {
            "query": "12",
            "syn_words": "",
            "rqt_type": 2,
            "song_info": {
              "total": 17495,
              "song_list": [
                {
                  "content": "",
                  "copy_type": "1",
                  "toneid": "0",
                  "info": "",
                  "all_rate": "24,64,128,192,256,320",
                  "resource_type": 0,
                  "relate_status": 0,
                  "has_mv_mobile": 0,
                  "song_id": "72100710",
                  "title": "12",
                  "ting_uid": "49997284",
                  "author": "The 1975",
                  "album_id": "72100621",
                  "album_title": "The 1975",
                  "is_first_publish": 0,
                  "havehigh": 2,
                  "charge": 1,
                  "has_mv": 0,
                  "learn": 0,
                  "song_source": "web",
                  "piao_id": "0",
                  "korean_bb_song": "0",
                  "resource_type_ext": "0",
                  "mv_provider": "0000000000",
                  "artist_id": "34211061",
                  "all_artist_id": "34211061",
                  "lrclink": "",
                  "data_source": 0,
                  "cluster_id": 0
                },
                {
                  "content": "",
                  "copy_type": "1",
                  "toneid": "0",
                  "info": "",
                  "all_rate": "64,128,192,256,320",
                  "resource_type": 0,
                  "relate_status": 0,
                  "has_mv_mobile": 0,
                  "song_id": "86752859",
                  "title": "12",
                  "ting_uid": "49997284",
                  "author": "The 1975",
                  "album_id": "86752767",
                  "album_title": "The 1975",
                  "is_first_publish": 0,
                  "havehigh": 2,
                  "charge": 1,
                  "has_mv": 0,
                  "learn": 0,
                  "song_source": "web",
                  "piao_id": "0",
                  "korean_bb_song": "0",
                  "resource_type_ext": "0",
                  "mv_provider": "0000000000",
                  "artist_id": "34211061",
                  "all_artist_id": "34211061",
                  "lrclink": "",
                  "data_source": 0,
                  "cluster_id": 0
                }
              ]
            },
            "artist_info": {
              "total": 34,
              "artist_list": [
                {
                  "artist_id": "73330871",
                  "author": "\u5f20\u4eae\u4eae",
                  "ting_uid": "110936311",
                  "avatar_middle": "http:\/\/qukufile2.qianqian.com\/data2\/pic\/247111636\/247111636.jpg",
                  "album_num": 0,
                  "song_num": 28,
                  "country": "\u4e2d\u56fd",
                  "artist_desc": "",
                  "artist_source": "yyr"
                },
                {
                  "artist_id": "73331411",
                  "author": "Alex Zr",
                  "ting_uid": "110936851",
                  "avatar_middle": "http:\/\/qukufile2.qianqian.com\/data2\/pic\/4b4583d58db0927e73e9d35254aef3f7\/256966488\/256966488.jpg",
                  "album_num": 0,
                  "song_num": 162,
                  "country": "\u4e2d\u56fd",
                  "artist_desc": "",
                  "artist_source": "yyr"
                }
              ]
            },
            "album_info": {
              "total": 1164,
              "album_list": [
                {
                  "album_id": "130208313",
                  "author": "12 Stones",
                  "hot": 35,
                  "title": "We Are One",
                  "artist_id": "1462775",
                  "all_artist_id": "1462775",
                  "company": "\u73af\u7403\u5531\u7247",
                  "publishtime": "2014-12-08",
                  "album_desc": "",
                  "pic_small": "http:\/\/qukufile2.qianqian.com\/data2\/pic\/130209152\/130209152.jpg"
                },
                {
                  "album_id": "258083647",
                  "author": "12 Stones",
                  "hot": 2,
                  "title": "The Only Easy Day Was Yesterday",
                  "artist_id": "1462775",
                  "all_artist_id": "1462775",
                  "company": "\u73af\u7403\u5531\u7247",
                  "publishtime": "2014-07-21",
                  "album_desc": " ",
                  "pic_small": "http:\/\/qukufile2.qianqian.com\/data2\/pic\/a1fde425bf9abd76200f297e24541d14\/258083751\/258083751.jpg"
                }
              ]
            }
          }
        }*/

        #endregion

        /// <summary>
        /// merge
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>song, album, artist collection</returns>
        public static SearchMethod Merge(string query, int pageNumber, int? pageSize)
        {
            SearchMethod search = SearchMethod.New;
            search.Value = string.Format("{0}.merge", Prefix);
            search.Parameters.Add(Parameter.Make("query", query));
            search.Parameters.Add(Parameter.Make("page_no", pageNumber.ToString()));
            if(pageSize.HasValue)
                search.Parameters.Add(Parameter.Make("page_size", pageSize.ToString()));
            return search;
        }
    }
}
