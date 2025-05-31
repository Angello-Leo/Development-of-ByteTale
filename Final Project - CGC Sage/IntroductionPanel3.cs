using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project___CGC_Sage
{
    public partial class IntroductionPanel3 : Form
    {
        string fullText1 = "“I didn’t know if it was real. But it knew me.”";
        int currentCharIndex = 0;
        string fullText2 = "Press \"Enter\" to Continue..";
        int currentCharIndex2 = 0;
        bool textComplete1 = false;
        bool textComplete2 = false;

        public IntroductionPanel3()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            label2.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(label2);
        }

        private void typingTimer_Tick(object sender, EventArgs e)
        {
            bool anyTextLeft = false;

            // Type out first line of text (fullText1)
            if (currentCharIndex < fullText1.Length)
            {
                lblstring1.Text += fullText1[currentCharIndex];
                currentCharIndex++;
                anyTextLeft = true;
            }

            // Once first text is completed, show the instruction text
            if (currentCharIndex == fullText1.Length && !textComplete1)
            {
                textComplete1 = true;
                lblinstruction.Text = fullText2; // Show the instruction text after fullText1
                textComplete2 = true; // Mark instruction as complete
            }

            // Stop the timer when there is no text left to type
            if (!anyTextLeft)
            {
                typingTimer.Stop();
            }
        }

        private void StartTypingEffect()
        {
            lblstring1.Text = "";  // Clear any previous text
            lblinstruction.Text = "";  // Clear instruction text

            currentCharIndex = 0;
            currentCharIndex2 = 0;
            typingTimer.Interval = 20;  // Set typing interval
            typingTimer.Tick += typingTimer_Tick;  // Add typing effect event handler
            typingTimer.Start();  // Start typing the text
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // If Enter is pressed and both text and instruction are complete, move to next form
            if (e.KeyCode == Keys.Enter && textComplete1 && textComplete2)
            {
                IntroductionPanel4 Intro4 = new IntroductionPanel4();
                Intro4.Show();
                this.Hide();
            }
            // If Enter is pressed after fullText1 is typed but before fullText2 is typed
            else if (e.KeyCode == Keys.Enter && textComplete1 && !textComplete2)
            {
                lblinstruction.Text = fullText2;  // Immediately show the instruction text
                textComplete2 = true;  // Mark instruction text as complete
            }
            // If Enter is pressed before fullText1 is fully typed, complete typing
            else if (e.KeyCode == Keys.Enter && !textComplete1)
            {
                lblstring1.Text = fullText1;  // Show the fullText1 immediately
                textComplete1 = true;

                // If instruction is not yet shown, show it
                if (!textComplete2)
                {
                    lblinstruction.Text = fullText2;
                    textComplete2 = true;
                }

                typingTimer.Stop();  // Stop the timer once the text is fully displayed
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void IntroductionPanel3_Load(object sender, EventArgs e)
        {
            StartTypingEffect();  // Start typing effect when the form loads
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Custom painting logic, if any, goes here
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Handle label2 click event if necessary
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Handle pictureBox1 click event if necessary
        }
    }
}
