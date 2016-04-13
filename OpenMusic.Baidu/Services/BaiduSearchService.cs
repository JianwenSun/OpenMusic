using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu.Services
{
    using Newtonsoft.Json;
    using OpenMusic.Contents;
    using OpenMusic.Services;

    /// <summary>
    /// baidu search service
    /// </summary>
    [Service(ServiceType = typeof(ISearchService), ServiceImpType = typeof(BaiduSearchService))]
    public sealed class BaiduSearchService : SearchService, IBaiduService
    {
        public static BaiduSearchService GetService(IBaiduClient client) => new BaiduSearchService(client);

        public IBaiduClient BaiduClient { get { return (IBaiduClient)this.Client; } }

        public BaiduSearchService(IBaiduClient client) 
            : base(client)
        {

        }

        /// <summary>
        /// suggestion
        /// </summary>
        /// <param name="query"></param>
        /// <returns>only song names</returns>
        public async override Task<SongSuggestionContent> GetSongSuggestionAsync(string query)
        {
            return await this.GetResponse(new SongSuggestionContent(), SearchMethod.Suggestion(query), (o) =>
            {
                if (o.HasError) return;
                suggestion suggestion = (suggestion)JsonConvert.DeserializeObject(o.Value, typeof(suggestion));
                o.Query = suggestion.query;
                o.Items = suggestion.suggestion_list;
            });
        }

        /// <summary>
        /// (search.merge)
        /// </summary>
        /// <param name="query"></param>
        /// <returns>catalogs contains song, album, artist</returns>
        public async override Task<CatalogContent> GetCatalogAsync(string query, int pageNumber = 1, int? pageSize = default(int?))
        {
            return await this.GetResponse(new CatalogContent(), SearchMethod.Merge(query, pageNumber, pageSize), (o) =>
            {
                ContentConverter.Convert(o, (merge)JsonConvert.DeserializeObject(o.Value, typeof(merge)));
            });
        }

        /// <summary>
        /// (search.catalogSug)
        /// </summary>
        /// <param name="query"></param>
        /// <returns>suggestion contain song, album, artist</returns>
        public async override Task<CatalogSuggestionContent> GetCatalogSuggestionAsync(string query)
        {
            return await this.GetResponse(new CatalogSuggestionContent(), SearchMethod.CatalogSug(query), (o)=> 
            {
                catalogSug catalogSug = (catalogSug)JsonConvert.DeserializeObject(o.Value, typeof(catalogSug));
            });
        }

        /// <summary>
        /// (search.common)
        /// </summary>
        /// <param name="query"></param>
        /// <returns>only songs</returns>
        public async override Task<SongContent> GetSongsAsync(string query, int pageNumber = 1, int? pageSize = default(int?))
        {
            return await this.GetResponse(new SongContent(), SearchMethod.Common(query, pageNumber, pageSize), (o) =>
            {
                common common = (common)JsonConvert.DeserializeObject(o.Value, typeof(common));
            });
        }

        private async Task<T> GetResponse<T, M>(T content, M method, Action<T> callback)
            where T : Content
            where M : SearchMethod
        {
            Exception exception = null;
            try
            {
                BaiduRestResponse response = await this.BaiduClient.RestClient.SendAsync(Activator.CreateInstance<BaiduRestRequest>()
                    .SetFormat(Format.Json)
                    .SetMethod(method));

                exception = response.Exception;
                content.Value = response.Content;
            }
            catch (Exception e)
            {
                exception = e;
            }
            finally
            {
                if (exception != null)
                {
                    content.Exception = exception;
                    content.HasError = true;
                }
            }

            if (!content.HasError)
                callback.Invoke(content);
            return content;
        }
    }
}