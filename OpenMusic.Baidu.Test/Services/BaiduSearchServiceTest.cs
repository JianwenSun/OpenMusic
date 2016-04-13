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
    public class BaiduSearchServiceTest
    {
        [TestMethod]
        public async Task GetCatalogSuggestion()
        {
            Assert.IsFalse((await BaiduSearchService.GetService(BaiduClient.Guest).GetCatalogSuggestionAsync("123木头人")).HasError);
        }

        [TestMethod]
        public async Task GetCatalog()
        {
            Assert.IsFalse((await BaiduSearchService.GetService(BaiduClient.Guest).GetCatalogAsync("123木头人")).HasError);
        }

        [TestMethod]
        public async Task GetSongs()
        {
            Assert.IsFalse((await BaiduSearchService.GetService(BaiduClient.Guest).GetSongsAsync("123木头人", 1, 50)).HasError);
        }

        [TestMethod]
        public async Task GetSongSuggestion()
        {
            Assert.IsFalse((await BaiduSearchService.GetService(BaiduClient.Guest).GetSongSuggestionAsync("123木头人")).HasError);
        }
    }
}
