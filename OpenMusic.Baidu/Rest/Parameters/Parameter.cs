using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace OpenMusic.Baidu
{
    public class Parameter : IParameter
    {
        public static Parameter Make(string key, string value)
        {
            return new Parameter(key, value);
        }

        public string Key { get; set; }

        public string Value { get; set; }

        public Parameter()
        {
            this.Value = string.Empty;

            ParameterAttribute attribute = this.GetType().GetTypeInfo().GetCustomAttribute<ParameterAttribute>();
            if (attribute != null)
                this.Key = (attribute).GetKey(this);
        }

        public Parameter(string value)
            : this()
        {
            this.Value = value;
        }

        public Parameter(string name, string value)
        {
            this.Key = name;
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Parameter)
                return (obj as Parameter).Key == this.Key;

            return false;
        }

        public override int GetHashCode()
        {
            return this.Key.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.Key, this.Value);
        }
    }
}
