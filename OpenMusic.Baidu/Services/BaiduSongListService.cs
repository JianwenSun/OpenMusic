using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu.Services
{
    using Newtonsoft.Json;
    using OpenMusic.Contents;
    using OpenMusic.Conveters;
    using OpenMusic.Services;

    /// <summary>
    /// baidu song service
    /// </summary>
    [Service(ServiceType = typeof(ISongListService), ServiceImpType = typeof(BaiduSongListService))]
    public sealed class BaiduSongListService : SongListService, IBaiduService
    {
        public static BaiduSongListService GetService(IBaiduClient client) => new BaiduSongListService(client);

        public IBaiduClient BaiduClient { get { return (IBaiduClient)this.Client; } }

        public BaiduSongListService(IBaiduClient client) 
            : base(client)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public BaiduSongListService(IClient client) : base(client) { }

        public async override Task<SongListContent> GedanAsync(int pageNumber, int? pageSize = 30)
        {
            return await this.GetResponse(new SongListContent(), DiyMethod.Gedan(pageNumber, pageSize), (o) =>
            {
                ContentConverter.Convert(o, (gedan)JsonConvert.DeserializeObject(o.Value, typeof(gedan)));
            });
        }

        /// <summary>
        /// gedaninfo
        /// </summary>
        /// <param name="listid"></param>
        /// <returns></returns>
        public async override Task<SongListInfoContent> GedanInfoAsync(string listid)
        {
            return await this.GetResponse(new SongListInfoContent(), DiyMethod.GedanInfo(listid), (o) =>
            {
                ContentConverter.Convert(o, (gedanInfo)JsonConvert.DeserializeObject(o.Value, typeof(gedanInfo)));
            });
        }

        private async Task<T> GetResponse<T, M>(T content, M method, Action<T> callback)
            where T : Content
            where M : DiyMethod
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
                if(exception != null)
                {
                    content.Exception = exception;
                    content.HasError = true;
                }
            }

            if(!content.HasError)
                callback.Invoke(content);
            return content;
        }
    }
}
