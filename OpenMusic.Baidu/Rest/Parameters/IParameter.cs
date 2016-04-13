using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Baidu
{
    public interface IParameter
    {
        string Key { get; }
        string Value { get; set; }
    }
}
