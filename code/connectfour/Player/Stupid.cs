/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 * author:      wieschoo
 * url:         http://www.wieschoo.com
 * copyright:   2013 by wieschoo
 * license:     http://www.wieschoo.com/license_agreement/
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using connectfour.GameComponents;

namespace connectfour.Player
{
    public class Stupid : APlayer
    {
        Random r = new Random();

        public override int Play(Board Situation)
        {
            List<int> ValidMoves = Situation.GetValidMoves();
            int MoveId = r.Next(0, ValidMoves.Count - 1);
            return ValidMoves[MoveId];
        }
    }
}
