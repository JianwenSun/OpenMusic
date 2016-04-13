using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Baidu
{
    public interface IBaiduClient : IClient
    {
        IBaiduRestClient RestClient { get; }
    }
}
