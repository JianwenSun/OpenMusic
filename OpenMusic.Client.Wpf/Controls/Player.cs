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
using System.ComponentModel;

namespace OpenMusic.Wpf.Controls
{
    using Core;
    using OpenMusic.Datas;
    using System.Collections;
    using System.Collections.ObjectModel;

    [TemplatePart(Name = PART_TimeSlider, Type =typeof(TimeSlider))]
    public class Player : Control
    {
        const string PART_TimeSlider = "PART_TimeSlider";

        #region Play or Pause
        public static readonly RoutedCommand PlayOrPauseCommand = new RoutedCommand("PlayOrPauseCommand", typeof(Player));
        #endregion

        #region Play Song
        public static readonly RoutedCommand PlaySongCommand = new RoutedCommand("PlaySongCommand", typeof(Player));
        #endregion

        #region Stop
        public static readonly RoutedCommand StopCommand = new RoutedCommand("StopCommand", typeof(Player));
        #endregion

        #region Play Prev
        public static readonly RoutedCommand PlayPrevCommand = new RoutedCommand("PlayPrevCommand", typeof(Player));
        #endregion

        #region Play Next
        public static readonly RoutedCommand PlayNextCommand = new RoutedCommand("PlayNextCommand", typeof(Player));
        #endregion

        #region Repeat
        public static readonly RoutedCommand RepeatCommand = new RoutedCommand("RepeatCommand", typeof(Player));
        #endregion

        #region ShowEqualizer
        public static readonly RoutedCommand ShowEqualizerCommand = new RoutedCommand("ShowEqualizerCommand", typeof(Player));
        #endregion

        #region Shuffle
        public static readonly RoutedCommand ShuffleCommand = new RoutedCommand("ShuffleCommand", typeof(Player));
        #endregion

        #region Mute
        public static readonly RoutedCommand MuteCommand = new RoutedCommand("MuteCommand", typeof(Player));
        #endregion

        #region Play List
        public static readonly DependencyProperty ItemsProperty
               = DependencyProperty.Register("Items", typeof(IEnumerable<ISong>), typeof(Player));

        public IEnumerable<ISong> Items
        {
            get { return (IEnumerable<ISong>)this.GetValue(ItemsProperty); }
            set { this.SetValue(ItemsProperty, value); }
        }
        #endregion

        #region Play Current
        public static readonly DependencyProperty CurrentProperty
               = DependencyProperty.Register("Current", typeof(ISong), typeof(Player), new PropertyMetadata(null, OnCurrentPropertyChanged));

        public ISong Current
        {
            get { return (ISong)this.GetValue(CurrentProperty); }
            set { this.SetValue(CurrentProperty, value); }
        }
        #endregion

        #region Play State
        public static readonly DependencyProperty StateProperty
               = DependencyProperty.Register("State", typeof(PlayState), typeof(Player), new PropertyMetadata(PlayState.Stop));

        public PlayState State
        {
            get { return (PlayState)this.GetValue(StateProperty); }
            set { this.SetValue(StateProperty, value); }
        }
        #endregion

        #region PlayerEngine 

        public static readonly DependencyProperty EngineProperty
               = DependencyProperty.Register("Engine", typeof(PlayEngine), typeof(Player), new PropertyMetadata(null, OnEnginePropertyChanged));

        public PlayEngine Engine
        {
            get { return (PlayEngine)this.GetValue(EngineProperty); }
            set { this.SetValue(EngineProperty, value); }
        }

        #endregion

        #region IsAvailable 

        public static readonly DependencyProperty IsAvailableProperty
               = DependencyProperty.Register("IsAvailable", typeof(bool), typeof(Player), new PropertyMetadata(false));

        public bool IsAvailable
        {
            get { return (bool)this.GetValue(IsAvailableProperty); }
            set { this.SetValue(IsAvailableProperty, value); }
        }

        #endregion

        public TimeSlider TimeSlider { get; private set; }

