using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Final_Project___CGC_Sage
{
    public class PictureEnemy : PictureBox
    {
        Random rand = new Random();
        Panel game;
        public PictureEnemy(Panel _game, Point location)
        {
            game = _game;
            // Picture Box Attached
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Size = new Size(45, 45);
            this.Location = new Point(rand.Next(0, game.Width - this.Width), 0);
            game.Controls.Add(this);
        }

        public void ChangePicture(string word)
        {
            if (word.Length == 1)
            {
                this.Image = Properties.Resources.Peble1;
            }
            else if (word.Length >= 2 && word.Length <= 3)
            {
                if (word.Length == 2)
                {
                    this.Image = Properties.Resources.StalactiteSmall;
                }
                else if (word.Length == 3)
                {
                    this.Image = Properties.Resources.StalactiteBig;
                }
            }
            else if (word.Length >= 4 && word.Length <= 6)
            {
                if (word.Length == 4)
                {
                    this.Image = Properties.Resources.Peble2;
                }
                else if (word.Length == 5)
                {
                    this.Image = Properties.Resources.Stone2;
                }
                else if (word.Length == 6)
                {
                    this.Image = Properties.Resources.Boulder1;
                }
            }
            else if (word.Length >= 7)
            {
                if (word.Length >= 7 && word.Length <= 8)
                {
                    this.Image = Properties.Resources.Rock1;
                }
                else
                {
                    this.Image = Properties.Resources.Rock2;
                }
                this.Size = new Size(80, 80);
            }
            this.Refresh();
        }
    }
}
