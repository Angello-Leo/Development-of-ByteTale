namespace Final_Project___CGC_Sage
{
    partial class IntroductionPanel5
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
            this.lblstring1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.typingTimer = new System.Windows.Forms.Timer(this.components);
            this.lblinstruction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblstring1
            // 
            this.lblstring1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblstring1.AutoSize = true;
            this.lblstring1.Font = new System.Drawing.Font("Pixel Operator HB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstring1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblstring1.Location = new System.Drawing.Point(145, 526);
            this.lblstring1.Name = "lblstring1";
            this.lblstring1.Size = new System.Drawing.Size(863, 32);
            this.lblstring1.TabIndex = 8;
            this.lblstring1.Text = "“Maybe the way out wasn’t up or down. Maybe it was through me.”\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::Final_Project___CGC_Sage.Properties.Resources.intro5;
            this.pictureBox1.Location = new System.Drawing.Point(56, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1070, 387);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Pixel Operator HB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(573, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(542, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "Visual Credits to TobyFox and Undertale\r\n";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Pixel Operator HB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(739, 422);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "Visual Arts not ours.";
            // 
            // typingTimer
            // 
            this.typingTimer.Enabled = true;
            // 
            // lblinstruction
            // 
            this.lblinstruction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblinstruction.AutoSize = true;
            this.lblinstruction.Font = new System.Drawing.Font("Pixel Operator HB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinstruction.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblinstruction.Location = new System.Drawing.Point(316, 558);
            this.lblinstruction.Name = "lblinstruction";
            this.lblinstruction.Size = new System.Drawing.Size(350, 32);
            this.lblinstruction.TabIndex = 14;
            this.lblinstruction.Text = "Press Enter to continue..\r\n";
            this.lblinstruction.Click += new System.EventHandler(this.lblinstruction_Click);
            // 
            // IntroductionPanel5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1181, 670);
            this.Controls.Add(this.lblinstruction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblstring1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IntroductionPanel5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IntroductionPanel5";
            this.Load += new System.EventHandler(this.IntroductionPanel5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblstring1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer typingTimer;
        private System.Windows.Forms.Label lblinstruction;
    }
}