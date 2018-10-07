namespace OTTER
{
    partial class TestForm
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
            this.btnNovaKarta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBrojSpriteova = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNovaKarta
            // 
            this.btnNovaKarta.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNovaKarta.Location = new System.Drawing.Point(33, 25);
            this.btnNovaKarta.Name = "btnNovaKarta";
            this.btnNovaKarta.Size = new System.Drawing.Size(112, 29);
            this.btnNovaKarta.TabIndex = 0;
            this.btnNovaKarta.Text = "Dodaj novu kartu";
            this.btnNovaKarta.UseVisualStyleBackColor = true;
            this.btnNovaKarta.Click += new System.EventHandler(this.btnNovaKarta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(185, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Broj spriteova:";
            // 
            // lblBrojSpriteova
            // 
            this.lblBrojSpriteova.AutoSize = true;
            this.lblBrojSpriteova.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBrojSpriteova.Location = new System.Drawing.Point(285, 31);
            this.lblBrojSpriteova.Name = "lblBrojSpriteova";
            this.lblBrojSpriteova.Size = new System.Drawing.Size(94, 16);
            this.lblBrojSpriteova.TabIndex = 2;
            this.lblBrojSpriteova.Text = "Broj spriteova:";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 95);
            this.Controls.Add(this.lblBrojSpriteova);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNovaKarta);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNovaKarta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBrojSpriteova;
    }
}