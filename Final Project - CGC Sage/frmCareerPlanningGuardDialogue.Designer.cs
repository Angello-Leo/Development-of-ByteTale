namespace Final_Project___CGC_Sage
{
    partial class frmCareerPlanningGuardDialogue
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
            this.lblDialogue = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSelect = new System.Windows.Forms.Label();
            this.lblGuide = new System.Windows.Forms.Label();
            this.lblOption3 = new System.Windows.Forms.Label();
            this.lblOption2 = new System.Windows.Forms.Label();
            this.lblOption1 = new System.Windows.Forms.Label();
            this.typingTimerCareer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxSoul = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSoul)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDialogue
            // 
            this.lblDialogue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDialogue.AutoSize = true;
            this.lblDialogue.Font = new System.Drawing.Font("Pixel Operator HB", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDialogue.Location = new System.Drawing.Point(423, 85);
            this.lblDialogue.Name = "lblDialogue";
            this.lblDialogue.Size = new System.Drawing.Size(713, 35);
            this.lblDialogue.TabIndex = 0;
            this.lblDialogue.Text = "Hmmm... Your path seems blurry and undecided..";
            this.lblDialogue.Click += new System.EventHandler(this.lblDialogue_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 369);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Controls.Add(this.lblSelect);
            this.panel2.Controls.Add(this.lblDialogue);
            this.panel2.Controls.Add(this.lblGuide);
            this.panel2.Controls.Add(this.pictureBoxSoul);
            this.panel2.Controls.Add(this.lblOption3);
            this.panel2.Controls.Add(this.lblOption2);
            this.panel2.Controls.Add(this.lblOption1);
            this.panel2.Location = new System.Drawing.Point(9, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1196, 344);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblSelect
            // 
            this.lblSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSelect.AutoSize = true;
            this.lblSelect.Font = new System.Drawing.Font("Pixel Operator HB", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblSelect.Location = new System.Drawing.Point(515, 269);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(489, 35);
            this.lblSelect.TabIndex = 5;
            this.lblSelect.Text = "Press \"Z\" to select and continue";
            this.lblSelect.Click += new System.EventHandler(this.txtSelect_Click);
            // 
            // lblGuide
            // 
            this.lblGuide.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGuide.AutoSize = true;
            this.lblGuide.Font = new System.Drawing.Font("Pixel Operator HB", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuide.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblGuide.Location = new System.Drawing.Point(594, 146);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(391, 42);
            this.lblGuide.TabIndex = 3;
            this.lblGuide.Text = "Press \"Z to continue\"";
            this.lblGuide.Visible = false;
            this.lblGuide.Click += new System.EventHandler(this.lblGuide_Click);
            // 
            // lblOption3
            // 
            this.lblOption3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOption3.AutoSize = true;
            this.lblOption3.Font = new System.Drawing.Font("Pixel Operator HB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOption3.Location = new System.Drawing.Point(888, 235);
            this.lblOption3.Name = "lblOption3";
            this.lblOption3.Size = new System.Drawing.Size(155, 21);
            this.lblOption3.TabIndex = 3;
            this.lblOption3.Text = "Maybe next time.";
            this.lblOption3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblOption2
            // 
            this.lblOption2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOption2.AutoSize = true;
            this.lblOption2.Font = new System.Drawing.Font("Pixel Operator HB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOption2.Location = new System.Drawing.Point(621, 235);
            this.lblOption2.Name = "lblOption2";
            this.lblOption2.Size = new System.Drawing.Size(222, 21);
            this.lblOption2.TabIndex = 2;
            this.lblOption2.Text = "What is this cave about?";
            this.lblOption2.Click += new System.EventHandler(this.lblOption2_Click);
            // 
            // lblOption1
            // 
            this.lblOption1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOption1.AutoSize = true;
            this.lblOption1.Font = new System.Drawing.Font("Pixel Operator HB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOption1.Location = new System.Drawing.Point(392, 235);
            this.lblOption1.Name = "lblOption1";
            this.lblOption1.Size = new System.Drawing.Size(176, 21);
            this.lblOption1.TabIndex = 1;
            this.lblOption1.Text = "I am ready to enter";
            this.lblOption1.Click += new System.EventHandler(this.lblOption1_Click);
            // 
            // typingTimerCareer
            // 
            this.typingTimerCareer.Enabled = true;
            this.typingTimerCareer.Tick += new System.EventHandler(this.typingTimerCareer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Image = global::Final_Project___CGC_Sage.Properties.Resources.GDialogue;
            this.pictureBox1.Location = new System.Drawing.Point(39, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(322, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBoxSoul
            // 
            this.pictureBoxSoul.Image = global::Final_Project___CGC_Sage.Properties.Resources.soul;
            this.pictureBoxSoul.Location = new System.Drawing.Point(601, 235);
            this.pictureBoxSoul.Name = "pictureBoxSoul";
            this.pictureBoxSoul.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxSoul.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxSoul.TabIndex = 4;
            this.pictureBoxSoul.TabStop = false;
            this.pictureBoxSoul.Click += new System.EventHandler(this.pictureBoxSoul_Click);
            // 
            // frmCareerPlanningGuardDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1220, 368);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCareerPlanningGuardDialogue";
            this.Text = "frmCareerPlanningGuardDialogue";
            this.Load += new System.EventHandler(this.frmCareerPlanningGuardDialogue_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSoul)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDialogue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblOption3;
        private System.Windows.Forms.Label lblOption2;
        private System.Windows.Forms.Label lblOption1;
        private System.Windows.Forms.PictureBox pictureBoxSoul;
        private System.Windows.Forms.Timer typingTimerCareer;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Label lblGuide;
    }
}