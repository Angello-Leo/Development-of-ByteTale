using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project___CGC_Sage
{
    public class CreateEnemy : Label
    {
        Random rand = new Random();
        Panel game;
        public string word;
        int typeIndex = 0;
        public bool TrackPlayer { get; set; }
        public bool Debris { get; set; }
        public Point MovementDirection { get; set; } = new Point(0, 3);

        public PictureEnemy AttachedPicture { get; set; }  
        public CreateEnemy(Panel gamePanel, string _word, PictureEnemy attachedPicture)
        {
            game = gamePanel;
            word = _word;
            AttachedPicture = attachedPicture;

            this.Text = word;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.White;
            this.BorderStyle = BorderStyle.None;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.AutoSize = true;
            this.Font = FontManager.GetFont("Pixel Operator HB 8", 8, FontStyle.Bold);
            this.Location = new Point(AttachedPicture.Left, AttachedPicture.Bottom);
            game.Controls.Add(this);
        }

        public char GetNextLetter()
        {
            return word[typeIndex];
        }

        public void RemoveLetter()
        {
            if (typeIndex < word.Length)
            {
                typeIndex++;
                UpdateDisplay();
            }
        }

        public bool Typed()
        {
            return typeIndex >= word.Length;
        }

        private void UpdateDisplay()
        {
            // Update label text based on typeIndex
            if (typeIndex < word.Length)
                this.Text = word.Substring(typeIndex);
            else
                this.Text = "";
            this.Refresh();
        }
        public Point GetNextLetterPosition()
        {
            int charIndex = typeIndex; // however you track the next letter index
            int charWidth = 12; // approximate width of each character (adjust as needed)

            return new Point(this.Left + charWidth * charIndex, this.Top + this.Height / 2);
        }

    }

}
