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
using connectfour.GameComponents;
using connectfour.Heuristic;

namespace connectfour.Player
{
    public class MiniMax : APlayer
    {
        // max deep of thinking
        protected const int MAX_DEEP = 3;

        protected MCScore Scores = new MCScore();

        /// <summary>
        /// returns a move by minimax and deep cuts
        /// </summary>
        /// <param name="CurrentSituation">current game situation</param>
        /// <returns>move to play</returns>
        public override int Play(Board CurrentSituation)
        {

            List<int> CandidateMoves = CurrentSituation.GetValidMoves();    // get a possible Moves
            TProcess.Maximum = CandidateMoves.Count;                        // display the current thinking progress
            TProcess.Value = 0;
            float alpha = float.MinValue;                                   // current best valuation alpha
            int ColumnToPlay = -1;                                          // column to play
            foreach (int M in CandidateMoves)                               // test a canditate moves
            {
                TProcess.PerformStep();                                     // next move => update progressbar
                float eval = ScoreMove(CurrentSituation, M, 0);             // Score the move
                if (eval > alpha)                                           // is this move better?
                {
                    alpha = eval;                                           // then we take this move
                    ColumnToPlay = M;
                }
            }
            return ColumnToPlay;
        }
        /// <summary>
        /// internal score of move
        /// </summary>
        /// <param name="Situation">current game situation</param>
        /// <param name="Move">move to do</param>
        /// <param name="deep">current deep</param>
        /// <returns>value of move</returns>
        protected float ScoreMove(Board Situation, int Move, int deep)
        {
            // game finished?
            State Result = Situation.TestVictory();
            // if game is finished ...
            if (Result != State.empty)
            {
                // is draw?
                if (Result == State.draw)
                    return 0.0f;
                // else return score 1.0f for winning and -1.0f for loosing
                return (Result == Situation.CurrentPlayer) ? 1f : -1f;
            }
            // cut deep
            if (deep == MAX_DEEP)
            {
                // adjust strength dynamically
                int S = Convert.ToInt32(Strength / ((double)Math.Pow(7, MAX_DEEP)));
                Scores.SetStrength(S);
                // Score Board due monte carlo
                return Scores.Evaluate(Situation, Move);

            }

            Situation.Move(Move);                                   // do move
            List<int> CandidateMoves = Situation.GetValidMoves();   // new situation, so new possible moves

            float val = float.MinValue;                             // temp alpha value

            foreach (int M in CandidateMoves)
            {
                val = Math.Max(val, -1f * ScoreMove(Situation, M, deep + 1)); // evaluate each move by recursion 
            }

            Situation.UnMove(Move);                               // redo move
            return val;                                           // return value
        }


    }
}
