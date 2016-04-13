using OpenMusic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf.CacheStorage
{
    public interface ICacheStorageService
    {
        ICacheStorage CacheStorage { get; set; }
    }
}
