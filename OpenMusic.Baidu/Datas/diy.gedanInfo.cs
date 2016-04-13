using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu
{
    #region Json Format

    /*
    {
      "collectnum": "441",
      "content": [
        {
          "album_id": "7313053",
          "album_title": "Lost And Found",
          "all_artist_id": "5142",
          "all_rate": "24,64,128,192,256,320,flac",
          "author": "\u4f59\u6587\u4e50",
          "charge": 1,
          "copy_type": "1",
          "has_mv": 0,
          "has_mv_mobile": 0,
          "havehigh": 2,
          "high_rate": "320",
          "is_charge": "1",
          "is_first_publish": 0,
          "is_ksong": "0",
          "korean_bb_song": "0",
          "learn": 0,
          "mv_provider": "0000000000",
          "piao_id": "0",
          "relate_status": "0",
          "resource_type": "0",
          "resource_type_ext": "0",
          "share": "http:\/\/music.baidu.com\/song\/309602",
          "song_id": "309602",
          "song_source": "web",
          "ting_uid": "7638",
          "title": "\u7231\u5feb\u7f57\u5bc6\u6b27",
          "toneid": "0"
        },
        {
          "title": "\u7231",
          "song_id": "275258",
          "author": "\u9648\u6167\u7433",
          "album_id": "7322975",
          "album_title": "\u7231",
          "relate_status": "0",
          "is_charge": "1",
          "all_rate": "64,128,192,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "107",
          "copy_type": "1",
          "has_mv": 1,
          "toneid": "0",
          "resource_type": "0",
          "is_ksong": "1",
          "has_mv_mobile": 1,
          "ting_uid": "82402",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 1,
          "learn": 1,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0100000000",
          "share": "http:\/\/music.baidu.com\/song\/275258"
        },
        {
          "title": "\u7231, \u4e00\u6b21\u7ed9\u4e0d\u5b8c",
          "song_id": "124030599",
          "author": "\u738b\u83f2",
          "album_id": "7311920",
          "album_title": "\u4f20\u5947 - \u80e1\u601d\u4e71\u60f3",
          "relate_status": "0",
          "is_charge": "1",
          "all_rate": "24,64,128,192,256,320",
          "high_rate": "320",
          "all_artist_id": "15",
          "copy_type": "1",
          "has_mv": 0,
          "toneid": "0",
          "resource_type": "0",
          "is_ksong": "0",
          "has_mv_mobile": 0,
          "ting_uid": "45561",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 1,
          "learn": 0,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0000000000",
          "share": "http:\/\/music.baidu.com\/song\/124030599"
        },
        {
          "title": "\u559c\u6b22",
          "song_id": "7314651",
          "author": "\u6731\u8335",
          "album_id": "7311129",
          "album_title": "\u5730\u9707",
          "relate_status": "0",
          "is_charge": "1",
          "all_rate": "24,64,128,192,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "223",
          "copy_type": "1",
          "has_mv": 0,
          "toneid": "0",
          "resource_type": "0",
          "is_ksong": "0",
          "has_mv_mobile": 0,
          "ting_uid": "82480",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 1,
          "learn": 0,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0000000000",
          "share": "http:\/\/music.baidu.com\/song\/7314651"
        },
        {
          "title": "True Love",
          "song_id": "7319953",
          "author": "\u8521\u5065\u96c5",
          "album_id": "7312930",
          "album_title": "\u9ed8\u5951",
          "relate_status": "0",
          "is_charge": "1",
          "all_rate": "24,64,128,192,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "295",
          "copy_type": "1",
          "has_mv": 0,
          "toneid": "0",
          "resource_type": "0",
          "is_ksong": "1",
          "has_mv_mobile": 0,
          "ting_uid": "1180",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 1,
          "learn": 1,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0000000000",
          "share": "http:\/\/music.baidu.com\/song\/7319953"
        },
        {
          "title": "\u72ec\u5bb6\u8bb0\u5fc6",
          "song_id": "259500968",
          "author": "\u9648\u5c0f\u6625",
          "album_id": "259492934",
          "album_title": "Guo Yu Jing Dian 101 Vol.3",
          "relate_status": "0",
          "is_charge": "0",
          "all_rate": "64,128,256,320",
          "high_rate": "320",
          "all_artist_id": "150",
          "copy_type": "1",
          "has_mv": 0,
          "toneid": "0",
          "resource_type": "0",
          "is_ksong": "0",
          "has_mv_mobile": 0,
          "ting_uid": "1111",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 0,
          "learn": 0,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0000000000",
          "share": "http:\/\/music.baidu.com\/song\/259500968"
        },
        {
          "title": "\u559c\u6b22",
          "song_id": "241855699",
          "author": "\u5468\u5b50\u7430",
          "album_id": "241855813",
          "album_title": "\u8def\u8fc7\u9752\u6625",
          "relate_status": "0",
          "is_charge": "0",
          "all_rate": "24,64,128,192,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "14887757",
          "copy_type": "1",
          "has_mv": 0,
          "toneid": "0",
          "resource_type": "0",
          "is_ksong": "0",
          "has_mv_mobile": 0,
          "ting_uid": "8025983",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 0,
          "learn": 0,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0000000000",
          "share": "http:\/\/music.baidu.com\/song\/241855699"
        },
        {
          "title": "\u591a\u8fdc\u90fd\u8981\u5728\u4e00\u8d77",
          "song_id": "137098520",
          "author": "G.E.M.\u9093\u7d2b\u68cb",
          "album_id": "256964041",
          "album_title": "\u65b0\u7684\u5fc3\u8df3",
          "relate_status": "0",
          "is_charge": "0",
          "all_rate": "24,64,128,192,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "1814",
          "copy_type": "1",
          "has_mv": 0,
          "toneid": "0",
          "resource_type": "0",
          "is_ksong": "0",
          "has_mv_mobile": 0,
          "ting_uid": "7898",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 0,
          "learn": 0,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0000000000",
          "share": "http:\/\/music.baidu.com\/song\/137098520"
        },
        {
          "title": "\u5fc3\u7535\u611f\u5e94",
          "song_id": "18271037",
          "author": "\u6881\u9759\u8339",
          "album_id": "14950867",
          "album_title": "\u7231\u4e45\u89c1\u4eba\u5fc3",
          "relate_status": "0",
          "is_charge": "1",
          "all_rate": "24,64,128,192,219,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "120",
          "copy_type": "1",
          "has_mv": 0,
          "toneid": "600902000009442322",
          "resource_type": "0",
          "is_ksong": "0",
          "has_mv_mobile": 0,
          "ting_uid": "1095",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 1,
          "learn": 0,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0000000000",
          "share": "http:\/\/music.baidu.com\/song\/18271037"
        },
        {
          "title": "\u6700\u7231\u6307\u6570",
          "song_id": "275880",
          "author": "\u4f59\u6587\u4e50",
          "album_id": "7313053",
          "album_title": "Lost And Found",
          "relate_status": "0",
          "is_charge": "1",
          "all_rate": "24,64,128,192,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "5142",
          "copy_type": "1",
          "has_mv": 1,
          "toneid": "0",
          "resource_type": "0",
          "is_ksong": "0",
          "has_mv_mobile": 1,
          "ting_uid": "7638",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 1,
          "learn": 0,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "1000000000",
          "share": "http:\/\/music.baidu.com\/song\/275880"
        },
        {
          "title": "I Really Like You",
          "song_id": "257113237",
          "author": "Carly Rae Jepsen",
          "album_id": "257113099",
          "album_title": "I Really Like You",
          "relate_status": "0",
          "is_charge": "0",
          "all_rate": "24,64,128,192,256,320",
          "high_rate": "320",
          "all_artist_id": "2024840",
          "copy_type": "1",
          "has_mv": 0,
          "toneid": "0",
          "resource_type": "0",
          "is_ksong": "0",
          "has_mv_mobile": 0,
          "ting_uid": "2387380",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 0,
          "learn": 0,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0000000000",
          "share": "http:\/\/music.baidu.com\/song\/257113237"
        },
        {
          "title": "\u5982\u679c\u7231",
          "song_id": "114627576",
          "author": "\u5f20\u5b66\u53cb",
          "album_id": "65510034",
          "album_title": "\u5f20\u5b66\u53cb1\/2\u4e16\u7eaa\u6f14\u5531\u4f1a",
          "relate_status": "0",
          "is_charge": "1",
          "all_rate": "24,64,128,192,256,320",
          "high_rate": "320",
          "all_artist_id": "23",
          "copy_type": "1",
          "has_mv": 1,
          "toneid": "0",
          "resource_type": "0",
          "is_ksong": "0",
          "has_mv_mobile": 1,
          "ting_uid": "2507",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 1,
          "learn": 0,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0100000000",
          "share": "http:\/\/music.baidu.com\/song\/114627576"
        },
        {
          "title": "\u4f60\u7ed9\u6211\u7684\u7231\u6700\u591a",
          "song_id": "232885",
          "author": "\u5f20\u5b66\u53cb",
          "album_id": "7325421",
          "album_title": "\u543b\u522b",
          "relate_status": "0",
          "is_charge": "1",
          "all_rate": "24,64,128,192,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "23",
          "copy_type": "1",
          "has_mv": 0,
          "toneid": "0",
          "resource_type": "0",
          "is_ksong": "1",
          "has_mv_mobile": 0,
          "ting_uid": "2507",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 1,
          "learn": 1,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0000000000",
          "share": "http:\/\/music.baidu.com\/song\/232885"
        },
        {
          "title": "\u7231\u7b11\u7684\u773c\u775b",
          "song_id": "5738291",
          "author": "\u6797\u4fca\u6770",
          "album_id": "2496539",
          "album_title": "\u5979\u8bf4 \u6982\u5ff5\u81ea\u9009\u8f91",
          "relate_status": "0",
          "is_charge": "0",
          "all_rate": "31,32,64,128,192,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "45",
          "copy_type": "1",
          "has_mv": 1,
          "toneid": "600902000008745982",
          "resource_type": "0",
          "is_ksong": "1",
          "has_mv_mobile": 1,
          "ting_uid": "1052",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 0,
          "learn": 1,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0100000000",
          "share": "http:\/\/music.baidu.com\/song\/5738291"
        },
        {
          "title": "\u7f8e\u68a6\u6210\u771f",
          "song_id": "227570",
          "author": "\u8bb8\u8339\u82b8",
          "album_id": "70741",
          "album_title": "\u56fd\u8bed\u771f\u7ecf\u5178",
          "relate_status": "0",
          "is_charge": "1",
          "all_rate": "24,64,128,192,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "334",
          "copy_type": "1",
          "has_mv": 1,
          "toneid": "600902000005304257",
          "resource_type": "0",
          "is_ksong": "1",
          "has_mv_mobile": 1,
          "ting_uid": "1204",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 1,
          "learn": 1,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "1100000000",
          "share": "http:\/\/music.baidu.com\/song\/227570"
        },
        {
          "title": "\u53ef\u4ee5\u7231\u4f60\u771f\u597d",
          "song_id": "885391",
          "author": "\u8521\u5065\u96c5",
          "album_id": "7312201",
          "album_title": "\u76f8\u4fe1 I Do Blieve",
          "relate_status": "0",
          "is_charge": "1",
          "all_rate": "24,64,128,192,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "295",
          "copy_type": "1",
          "has_mv": 1,
          "toneid": "600902000005266665",
          "resource_type": "0",
          "is_ksong": "1",
          "has_mv_mobile": 1,
          "ting_uid": "1180",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 1,
          "learn": 1,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "1100000000",
          "share": "http:\/\/music.baidu.com\/song\/885391"
        },
        {
          "title": "\u5199\u4e0d\u5b8c\u7684\u6e29\u67d4",
          "song_id": "360662",
          "author": "G.E.M.\u9093\u7d2b\u68cb",
          "album_id": "360694",
          "album_title": "18...",
          "relate_status": "0",
          "is_charge": "0",
          "all_rate": "24,64,128,192,210,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "1814",
          "copy_type": "1",
          "has_mv": 1,
          "toneid": "0",
          "resource_type": "0",
          "is_ksong": "1",
          "has_mv_mobile": 1,
          "ting_uid": "7898",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 0,
          "learn": 1,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0100000000",
          "share": "http:\/\/music.baidu.com\/song\/360662"
        },
        {
          "title": "\u56db\u6b21\u6211\u7231\u4f60",
          "song_id": "2118911",
          "author": "\u5f90\u82e5\u7444",
          "album_id": "2022420",
          "album_title": "\u6211\u7231\u4f60\u00d74",
          "relate_status": "0",
          "is_charge": "0",
          "all_rate": "24,64,128,192,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "274",
          "copy_type": "1",
          "has_mv": 0,
          "toneid": "0",
          "resource_type": "0",
          "is_ksong": "1",
          "has_mv_mobile": 0,
          "ting_uid": "1168",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 0,
          "learn": 1,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0000000000",
          "share": "http:\/\/music.baidu.com\/song\/2118911"
        },
        {
          "title": "\u7231\u6709\u5f15\u529b",
          "song_id": "259823887",
          "author": "\u674e\u5b87\u6625",
          "album_id": "259823979",
          "album_title": "\u6df7\u86cb\uff0c\u6211\u60f3\u4f60",
          "relate_status": "0",
          "is_charge": "0",
          "all_rate": "64,128,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "1",
          "copy_type": "1",
          "has_mv": 0,
          "toneid": "0",
          "resource_type": "0",
          "is_ksong": "0",
          "has_mv_mobile": 0,
          "ting_uid": "1025",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 0,
          "learn": 0,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0000000000",
          "share": "http:\/\/music.baidu.com\/song\/259823887"
        },
        {
          "title": "\u5c0f\u7231\u60c5",
          "song_id": "16679081",
          "author": "\u6881\u9759\u8339",
          "album_id": "16679089",
          "album_title": "\u5c0f\u7231\u60c5",
          "relate_status": "0",
          "is_charge": "0",
          "all_rate": "24,64,128,192,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "120",
          "copy_type": "1",
          "has_mv": 1,
          "toneid": "600902000009442294",
          "resource_type": "0",
          "is_ksong": "0",
          "has_mv_mobile": 1,
          "ting_uid": "1095",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 0,
          "learn": 0,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "1100000000",
          "share": "http:\/\/music.baidu.com\/song\/16679081"
        },
        {
          "title": "\u7231\u7684\u52c7\u6c14",
          "song_id": "123413701",
          "author": "\u66f2\u5a49\u5a77",
          "album_id": "123413697",
          "album_title": "\u7231\u7684\u52c7\u6c14(\u7535\u89c6\u5267\u0022\u79bb\u5a5a\u5f8b\u5e08\u0022\u4e3b\u9898\u66f2)",
          "relate_status": "0",
          "is_charge": "1",
          "all_rate": "24,64,128,192,256,320",
          "high_rate": "320",
          "all_artist_id": "10490649",
          "copy_type": "1",
          "has_mv": 0,
          "toneid": "0",
          "resource_type": "0",
          "is_ksong": "0",
          "has_mv_mobile": 0,
          "ting_uid": "687850",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 1,
          "learn": 0,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0000000000",
          "share": "http:\/\/music.baidu.com\/song\/123413701"
        },
        {
          "title": "\u53ea\u5bf9\u4f60\u6709\u611f\u89c9",
          "song_id": "2496515",
          "author": "\u6797\u4fca\u6770",
          "album_id": "2496539",
          "album_title": "\u5979\u8bf4 \u6982\u5ff5\u81ea\u9009\u8f91",
          "relate_status": "0",
          "is_charge": "0",
          "all_rate": "24,64,128,192,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "45",
          "copy_type": "1",
          "has_mv": 0,
          "toneid": "600902000008745978",
          "resource_type": "0",
          "is_ksong": "1",
          "has_mv_mobile": 0,
          "ting_uid": "1052",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 0,
          "learn": 1,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0000000000",
          "share": "http:\/\/music.baidu.com\/song\/2496515"
        },
        {
          "title": "\u597d\u7537\u4eba",
          "song_id": "7354410",
          "author": "\u9648\u5c0f\u6625",
          "album_id": "7325335",
          "album_title": "Love Best\u6700\u7231\u60c5\u6b4c\u96c62",
          "relate_status": "0",
          "is_charge": "1",
          "all_rate": "24,64,128,192,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "150",
          "copy_type": "1",
          "has_mv": 1,
          "toneid": "600902000001311690",
          "resource_type": "0",
          "is_ksong": "0",
          "has_mv_mobile": 1,
          "ting_uid": "1111",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 1,
          "learn": 0,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "0100000000",
          "share": "http:\/\/music.baidu.com\/song\/7354410"
        },
        {
          "title": "\u5c0f\u7231\u60c5",
          "song_id": "16679081",
          "author": "\u6881\u9759\u8339",
          "album_id": "16679089",
          "album_title": "\u5c0f\u7231\u60c5",
          "relate_status": "0",
          "is_charge": "0",
          "all_rate": "24,64,128,192,256,320,flac",
          "high_rate": "320",
          "all_artist_id": "120",
          "copy_type": "1",
          "has_mv": 1,
          "toneid": "600902000009442294",
          "resource_type": "0",
          "is_ksong": "0",
          "has_mv_mobile": 1,
          "ting_uid": "1095",
          "is_first_publish": 0,
          "havehigh": 2,
          "charge": 0,
          "learn": 0,
          "song_source": "web",
          "piao_id": "0",
          "korean_bb_song": "0",
          "resource_type_ext": "0",
          "mv_provider": "1100000000",
          "share": "http:\/\/music.baidu.com\/song\/16679081"
        }
      ],
      "desc": "\u6211\u4eec\u76f8\u7231\u5427\uff0c\u65e0\u8bba\u5929\u7a7a\u662f\u4ec0\u4e48\u989c\u8272\uff0c\u65e0\u8bba\u96e8\u6ef4\u4f1a\u843d\u5728\u54ea\u91cc\uff0c\u65e0\u8bba\u4f60\u6211\u4ec0\u4e48\u65f6\u5019\u76f8\u9047\uff0c\u6211\u4eec\u76f8\u7231\u5427\u3002",
      "error_code": 22000,
      "height": "520",
      "listenum": "106617",
      "listid": "6437",
      "pic_300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/d6ca7bcb0a46f21f88e86ce8f1246b600d33aea8.jpg",
      "pic_500": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/9f2f070828381f30e224b012ae014c086e06f04f.jpg",
      "pic_w700": "http:\/\/d.hiphotos.baidu.com\/ting\/pic\/item\/c8ea15ce36d3d539fae13d783d87e950342ab0a8.jpg",
      "tag": "\u751c\u871c,\u60c5\u4fa3,\u6d6a\u6f2b,couple",
      "title": "\u6211\u4eec\u76f8\u7231\u5427 \u5728\u82b1\u5f00\u7684\u5b63\u8282",
      "url": "http:\/\/music.baidu.com\/songlist\/6437",
      "width": "520"
    }
    */

    #endregion

    [DataContract, ContentConverter(Converter = typeof(SongListInfoContentConverter))]
    public class gedanInfo : IContentResult
    {
        [DataMember]
        public string collectnum { get; set; }
        [DataMember]
        public string desc { get; set; }
        [DataMember]
        public int error_code { get; set; }
        [DataMember]
        public string height { get; set; }
        [DataMember]
        public string listenum { get; set; }
        [DataMember]
        public string listid { get; set; }
        [DataMember]
        public string pic_300 { get; set; }
        [DataMember]
        public string pic_500 { get; set; }
        [DataMember]
        public string pic_w700 { get; set; }
        [DataMember]
        public string tag { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string width { get; set; }

        [DataMember]
        public List<_song> content { get; set; }

        public gedanInfo()
        {
            this.content = new List<_song>();
        }

        [DataContract]
        public class _song
        {
            [DataMember]
            public string album_id { get; set; }
            [DataMember]
            public string album_title { get; set; }
            [DataMember]
            public string all_artist_id { get; set; }
            [DataMember]
            public string all_rate { get; set; }
            [DataMember]
            public string author { get; set; }
            [DataMember]
            public int charge { get; set; }
            [DataMember]
            public string copy_type { get; set; }
            [DataMember]
            public int has_mv { get; set; }
            [DataMember]
            public int has_mv_mobile { get; set; }
            [DataMember]
            public int havehigh { get; set; }
            [DataMember]
            public string high_rate { get; set; }
            [DataMember]
            public string is_charge { get; set; }
            [DataMember]
            public int is_first_publish { get; set; }
            [DataMember]
            public string is_ksong { get; set; }
            [DataMember]
            public string korean_bb_song { get; set; }
            [DataMember]
            public int learn { get; set; }
            [DataMember]
            public string mv_provider { get; set; }
            [DataMember]
            public string piao_id { get; set; }
            [DataMember]
            public string relate_status { get; set; }
            [DataMember]
            public string resource_type { get; set; }
            [DataMember]
            public string resource_type_ext { get; set; }
            [DataMember]
            public string share { get; set; }
            [DataMember]
            public string song_id { get; set; }
            [DataMember]
            public string song_source { get; set; }
            [DataMember]
            public string ting_uid { get; set; }
            [DataMember]
            public string title { get; set; }
            [DataMember]
            public string toneid { get; set; }
        }
    }
}
