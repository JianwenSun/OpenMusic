using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Services
{
    using OpenMusic.Contents;

    public abstract class SearchService : Service, ISearchService
    {
        public SearchService(IClient client) : base(client) { }
        public abstract Task<CatalogContent> GetCatalogAsync(string query, int pageNumber = 1, int? pageSize = default(int?));
        public abstract Task<CatalogSuggestionContent> GetCatalogSuggestionAsync(string query);
        public abstract Task<SongContent> GetSongsAsync(string query, int pageNumber = 1, int? pageSize = default(int?));
        public abstract Task<SongSuggestionContent> GetSongSuggestionAsync(string query);
    }
}