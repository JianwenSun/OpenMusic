using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu.Test
{
    using OpenMusic.Baidu.Services;
    using OpenMusic.Contents;
    using OpenMusic.Extends;

    [TestClass]
    public class BaiduSongListServiceTest
    {
        public IBaiduClient Client { get; set; }

        [TestInitialize]
        public void Init()
        {
            this.Client = BaiduClient.Guest;
        }

        [TestMethod]
        public async Task Gedan()
        {
            Assert.IsFalse((await BaiduSongListService.GetService(this.Client).GedanAsync(1)).HasError);
        }

        [TestMethod]
        public async Task GedanInfo()
        {
            Assert.IsFalse((await BaiduSongListService.GetService(this.Client).GedanInfoAsync("6437")).HasError);
        }

        [TestMethod]
        public async Task StepByStep()
        {
            BaiduRestService.GetService(this.Client.RestClient).Responsed += BaiduSongListServiceTest_Responsed;
            SongListContent songlistContent = await BaiduSongListService.GetService(this.Client).GedanAsync(1);
            foreach (var songlist in songlistContent.SongLists)
            {
                SongListInfoContent songlistInfoContent = await BaiduSongListService.GetService(this.Client).GedanInfoAsync(songlist.ListId);
                foreach (var song in songlistInfoContent.Songs)
                {
                    SongInfoContent songInfoContent = await BaiduSongService.GetService(this.Client).GetInfoAsync(song.SongId);
                    song.CopyFrom(songInfoContent.Item);
                }
            }
            BaiduRestService.GetService(this.Client.RestClient).Responsed -= BaiduSongListServiceTest_Responsed;
        }

        private void BaiduSongListServiceTest_Responsed(object sender, BaiduRestEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Response.Content);
        }
    }
}
