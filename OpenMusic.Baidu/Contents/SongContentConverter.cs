using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OpenMusic.Baidu
{
    using OpenMusic.Contents;
    using OpenMusic.Extends;
    public sealed class SongContentConverter : ContentConverter<SongContent, common>
    {
        public override SongContent Convert(common result)
        {
            SongContent content = new SongContent();
            return content;
        }

        public override void Convert(SongContent content, common result)
        {
            content.CopyFrom(this.Convert(result));
        }
    }
}
