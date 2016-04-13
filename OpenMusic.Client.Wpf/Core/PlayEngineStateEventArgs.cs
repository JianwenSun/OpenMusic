using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf.Core
{
    public class PlayEngineStateEventArgs : System.EventArgs
    {
        public PlayState OldValue
        {
            get;
            set;
        }
        public PlayState NewValue
        {
            get;
            set;
        }
    }
}
