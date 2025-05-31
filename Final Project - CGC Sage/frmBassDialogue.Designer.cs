namespace Final_Project___CGC_Sage
{
    partial class frmBassDialogue
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
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblDev = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLeo = new System.Windows.Forms.Label();
            this.lblContinue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            this.lblInstructions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInstructions.Font = new System.Drawing.Font("Sitka Display", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblInstructions.Location = new System.Drawing.Point(251, 252);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(299, 53);
            this.lblInstructions.TabIndex = 8;
            this.lblInstructions.Text = "Press \"C\" to exit..";
            // 
            // lblDev
            // 
            this.lblDev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDev.Font = new System.Drawing.Font("Pixel Operator HB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDev.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDev.Location = new System.Drawing.Point(296, 199);
            this.lblDev.Name = "lblDev";
            this.lblDev.Size = new System.Drawing.Size(236, 53);
            this.lblDev.TabIndex = 7;
            this.lblDev.Text = "(Developer)";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(338, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // lblLeo
            // 
            this.lblLeo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLeo.Font = new System.Drawing.Font("Pixel Operator HB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLeo.Location = new System.Drawing.Point(192, 146);
            this.lblLeo.Name = "lblLeo";
            this.lblLeo.Size = new System.Drawing.Size(534, 53);
            this.lblLeo.TabIndex = 5;
            this.lblLeo.Text = "Bass of Leo Angello P. Visto\r\n";
            // 
            // lblContinue
            // 
            this.lblContinue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblContinue.Font = new System.Drawing.Font("Pixel Operator HB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContinue.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblContinue.Location = new System.Drawing.Point(216, 252);
            this.lblContinue.Name = "lblContinue";
            this.lblContinue.Size = new System.Drawing.Size(413, 53);
            this.lblContinue.TabIndex = 14;
            this.lblContinue.Text = "Press \"Z\" to continue.";
            // 
            // frmBassDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblContinue);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblDev);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLeo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBassDialogue";
            this.Text = "frmBassDialogue";
            this.Load += new System.EventHandler(this.frmBassDialogue_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblDev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLeo;
        private System.Windows.Forms.Label lblContinue;
    }
}