/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 * author:      wieschoo
 * url:         http://www.wieschoo.com
 * copyright:   2013 by wieschoo
 * license:     http://www.wieschoo.com/license_agreement/
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using connectfour.GameComponents;
using connectfour.Player;
using connectfour.Heuristic;
using System.Drawing.Drawing2D;

namespace connectfour
{
    public partial class Form1 : Form
    {
        Board Game;
        const int BoardWidth = 7;
        const int BoardHeight = 6;
        const int fieldsize = 50;

        List<IPlayer> AIS;
        List<Button> PlayBtn = new List<Button> { };
        Color ControlColor;

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < BoardWidth; i++)
            {
                Button PlayMove = new Button();
                PlayMove.Name = i.ToString();
                PlayMove.Text = (i + 1).ToString();
                PlayMove.Size = new System.Drawing.Size(50, 23);
                PlayMove.Location = new System.Drawing.Point(62 + 50 * i, 89);
                PlayMove.UseVisualStyleBackColor = true;
                PlayMove.Click += new EventHandler(ManualMove);
                PlayMove.BackColor = Color.YellowGreen;
                this.Controls.Add(PlayMove);
                PlayBtn.Add(PlayMove);
            }
            ControlColor = PlayBtn[0].BackColor;
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.Gray,
                                                                       Color.Black,
                                                                       90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Game = new Board(BoardHeight, BoardWidth);
            pbxBoard.Width = BoardWidth * fieldsize + 1;
            pbxBoard.Height = BoardHeight * fieldsize + 1;

            cmbOpponent.SelectedIndex = 1;

            AIS = new List<IPlayer> { };

            Stupid S1 = new Stupid();
            S1.SetGUIMembers(pgbThinking, txtLog);

            MonteCarlo MC1 = new MonteCarlo();
            MC1.SetStrength(20000);
            MC1.SetGUIMembers(pgbThinking, txtLog);

            MonteCarlo MC2 = new MonteCarlo();
            MC2.SetStrength(50000);
            MC2.SetGUIMembers(pgbThinking, txtLog);

            MonteCarlo MC3 = new MonteCarlo();
            MC3.SetStrength(100000);
            MC3.SetGUIMembers(pgbThinking, txtLog);

            MonteCarloPlus MCP1 = new MonteCarloPlus();
            MCP1.SetStrength(20000);
            MCP1.SetGUIMembers(pgbThinking, txtLog);

            MonteCarloPlus MCP2 = new MonteCarloPlus();
            MCP2.SetStrength(50000);
            MCP2.SetGUIMembers(pgbThinking, txtLog);

            MonteCarloPlus MCP3 = new MonteCarloPlus();
            MCP3.SetStrength(100000);
            MCP3.SetGUIMembers(pgbThinking, txtLog);

            MonteCarloTime MCT1 = new MonteCarloTime();
            MCT1.SetStrength(5000);
            MCT1.SetGUIMembers(pgbThinking, txtLog);

            MonteCarloTime MCT2 = new MonteCarloTime();
            MCT2.SetStrength(7000);
            MCT2.SetGUIMembers(pgbThinking, txtLog);

            MonteCarloTime MCT3 = new MonteCarloTime();
            MCT3.SetStrength(10000);
            MCT3.SetGUIMembers(pgbThinking, txtLog);

            MonteCarloTime MCT4 = new MonteCarloTime();
            MCT4.SetStrength(20000);
            MCT4.SetGUIMembers(pgbThinking, txtLog);

            MiniMax MM1 = new MiniMax();
            MM1.SetStrength(40000);
            MM1.SetGUIMembers(pgbThinking, txtLog);

            AlphaBeta AB1 = new AlphaBeta();
            AB1.SetGUIMembers(pgbThinking, txtLog);
            
            AIS.Add(S1);
            AIS.Add(MC1);
            AIS.Add(MC2);
            AIS.Add(MC3);
            AIS.Add(MCP1);
            AIS.Add(MCP2);
            AIS.Add(MCP3);
            AIS.Add(MCT1);
            AIS.Add(MCT2);
            AIS.Add(MCT3);
            AIS.Add(MCT4);
            AIS.Add(MM1);
            AIS.Add(AB1);
            
            

            string[] labels = new string[]{
            "MonteCarlo (50000)",
            "MonteCarlo (100000)",
            "MonteCarloPlus (20000)",
            "MonteCarloPlus (50000)",
            "MonteCarloPlus (100000)",
            "MonteCarlo (5sec)",
            "MonteCarlo (7sec)",
            "MonteCarlo (10sec)",
            "MonteCarlo (20sec)",
            "MiniMax (deep=2,dyn=70000)",
            "AlphaBeta (deep=3,1000)"};

