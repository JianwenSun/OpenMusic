using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenMusic.Baidu
{
    public interface IBaiduRestClient
    {
        IBaiduClient BaiduClient { get; }

        /// <summary>
        /// Execute request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BaiduRestResponse> SendAsync([NotNull] BaiduRestRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
