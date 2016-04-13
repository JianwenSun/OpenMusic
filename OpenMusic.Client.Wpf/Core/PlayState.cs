using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf.Core
{
    public enum PlayState
    {
        [Display(Name = "停止")]
        Stop,
        [Display(Name = "正在播放")]
        Play,
        [Display(Name = "暂停")]
        Pause
    }
}
