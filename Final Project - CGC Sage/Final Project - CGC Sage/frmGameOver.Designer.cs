namespace Final_Project___CGC_Sage
{
    partial class frmGameOver
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
            this.lblGameOver = new System.Windows.Forms.Label();
            this.heartBox = new System.Windows.Forms.PictureBox();
            this.lblContinue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.heartBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGameOver
            // 
            this.lblGameOver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("Pixel Operator HB 8", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.ForeColor = System.Drawing.Color.White;
            this.lblGameOver.Location = new System.Drawing.Point(354, 64);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(550, 59);
            this.lblGameOver.TabIndex = 0;
            this.lblGameOver.Text = "GAME OVER\r\n";
            this.lblGameOver.Visible = false;
            // 
            // heartBox
            // 
            this.heartBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.heartBox.Location = new System.Drawing.Point(383, 265);
            this.heartBox.Name = "heartBox";
            this.heartBox.Size = new System.Drawing.Size(493, 308);
            this.heartBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.heartBox.TabIndex = 1;
            this.heartBox.TabStop = false;
            // 
            // lblContinue
            // 
            this.lblContinue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblContinue.AutoSize = true;
            this.lblContinue.Font = new System.Drawing.Font("Pixel Operator HB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContinue.ForeColor = System.Drawing.Color.White;
            this.lblContinue.Location = new System.Drawing.Point(378, 206);
            this.lblContinue.Name = "lblContinue";
            this.lblContinue.Size = new System.Drawing.Size(91, 30);
            this.lblContinue.TabIndex = 2;
            this.lblContinue.Text = "label1";
            this.lblContinue.Visible = false;
            // 
            // frmGameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1159, 610);
            this.Controls.Add(this.lblContinue);
            this.Controls.Add(this.heartBox);
            this.Controls.Add(this.lblGameOver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGameOver";
            this.Text = "frmGameOver";
            this.Load += new System.EventHandler(this.frmGameOver_Load);
            ((System.ComponentModel.ISupportInitialize)(this.heartBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.PictureBox heartBox;
        private System.Windows.Forms.Label lblContinue;
    }
}