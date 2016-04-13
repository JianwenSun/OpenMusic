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
    [Service(ServiceType = typeof(ISongService), ServiceImpType = typeof(BaiduSongService))]
    public sealed class BaiduSongService : SongService, IBaiduService
    {
        public static BaiduSongService GetService(IBaiduClient client) => new BaiduSongService(client);

        public IBaiduClient BaiduClient { get { return (IBaiduClient)this.Client; } }

        public BaiduSongService(IBaiduClient client) 
            : base(client)
        {

        }

        /// <summary>
        /// get infor async
        /// </summary>
        /// <param name="songId"></param>
        /// <returns>content</returns>
        public async override Task<SongInfoContent> GetInfoAsync(string songId)
        {
            return await this.GetResponse(new SongInfoContent(), SongMethod.GetInfo(songId), (o) =>
            {
                if (o.HasError) return;
                ContentConverter.Convert(o, (getinfo)JsonConvert.DeserializeObject(o.Value, typeof(getinfo)));
            });
        }

        /// <summary>
        /// get infos async
        /// </summary>
        /// <param name="songId"></param>
        /// <returns>content</returns>
        public async override Task<SongInfoContent> GetInfosAsync(string songId)
        {
            return await this.GetResponse(new SongInfoContent(), SongMethod.GetInfos(songId), (o) =>
            {
                if (o.HasError) return;
                ContentConverter.Convert(o, (getinfos)JsonConvert.DeserializeObject(o.Value, typeof(getinfos)));
            });
        }
        
        private async Task<T> GetResponse<T, M>(T content, M method, Action<T> callback)
            where T : Content
            where M : SongMethod
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
