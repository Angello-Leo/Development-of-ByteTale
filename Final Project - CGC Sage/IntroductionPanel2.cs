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
    public partial class IntroductionPanel2 : Form
    {
        string fullText1 = "“Down here, everything echoes. My footsteps. My doubts.”";
        int currentCharIndex = 0;
        string fullText2 = "Press \"Enter\" to Continue..";
        int currentCharIndex2 = 0;
        bool textComplete1 = false;
        bool textComplete2 = false;

        public IntroductionPanel2()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // If Enter is pressed and text is complete, proceed to next form
            if (e.KeyCode == Keys.Enter && textComplete1 && textComplete2)
            {
                IntroductionPanel3 Intro3 = new IntroductionPanel3();
                Intro3.Show();
                this.Hide();
            }
            // If Enter is pressed and first text is complete, show instruction text
            else if (e.KeyCode == Keys.Enter && textComplete1 && !textComplete2)
            {
                lblinstruction.Text = fullText2;  // Display the instruction
                textComplete2 = true;
            }
            // If Enter is pressed and first text isn't complete, finish typing it
            else if (e.KeyCode == Keys.Enter && !textComplete1)
            {
                lblstring1.Text = fullText1;  // Display full text immediately
                textComplete1 = true;

                // Automatically show instruction text if not already shown
                if (!textComplete2)
                {
                    lblinstruction.Text = fullText2;
                    textComplete2 = true;
                }

                typingTimer.Stop();  // Stop the typing timer once all text is displayed
            }
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
                lblinstruction.Text = fullText2;  // Display instruction text
                textComplete2 = true;
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
            lblinstruction.Text = "";  // Clear the instruction text

            currentCharIndex = 0;
            currentCharIndex2 = 0;
            typingTimer.Interval = 20;  // Set the typing interval
            typingTimer.Tick += typingTimer_Tick;  // Add the typing effect event handler
            typingTimer.Start();  // Start typing
        }

        private void IntroductionPanel2_Load(object sender, EventArgs e)
        {
            StartTypingEffect();  // Start the typing effect when the form loads
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // You can add any custom painting logic here if necessary
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Handle label1 click event if necessary
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
