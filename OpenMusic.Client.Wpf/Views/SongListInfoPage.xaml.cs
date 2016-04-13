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
    using Datas;
    using ViewModels;

    /// <summary>
    /// Interaction logic for SongListInfoPage.xaml
    /// </summary>
    public partial class SongListInfoPage : Page
    {
        public SongListInfoPage()
        {
            InitializeComponent();
        }

        public SongListInfoPage(ISongList songlist)
        {
            InitializeComponent();
            this.Dispatcher.BeginInvoke(new Action(()=> 
            {
                (this.DataContext as SongListInfoPageViewModel).GetInfo(songlist);
            }));
        }
    }
}
