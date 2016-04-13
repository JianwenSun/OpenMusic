using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Services
{
    using OpenMusic.Contents;
    public interface ISongListService : IService
    {
        /// <summary>
        /// ge dan
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<SongListContent> GedanAsync(int pageNumber = 1, int? pageSize = 20);
        
        /// <summary>
        /// dedan info
        /// </summary>
        /// <param name="listid"></param>
        /// <returns></returns>
        Task<SongListInfoContent> GedanInfoAsync(string listid);
    }
}
