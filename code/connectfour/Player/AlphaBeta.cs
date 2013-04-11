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
using System.Windows.Forms;

namespace connectfour.Player
{
    public class AlphaBeta : APlayer
    {
        // max deep of thinking
        protected const int MAX_DEEP = 9;

        //protected CountingScore Scores = new CountingScore();
        protected MCScore Scores = new MCScore();
        protected Board WorkingBoard;
        protected State CP;

        /// <summary>
        /// returns a move by minimax and deep cuts
        /// </summary>
        /// <remarks>
        /// THIS IS STILL BUGGY!!!
        /// </remarks>
        /// <param name="CurrentSituation">current game situation</param>
        /// <returns>move to play</returns>
        public override int Play(Board CurrentSituation)
        {
            Scores.SetStrength(100);
            CP = CurrentSituation.CurrentPlayer;
            List<int> CandidateMoves = CurrentSituation.GetValidMoves();
            TProcess.Maximum = CandidateMoves.Count;
            TProcess.Value = 0;
            float value = float.MinValue;
            int ColumnToPlay = -1;
            WorkingBoard = CurrentSituation.Clone();
            foreach (int M in CandidateMoves)
            {
                TProcess.PerformStep();
                float eval = ScoreMove(M, 0, float.MinValue, float.MaxValue);
                //MessageBox.Show(value.ToString());
                if (eval > value)
                {
                    value = eval;
                    ColumnToPlay = M;
                }
            }
            
            return ColumnToPlay;
        }
        /// <summary>
        /// internal score of move
        /// </summary>
        /// <param name="Move">move to do</param>
        /// <param name="deep">current deep</param>
        /// <param name="alpha">value of alpha</param>
        /// <param name="beta">value of beta</param>
        /// <returns>value of move</returns>
        protected float ScoreMove( int Move, int deep, float alpha, float beta)
        {

            State Result = WorkingBoard.TestVictory();
            
            if (Result != State.empty)
            {
                if (Result == State.draw)
                    return 0.0f;
                return (Result == CP) ? 1f : -1f;
            }

            if (deep == MAX_DEEP)
            {
                int S = 50;
                Scores.SetStrength(S);
                return Scores.Evaluate(WorkingBoard, Move);

            }

            WorkingBoard.Move(Move);
            List<int> CandidateMoves = WorkingBoard.GetValidMoves();
  
            foreach (int M in CandidateMoves)
            {
                float val = -1f * ScoreMove( M, deep + 1,-1*alpha,-1*beta);
                // beta cut off
                if (val >= beta)
                {
                    WorkingBoard.UnMove(Move);
                    return val;
                }
                // update bound 
                if (val >= alpha)
                    alpha = val;

            }
            WorkingBoard.UnMove(Move);
            return alpha;
        }


    }
}
