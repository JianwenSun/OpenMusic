using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OpenMusic.Contents
{
    using OpenMusic.Extends;
    public class Content : ICopyAble
    {
        public bool HasError { get; set; }
        public Exception Exception { get; set; }

        public string Value { get; set; }
    }
}
