using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace OpenMusic.Wpf.Behaviors
{
    using Controls;
    using Services;

    public class PlayerOperationBehavior : Behavior<Player>
    {
        public static readonly DependencyProperty PlayerServiceProperty
          = DependencyProperty.Register("PlayerService", typeof(PlayerService),
              typeof(PlayerOperationBehavior));

        public PlayerService PlayerService
        {
            get { return (PlayerService)this.GetValue(PlayerServiceProperty); }
            set { this.SetValue(PlayerServiceProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            this.PlayerService.Initialize(sender as Player);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
    }
}
