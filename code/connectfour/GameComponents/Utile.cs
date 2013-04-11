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
using System.Diagnostics;
using connectfour.Heuristic;
namespace connectfour.GameComponents
{
    public static class Utile
    {
        public static int CountBits(long x)
        {
            x = x - ((x >> 1) & 0x55555555);
            x = (x & 0x33333333) + ((x >> 2) & 0x33333333);
            x = (x + (x >> 4)) & 0x0F0F0F0F;
            x = x + (x >> 8);
            x = x + (x >> 16);
            return (int) (x & 0x0000003F);
        }

        public static int GetPlayoutsNumber(Board Current, int ms)
        {
            int playouts_to_think = 0;
            MCScore MCEvaluation = new MCScore();
            // test speed
            MCEvaluation.SetStrength(1000);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int Move = Current.GetValidMoves()[0];
            float f = MCEvaluation.Evaluate(Current, Move);
            sw.Stop();
            playouts_to_think = Convert.ToInt32(1000 / (float)sw.Elapsed.TotalMilliseconds * (ms/(float)Current.GetValidMoves().Count));
            return playouts_to_think;
        }
        public static List<int> PreprocessMoves(Board Current, List<int> TestCandidates)
        {
            List<int> CandidateMoves = new List<int> { };

            foreach (int Move in TestCandidates)
            {
                Board CheckWin = Current.Clone();
                // test if immediate win possible
                CheckWin.Move(Move);
                if (CheckWin.TestVictory() == Current.CurrentPlayer)
                {
                    CandidateMoves.Add(Move);
                    return CandidateMoves;
                }
                else
                {
                    // test if we make an assist for our opponent
                    List<int> OpponentMoves = CheckWin.GetValidMoves();
                    bool IsBad = false;
                    foreach (int OMove in OpponentMoves)
                    {
                        Board Tmp = CheckWin.Clone();
                        Tmp.Move(OMove);
                        // did we make an assist?
                        if (Tmp.TestVictory() == Current.CurrentOpponent)
                        {
                            // forget the move!
                            IsBad = true;
                            break;
                        }
                    }
                    if (!IsBad)
                    {
                        CandidateMoves.Add(Move);
                    }
                }
            }
            return CandidateMoves;
        }
    }
}
