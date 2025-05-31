namespace Final_Project___CGC_Sage
{
    partial class frmControllerDialogue
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
            this.lblRalfh = new System.Windows.Forms.Label();
            this.lblContinue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            this.lblInstructions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInstructions.Font = new System.Drawing.Font("Sitka Display", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblInstructions.Location = new System.Drawing.Point(244, 252);
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
            this.lblDev.Location = new System.Drawing.Point(289, 199);
            this.lblDev.Name = "lblDev";
            this.lblDev.Size = new System.Drawing.Size(254, 53);
            this.lblDev.TabIndex = 7;
            this.lblDev.Text = "(Developer)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // lblRalfh
            // 
            this.lblRalfh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRalfh.Font = new System.Drawing.Font("Pixel Operator HB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRalfh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRalfh.Location = new System.Drawing.Point(95, 146);
            this.lblRalfh.Name = "lblRalfh";
            this.lblRalfh.Size = new System.Drawing.Size(693, 53);
            this.lblRalfh.TabIndex = 5;
            this.lblRalfh.Text = "Controller of Ralfh Justine N. Lindog\r\n";
            // 
            // lblContinue
            // 
            this.lblContinue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblContinue.Font = new System.Drawing.Font("Pixel Operator HB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContinue.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblContinue.Location = new System.Drawing.Point(211, 252);
            this.lblContinue.Name = "lblContinue";
            this.lblContinue.Size = new System.Drawing.Size(416, 53);
            this.lblContinue.TabIndex = 9;
            this.lblContinue.Text = "Press \"Z\" to continue.";
            // 
            // frmControllerDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblContinue);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblDev);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRalfh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmControllerDialogue";
            this.Text = "frmControllerDialogue";
            this.Load += new System.EventHandler(this.frmControllerDialogue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblDev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRalfh;
        private System.Windows.Forms.Label lblContinue;
    }
}