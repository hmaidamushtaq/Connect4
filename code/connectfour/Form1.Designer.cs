namespace connectfour
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbOpponent = new System.Windows.Forms.ComboBox();
            this.pbxBoard = new System.Windows.Forms.PictureBox();
            this.btnAI = new System.Windows.Forms.Button();
            this.pgbThinking = new System.Windows.Forms.ProgressBar();
            this.lblVictory = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbOpponent
            // 
            this.cmbOpponent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOpponent.FormattingEnabled = true;
            this.cmbOpponent.Items.AddRange(new object[] {
            "Stupid",
            "MonteCarlo (20000)"});
            this.cmbOpponent.Location = new System.Drawing.Point(146, 33);
            this.cmbOpponent.Name = "cmbOpponent";
            this.cmbOpponent.Size = new System.Drawing.Size(198, 21);
            this.cmbOpponent.TabIndex = 16;
            // 
            // pbxBoard
            // 
            this.pbxBoard.Location = new System.Drawing.Point(62, 124);
            this.pbxBoard.Name = "pbxBoard";
            this.pbxBoard.Size = new System.Drawing.Size(168, 118);
            this.pbxBoard.TabIndex = 0;
            this.pbxBoard.TabStop = false;
            this.pbxBoard.Click += new System.EventHandler(this.pbxBoard_Click);
            // 
            // btnAI
            // 
            this.btnAI.Location = new System.Drawing.Point(350, 31);
            this.btnAI.Name = "btnAI";
            this.btnAI.Size = new System.Drawing.Size(62, 23);
            this.btnAI.TabIndex = 3;
            this.btnAI.Text = "AI play";
            this.btnAI.UseVisualStyleBackColor = true;
            this.btnAI.Click += new System.EventHandler(this.btnAI_Click);
            // 
            // pgbThinking
            // 
            this.pgbThinking.Location = new System.Drawing.Point(146, 60);
            this.pgbThinking.Name = "pgbThinking";
            this.pgbThinking.Size = new System.Drawing.Size(266, 23);
            this.pgbThinking.Step = 1;
            this.pgbThinking.TabIndex = 12;
            // 
            // lblVictory
            // 
            this.lblVictory.AutoSize = true;
            this.lblVictory.BackColor = System.Drawing.Color.Transparent;
            this.lblVictory.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVictory.ForeColor = System.Drawing.Color.Red;
            this.lblVictory.Location = new System.Drawing.Point(153, 211);
            this.lblVictory.Name = "lblVictory";
            this.lblVictory.Size = new System.Drawing.Size(174, 31);
            this.lblVictory.TabIndex = 13;
            this.lblVictory.Text = "Winner: none";
            this.lblVictory.Visible = false;
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrent.ForeColor = System.Drawing.Color.White;
            this.lblCurrent.Location = new System.Drawing.Point(227, 9);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(67, 13);
            this.lblCurrent.TabIndex = 15;
            this.lblCurrent.Text = "Current: blue";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Logs";
            this.label1.Visible = false;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(428, 60);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(213, 382);
            this.txtLog.TabIndex = 14;
            this.txtLog.Visible = false;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(146, 4);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 18;
            this.btnNewGame.Text = "new game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(59, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "thinking progess";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(59, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "opponent:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.ClientSize = new System.Drawing.Size(461, 473);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbOpponent);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblVictory);
            this.Controls.Add(this.pgbThinking);
            this.Controls.Add(this.btnAI);
            this.Controls.Add(this.pbxBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Connect4 - wieschoo.com";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxBoard;
        private System.Windows.Forms.Button btnAI;
        private System.Windows.Forms.ProgressBar pgbThinking;
        private System.Windows.Forms.Label lblVictory;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.ComboBox cmbOpponent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