        static Player()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Player), new FrameworkPropertyMetadata(typeof(Player)));
        }

        public Player()
        {
            this.Items = new ObservableCollection<ISong>();
            CommandManager.RegisterClassCommandBinding(typeof(Player), new CommandBinding(PlayOrPauseCommand, this.ExecutePlayOrPauseCommand, this.CanExecutePlayOrPauseCommand));
            CommandManager.RegisterClassCommandBinding(typeof(Player), new CommandBinding(PlayNextCommand, this.ExecutePlayNextCommand, this.CanExecutePlayNextCommand));
            CommandManager.RegisterClassCommandBinding(typeof(Player), new CommandBinding(PlayPrevCommand, this.ExecutePlayPrevCommand, this.CanExecutePlayPrevCommand));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.TimeSlider = this.GetTemplateChild(PART_TimeSlider) as TimeSlider;
            DependencyPropertyDescriptor.FromProperty(TimeSlider.PositionProperty, typeof(Player))
                .AddValueChanged(this.TimeSlider, this.OnTimeSliderPostionChanged);
        }

        #region public method

        public void Play(ISong song)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                this.Current = song;
            }));
        }

        #endregion

        protected virtual void OnCurrentChanged(ISong oldSong, ISong newSong)
        {
            this.TimeSlider.Reset();

            if (newSong != null)
            {
                if (!this.Items.Contains(newSong))
                    (this.Items as IList).Add(newSong);

                if (this.IsAvailable)
                    this.Engine.Play(newSong);
            }
        }

        #region Private PlayOrPause Method

        void CanExecutePlayOrPauseCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.IsAvailable)
            {
                switch (this.Engine.State)
                {
                    case PlayState.Stop:
                        e.CanExecute = this.Current != null;
                        break;
                    case PlayState.Play:
                        e.CanExecute = true;
                        break;
                    case PlayState.Pause:
                        e.CanExecute = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                e.CanExecute = false;
            }
        }

        void ExecutePlayOrPauseCommand(object sender, ExecutedRoutedEventArgs e)
        {
            switch (this.Engine.State)
            {
                case PlayState.Stop:
                    this.Engine.Play();
                    break;
                case PlayState.Play:
                    this.Engine.Pause();
                    break;
                case PlayState.Pause:
                    this.Engine.Resume();
                    break;
                default:
                    break;
            }

            this.State = this.Engine.State;
        }

        #endregion

        #region Private PlayPrev Method

        void CanExecutePlayPrevCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.IsAvailable && this.Items != null && this.Items.Count() > 0 && this.Current != null)
            {
                int index = (this.Items as IList).IndexOf(this.Current);
                if (index > 0)
                    e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        void ExecutePlayPrevCommand(object sender, ExecutedRoutedEventArgs e)
        {
            int index = (this.Items as IList).IndexOf(this.Current);
            this.Current = (this.Items as IList)[index - 1] as ISong;
            this.State = this.Engine.State;
        }

        #endregion

        bool CanExecuteStopCommand(object obj)
        {
            if (!this.IsAvailable) return false;
            switch (this.Engine.State)
            {
                case PlayState.Stop:
                    break;
                case PlayState.Play:
                    return true;
                case PlayState.Pause:
                    return true;
                default:
                    break;
            }
            return false;
        }

        void ExecuteStopCommand(object obj)
        {
            this.Engine.Stop();
            this.State = this.Engine.State;
        }


        #region Private PlayNext Method

        void CanExecutePlayNextCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.IsAvailable && this.Current != null)
            {
                int index = (this.Items as IList).IndexOf(this.Current);
                if (index < (this.Items as IList).Count - 1)
                    e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        void ExecutePlayNextCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (this.Current != null)
            {
                int index = (this.Items as IList).IndexOf(this.Current);
                this.Current = (this.Items as IList)[index + 1] as ISong;
            }
            else
            {
                this.Current = (this.Items as IList)[0] as ISong;
            }
            this.State = this.Engine.State;
        }

        #endregion

        void ExecuteRepeatCommand(object obj)
        {

        }


        private static void OnCurrentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Player player = d as Player;
            player.OnCurrentChanged(e.OldValue as ISong, e.NewValue as ISong);
        }

        private static void OnEnginePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Player player = d as Player;
            if(e.NewValue != null)
            {
                PlayEngine engine = e.NewValue as PlayEngine;
                engine.StateChanged += player.Engine_StateChanged;
                engine.CurrentChanged += player.Engine_CurrentChanged;
                engine.DurationChanged += player.Engine_DurationChanged;
                player.IsAvailable = true;
            }
            else
            {
                player.IsAvailable = false;
            }

            if(e.OldValue != null)
            {
                PlayEngine engine = e.OldValue as PlayEngine;
                engine.StateChanged -= player.Engine_StateChanged;
            }
        }

        private void Engine_DurationChanged(object sender, PlayEngineDurationEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                this.TimeSlider.Duration = e.Duration;
            }));
        }

        private void Engine_CurrentChanged(object sender, PlayEngineCurrentEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                this.TimeSlider.Position = e.Current;
            }));
        }

        private void Engine_StateChanged(object sender, PlayEngineStateEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(() => 
            {
                this.State = (PlayState)e.NewValue;
            }));
        }

        void OnTimeSliderPostionChanged(object sender, EventArgs e)
        {
            this.Engine.Play(this.TimeSlider.Position);
        }
    }
}
