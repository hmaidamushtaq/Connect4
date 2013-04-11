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
using connectfour.Heuristic;

namespace connectfour.Player
{
    class MonteCarloPlus : APlayer
    {

        protected MCScore MCEvaluation = new MCScore();
        protected IPlayer MC = new MonteCarlo();  // shit interface ;-)

        public override int Play(Board Current)
        {
            MCEvaluation.SetStrength(Strength);
            List<int> CandidateMoves = Utile.PreprocessMoves(Current, Current.GetValidMoves());
            int ColumnToPlay = -1;
            float BestValue = float.MinValue;

            TProcess.Maximum = CandidateMoves.Count;
            TProcess.Value = 0;

            if (CandidateMoves.Count==0)
            {
                List<int> C = Current.GetValidMoves();
                return C[0];
            }

            if (CandidateMoves.Count==1)
            {
                return CandidateMoves[0];
            }

            foreach (int Move in CandidateMoves)
            {
                TProcess.PerformStep();
                float CurrentValue = MCEvaluation.Evaluate(Current, Move);
                if (CurrentValue > BestValue)
                {
                    BestValue = CurrentValue;
                    ColumnToPlay = Move;
                }
            }
            return ColumnToPlay;

        }

    }
}