using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;

namespace OpenMusic.Wpf.ViewModels
{
    using Commands;
    using Contents;
    using OpenMusic.Datas;
    using OpenMusic.Services;
    using System.Windows;
    public class SongListViewModel : BaseViewModel
    {
        public ICollectionView CollectionView { get; private set; }
        public ICommand MoreCommand { get; private set; }
        public ObservableCollection<SongList> SongLists { get; set; }
        public int Total { get; set; }
        public int CurrentTotal { get; set; }
        public string Title { get; set; }

        int page = 1;
        int pageSize = 15;
        object locker = new object();

        bool isLoading = false;

        public SongListViewModel(ServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
            this.SongLists = new ObservableCollection<SongList>();
            this.CollectionView = new ListCollectionView(this.SongLists);
            this.MoreCommand = new Command<object>(this.OnShowMore, this.CanShowMore);
            this.Initialize();
        }

        private void Initialize()
        {
            this.AddMore();
        }

        private void OnShowMore(object parameter)
        {
            if (isLoading)
                return;

            lock (locker)
            {
                this.AddMore();
            }
        }

        private bool CanShowMore(object parameter)
        {
            return true;
        }

        private async void AddMore()
        {
            isLoading = true;
            SongListContent content = await ServiceProvider.GetService<ISongListService>().GedanAsync(page, pageSize);
            if(!content.HasError)
            {
                foreach (var item in content.SongLists)
                {
                    this.SongLists.Add((SongList)item);
                }
                page++;
            }
            else
            {
                MessageBox.Show(content.Exception.Message);
            }
            isLoading = false;
        }
    }
}
