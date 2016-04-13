using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace OpenMusic.Wpf.Core
{
    using Datas;
    using NAudio.Wave;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Threading;
    using System.Windows;
    public class PlayEngine : IPlayEngine, INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PlayEngineStateEventHandler StateChanged;
        public event PlayEngineDurationEventHandler DurationChanged;
        public event PlayEngineCurrentEventHandler CurrentChanged;

        ISong song;
        public ISong Song
        {
            get { return song; }
            private set
            {
                if(this.song != value)
                {
                    var oldSong = this.song;
                    this.song = value;
                    var newSong = this.song;
                    this.OnSongChanged(oldSong, newSong);
                }
            }
        }

        double length;
        public double Length
        {
            get { return length; }
            set
            {
                if(this.length != value)
                {
                    this.length = value;
                    this.OnPropertyChanged("Length");
                }
            }
        }

        double position;
        public double Position
        {
            get { return position; }
            set
            {
                if (this.position != value)
                {
                    this.position = value;
                    this.OnPropertyChanged("Position");
                }
            }
        }

        PlayState state;
        public PlayState State
        {
            get { return state; }
        }

        double volume;
        public double Volume
        {
            get { return volume; }
            set
            {
                if (this.volume != value)
                {
                    this.volume = value;
                    this.OnPropertyChanged("Volume");
                }
            }
        }

        TimeSpan duration;
        public TimeSpan Duration
        {
            get { return duration; }
        }

        TimeSpan current;
        public TimeSpan Current
        {
            get { return current; }
        }

        private SongWavePlayer player { get; set; }

        double speed;
        public double Speed
        {
            get { return speed; }
            set
            {
                if (this.speed != value)
                {
                    this.speed = value;
                    this.OnPropertyChanged("Speed");
                }
            }
        }

        public PlayEngine()
        {
        }

        protected virtual void OnSongChanged(ISong oldSong, ISong newSong)
        {
            this.Reset();
            this.play(newSong);
        }

        protected virtual void OnStateChanged(PlayState oldState, PlayState newState)
        {
            
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            if (this.player != null)
                this.player.Pause();

            this.RasieStateEvent(PlayState.Pause);
        }

        public void Resume()
        {
            if (this.player != null)
                this.player.Resume();

            this.RasieStateEvent(PlayState.Play);
        }

        public void Stop()
        {
            if (this.player != null)
                this.player.Stop();

            this.RasieStateEvent(PlayState.Stop);
        }

        public void Play()
        {
            if (this.player != null)
            {
                this.player.Play();
            }
            this.RasieStateEvent(PlayState.Play);
        }

        public void Play(ISong song)
        {
            this.Song = song;
            this.RasieStateEvent(PlayState.Play);
        }

        public void PlayNext()
        {
            throw new NotImplementedException();
        }

        public void PlayPrev()
        {
            throw new NotImplementedException();
        }

        public void PlaySongList(ISongList songlist)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            if(this.player != null)
            {
                this.player.Stop();
                this.player.Dispose();
                this.player.Stopped += Player_Stopped;
                this.player = null;
            }
        }

        public void Uninit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        internal void SetCurrent(TimeSpan current)
        {
            this.current = current;
            this.OnPropertyChanged("Current");
            if (this.CurrentChanged != null)
                this.CurrentChanged(this, new PlayEngineCurrentEventArgs() { Current = current });
        }

        internal void SetDuration(TimeSpan duration)
        {
            this.duration = duration;
            this.OnPropertyChanged("Duration");
            if (this.DurationChanged != null)
                this.DurationChanged(this, new PlayEngineDurationEventArgs() { Duration = duration });
        }

        private void play(ISong song)
        {
            this.Reset();
            this.player = new SongWavePlayer(new SongWaveContent(this, song));
            this.player.Stopped += Player_Stopped;
            this.player.Play();
        }

        public void Play(TimeSpan timeSpan)
        {
            if (this.current == timeSpan) return;

            if(timeSpan < this.duration)
            {
                this.player.Play(timeSpan);   
            }
            else if(timeSpan == this.duration)
            {
                this.player.Reset();
            }
        }

        private void RasieStateEvent(PlayState state)
        {
            if (this.state == state) return;
            var oldValue = this.state;
            this.state = state;
            this.OnPropertyChanged("State");
            if (this.StateChanged != null)
                this.StateChanged(this, new PlayEngineStateEventArgs() { OldValue = oldValue, NewValue = this.state });
        }

        private void Player_Stopped(object sender, EventArgs e)
        {
            this.RasieStateEvent(PlayState.Stop);
        }
    }

    class SongWaveContent : IDisposable
    {
        public event EventHandler Initialized;
        public ISong Song { get; private set; }
        public string Url { get; private set; }
        public Stream Stream { get; private set; }
        public bool Cached { get; private set; }
        public long ReceivedLength { get; private set; }
        public PlayEngine PlayEngine { get; private set; }
        public bool IsInitialized { get; private set; }

        const long initializedLong = 65536 * 10;

        Thread thread;
        object locker = new object();

        public SongWaveContent(PlayEngine playEngine, ISong song)
        {
            this.Song = song;
            this.Stream = MemoryStream.Synchronized(new MemoryStream());
            this.PlayEngine = playEngine;
            ISongUrl url = this.Song.Urls.FirstOrDefault();
            if (url != null)
                this.Url = url.FileLink;
        }

        public void StartCache()
        {
            if (this.Cached) return;

            thread = new Thread(delegate (object o)
            {
                if (string.IsNullOrEmpty(this.Url)) return;
                try
                {
                    var response = WebRequest.Create(this.Url).GetResponse();
                    this.PlayEngine.Length = response.ContentLength;
                    using (var stream = response.GetResponseStream())
                    {
                        byte[] buffer = new byte[65536]; // 64KB chunks
                        int read;
                        while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            lock (locker)
                            {
                                var pos = this.Stream.Position;
                                this.Stream.Position = this.Stream.Length;
                                this.Stream.Write(buffer, 0, read);
                                this.Stream.Position = pos;
                                this.ReceivedLength += read;

                                if(!IsInitialized && this.ReceivedLength > initializedLong)
                                    this.OnInitialized(true);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    this.OnInitialized(false);
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    this.Cached = true;
                }
            });
            thread.Priority = ThreadPriority.Highest;
            thread.Start();
        }

        public void StopCache()
        {
            if (thread != null && thread.IsAlive)
                thread.Abort();

            this.ReceivedLength = 0;
        }

        public void SetPosition(long position)
        {
            lock (locker)
            {
                if(this.Stream.CanRead)
                {
                    if (position < this.Stream.Length)
                    {
                        this.Stream.Position = position;
                    }
                }
            }
        }

        void OnInitialized(bool initialized)
        {
            this.IsInitialized = initialized;

            if (this.Initialized != null)
                this.Initialized(this, EventArgs.Empty);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                if (this.Stream != null)
                    this.Stream.Dispose();
            }
            _disposed = true;
        }

        //是否回收完毕
        bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~SongWaveContent()
        {
            Dispose(false);
        }
    }

    class SongWavePlayer : IDisposable
    {
        SongWaveContent Content { get; set; }
        Mp3Reader mp3FileReader;
        WaveStream waveFormatConversionStream;
        WaveStream blockAlignedStream;
        WaveOut waveOut;
        bool initialized;
        bool contentInitialized;
        DispatcherTimer timer = new DispatcherTimer();
        public event EventHandler Stopped;

        PlayState waitState = PlayState.Stop;

        public SongWavePlayer(SongWaveContent content)
        {
            this.Content = content;
            this.Content.Initialized += Content_Initialized;
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += Timer_Tick;
        }

        public void Play()
        {
            if(!this.Content.Cached)
                this.Content.StartCache();

            if(!this.contentInitialized)
                waitState = PlayState.Play;
            else
            {
                this.play();
            }
        }

        public void Pause()
        {
            if (!this.contentInitialized)
                waitState = PlayState.Pause;
            else if(this.initialized)
            {
                this.waveOut.Pause();
                this.timer.Stop();
            }
        }

        public void Resume()
        {
            if (!this.contentInitialized)
                waitState = PlayState.Play;
            else if (this.initialized)
            {
                this.waveOut.Resume();
                this.timer.Start();
            }
        }

        public void Stop()
        {
            this.Content.StopCache();

            if (!this.contentInitialized)
                waitState = PlayState.Pause;
            else if (this.initialized)
            {
                this.waveOut.Stop();
                this.timer.Stop();
            }
        }

        public void Reset()
        {
            if (!this.contentInitialized)
                waitState = PlayState.Stop;
            else if (this.initialized)
            {
                this.waveOut.Stop();
                this.timer.Stop();
            }
        }

        void play()
        {
            if (!this.initialized)
                this.Init();

            if (!this.initialized) return;

            if (this.waveOut != null)
            {
                this.waveOut.PlaybackStopped -= WaveOut_PlaybackStopped;
                this.waveOut.Stop();
                this.waveOut.Dispose();
                this.waveOut = null;
            }

            this.Content.SetPosition(0);
            this.waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback());
            this.waveOut.Init(blockAlignedStream);
            this.waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
            this.waveOut.Play();
            this.timer.Start();
        }

        void waitToPlay()
        {
            switch (this.waitState)
            {
                case PlayState.Stop:
                    break;
                case PlayState.Play:
                    this.play();
                    break;
                case PlayState.Pause:
                    break;
                default:
                    break;
            }
        }

        void Content_Initialized(object sender, EventArgs e)
        {
            if(this.Content.IsInitialized)
            {
                this.contentInitialized = true;
                this.waitToPlay();
            }
            else
            {
                if (this.Stopped != null)
                    this.Stopped(this, EventArgs.Empty);
            }
        }

        void Init()
        {
            try
            {
                this.mp3FileReader = new Mp3Reader(this.Content.Stream);
                this.waveFormatConversionStream = WaveFormatConversionStream.CreatePcmStream(this.mp3FileReader);
                this.blockAlignedStream = new BlockAlignReductionStream(this.waveFormatConversionStream);
                this.Content.PlayEngine.Speed = this.mp3FileReader.Mp3WaveFormat.AverageBytesPerSecond;
                if (this.Content.PlayEngine.Speed > 0)
                {
                    int sencods = (int)(this.Content.PlayEngine.Length / this.Content.PlayEngine.Speed);
                    this.Content.PlayEngine.SetDuration(TimeSpan.FromSeconds(sencods));
                }

                this.initialized = true;
            }
            catch (Exception)
            {
                this.initialized = false;
            }
        }

        internal void Play(TimeSpan timespan)
        {
            if(this.initialized)
            {
                this.mp3FileReader.Position = (long)((timespan.TotalSeconds / this.Content.PlayEngine.Duration.TotalSeconds) * this.Content.Stream.Length);
            }
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            if (this.mp3FileReader != null)
            {
                int sencods = (int)(((this.Content.Stream.Position - this.mp3FileReader.DataStartPosition) * 1.0 / this.Content.PlayEngine.Length) * this.Content.PlayEngine.Duration.TotalSeconds);
                this.Content.PlayEngine.SetCurrent(TimeSpan.FromSeconds(sencods));
            }
            else
                this.Content.PlayEngine.SetCurrent(TimeSpan.FromSeconds(0));
        }

        void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            this.Content.SetPosition(0);
            this.blockAlignedStream.Position = 0;

            if (this.Stopped != null)
                this.Stopped(this, EventArgs.Empty);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                if (this.mp3FileReader != null)
                    this.mp3FileReader.Dispose();

                if (this.Content != null)
                    this.Content.Dispose();

                if(this.waveOut != null)
                {
                    this.waveOut.PlaybackStopped -= WaveOut_PlaybackStopped;
                    this.waveOut.Stop();
                    this.waveOut.Dispose();
                }

                if (this.timer != null)
                    this.timer.Stop();
            }
            _disposed = true;
        }

        //是否回收完毕
        bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~SongWavePlayer()
        {
            Dispose(false);
        }
    }
}
