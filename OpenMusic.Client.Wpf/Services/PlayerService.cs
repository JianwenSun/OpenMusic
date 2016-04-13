using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OpenMusic.Wpf.Services
{
    using Datas;
    using Controls;

    public class PlayerService
    {
        public static PlayerService Default = new PlayerService();

        private PlayerService() { }

        public Player Player { get; private set; }

        public void Initialize(Player player)
        {
            this.Player = player;
        }

        public void Play(ISong song)
        {
            this.Player.Play(song);
        }
    }
}
