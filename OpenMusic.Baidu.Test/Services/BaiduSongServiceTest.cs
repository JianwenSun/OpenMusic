using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMusic.Baidu.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu.Test
{
    [TestClass]
    public class BaiduSongServiceTest
    {
        [TestMethod]
        public async Task GetInfoAsync()
        {
            Assert.IsFalse((await BaiduSongService.GetService(BaiduClient.Guest).GetInfoAsync("280171")).HasError);
        }

        [TestMethod]
        public async Task GetInfosAsync()
        {
            Assert.IsFalse((await BaiduSongService.GetService(BaiduClient.Guest).GetInfosAsync("280171")).HasError);
        }
    }
}
