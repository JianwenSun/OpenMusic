using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace OpenMusic.Wpf.Behaviors
{
    using Controls;
    using System.Windows.Controls;
    public class ScrollingToBottomBehavior : Behavior<Control>
    {
        public static readonly DependencyProperty CommandProperty
            = DependencyProperty.Register("Command", typeof(ICommand), typeof(ScrollingToBottomBehavior));

        public static readonly DependencyProperty CommandParameterProperty 
            = DependencyProperty.Register("ommandParameter", typeof(object), typeof(ScrollingToBottomBehavior));

        public ICommand Command
        {
            get { return (ICommand)this.GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return this.GetValue(CommandParameterProperty); }
            set { this.SetValue(CommandParameterProperty, value); }
        }


        ScrollViewer scrollviewer;

        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if(scrollviewer != null)
                scrollviewer.ScrollChanged -= Scrollviewer_ScrollChanged;
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            scrollviewer = this.AssociatedObject.FindChildByType<ScrollViewer>();
            if (scrollviewer != null)
                scrollviewer.ScrollChanged += Scrollviewer_ScrollChanged;
        }

        private void Scrollviewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;

            if(scrollViewer.ScrollableHeight > 0)
            {
                double index = scrollViewer.ScrollableHeight - scrollViewer.VerticalOffset;
                if(index < 100)
                {
                    if (this.Command != null)
                        this.Command.Execute(this.CommandParameter);
                }
            }
        }
    }
}
