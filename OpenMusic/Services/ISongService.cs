using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Services
{
    using OpenMusic.Contents;
    public interface ISongService : IService
    {
        /// <summary>
        /// Get song information
        /// </summary>
        /// <param name="songId"></param>
        /// <returns>song detail</returns>
        Task<SongInfoContent> GetInfosAsync(string songId);

        /// <summary>
        /// Get song information
        /// </summary>
        /// <param name="songId"></param>
        /// <returns>song detail</returns>
        Task<SongInfoContent> GetInfoAsync(string songId);
    }
}