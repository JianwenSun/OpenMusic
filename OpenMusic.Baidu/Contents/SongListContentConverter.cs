using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using OpenMusic.Conveters;

namespace OpenMusic.Baidu
{
    using OpenMusic.Contents;
    using OpenMusic.Datas;
    using OpenMusic.Extends;
    public sealed class SongListContentConverter : ContentConverter<SongListContent, gedan>
    {
        public override SongListContent Convert(gedan result)
        {
            return new SongListContent()
            {
                HaveMore = result.havemore,
                Total = result.total,
                SongLists = result.content.Select<gedan._songlist, ISongList>((o) => 
                {
                    return new SongList()
                    {
                        CollectNumber = o.collectnum,
                        Describtion = o.desc,
                        ListId = o.listid,
                        ListenNumber = o.listenum,
                        PictureS300 = o.pic_300,
                        Tag = o.tag,
                        Title = o.title,
                        State = o
                    };
                }).ToList()
            };
        }

        public override void Convert(SongListContent content, gedan result)
        {
            content.CopyFrom(this.Convert(result));
        }
    }
}
