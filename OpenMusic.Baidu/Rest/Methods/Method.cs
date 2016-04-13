using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Baidu
{
    [Parameter(Key = "method")]
    public abstract class Method : Parameter
    {
        public ParameterCollection Parameters { get; }

        public Method()
        {
            this.Parameters = new ParameterCollection();
        }
    }
}
