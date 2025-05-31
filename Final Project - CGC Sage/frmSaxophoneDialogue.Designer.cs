namespace Final_Project___CGC_Sage
{
    partial class frmSaxophoneDialogue
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
            this.lblKing = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDev = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblContinue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblKing
            // 
            this.lblKing.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKing.Font = new System.Drawing.Font("Pixel Operator HB", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKing.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblKing.Location = new System.Drawing.Point(65, 43);
            this.lblKing.Name = "lblKing";
            this.lblKing.Size = new System.Drawing.Size(723, 53);
            this.lblKing.TabIndex = 1;
            this.lblKing.Text = "Saxophone of King Alfonze V. Mangundayao\r\n";
            this.lblKing.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // lblDev
            // 
            this.lblDev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDev.Font = new System.Drawing.Font("Pixel Operator HB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDev.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDev.Location = new System.Drawing.Point(305, 96);
            this.lblDev.Name = "lblDev";
            this.lblDev.Size = new System.Drawing.Size(239, 53);
            this.lblDev.TabIndex = 3;
            this.lblDev.Text = "(Developer)";
            // 
            // lblInstructions
            // 
            this.lblInstructions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInstructions.Font = new System.Drawing.Font("Sitka Display", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblInstructions.Location = new System.Drawing.Point(260, 149);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(299, 53);
            this.lblInstructions.TabIndex = 4;
            this.lblInstructions.Text = "Press \"C\" to exit..";
            this.lblInstructions.Visible = false;
            // 
            // lblContinue
            // 
            this.lblContinue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblContinue.Font = new System.Drawing.Font("Pixel Operator HB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContinue.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblContinue.Location = new System.Drawing.Point(229, 149);
            this.lblContinue.Name = "lblContinue";
            this.lblContinue.Size = new System.Drawing.Size(416, 53);
            this.lblContinue.TabIndex = 5;
            this.lblContinue.Text = "Press \"Z\" to continue.";
            this.lblContinue.Click += new System.EventHandler(this.lblContinue_Click);
            // 
            // frmSaxophoneDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 200);
            this.Controls.Add(this.lblContinue);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblDev);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblKing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSaxophoneDialogue";
            this.Text = "frmSaxophoneDialogue";
            this.Load += new System.EventHandler(this.frmSaxophoneDialogue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblKing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDev;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblContinue;
    }
}