using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace OpenMusic.Wpf.Behaviors
{
    using CacheStorage;
    using System.Threading;
    public abstract class LoadBehavior<T> : Behavior<T> where T : DependencyObject
    {
        public static readonly DependencyProperty UrlProperty
            = DependencyProperty.Register("Url", typeof(string), 
                typeof(LoadBehavior<T>),
                new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnUrlPropertyChanged)));

        public string Url
        {
            get { return (string)this.GetValue(UrlProperty); }
            set { this.SetValue(UrlProperty, value); }
        }

        public static readonly DependencyProperty IsLoadingProperty
            = DependencyProperty.Register("IsLoading", typeof(bool), typeof(LoadBehavior<T>));

        public bool IsLoading
        {
            get { return (bool)this.GetValue(IsLoadingProperty); }
            set { this.SetValue(IsLoadingProperty, value); }
        }

        public static readonly DependencyProperty IsCompletedProperty
           = DependencyProperty.Register("IsCompleted", typeof(bool), typeof(LoadBehavior<T>));

        public bool IsCompleted
        {
            get { return (bool)this.GetValue(IsCompletedProperty); }
            set { this.SetValue(IsCompletedProperty, value); }
        }

        public abstract void CallBack(byte[] buffer);

        private static void OnUrlPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            LoadBehavior<T> behavior = d as LoadBehavior<T>;

            if (e.NewValue == null)
            {

            }
            else
            {
                behavior.Request(e.NewValue.ToString());
            }
        }

        private void Request(string url)
        {
            ICacheStorageService cacheStorageService = ApplicationContent.Instance.Injector.Resolve<ICacheStorageService>();
            if (cacheStorageService != null)
            {
                cacheStorageService.CacheStorage.LoadAsync(url.GetHashCode().ToString(), (o)=> 
                {
                    if(o == null)
                    {

                        Thread thread = new Thread(() =>
                        {
                            try
                            {
                                var webClient = new WebClient();
                                var buffer = webClient.DownloadData(url);
                                if(buffer.Length == 0)
                                {

                                }

                                CallBack(buffer);
                                cacheStorageService.CacheStorage.Save(url.GetHashCode().ToString(), DateTime.Now.Add(new TimeSpan(1, 0, 0, 0)), buffer);
                            }
                            catch (Exception)
                            {

                            }
                        });

                        thread.Priority = ThreadPriority.Highest;
                        thread.Start();
                    }
                    else
                    {
                        CallBack(o);
                    }
                });
            }
        }
    }
}
