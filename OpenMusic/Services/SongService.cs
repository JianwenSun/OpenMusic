using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Services
{
    using OpenMusic.Contents;

    public abstract class SongService : Service, ISongService
    {
        public SongService(IClient client) : base(client) { }
        /// <summary>
        /// Get song information
        /// </summary>
        /// <param name="songId"></param>
        /// <returns>song detail</returns>
        public abstract Task<SongInfoContent> GetInfosAsync(string songId);

        /// <summary>
        /// Get song information
        /// </summary>
        /// <param name="songId"></param>
        /// <returns>song detail</returns>
        public abstract Task<SongInfoContent> GetInfoAsync(string songId);
    }
}