using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project___CGC_Sage
{
    public class Player : PictureBox
    {
        Panel gamePanel;
        public Player(Panel _gamePanel)
        {
            gamePanel = _gamePanel;

            this.BackColor = Color.Transparent;
            this.Image = Properties.Resources.Player;
            this.Location = new Point(gamePanel.Width / 2 - 5, gamePanel.Height - 5);
            this.Parent = gamePanel;
            this.Size = new Size(60, 60);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.TabStop = false;
            gamePanel.Controls.Add(this);
        }
        public void RotateTowards(Point target)
        {
            // Center of the player control
            float playerCenterX = this.Left + this.Width / 2;
            float playerCenterY = this.Top + this.Height / 2;

            // Target point relative to player center
            float dx = target.X - playerCenterX;
            float dy = target.Y - playerCenterY;

            // Calculate angle in degrees (Atan2 returns in radians, convert to degrees)
            double angle = Math.Atan2(dy, dx) * (180 / Math.PI);

            // If your player sprite faces up by default and you want to correct for it, subtract 90°
            angle += 90;

            // Rotate the player image
            this.Image = RotateImage(Properties.Resources.Player, (float)angle);
            this.Refresh();
        }

        private Bitmap RotateImage(Image img, float rotationAngle)
        {
            // New bitmap to hold rotated image
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TranslateTransform((float)img.Width / 2, (float)img.Height / 2);
                g.RotateTransform(rotationAngle);
                g.TranslateTransform(-(float)img.Width / 2, -(float)img.Height / 2);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, new Point(0, 0));
            }

            return bmp;
        }


    }
}
    

