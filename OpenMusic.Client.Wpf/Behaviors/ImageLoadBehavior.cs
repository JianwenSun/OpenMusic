using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace OpenMusic.Wpf.Behaviors
{
    public class ImageLoadBehavior : LoadBehavior<Image>
    {
        public static readonly DependencyProperty UseAnimationProperty
           = DependencyProperty.Register("UseAnimation", typeof(bool),
               typeof(ImageLoadBehavior),
               new PropertyMetadata(true));

        public bool UseAnimation
        {
            get { return (bool)this.GetValue(UseAnimationProperty); }
            set { this.SetValue(UseAnimationProperty, value); }
        }

        public override void CallBack(byte[] buffer)
        {
            var bitmapImage = new BitmapImage();

            using (var stream = new MemoryStream(buffer))
            {
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
            }

            Dispatcher.BeginInvoke((Action)(() => 
            {
                this.AssociatedObject.Source = bitmapImage;
                DoubleAnimation daV = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.6)));
                this.AssociatedObject.BeginAnimation(UIElement.OpacityProperty, daV);
            }), DispatcherPriority.DataBind);
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation daV = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.6)));
            this.AssociatedObject.BeginAnimation(UIElement.OpacityProperty, daV);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
    }
}
 