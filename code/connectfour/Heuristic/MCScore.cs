/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 * author:      wieschoo
 * url:         http://www.wieschoo.com
 * copyright:   2013 by wieschoo
 * license:     http://www.wieschoo.com/license_agreement/
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
using System;
using connectfour.GameComponents;
using System.Windows.Forms;
using System.Collections.Generic;

namespace connectfour.Heuristic
{
    public class MCScore : IHeuristic
    {

        protected int NumberOfPlayouts = 30000;
        protected Random Rnd = new Random();

        public void SetStrength(int Value)
        {
            NumberOfPlayouts = Value;
        }

        public float Evaluate(Board Current, int Move)
        {
            int Value = 0;
            // value of move
            for (int Plays = 0; Plays < NumberOfPlayouts; Plays++)
            {
                Board MCPlayout = Current.Clone();
                MCPlayout.Move(Move);
                State Winner = Expand(MCPlayout);
                if (Winner == Current.CurrentPlayer)
                    Value++;                                        // win means +1
                else if (Winner == Current.CurrentOpponent)
                    Value--;                                        // loss means -1
            }
            return (Value / (float)NumberOfPlayouts);                // project into [-1,1]

        }
        protected State Expand(Board Game)
        {
            // maybe the next move
            int MoveId;
            // until the game ends play it
            while (Game.TestVictory() == State.empty)
            {
                List<int> ValidMoves = Game.GetValidMoves();
                MoveId = Rnd.Next(0, ValidMoves.Count - 1);
                Game.Move(ValidMoves[MoveId]);
            }
            // return the winner
            return Game.TestVictory();
        }


    }
}
