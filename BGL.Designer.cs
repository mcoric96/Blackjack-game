namespace OTTER
{
    partial class BGL
    {


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BGL));
            this.syncRate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnNovaIgra = new System.Windows.Forms.Button();
            this.btnBasicStrategy = new System.Windows.Forms.Button();
            this.btnWikipedia = new System.Windows.Forms.Button();
            this.lblNovac = new System.Windows.Forms.Label();
            this.btnHit = new System.Windows.Forms.Button();
            this.btnStand = new System.Windows.Forms.Button();
            this.btnDouble = new System.Windows.Forms.Button();
            this.btnClearOklada = new System.Windows.Forms.Button();
            this.pictureBoxChip100 = new System.Windows.Forms.PictureBox();
            this.pictureBoxChip50 = new System.Windows.Forms.PictureBox();
            this.pictureBoxChip25 = new System.Windows.Forms.PictureBox();
            this.pictureBoxChip5 = new System.Windows.Forms.PictureBox();
            this.pictureBoxDollar = new System.Windows.Forms.PictureBox();
            this.pictureBoxStol = new System.Windows.Forms.PictureBox();
            this.lblMisKoordinate = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblPlayerMoney = new System.Windows.Forms.Label();
            this.lblUserScore = new System.Windows.Forms.Label();
            this.lblDealerScore = new System.Windows.Forms.Label();
            this.btnTestButton = new System.Windows.Forms.Button();
            this.lblActivePlayer = new System.Windows.Forms.Label();
            this.btnDeal = new System.Windows.Forms.Button();
            this.btnTest2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChip100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChip50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChip25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChip5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDollar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStol)).BeginInit();
            this.SuspendLayout();
            // 
            // syncRate
            // 
            this.syncRate.AutoSize = true;
            this.syncRate.BackColor = System.Drawing.Color.Transparent;
            this.syncRate.Location = new System.Drawing.Point(992, 616);
            this.syncRate.Name = "syncRate";
            this.syncRate.Size = new System.Drawing.Size(55, 39);
            this.syncRate.TabIndex = 0;
            this.syncRate.Text = "60";
            this.syncRate.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 17;
            this.timer1.Tick += new System.EventHandler(this.Update);
            // 
            // timer2
            // 
            this.timer2.Interval = 250;
            this.timer2.Tick += new System.EventHandler(this.updateFrameRate);
            // 
            // btnNovaIgra
            // 
            this.btnNovaIgra.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNovaIgra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNovaIgra.ForeColor = System.Drawing.Color.Black;
            this.btnNovaIgra.Location = new System.Drawing.Point(19, 623);
            this.btnNovaIgra.Name = "btnNovaIgra";
            this.btnNovaIgra.Size = new System.Drawing.Size(111, 29);
            this.btnNovaIgra.TabIndex = 2;
            this.btnNovaIgra.Text = "New game";
            this.btnNovaIgra.UseVisualStyleBackColor = true;
            this.btnNovaIgra.Click += new System.EventHandler(this.btnNovaIgra_Click);
            // 
            // btnBasicStrategy
            // 
            this.btnBasicStrategy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBasicStrategy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBasicStrategy.ForeColor = System.Drawing.Color.Black;
            this.btnBasicStrategy.Location = new System.Drawing.Point(136, 623);
            this.btnBasicStrategy.Name = "btnBasicStrategy";
            this.btnBasicStrategy.Size = new System.Drawing.Size(115, 29);
            this.btnBasicStrategy.TabIndex = 3;
            this.btnBasicStrategy.Text = "Basic strategy";
            this.btnBasicStrategy.UseVisualStyleBackColor = true;
            this.btnBasicStrategy.Click += new System.EventHandler(this.btnBasicStrategy_Click);
            // 
            // btnWikipedia
            // 
            this.btnWikipedia.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnWikipedia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWikipedia.ForeColor = System.Drawing.Color.Black;
            this.btnWikipedia.Location = new System.Drawing.Point(257, 623);
            this.btnWikipedia.Name = "btnWikipedia";
            this.btnWikipedia.Size = new System.Drawing.Size(115, 29);
            this.btnWikipedia.TabIndex = 4;
            this.btnWikipedia.Text = "Wikipedia";
            this.btnWikipedia.UseVisualStyleBackColor = true;
            this.btnWikipedia.Click += new System.EventHandler(this.btnWikipedia_Click);
            // 
            // lblNovac
            // 
            this.lblNovac.AutoSize = true;
            this.lblNovac.BackColor = System.Drawing.Color.Transparent;
            this.lblNovac.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNovac.Location = new System.Drawing.Point(601, 511);
            this.lblNovac.Name = "lblNovac";
            this.lblNovac.Size = new System.Drawing.Size(24, 25);
            this.lblNovac.TabIndex = 6;
            this.lblNovac.Text = "0";
            // 
            // btnHit
            // 
            this.btnHit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnHit.ForeColor = System.Drawing.Color.Black;
            this.btnHit.Location = new System.Drawing.Point(367, 556);
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new System.Drawing.Size(82, 29);
            this.btnHit.TabIndex = 7;
            this.btnHit.Text = "Hit";
            this.btnHit.UseVisualStyleBackColor = true;
            this.btnHit.Click += new System.EventHandler(this.HitClick);
            // 
            // btnStand
            // 
            this.btnStand.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStand.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStand.ForeColor = System.Drawing.Color.Black;
            this.btnStand.Location = new System.Drawing.Point(455, 556);
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new System.Drawing.Size(82, 29);
            this.btnStand.TabIndex = 8;
            this.btnStand.Text = "Stand";
            this.btnStand.UseVisualStyleBackColor = true;
            this.btnStand.Click += new System.EventHandler(this.StandClick);
            // 
            // btnDouble
            // 
            this.btnDouble.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDouble.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDouble.ForeColor = System.Drawing.Color.Black;
            this.btnDouble.Location = new System.Drawing.Point(543, 556);
            this.btnDouble.Name = "btnDouble";
            this.btnDouble.Size = new System.Drawing.Size(82, 29);
            this.btnDouble.TabIndex = 9;
            this.btnDouble.Text = "Double";
            this.btnDouble.UseVisualStyleBackColor = true;
            this.btnDouble.Click += new System.EventHandler(this.btnDouble_Click);
            // 
            // btnClearOklada
            // 
            this.btnClearOklada.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClearOklada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClearOklada.ForeColor = System.Drawing.Color.Black;
            this.btnClearOklada.Location = new System.Drawing.Point(926, 556);
            this.btnClearOklada.Name = "btnClearOklada";
            this.btnClearOklada.Size = new System.Drawing.Size(97, 29);
            this.btnClearOklada.TabIndex = 14;
            this.btnClearOklada.Text = "Clear bet";
            this.btnClearOklada.UseVisualStyleBackColor = true;
            this.btnClearOklada.Click += new System.EventHandler(this.ClearBet_Clicked);
            // 
            // pictureBoxChip100
            // 
            this.pictureBoxChip100.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxChip100.Image = global::OTTER.Properties.Resources._100chip;
            this.pictureBoxChip100.Location = new System.Drawing.Point(870, 547);
            this.pictureBoxChip100.Name = "pictureBoxChip100";
            this.pictureBoxChip100.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxChip100.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxChip100.TabIndex = 13;
            this.pictureBoxChip100.TabStop = false;
            this.pictureBoxChip100.Click += new System.EventHandler(this.pictureBoxChip100_Click);
            // 
            // pictureBoxChip50
            // 
            this.pictureBoxChip50.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxChip50.Image = global::OTTER.Properties.Resources._50chips;
            this.pictureBoxChip50.Location = new System.Drawing.Point(809, 547);
            this.pictureBoxChip50.Name = "pictureBoxChip50";
            this.pictureBoxChip50.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxChip50.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxChip50.TabIndex = 12;
            this.pictureBoxChip50.TabStop = false;
            this.pictureBoxChip50.Click += new System.EventHandler(this.pictureBoxChip50_Click);
            // 
            // pictureBoxChip25
            // 
            this.pictureBoxChip25.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxChip25.Image = global::OTTER.Properties.Resources._25chips;
            this.pictureBoxChip25.Location = new System.Drawing.Point(748, 547);
            this.pictureBoxChip25.Name = "pictureBoxChip25";
            this.pictureBoxChip25.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxChip25.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxChip25.TabIndex = 11;
            this.pictureBoxChip25.TabStop = false;
            this.pictureBoxChip25.Click += new System.EventHandler(this.pictureBoxChip25_Click);
            // 
            // pictureBoxChip5
            // 
            this.pictureBoxChip5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxChip5.Image = global::OTTER.Properties.Resources._5chip;
            this.pictureBoxChip5.Location = new System.Drawing.Point(687, 547);
            this.pictureBoxChip5.Name = "pictureBoxChip5";
            this.pictureBoxChip5.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxChip5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxChip5.TabIndex = 10;
            this.pictureBoxChip5.TabStop = false;
            this.pictureBoxChip5.Click += new System.EventHandler(this.pictureBoxChip5_Click);
            // 
            // pictureBoxDollar
            // 
            this.pictureBoxDollar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxDollar.Image = global::OTTER.Properties.Resources.dolar;
            this.pictureBoxDollar.Location = new System.Drawing.Point(543, 498);
            this.pictureBoxDollar.Name = "pictureBoxDollar";
            this.pictureBoxDollar.Size = new System.Drawing.Size(51, 38);
            this.pictureBoxDollar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDollar.TabIndex = 5;
            this.pictureBoxDollar.TabStop = false;
            // 
            // pictureBoxStol
            // 
            this.pictureBoxStol.Image = global::OTTER.Properties.Resources.blackjack_table_related_keywords_suggestions_blackjack_table_long_duA9Z8_clipart;
            this.pictureBoxStol.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxStol.Name = "pictureBoxStol";
            this.pictureBoxStol.Size = new System.Drawing.Size(1187, 538);
            this.pictureBoxStol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStol.TabIndex = 1;
            this.pictureBoxStol.TabStop = false;
            this.pictureBoxStol.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxStol_MouseMove);
            // 
            // lblMisKoordinate
            // 
            this.lblMisKoordinate.AutoSize = true;
            this.lblMisKoordinate.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMisKoordinate.Location = new System.Drawing.Point(1076, 622);
            this.lblMisKoordinate.Name = "lblMisKoordinate";
            this.lblMisKoordinate.Size = new System.Drawing.Size(55, 33);
            this.lblMisKoordinate.TabIndex = 16;
            this.lblMisKoordinate.Text = "0;0";
            this.lblMisKoordinate.Visible = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 300;
            this.GameTimer.Tick += new System.EventHandler(this.UpdateGameTimer);
            // 
            // lblPlayerMoney
            // 
            this.lblPlayerMoney.AutoSize = true;
            this.lblPlayerMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPlayerMoney.Location = new System.Drawing.Point(682, 609);
            this.lblPlayerMoney.Name = "lblPlayerMoney";
            this.lblPlayerMoney.Size = new System.Drawing.Size(101, 25);
            this.lblPlayerMoney.TabIndex = 17;
            this.lblPlayerMoney.Text = "Money: 0";
            // 
            // lblUserScore
            // 
            this.lblUserScore.AutoSize = true;
            this.lblUserScore.BackColor = System.Drawing.Color.Black;
            this.lblUserScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUserScore.ForeColor = System.Drawing.Color.Yellow;
            this.lblUserScore.Location = new System.Drawing.Point(477, 413);
            this.lblUserScore.Name = "lblUserScore";
            this.lblUserScore.Size = new System.Drawing.Size(18, 20);
            this.lblUserScore.TabIndex = 18;
            this.lblUserScore.Text = "0";
            // 
            // lblDealerScore
            // 
            this.lblDealerScore.AutoSize = true;
            this.lblDealerScore.BackColor = System.Drawing.Color.Black;
            this.lblDealerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDealerScore.ForeColor = System.Drawing.Color.Yellow;
            this.lblDealerScore.Location = new System.Drawing.Point(477, 71);
            this.lblDealerScore.Name = "lblDealerScore";
            this.lblDealerScore.Size = new System.Drawing.Size(18, 20);
            this.lblDealerScore.TabIndex = 19;
            this.lblDealerScore.Text = "0";
            // 
            // btnTestButton
            // 
            this.btnTestButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTestButton.ForeColor = System.Drawing.Color.Black;
            this.btnTestButton.Location = new System.Drawing.Point(1082, 556);
            this.btnTestButton.Name = "btnTestButton";
            this.btnTestButton.Size = new System.Drawing.Size(106, 31);
            this.btnTestButton.TabIndex = 20;
            this.btnTestButton.Text = "Test button";
            this.btnTestButton.UseVisualStyleBackColor = true;
            this.btnTestButton.Visible = false;
            this.btnTestButton.Click += new System.EventHandler(this.btnTestButton_Click);
            // 
            // lblActivePlayer
            // 
            this.lblActivePlayer.AutoSize = true;
            this.lblActivePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblActivePlayer.Location = new System.Drawing.Point(15, 563);
            this.lblActivePlayer.Name = "lblActivePlayer";
            this.lblActivePlayer.Size = new System.Drawing.Size(122, 24);
            this.lblActivePlayer.TabIndex = 21;
            this.lblActivePlayer.Text = "Active player:";
            // 
            // btnDeal
            // 
            this.btnDeal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDeal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeal.ForeColor = System.Drawing.Color.Black;
            this.btnDeal.Location = new System.Drawing.Point(226, 557);
            this.btnDeal.Name = "btnDeal";
            this.btnDeal.Size = new System.Drawing.Size(135, 29);
            this.btnDeal.TabIndex = 22;
            this.btnDeal.Text = "Deal next round";
            this.btnDeal.UseVisualStyleBackColor = true;
            this.btnDeal.Click += new System.EventHandler(this.Deal_Click);
            // 
            // btnTest2
            // 
            this.btnTest2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTest2.ForeColor = System.Drawing.Color.Black;
            this.btnTest2.Location = new System.Drawing.Point(1081, 592);
            this.btnTest2.Name = "btnTest2";
            this.btnTest2.Size = new System.Drawing.Size(107, 27);
            this.btnTest2.TabIndex = 23;
            this.btnTest2.Text = "Test 2";
            this.btnTest2.UseVisualStyleBackColor = true;
            this.btnTest2.Visible = false;
            this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // BGL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1211, 664);
            this.Controls.Add(this.btnTest2);
            this.Controls.Add(this.btnDeal);
            this.Controls.Add(this.lblActivePlayer);
            this.Controls.Add(this.btnTestButton);
            this.Controls.Add(this.lblDealerScore);
            this.Controls.Add(this.lblUserScore);
            this.Controls.Add(this.lblPlayerMoney);
            this.Controls.Add(this.lblMisKoordinate);
            this.Controls.Add(this.btnClearOklada);
            this.Controls.Add(this.pictureBoxChip100);
            this.Controls.Add(this.pictureBoxChip50);
            this.Controls.Add(this.pictureBoxChip25);
            this.Controls.Add(this.pictureBoxChip5);
            this.Controls.Add(this.btnDouble);
            this.Controls.Add(this.btnStand);
            this.Controls.Add(this.btnHit);
            this.Controls.Add(this.lblNovac);
            this.Controls.Add(this.pictureBoxDollar);
            this.Controls.Add(this.btnWikipedia);
            this.Controls.Add(this.btnBasicStrategy);
            this.Controls.Add(this.btnNovaIgra);
            this.Controls.Add(this.syncRate);
            this.Controls.Add(this.pictureBoxStol);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.MaximizeBox = false;
            this.Name = "BGL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blackjack";
            this.Load += new System.EventHandler(this.startTimer);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClicked);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChip100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChip50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChip25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChip5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDollar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label syncRate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pictureBoxStol;
        private System.Windows.Forms.Button btnNovaIgra;
        private System.Windows.Forms.Button btnBasicStrategy;
        private System.Windows.Forms.Button btnWikipedia;
        private System.Windows.Forms.PictureBox pictureBoxDollar;
        private System.Windows.Forms.Label lblNovac;
        private System.Windows.Forms.Label lblMisKoordinate;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Button btnHit;
        private System.Windows.Forms.Button btnStand;
        private System.Windows.Forms.Button btnDouble;
        private System.Windows.Forms.PictureBox pictureBoxChip5;
        private System.Windows.Forms.PictureBox pictureBoxChip25;
        private System.Windows.Forms.PictureBox pictureBoxChip50;
        private System.Windows.Forms.PictureBox pictureBoxChip100;
        private System.Windows.Forms.Button btnClearOklada;
        private System.Windows.Forms.Label lblPlayerMoney;
        private System.Windows.Forms.Label lblUserScore;
        private System.Windows.Forms.Label lblDealerScore;
        private System.Windows.Forms.Button btnTestButton;
        private System.Windows.Forms.Label lblActivePlayer;
        private System.Windows.Forms.Button btnDeal;
        private System.Windows.Forms.Button btnTest2;
    }
}

