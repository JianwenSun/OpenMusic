using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf.ViewModels
{
    using OpenMusic.Datas;
    using OpenMusic.Contents;
    using OpenMusic.Services;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using System.Windows.Data;
    using Commands;
    public class SongListInfoPageViewModel : PageViewModel
    {
        public ISongList SongList { get; private set; }
        public ICollectionView CollectionView { get; private set; }
        public ObservableCollection<ISong> Songs { get; set; }

        string pictureUrl;
        public string PictureUrl
        {
            get { return pictureUrl; }
            set
            {
                if(pictureUrl != value)
                {
                    pictureUrl = value;
                    this.RasiePropertyChanged("PictureUrl");
                }
            }
        }

        public SongListInfoPageViewModel(ServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
            this.Songs = new ObservableCollection<ISong>();
            this.CollectionView = new ListCollectionView(this.Songs);
        }

        public async void GetInfo(ISongList songlist)
        {
            this.SongList = songlist;

            SongListInfoContent content = await ServiceProvider.GetService<ISongListService>().GedanInfoAsync(this.SongList.ListId);
            if (!content.HasError)
            {
                foreach (var song in content.Songs)
                {
                    this.Songs.Add(song);
                }

                this.PictureUrl = content.PictureS500;
            }
        }
    }
}
