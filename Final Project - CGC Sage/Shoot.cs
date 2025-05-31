using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project___CGC_Sage
{
    public class Shoot : PictureBox
    {
        private Timer shootTimer;
        private Point target;
        private Player player;
        private Panel gamePanel;
        private float speed = 10f;
        public Shoot(Panel _gamePanel, Player _player, Point _target)
        {
            gamePanel = _gamePanel;
            player = _player;
            target = _target;


            this.BackColor = Color.Yellow;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Size = new Size(8, 8);
            this.Location = new Point(player.Left + player.Width / 2 - this.Width / 2, player.Top + player.Height / 2 - this.Height / 2);
            this.BringToFront();
            this.Parent = gamePanel;
            this.TabStop = false;
            gamePanel.Controls.Add(this);

            shootTimer = new Timer();
            shootTimer.Interval = 1;
            shootTimer.Tick += aimTarget;
            shootTimer.Start();
        }

        private void aimTarget(object sender, EventArgs e)
        {
            // Calculate direction
            float dx = target.X - (this.Left + this.Width / 2);
            float dy = target.Y - (this.Top + this.Height / 2);
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance < speed)
            {
                shootTimer.Stop();
                shootTimer.Dispose();
                gamePanel.Controls.Remove(this);
                this.Dispose();
                // You can trigger enemy hit logic here too if needed
            }
            else
            {
                // Move bullet towards target
                this.Left += (int)(dx / distance * speed);
                this.Top += (int)(dy / distance * speed);
            }
        }
    }
}
