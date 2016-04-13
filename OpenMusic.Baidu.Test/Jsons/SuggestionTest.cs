using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu.Test
{
    [TestClass]
    public class SuggestionTest
    {
        [TestMethod]
        public void Test()
        {
            catalogSug catalogSug = new catalogSug();
            catalogSug.song = new List<catalogSug._song>()
            {
                new catalogSug._song() { artistname = "s", bitrate_fee = "s", control = "b", encrypted_songid = "v", has_mv = "0", songid = "123123", songname = "123", yyr_artist = "sss" },
                new catalogSug._song() { artistname = "s", bitrate_fee = "s", control = "b", encrypted_songid = "v", has_mv = "0", songid = "123123", songname = "123", yyr_artist = "sss" },
                new catalogSug._song() { artistname = "s", bitrate_fee = "s", control = "b", encrypted_songid = "v", has_mv = "0", songid = "123123", songname = "123", yyr_artist = "sss" },
                new catalogSug._song() { artistname = "s", bitrate_fee = "s", control = "b", encrypted_songid = "v", has_mv = "0", songid = "123123", songname = "123", yyr_artist = "sss" },
            };

            catalogSug.album = new List<catalogSug._album>()
            {
                new catalogSug._album() { albumid = "123320", albumname = "sdsadsda", artistname = "sssss", artistpic = "22222222" },
                new catalogSug._album() { albumid = "123320", albumname = "sdsadsda", artistname = "sssss", artistpic = "22222222" },
                new catalogSug._album() { albumid = "123320", albumname = "sdsadsda", artistname = "sssss", artistpic = "22222222" },
                new catalogSug._album() { albumid = "123320", albumname = "sdsadsda", artistname = "sssss", artistpic = "22222222" },
            };

            catalogSug.artist = new List<catalogSug._artist>()
            {
                new catalogSug._artist() { artistid = "3232", artistpic = "sssssssssss", artistname = "dsdsds", yyr_artist = "sssssssssss" },
                new catalogSug._artist() { artistid = "3232", artistpic = "sssssssssss", artistname = "dsdsds", yyr_artist = "sssssssssss" },
                new catalogSug._artist() { artistid = "3232", artistpic = "sssssssssss", artistname = "dsdsds", yyr_artist = "sssssssssss" },
                new catalogSug._artist() { artistid = "3232", artistpic = "sssssssssss", artistname = "dsdsds", yyr_artist = "sssssssssss" },
            };

            catalogSug.error_code = 20000;
            catalogSug.order = "dsdsdsds";

            string content = JsonConvert.SerializeObject(catalogSug);
            catalogSug suggestion = (catalogSug)JsonConvert.DeserializeObject(content, typeof(catalogSug));
            string content1 = JsonConvert.SerializeObject(suggestion);
            Assert.IsTrue(content == content1);
        }
    }
}
