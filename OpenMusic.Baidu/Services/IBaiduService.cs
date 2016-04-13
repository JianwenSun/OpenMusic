using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu.Services
{
    public interface IBaiduService
    {
        IBaiduClient BaiduClient { get; }
    }
}
