using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf.ViewModels
{
    using Contents;
    using OpenMusic.Datas;
    using OpenMusic.Services;
    using Services;
    public class SongInfoPageViewModel : PageViewModel
    {
        public ISong Song { get; private set; }

        string pictureUrl;
        public string PictureUrl
        {
            get { return pictureUrl; }
            set
            {
                if (pictureUrl != value)
                {
                    pictureUrl = value;
                    this.RasiePropertyChanged("PictureUrl");
                }
            }
        }

        public SongInfoPageViewModel(ServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
        }

        public async void GetInfo(ISong song, Action action)
        {
            SongInfoContent content = await ServiceProvider.GetService<ISongService>().GetInfoAsync(song.SongId);
            if (!content.HasError)
            {
                this.Song = content.Item;
                this.PictureUrl = this.Song.PictureBig;
            }

            action();
        }
    }
}
