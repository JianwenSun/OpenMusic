using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenMusic.Wpf.Views
{
    using OpenMusic.Datas;
    using Services;
    using ViewModels;
    /// <summary>
    /// Interaction logic for SongInfoPage.xaml
    /// </summary>
    public partial class SongInfoPage : Page
    {
        public SongInfoPage()
        {
            InitializeComponent();
        }

        public SongInfoPage(ISong song)
        {
            InitializeComponent();

            this.Dispatcher.BeginInvoke(new Action(() => 
            {
                (this.DataContext as SongInfoPageViewModel).GetInfo(song, ()=> 
                {
                    ISong song1 = (this.DataContext as SongInfoPageViewModel).Song;
                    Task.Run(() =>
                    {
                        PlayerService.Default.Play(song1);
                    });
                });
            }));
        }
    }
}
