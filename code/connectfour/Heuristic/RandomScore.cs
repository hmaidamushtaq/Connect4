/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 * author:      wieschoo
 * url:         http://www.wieschoo.com
 * copyright:   2013 by wieschoo
 * license:     http://www.wieschoo.com/license_agreement/
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
using connectfour.GameComponents;
using System;

namespace connectfour.Heuristic
{
    public class RandomScore : IHeuristic
    {

        public void SetStrength(int Value)
        {

        }

        public float Evaluate(Board CurrentGame, int Move)
        {
            return (float)CurrentGame.Rnd.Next(-100, 100)/100.0f;
        }

    }
}
