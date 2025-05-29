namespace Final_Project___CGC_Sage
{
    partial class frmDoggoDialogue
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
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblDev = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblToby = new System.Windows.Forms.Label();
            this.typingTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            this.lblInstructions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Pixel Operator HB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblInstructions.Location = new System.Drawing.Point(215, 271);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(340, 39);
            this.lblInstructions.TabIndex = 8;
            this.lblInstructions.Text = "Press \"C\" to exit..";
            // 
            // lblDev
            // 
            this.lblDev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDev.AutoSize = true;
            this.lblDev.Font = new System.Drawing.Font("Pixel Operator HB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDev.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDev.Location = new System.Drawing.Point(29, 199);
            this.lblDev.Name = "lblDev";
            this.lblDev.Size = new System.Drawing.Size(678, 39);
            this.lblDev.TabIndex = 7;
            this.lblDev.Text = "(Creator and Developer of Undertale)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // lblToby
            // 
            this.lblToby.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblToby.AutoSize = true;
            this.lblToby.Font = new System.Drawing.Font("Pixel Operator HB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToby.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblToby.Location = new System.Drawing.Point(13, 146);
            this.lblToby.Name = "lblToby";
            this.lblToby.Size = new System.Drawing.Size(709, 39);
            this.lblToby.TabIndex = 5;
            this.lblToby.Text = "This Application is inspired by TobyFox\r\n";
            // 
            // typingTimer
            // 
            this.typingTimer.Enabled = true;
            // 
            // frmDoggoDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblDev);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblToby);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDoggoDialogue";
            this.Text = "frmDoggoDialogue";
            this.Load += new System.EventHandler(this.frmDoggoDialogue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblDev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblToby;
        private System.Windows.Forms.Timer typingTimer;
    }
}