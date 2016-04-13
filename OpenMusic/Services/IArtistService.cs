using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Services
{
    using OpenMusic.Contents;
    using OpenMusic.Datas;

    public interface IArtistService : IService
    {
        /// <summary>
        /// get song list by emotion
        /// </summary>
        /// <param name="tEmotion"></param>
        /// <returns></returns>
        Task<SongListContent> GetSongListAsync(TEmotion tEmotion);

        /// <summary>
        /// get song list by language
        /// </summary>
        /// <param name="tLanguage"></param>
        /// <returns></returns>
        Task<SongListContent> GetSongListAsync(TLanguage tLanguage);

        /// <summary>
        /// get song list by scene
        /// </summary>
        /// <param name="tScene"></param>
        /// <returns></returns>
        Task<SongListContent> GetSongListAsync(TScene tScene);

        /// <summary>
        /// get song list by style
        /// </summary>
        /// <param name="tStyle"></param>
        /// <returns></returns>
        Task<SongListContent> GetSongListAsync(TStyle tStyle);

        /// <summary>
        /// get song list by topic
        /// </summary>
        /// <param name="tTopic"></param>
        /// <returns></returns>
        Task<SongListContent> GetSongListAsync(TTopic tTopic);

        /// <summary>
        /// get artist list by area and type
        /// </summary>
        /// <param name="tArea"></param>
        /// <param name="tArtist"></param>
        /// <returns></returns>
        Task<ArtistContent> GetList(TArea tArea, TArtist tArtist);

        /// <summary>
        /// get songs by artist
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        Task<SongContent> GetSongListAsync(IArtist artist);

        /// <summary>
        /// get albums by artist
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        Task<AlbumContent> GetAlbumListAsync(IArtist artist);

        /// <summary>
        /// get infor
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        Task<ArtistContent> GetInforAsync(IArtist artist);
    }
}
