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
    public partial class IntroductionPanel4 : Form
    {
        string fullText1 = "“The cave doesn’t want me trapped. It wants me to choose.”";
        int currentCharIndex = 0;
        string fullText2 = "Press \"Enter\" to Continue..";
        int currentCharIndex2 = 0;
        bool textComplete1 = false;
        bool textComplete2 = false;

        public IntroductionPanel4()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Custom painting logic, if any, goes here
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle Enter key when both text and instruction are complete
            if (e.KeyCode == Keys.Enter && textComplete1 && textComplete2)
            {
                IntroductionPanel5 Intro5 = new IntroductionPanel5();
                Intro5.Show();
                this.Hide();
            }
            // If Enter is pressed after first text is typed but before instruction
            else if (e.KeyCode == Keys.Enter && textComplete1 && !textComplete2)
            {
                lblinstruction.Text = fullText2; // Show instruction text immediately
                textComplete2 = true;
            }
            // If Enter is pressed before first text is fully typed, complete typing
            else if (e.KeyCode == Keys.Enter && !textComplete1)
            {
                lblstring1.Text = fullText1; // Show the full first text immediately
                textComplete1 = true;

                // If instruction is not shown, show it
                if (!textComplete2)
                {
                    lblinstruction.Text = fullText2;
                    textComplete2 = true;
                }

                typingTimer.Stop(); // Stop the timer once text is fully displayed
            }
        }

        private void typingTimer_Tick(object sender, EventArgs e)
        {
            bool anyTextLeft = false;

            // Type out the first line of text (fullText1)
            if (currentCharIndex < fullText1.Length)
            {
                lblstring1.Text += fullText1[currentCharIndex];
                currentCharIndex++;
                anyTextLeft = true;
            }

            // Once fullText1 is completed, show the instruction text
            if (currentCharIndex == fullText1.Length && !textComplete1)
            {
                textComplete1 = true;
                lblinstruction.Text = fullText2; // Show instruction text after first text
                textComplete2 = true; // Mark instruction text as complete
            }

            // Stop the timer when no more text is left to type
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
            typingTimer.Interval = 20;  // Set the typing interval
            typingTimer.Tick += typingTimer_Tick;  // Add event handler for typing effect
            typingTimer.Start();  // Start typing the text
        }

        private void IntroductionPanel4_Load(object sender, EventArgs e)
        {
            StartTypingEffect();  // Start the typing effect when the form loads
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            // Custom painting logic, if any, goes here
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Handle label5 click event if necessary
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Handle label4 click event if necessary
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Handle pictureBox1 click event if necessary
        }
    }
}
