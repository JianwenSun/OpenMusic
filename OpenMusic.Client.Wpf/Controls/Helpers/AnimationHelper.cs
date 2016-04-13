using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace OpenMusic.Wpf.Helpers
{
    public static class AnimationHelper
    {
        public static void FadeIn(this UIElement element, Duration duration)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation(1, duration);
            element.BeginAnimation(UIElement.OpacityProperty, doubleAnimation);
        }

        public static void FadeOut(this UIElement element, Duration duration)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, duration);
            element.BeginAnimation(UIElement.OpacityProperty, doubleAnimation);
        }

        public static void DelayVisibilty(this UIElement element, Duration duration, Visibility visibility)
        {
            if(visibility == Visibility.Visible)
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation da = new DoubleAnimation();
                da.From = 0;
                da.To = 1;
                da.Duration = duration;
                sb.Children.Add(da);
                Storyboard.SetTargetProperty(da, new PropertyPath(UIElement.OpacityProperty));
                Storyboard.SetTarget(da, element);
                sb.Completed += new EventHandler((s, e) =>
                {
                    element.Visibility = Visibility.Visible;
                });
                sb.Begin();
            }
            else
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation da = new DoubleAnimation();
                da.From = 1;
                da.To = 0;
                da.Duration = duration;
                sb.Children.Add(da);
                Storyboard.SetTargetProperty(da, new PropertyPath(UserControl.OpacityProperty));
                Storyboard.SetTarget(da, element);
                sb.Completed += new EventHandler((s,e)=> 
                {
                    element.Visibility = visibility;
                });
                sb.Begin();
            }
           
        }
    }
}
