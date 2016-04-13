using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace OpenMusic.Wpf.Helpers
{
    public class ImageLoader : DependencyObject
    {
        public static string GetSourceUrl(DependencyObject obj)
        {
            return (string)obj.GetValue(SourceUrlProperty);
        }

        public static void SetSourceUrl(DependencyObject obj, string value)
        {
            obj.SetValue(SourceUrlProperty, value);
        }

        public static readonly DependencyProperty SourceUrlProperty 
            = DependencyProperty.RegisterAttached("SourceUrl", typeof(string), typeof(ImageLoader), new PropertyMetadata
        {
            PropertyChangedCallback = (obj, e) =>
            {
                ((Image)obj).SetBinding(Image.SourceProperty,
                  new Binding("VerifiedUri")
                  {
                      Source = new ImageLoader { GivenUri = new Uri(e.NewValue.ToString()) },
                      IsAsync = true,
                  });
            }
        });

        Uri GivenUri;
        public Uri VerifiedUri
        {
            get
            {
                try
                {
                    Dns.GetHostEntry(GivenUri.DnsSafeHost);
                    return GivenUri;
                }
                catch (Exception)
                {
                    return null;
                }

            }
        }
    }
}
