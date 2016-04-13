using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMusic.Datas
{
    public interface ISongList : IItem
    {
        List<ISong> Songs { get; set; }

        string CollectNumber { get; set; }
        string Describtion { get; set; }
        string ListId { get; set; }
        string ListenNumber { get; set; }
        string PictureS300 { get; set; }
        string PictureS500 { get; set; }
        string Tag { get; set; }
        string Title { get; set; }
        string Url { get; set; }
    }
}