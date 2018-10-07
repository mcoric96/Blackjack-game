namespace OTTER
{
    partial class FormGameOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameOptions));
            this.label1 = new System.Windows.Forms.Label();
            this.axOlkComboBox1 = new AxMicrosoft.Office.Interop.Outlook.AxOlkComboBox();
            this.comboBoxBrojSpilova = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNovac = new System.Windows.Forms.TextBox();
            this.btnIgraj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axOlkComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Broj spilova";
            // 
            // axOlkComboBox1
            // 
            this.axOlkComboBox1.Location = new System.Drawing.Point(0, 0);
            this.axOlkComboBox1.Name = "axOlkComboBox1";
            this.axOlkComboBox1.TabIndex = 0;
            // 
            // comboBoxBrojSpilova
            // 
            this.comboBoxBrojSpilova.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBrojSpilova.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxBrojSpilova.FormattingEnabled = true;
            this.comboBoxBrojSpilova.Items.AddRange(new object[] {
            "2",
            "4",
            "6",
            "8"});
            this.comboBoxBrojSpilova.Location = new System.Drawing.Point(141, 12);
            this.comboBoxBrojSpilova.Name = "comboBoxBrojSpilova";
            this.comboBoxBrojSpilova.Size = new System.Drawing.Size(82, 21);
            this.comboBoxBrojSpilova.TabIndex = 1;
            this.comboBoxBrojSpilova.SelectedIndexChanged += new System.EventHandler(this.comboBoxBrojSpilova_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Novac";
            // 
            // textBoxNovac
            // 
            this.textBoxNovac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNovac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNovac.Location = new System.Drawing.Point(141, 64);
            this.textBoxNovac.Name = "textBoxNovac";
            this.textBoxNovac.Size = new System.Drawing.Size(82, 21);
            this.textBoxNovac.TabIndex = 3;
            this.textBoxNovac.TextChanged += new System.EventHandler(this.textBoxNovac_TextChanged);
            // 
            // btnIgraj
            // 
            this.btnIgraj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIgraj.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnIgraj.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnIgraj.Location = new System.Drawing.Point(16, 115);
            this.btnIgraj.Name = "btnIgraj";
            this.btnIgraj.Size = new System.Drawing.Size(207, 27);
            this.btnIgraj.TabIndex = 4;
            this.btnIgraj.Text = "Igraj";
            this.btnIgraj.UseVisualStyleBackColor = true;
            this.btnIgraj.Click += new System.EventHandler(this.btnIgraj_Click);
            // 
            // FormGameOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(246, 159);
            this.Controls.Add(this.btnIgraj);
            this.Controls.Add(this.textBoxNovac);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxBrojSpilova);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameOptions";
            this.Load += new System.EventHandler(this.FormGameOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axOlkComboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private AxMicrosoft.Office.Interop.Outlook.AxOlkComboBox axOlkComboBox1;
        private System.Windows.Forms.ComboBox comboBoxBrojSpilova;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNovac;
        private System.Windows.Forms.Button btnIgraj;
    }
}