using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Datas
{
    public interface IVideo : IItem
    {
        string AliasTitle { get; set; }
        string AllArtistId { get; set; }
        string Artist { get; set; }
        string ArtistId { get; set; }
        string VideoId { get; set; }
        string Provider { get; set; }
        string PublishTime { get; set; }
        string SubTitle { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        string Thumbnail { get; set; }
        string Title { get; set; }
    }
}
