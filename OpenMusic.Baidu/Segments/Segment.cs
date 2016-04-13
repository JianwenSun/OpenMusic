using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Baidu
{
    public class Segment
    {
        public string Name { get; set; }

        public Segment(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
