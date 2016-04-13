using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace OpenMusic.Baidu
{
    public class BaiduRestResponse : IDisposable
    {
        public BaiduRestRequest Request { get; set; }

        public HttpResponseMessage ResponseMessage { get; private set; }

        public string Content { get; private set; }

        public Exception Exception { get; private set; }

        private BaiduRestResponse()
        {
            this.Content = string.Empty;
        }

        public BaiduRestResponse([NotNull] BaiduRestRequest request, [NotNull] HttpResponseMessage responseMessage, string content)
            : this()
        {
            this.Request = request;
            this.ResponseMessage = responseMessage;
            this.Content = content;
        }

        public BaiduRestResponse([NotNull] BaiduRestRequest request, [NotNull] HttpResponseMessage responseMessage, Exception exception)
            : this()
        {
            this.Request = request;
            this.ResponseMessage = responseMessage;
            this.Exception = exception;
        }

        #region IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            ResponseMessage.Dispose();
        }

        #endregion
    }
}
