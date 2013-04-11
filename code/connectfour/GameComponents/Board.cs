/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 * author:      wieschoo
 * url:         http://www.wieschoo.com
 * copyright:   2013 by wieschoo
 * license:     http://www.wieschoo.com/license_agreement/
 * contains the idea of fhourstone
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace connectfour.GameComponents
{
    public enum State { empty = 1, red = 2, blue = 3, draw = 4 };

    public class Board
    {
        public Int64 BoardBlue;
        public Int64 BoardRed;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public int[] DiscsPerColumn;
        public State CurrentPlayer;
        public State CurrentOpponent;
        public Random Rnd;

        public Board(int height, int width)
        {
            Rnd = new Random();
            // store board size
            this.Width = width;
            this.Height = height;

            BoardBlue = 0;
            BoardRed = 0;

            this.CurrentPlayer = State.blue;
            this.CurrentOpponent = State.red;

            DiscsPerColumn = new int[Width];

            for (int col = 0; col < this.Width; col++)
                DiscsPerColumn[col] = 0;
        }

        public Board Clone()
        {
            Board tmp = new Board(Height, Width);
            tmp.CurrentPlayer = this.CurrentPlayer;
            tmp.CurrentOpponent = this.CurrentOpponent;
            tmp.BoardBlue = this.BoardBlue;
            tmp.BoardRed = this.BoardRed;
            for (int col = 0; col < this.Width; col++)
                tmp.DiscsPerColumn[col] = this.DiscsPerColumn[col];

            return tmp;
        }

        public void ChangePlayer()
        {
            CurrentPlayer = (CurrentPlayer == State.blue) ? State.red : State.blue;
            CurrentOpponent = (CurrentOpponent == State.blue) ? State.red : State.blue;
        }

        public bool IsMoveValid(int col)
        {
            return DiscsPerColumn[col] < Height;
        }

        public List<int> GetValidMoves()
        {
            List<int> ValidMoves = new List<int> { };
            for (int col = 0; col < this.Width; col++)
                if (IsMoveValid(col))
                    ValidMoves.Add(col);
            return ValidMoves;
        }
        public State TestVictory()
        {
            // check draw
            bool draw = true;
            for (int col = 0; col < this.Width; col++)
                if (IsMoveValid(col))
                {
                    draw = false;
                    break;
                }
            if (draw)
                return State.draw;

            // GET WINNER
            // test blue

            long y = BoardBlue & (BoardBlue >> 6);
            if ((y & (y >> 2 * 6)) > 0) // check \ diagonal
                return State.blue;
            y = BoardBlue & (BoardBlue >> 7);
            if ((y & (y >> 2 * 7)) > 0) // check horizontal -
                return State.blue;
            y = BoardBlue & (BoardBlue >> 8);
            if ((y & (y >> 2 * 8)) > 0) // check / diagonal
                return State.blue;
            y = BoardBlue & (BoardBlue >> 1);
            if ((y & (y >> 2)) > 0)     // check vertical |
                return State.blue;

            long yy = BoardRed & (BoardRed >> 6);
            if ((yy & (yy >> 2 * 6)) > 0) // check \ diagonal
                return State.red;
            yy = BoardRed & (BoardRed >> 7);
            if ((yy & (yy >> 2 * 7)) > 0) // check horizontal -
                return State.red;
            yy = BoardRed & (BoardRed >> 8);
            if ((yy & (yy >> 2 * 8)) > 0) // check / diagonal
                return State.red;
            yy = BoardRed & (BoardRed >> 1);
            if ((yy & (yy >> 2)) > 0)     // check vertical |
                return State.red;

            // no winner ? then return
            return State.empty;

        }
        public void Move(int col)
        {
            long pos = ((long)1 << (DiscsPerColumn[col] + 7 * col));
            if (CurrentPlayer == State.red)
            {
                BoardRed ^= pos;
            }
            else
            {
                BoardBlue ^= pos;
            }

            DiscsPerColumn[col]++;
            ChangePlayer();
        }
        public void UnMove(int col)
        {
            DiscsPerColumn[col]--;
            long pos = ((long)1 << (DiscsPerColumn[col] + 7 * col));
            if (CurrentOpponent == State.red)
            {
                BoardRed ^= pos;
            }
            else
            {
                BoardBlue ^= pos;
            }

            ChangePlayer();                     // change back
        }

        public State GetField(int r, int c)
        {
            long number = ((long)1 << (r + 7 * c));

            bool test = (BoardBlue & number) > 0;
            if (test)
                return State.blue;
            test = (BoardRed & number) > 0;
            if (test)
                return State.red;
            return State.empty;

        }


    }
}
