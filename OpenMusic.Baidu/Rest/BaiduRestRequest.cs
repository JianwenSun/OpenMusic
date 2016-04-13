using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace OpenMusic.Baidu
{
    public class BaiduRestRequest
    {
        public const string Url = @"http://tingapi.ting.baidu.com";

        public HttpMethod Method { get; set; }

        public Format Format { get; set; }
        public From From { get; set; }
        public Segment Server { get; set; }
        public Segment Version { get; set; }
        public Segment Ting { get; }
        public ParameterCollection Parameters { get; private set; }

        public BaiduRestRequest()
        {
            this.Parameters = new ParameterCollection();
            this.Ting = new Segment("ting");
            this.Method = HttpMethod.Get;
            this.Server = Baidu.Server.RestServer;
            this.Version = Baidu.Version.V1;
            this.Format = Baidu.Format.Json;
            this.From = Baidu.From.QianQian;
            this.Parameters.Add(this.Format);
            this.Parameters.Add(this.From);
            if (this.From.Version != null)
                this.Parameters.Add(this.From.Version);
        }

        public BaiduRestRequest SetFormat(Format format)
        {
            if (this.Parameters.Contains(format))
                this.Parameters.Remove(format);

            this.Parameters.Add(format);
            return this;
        }

        public BaiduRestRequest SetMethod(Method method)
        {
            this.Parameters.Add(method);
            this.Parameters.Add(method.Parameters);
            return this;
        }
        public Uri GetUri()
        {
            StringBuilder builder = new StringBuilder(Url);
            SegmentCollection segments = new SegmentCollection();
            segments.Add(this.Version);
            segments.Add(this.Server);
            segments.Add(this.Ting);
            foreach (var segment in segments)
                builder.Append(string.Format("/{0}", segment.Name));
            builder.Append("?");
            builder.Append(Parameters.ToString());
            return new Uri(builder.ToString());
        }
    }
}
