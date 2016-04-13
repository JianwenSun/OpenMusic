using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading;

namespace OpenMusic.Wpf.Commands
{
    using Contents;
    using Datas;
    using OpenMusic.Services;
    using Services;
    using OpenMusic.Extends;

    public static class PlayerCommands
    {
        public static ICommand PlaySongCommand = new Command(ExecutePlaySongCommand, CanExecutePlaySongCommand);

        static bool CanExecutePlaySongCommand(object sender)
        {
            ISong song = sender as ISong;
            if (song == null) return false;
            if (song.Urls == null) return false;
            if (song.Urls.Count > 0) return true;

            if (song.Urls.Count == 0)
            {
                ManualResetEvent resetEvent = new ManualResetEvent(false);
                Task.Run(() => {
                    GetSongInfo(song, resetEvent);
                });
                resetEvent.WaitOne();
                return true;
            }

            return false;
        }

        static void ExecutePlaySongCommand(object sender)
        {
            ISong song = sender as ISong;
            PlayerService.Default.Play(song);
        }

        async static void GetSongInfo(ISong song, ManualResetEvent resetEvent)
        {
            ServiceProvider serviceProvider = ApplicationContent.Instance.Injector.Resolve<ServiceProvider>();
            if (serviceProvider != null)
            {
                ISongService songService = serviceProvider.GetService<ISongService>();
                SongInfoContent content = await songService.GetInfoAsync(song.SongId);
                song.CopyFrom(content.Item);
            }

            resetEvent.Set();
        }
    }
}
