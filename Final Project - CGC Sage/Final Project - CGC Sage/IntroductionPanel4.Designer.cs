namespace Final_Project___CGC_Sage
{
    partial class IntroductionPanel4
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblinstruction = new System.Windows.Forms.Label();
            this.typingTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblstring1
            // 
            this.lblstring1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblstring1.AutoSize = true;
            this.lblstring1.Font = new System.Drawing.Font("Pixel Operator HB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstring1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblstring1.Location = new System.Drawing.Point(190, 526);
            this.lblstring1.Name = "lblstring1";
            this.lblstring1.Size = new System.Drawing.Size(790, 32);
            this.lblstring1.TabIndex = 6;
            this.lblstring1.Text = "“The cave doesn’t want me trapped. It wants me to choose.”\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::Final_Project___CGC_Sage.Properties.Resources.intro4;
            this.pictureBox1.Location = new System.Drawing.Point(56, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1070, 387);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Pixel Operator HB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(573, 458);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(542, 32);
            this.label5.TabIndex = 15;
            this.label5.Text = "Visual Credits to TobyFox and Undertale\r\n";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Pixel Operator HB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(708, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(292, 32);
            this.label4.TabIndex = 14;
            this.label4.Text = "Visual Arts not ours.";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblinstruction
            // 
            this.lblinstruction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblinstruction.AutoSize = true;
            this.lblinstruction.Font = new System.Drawing.Font("Pixel Operator HB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinstruction.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblinstruction.Location = new System.Drawing.Point(429, 562);
            this.lblinstruction.Name = "lblinstruction";
            this.lblinstruction.Size = new System.Drawing.Size(350, 32);
            this.lblinstruction.TabIndex = 16;
            this.lblinstruction.Text = "Press Enter to continue..\r\n";
            // 
            // typingTimer
            // 
            this.typingTimer.Enabled = true;
            // 
            // IntroductionPanel4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1181, 670);
            this.Controls.Add(this.lblinstruction);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblstring1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IntroductionPanel4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IntroductionPanel4";
            this.Load += new System.EventHandler(this.IntroductionPanel4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblstring1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblinstruction;
        private System.Windows.Forms.Timer typingTimer;
    }
}