            foreach(string t in labels){
                cmbOpponent.Items.Add(t);
            }
            cmbOpponent.MaxDropDownItems = labels.Length;
          

            cmbOpponent.Refresh();

            pgbThinking.Maximum = BoardWidth;
            DrawBoard();

        }
        private void DrawBoard()
        {

            SolidBrush Empty = new SolidBrush(Color.Red);
            SolidBrush White = new SolidBrush(Color.Red);
            SolidBrush Black = new SolidBrush(Color.Blue);




            // create Layout
            Bitmap Tmp = new Bitmap(fieldsize * BoardWidth + 1, fieldsize * BoardHeight + 1);
            Graphics g = Graphics.FromImage(Tmp);
            g.FillRectangle(new SolidBrush(Color.YellowGreen), new Rectangle(0, 0, fieldsize * BoardWidth + 1, fieldsize * BoardHeight + 1));

            // draw grid
            for (int i = 0; i <= fieldsize * BoardWidth; i += fieldsize)
                g.DrawLine(new Pen(Color.Black), new Point(i, 0), new Point(i, fieldsize * BoardHeight - 1));
            for (int i = 0; i <= fieldsize * BoardHeight; i += fieldsize)
                g.DrawLine(new Pen(Color.Black), new Point(0, i), new Point(fieldsize * BoardWidth - 1, i));

            // draw discs
            for (int row = 0; row < BoardHeight; row++)
                for (int col = 0; col < BoardWidth; col++)
                {
                    Rectangle Disc = new Rectangle(fieldsize * col + 2, fieldsize * (BoardHeight - (row + 1)) + 2, fieldsize - 4, fieldsize - 4);
                    GraphicsPath gp = new GraphicsPath();
                    gp.AddEllipse(Disc);
                    PathGradientBrush pgb = new PathGradientBrush(gp);
                    pgb.CenterPoint = new PointF(Disc.Width / 2 + fieldsize * col - fieldsize / 2, Disc.Height / 2 + fieldsize * (BoardHeight - (row + 1)) - fieldsize / 2);
                    
                    
                    if (Game.GetField(row, col) == State.blue)
                    {
                        pgb.CenterColor = Color.FromArgb(0, 158, 195);
                        pgb.SurroundColors = new Color[] { Color.FromArgb(6, 109, 171) };
                        g.FillPath(pgb, gp);
                    }
                    else if (Game.GetField(row, col) == State.red)
                    {
                        pgb.CenterColor = Color.FromArgb(255,48,25);
                        pgb.SurroundColors = new Color[] { Color.FromArgb(207,4,4) };
                        g.FillPath(pgb, gp);
                    }
                }

            pbxBoard.Image = Tmp;
            pbxBoard.Refresh();


        }

        private void PlayMove(int m)
        {
            Game.Move(m);
            DrawBoard();
            lblCurrent.Text = "Current: " + Game.CurrentPlayer.ToString();
            State Test = Game.TestVictory();
            if (Test != State.empty)
            {
                lblVictory.Text = "Winner: " + Test.ToString();
                lblVictory.BackColor = Color.GreenYellow;
                lblVictory.Visible = true;
            }

            for (int i = 0; i < BoardWidth;i++ )
            {
                if (i == m)
                    PlayBtn[i].BackColor = Color.OliveDrab;    
                else
                    PlayBtn[i].BackColor = Color.YellowGreen;
            }

//             uint ii = 0;
//             ii = ~ii;
//             MessageBox.Show(Convert.ToString(ii,2));

            


        }

        private void btnAI_Click(object sender, EventArgs e)
        {
            if (lblVictory.Visible == true)
            {
                MessageBox.Show("Please start new game");
            }
            else
            {
                int Agent = cmbOpponent.SelectedIndex;
                int m = AIS[Agent].Play(Game);
                PlayMove(m);
            }
        }

        public void ManualMove(object sender, EventArgs e)
        {
            if (lblVictory.Visible==true)
            {
                MessageBox.Show("Please start new game");
            }
            else
            {
                int m = Convert.ToInt32(((Button)sender).Name.ToString());
                PlayMove(m);
            }
           
        }

        private void pbxBoard_Click(object sender, EventArgs e)
        {

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Game = new Board(BoardHeight, BoardWidth);
            DrawBoard();
            lblVictory.Visible = false;
            lblCurrent.Text = "Current: blue";
            for (int i = 0; i < BoardWidth; i++)
            {
                    PlayBtn[i].BackColor = Color.YellowGreen;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CountingScore T = new CountingScore();
            float res = T.Evaluate(Game, 0);
            MessageBox.Show(res.ToString());
        }


    }
}
