using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Extends
{
    public static class DataExtends
    {
        public static void CopyFrom(this ICopyAble item, ICopyAble from)
        {
            if (item.GetType() != from.GetType())
                throw new Exception("CopyFrom method error.");

            foreach (var propertyInfo in item.GetType().GetRuntimeProperties())
            {
                propertyInfo.SetValue(item, propertyInfo.GetValue(from));
            }
        }
    }
}
