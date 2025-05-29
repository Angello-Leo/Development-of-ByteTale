namespace Final_Project___CGC_Sage
{
    partial class IntroductionPanel2
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
            this.lblstring1.Location = new System.Drawing.Point(197, 526);
            this.lblstring1.Name = "lblstring1";
            this.lblstring1.Size = new System.Drawing.Size(781, 32);
            this.lblstring1.TabIndex = 4;
            this.lblstring1.Text = "“Down here, everything echoes. My footsteps. My doubts.”\r\n";
            this.lblstring1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::Final_Project___CGC_Sage.Properties.Resources.intro21;
            this.pictureBox1.Location = new System.Drawing.Point(56, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1070, 387);
            this.pictureBox1.TabIndex = 5;
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
            this.label2.TabIndex = 10;
            this.label2.Text = "Visual Credits to TobyFox and Undertale\r\n";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Pixel Operator HB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(701, 422);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 32);
            this.label3.TabIndex = 11;
            this.label3.Text = "Visual Arts not ours.";
            // 
            // lblinstruction
            // 
            this.lblinstruction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblinstruction.AutoSize = true;
            this.lblinstruction.Font = new System.Drawing.Font("Pixel Operator HB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinstruction.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblinstruction.Location = new System.Drawing.Point(409, 562);
            this.lblinstruction.Name = "lblinstruction";
            this.lblinstruction.Size = new System.Drawing.Size(350, 32);
            this.lblinstruction.TabIndex = 14;
            this.lblinstruction.Text = "Press Enter to continue..\r\n";
            // 
            // typingTimer
            // 
            this.typingTimer.Enabled = true;
            // 
            // IntroductionPanel2
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
            this.Name = "IntroductionPanel2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IntroductionPanel2";
            this.Load += new System.EventHandler(this.IntroductionPanel2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblstring1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblinstruction;
        private System.Windows.Forms.Timer typingTimer;
    }
}