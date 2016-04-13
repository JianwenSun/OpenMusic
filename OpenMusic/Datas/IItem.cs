using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Datas
{
    using OpenMusic.Extends;

    public interface IItem : ICopyAble
    {
        object State { get; set; }
    }
}
