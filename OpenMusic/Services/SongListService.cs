using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Services
{
    using OpenMusic.Contents;

    public abstract class SongListService : Service, ISongListService
    {
        public SongListService(IClient client) : base(client) { }
        /// <summary>
        /// ge dan
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public abstract Task<SongListContent> GedanAsync(int pageNumber = 1, int? pageSize = null);

        /// <summary>
        /// dedan info
        /// </summary>
        /// <param name="listid"></param>
        /// <returns></returns>
        public abstract Task<SongListInfoContent> GedanInfoAsync(string listid);
    }
}
