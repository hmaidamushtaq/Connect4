/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 * author:      wieschoo
 * url:         http://www.wieschoo.com
 * copyright:   2013 by wieschoo
 * license:     http://www.wieschoo.com/license_agreement/
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
using connectfour.GameComponents;
using System;
using System.Windows.Forms;

namespace connectfour.Heuristic
{
    public class CountingScore : IHeuristic
    {


        public void SetStrength(int Value)
        {

        }
        // TODO !!!!!!!
        public float Evaluate(Board CurrentGame, int Move)
        {
            long me, en;
            // test blue
            if (CurrentGame.CurrentPlayer!=State.blue)
            {
                me = CurrentGame.BoardBlue;
                en = CurrentGame.BoardRed;
            } 
            else
            {
                en = CurrentGame.BoardBlue;
                me = CurrentGame.BoardRed;
            }

            long empty = me;
            long occupied = (me | en);


            long oppThreats = 0L;
            long ownThreats = 0L;

            // horizontal
            ownThreats |= (me & (me >> 7) & (me >> 7 * 2) & empty); //XXX_
            ownThreats |= (me & (me >> 1 * 7) & (me >> 3 * 7) & empty); //XX_X
            ownThreats |= (me & (me >> 2 * 7) & (me >> 3 * 7) & empty); 

            // vertical
            ownThreats |= (me & (me >> 1) & (me >> 2) & empty); //XXX_
           

            return Utile.CountBits(ownThreats);
        }

    }
}
