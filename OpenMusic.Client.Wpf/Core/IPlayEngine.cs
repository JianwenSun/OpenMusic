using OpenMusic.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf.Core
{
    public interface IPlayEngine : IDisposable
    {
        event PlayEngineStateEventHandler StateChanged;
        event PlayEngineDurationEventHandler DurationChanged;
        event PlayEngineCurrentEventHandler CurrentChanged;

        TimeSpan Duration { get; }
        TimeSpan Current { get; }
        double Position { get; set; }
        double Volume { get; set; }
        double Speed { get; }
        double Length { get; }

        void Init();
        void Pause();
        void Stop();
        void Play();
        void Play(ISong song);
        void Play(TimeSpan postion);
        void PlayNext();
        void PlayPrev();
        void Resume();
        void PlaySongList(ISongList songlist);
        void Reset();
        void Uninit();
    }
}
