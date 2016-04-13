using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace OpenMusic.Baidu
{
    public class ParameterCollection : List<Parameter>
    {
        public static ParameterCollection Instance
        {
            get { return new ParameterCollection(); }
        }

        public new ParameterCollection Add(Parameter parameter)
        {
            base.Add(parameter);
            return this;
        }

        public ParameterCollection Add(IEnumerable<Parameter> parameters)
        {
            foreach (var parameter in parameters)
                base.Add(parameter);
            return this;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                if(i != this.Count - 1)
                    builder.Append(string.Format("{0}={1}&", this[i].Key, this[i].Value));
                else
                    builder.Append(string.Format("{0}={1}", this[i].Key, this[i].Value));
            }
            return builder.ToString();
        }
    }
}
