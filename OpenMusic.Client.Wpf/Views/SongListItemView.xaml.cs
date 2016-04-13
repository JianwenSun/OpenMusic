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
    using MetroApp.Commands;
    using Navigations;
    using OpenMusic.Datas;
    using ViewModels;
    /// <summary>
    /// Interaction logic for SongListItemView.xaml
    /// </summary>
    public partial class SongListItemView : UserControl
    {
        public static readonly DependencyProperty SongListInfoCommandProperty
            = DependencyProperty.Register("SongListInfoCommand", typeof(ICommand), typeof(SongListItemView));

        public ICommand SongListInfoCommand
        {
            get { return (ICommand)this.GetValue(SongListInfoCommandProperty); }
            set { this.SetValue(SongListInfoCommandProperty, value); }
        }

        public SongListItemView()
        {
            this.SongListInfoCommand = new Command(this.ExecuteShowListInfoCommand, this.CanExecuteShowListInfoCommand);
            InitializeComponent();
        }

        private void ExecuteShowListInfoCommand(object obj)
        {
            NavigationViewService service = NavigationViewService.GetNavigationService(this);
            service.Navigate(new SongListInfoPage(obj as ISongList));
        }

        private bool CanExecuteShowListInfoCommand(object obj)
        {
            return NavigationViewService.CanNavigate(this);
        }
    }
}
