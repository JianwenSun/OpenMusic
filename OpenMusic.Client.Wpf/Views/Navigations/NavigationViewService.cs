
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Reflection;

namespace OpenMusic.Wpf.Navigations
{
    using Commands;
    using Views;
    using Helpers;
    using System.Collections;
    public class NavigationViewService
    {
        public static ICommand GoBackCommand
        {
            get;
            private set;
        }

        public static ICommand GoForwardCommand
        {
            get;
            private set;
        }

        private static bool CanGoBackCommand(object sender)
        {
            if(sender is DependencyObject)
            {
                var service = GetNavigationService(sender as DependencyObject);
                if (CanNavigate(sender as DependencyObject))
                {
                    if (service.AtLast())
                    {
                        service.NavigationView.DelayVisibilty(new Duration(TimeSpan.FromMilliseconds(100)), Visibility.Collapsed);
                        service.Clear();
                        return false;
                    }
                }

                return true;
            }
            return false;
        }

        private static void ExecuteGoBackCommand(object sender)
        {
            var service = GetNavigationService(sender as DependencyObject);
            service.GoBack();
        }

        private static bool CanGoForwardCommand(object sender)
        {
            if (sender is DependencyObject)
            {
                var service = GetNavigationService(sender as DependencyObject);
                if (CanNavigate(sender as DependencyObject))
                {
                    return false;
                }
            }
            return false;
        }

        private static void ExecuteGoForwardCommand(object sender)
        {
            var service = GetNavigationService(sender as DependencyObject);
            service.GoForward();
        }

        static NavigationViewService()
        {
            GoBackCommand = new Command(ExecuteGoBackCommand, CanGoBackCommand);
            GoForwardCommand = new Command(ExecuteGoForwardCommand, CanGoForwardCommand);
        }

        public static NavigationViewService GetNavigationService(DependencyObject obj)
        {
            Window window = Window.GetWindow(obj);
            if(window != null && window is MainWindow)
            {
                NavigationView navigationView = (window as MainWindow).FindChildByType<NavigationView>();
                if (navigationView != null)
                    return new NavigationViewService(navigationView);
            }

            return null;
        }

        public static bool CanNavigate(DependencyObject obj)
        {
            Window window = Window.GetWindow(obj);
            if (window != null && window is MainWindow)
            {
                NavigationView navigationView = (window as MainWindow).FindChildByType<NavigationView>();
                return navigationView != null;
            }
            return false;
        }

        public NavigationView NavigationView
        {
            get;
            private set;
        }

        internal Frame Frame
        {
            get { return this.NavigationView.MainFrame; }
        }

        private NavigationViewService(NavigationView navigationView)
        {
            this.NavigationView = navigationView;
        }

        public void Navigate(Uri uri)
        {
            this.Frame.Navigate(uri);
        }

        public void Navigate(object content)
        {
            this.NavigationView.DelayVisibilty(new Duration(TimeSpan.FromMilliseconds(300)), Visibility.Visible);
            this.Frame.Navigate(content);
        }

        public void Navigate(object content, object userState)
        {
            this.NavigationView.DelayVisibilty(new Duration(TimeSpan.FromMilliseconds(300)), Visibility.Visible);
            this.Frame.Navigate(content, userState);
        }

        public bool AtLast()
        {
            if (this.Frame.BackStack == null) return true;
            int result = 0;
            IEnumerator enumerator = this.Frame.BackStack.GetEnumerator();
            while (enumerator.MoveNext())
                result++;
            return result <= 1;
        }

        public void GoBack()
        {
            this.Frame.GoBack();
        }

        public void GoForward()
        {
            this.Frame.GoForward();
        }

        public bool CanGoBack()
        {
            return this.Frame.CanGoBack;
        }

        public bool CanGoForward()
        {
            return this.Frame.CanGoForward;
        }

        public void Clear()
        {
            if (!this.Frame.CanGoBack && !this.Frame.CanGoForward)
            {
                return;
            }

            var entry = this.Frame.RemoveBackEntry();
            while (entry != null)
            {
                entry = this.Frame.RemoveBackEntry();
            }
        }
    }
}
