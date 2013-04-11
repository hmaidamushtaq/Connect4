/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 * author:      wieschoo
 * url:         http://www.wieschoo.com
 * copyright:   2013 by wieschoo
 * license:     http://www.wieschoo.com/license_agreement/
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using connectfour.Heuristic;
using connectfour.GameComponents;

namespace connectfour.Player
{
    public abstract class APlayer : IPlayer
    {

        // logs and progress bar output
        protected System.Windows.Forms.ProgressBar TProcess;
        protected System.Windows.Forms.TextBox TLog;

        //protected MCScore Scores = new MCScore();
        protected Random Rnd = new Random();

        protected int Strength=1;


        public void SetGUIMembers(System.Windows.Forms.ProgressBar T, System.Windows.Forms.TextBox L)
        {
            TProcess = T;
            TLog = L;
        }
        public void SetStrength(int k)    // 1.0f means powerful and 0.0f means weak
        {
            Strength = k;
        }

        public abstract int Play(Board Current);
    }
}
