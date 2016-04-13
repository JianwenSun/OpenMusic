using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf.Core
{
    public class PlayEngineCurrentEventArgs : System.EventArgs
    {
        public TimeSpan Current { get; set; }
    }
}
