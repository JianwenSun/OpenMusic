using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Baidu
{
    public class ParameterAttribute : Attribute
    {
        public string Key { get; set; }

        public virtual string GetKey(Parameter parameter)
        {
            return this.Key;
        }
    }
}
