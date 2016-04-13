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

namespace OpenMusic.Wpf.Controls
{
    public class TimeSlider : Slider
    {
        #region DurationProperty

        public static DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(TimeSpan), typeof(TimeSlider), new PropertyMetadata(TimeSpan.FromSeconds(0), OnDurationPropertyChanged));

        public TimeSpan Duration
        {
            get { return (TimeSpan)this.GetValue(DurationProperty); }
            set { this.SetValue(DurationProperty, value); }
        }

        private static void OnDurationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TimeSlider timeSlider = d as TimeSlider;
            timeSlider.Reset((TimeSpan)e.NewValue);
        }

        private void Reset(TimeSpan timeSpan)
        {
            this.Minimum = 0;
            this.Maximum = timeSpan.TotalSeconds;
        }

        #endregion

        #region PositionProperty

        public static DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(TimeSpan), typeof(TimeSlider), new PropertyMetadata(TimeSpan.FromSeconds(0), OnPositionPropertyChanged, OnPositionCoerceValueChanged));

        public TimeSpan Position
        {
            get { return (TimeSpan)this.GetValue(PositionProperty); }
            set { this.SetValue(PositionProperty, value); }
        }

        private static void OnPositionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TimeSlider timeSlider = d as TimeSlider;
            timeSlider.UpdatePosition((TimeSpan)e.NewValue);
        }

        private static object OnPositionCoerceValueChanged(DependencyObject d, object baseValue)
        {
            TimeSlider timeSlider = d as TimeSlider;
            TimeSpan timeSpan = (TimeSpan)baseValue;
            if (timeSpan <= timeSlider.Duration)
                return timeSpan;
            return timeSlider.Duration;
        }

        private void UpdatePosition(TimeSpan timeSpan)
        {
            this.Value = timeSpan.TotalSeconds;
        }

        #endregion


        static TimeSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeSlider), new FrameworkPropertyMetadata(typeof(TimeSlider)));
        }
        
        public TimeSlider()
        {
            this.ValueChanged += TimeSlider_ValueChanged;
        }

        public void Reset()
        {
            this.Duration = TimeSpan.FromSeconds(60);
            this.Position = TimeSpan.FromSeconds(0);
        }

        private void TimeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Position = TimeSpan.FromSeconds(e.NewValue);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }        
}
