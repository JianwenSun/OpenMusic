using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenMusic.Baidu
{
    using OpenMusic.Baidu.Services;

    public class BaiduRestClient : IBaiduRestClient
    {
        public IBaiduClient BaiduClient { get; private set; }

        public BaiduRestClient(BaiduClient client)
        {
            this.BaiduClient = client;
        }

        private HttpClient _client;

        /// <summary>
        /// Execute request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BaiduRestResponse> SendAsync([NotNull] BaiduRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            BaiduRestResponse response = null;
            BaiduRestService.GetService(this).SendRequest(request);
            try
            {
                HttpResponseMessage httpResponseMessage = await GetHttpResponseMessage(request, cancellationToken).ConfigureAwait(false);
                string content = await GetResponseContent(httpResponseMessage).ConfigureAwait(false);
                response = new BaiduRestResponse(request, httpResponseMessage, content);
            }
            catch (Exception ex)
            {
                response = new BaiduRestResponse(request, new HttpResponseMessage(HttpStatusCode.BadRequest), ex);
            }
            finally
            {
                BaiduRestService.GetService(this).SendResponse(response);
            }
            return response;
        }

        private async Task<HttpResponseMessage> GetHttpResponseMessage([NotNull] BaiduRestRequest restRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            _client = new HttpClient();
            var message = new HttpRequestMessage(restRequest.Method, restRequest.GetUri());
            return await _client.SendAsync(message, cancellationToken).ConfigureAwait(false);
        }

        private static async Task<string> GetResponseContent([NotNull] HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.NoContent)
            {
                return await response.Content.ReadAsStringAsync().ConfigureAwait(false); ;
            }
            return null;
        }
    }
}
