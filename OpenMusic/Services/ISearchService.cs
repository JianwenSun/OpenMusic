using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Services
{
    using OpenMusic.Contents;

    public interface ISearchService : IService
    {
        /// <summary>
        /// Get songs
        /// </summary>
        /// <param name="query"></param>
        /// <returns>only songs</returns>
        Task<SongContent> GetSongsAsync(string query, int pageNumber = 1, int? pageSize = null);

        /// <summary>
        /// get song names (search.suggestion)
        /// </summary>
        /// <param name="query"></param>
        /// <returns>only song names</returns>
        Task<SongSuggestionContent> GetSongSuggestionAsync(string query);

        /// <summary>
        /// get catalog suggestions (search.catalogSug)
        /// </summary>
        /// <param name="query"></param>
        /// <returns>song, album, artist</returns>
        Task<CatalogSuggestionContent> GetCatalogSuggestionAsync(string query);

        /// <summary>
        /// get query (search.merge)
        /// </summary>
        /// <param name="query"></param>
        /// <returns>song, album, artist</returns>
        Task<CatalogContent> GetCatalogAsync(string query, int pageNumber = 1, int? pageSize = null);
    }
}