using System;
using System.Collections.Generic;
using System.Text;

namespace eFlash.GUI.ViewerAndQuizzer
{
    class PlayButton : System.Windows.Forms.Button
    {
        public string fileToPlay;
        public Player player;
        public Boolean isPlaying = false;
        public string alias = "";

        public PlayButton(string fileToPlay, Player player, string alias)
        {
            this.fileToPlay = fileToPlay;
            this.player = player;
            this.alias = alias;
        }
    }
}
