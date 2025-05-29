namespace Final_Project___CGC_Sage
{
    partial class Game
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
            this.spawnTimer = new System.Windows.Forms.Timer(this.components);
            this.fallTimer = new System.Windows.Forms.Timer(this.components);
            this.gamePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // spawnTimer
            // 
            this.spawnTimer.Interval = 500;
            this.spawnTimer.Tick += new System.EventHandler(this.spawnTimer_Tick);
            // 
            // fallTimer
            // 
            this.fallTimer.Tick += new System.EventHandler(this.fallTimer_Tick_1);
            // 
            // gamePanel
            // 
            this.gamePanel.BackgroundImage = global::Final_Project___CGC_Sage.Properties.Resources.Cave;
            this.gamePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gamePanel.Location = new System.Drawing.Point(181, 0);
            this.gamePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(351, 358);
            this.gamePanel.TabIndex = 0;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gamePanel_Paint);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.gamePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Game";
            this.Text = "TypingGame";
            this.Load += new System.EventHandler(this.TypingGame_Load);
            this.Shown += new System.EventHandler(this.Game_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Game_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer spawnTimer;
        private System.Windows.Forms.Timer fallTimer;
        private System.Windows.Forms.Panel gamePanel;
    }
}