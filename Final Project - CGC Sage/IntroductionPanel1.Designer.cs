namespace Final_Project___CGC_Sage
{
    partial class IntroductionPanel1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroductionPanel1));
            this.lblstring1 = new System.Windows.Forms.Label();
            this.lblstring2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.lblstring1.Location = new System.Drawing.Point(138, 526);
            this.lblstring1.Name = "lblstring1";
            this.lblstring1.Size = new System.Drawing.Size(938, 32);
            this.lblstring1.TabIndex = 1;
            this.lblstring1.Text = "“I was running from another failed test, another disappointed look... ";
            this.lblstring1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblstring2
            // 
            this.lblstring2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblstring2.AutoSize = true;
            this.lblstring2.Font = new System.Drawing.Font("Pixel Operator HB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstring2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblstring2.Location = new System.Drawing.Point(369, 562);
            this.lblstring2.Name = "lblstring2";
            this.lblstring2.Size = new System.Drawing.Size(432, 32);
            this.lblstring2.TabIndex = 2;
            this.lblstring2.Text = "and then, the ground gave way.”";
            this.lblstring2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(56, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1070, 387);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Pixel Operator HB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(573, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(542, 32);
            this.label3.TabIndex = 11;
            this.label3.Text = "Visual Credits to TobyFox and Undertale\r\n";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Pixel Operator HB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(707, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(292, 32);
            this.label4.TabIndex = 12;
            this.label4.Text = "Visual Arts not ours.";
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
            this.lblinstruction.Location = new System.Drawing.Point(421, 598);
            this.lblinstruction.Name = "lblinstruction";
            this.lblinstruction.Size = new System.Drawing.Size(350, 32);
            this.lblinstruction.TabIndex = 13;
            this.lblinstruction.Text = "Press Enter to continue..\r\n";
            // 
            // IntroductionPanel1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1181, 670);
            this.Controls.Add(this.lblinstruction);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblstring2);
            this.Controls.Add(this.lblstring1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IntroductionPanel1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IntroductionPanel1";
            this.Load += new System.EventHandler(this.IntroductionPanel1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblstring1;
        private System.Windows.Forms.Label lblstring2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer typingTimer;
        private System.Windows.Forms.Label lblinstruction;
    }
}