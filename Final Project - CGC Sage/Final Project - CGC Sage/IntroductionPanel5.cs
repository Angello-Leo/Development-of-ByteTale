using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Final_Project___CGC_Sage
{
    public partial class IntroductionPanel5 : Form
    {
        private Timer fadeOutTimer;
        private int enterPressCount = 0; // Counter for Enter presses

        string fullText1 = "“Maybe the way out wasn’t up or down. Maybe it was through me.”";
        int currentCharIndex = 0;
        string fullText2 = "Press \"Enter\" once or twice to Continue..";
        int currentCharIndex2 = 0;
        bool textComplete = false;

        public IntroductionPanel5()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.Opacity = 1.0; // Start visible
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void typingTimer_Tick(object sender, EventArgs e)
        {
            bool anyTextLeft = false;

            // Type out first line of text
            if (currentCharIndex < fullText1.Length)
            {
                lblstring1.Text += fullText1[currentCharIndex];
                currentCharIndex++;
                anyTextLeft = true;
            }

            // Type out instruction for pressing Enter to continue
            else if (currentCharIndex2 < fullText2.Length)
            {
                lblinstruction.Text += fullText2[currentCharIndex2];
                currentCharIndex2++;
                anyTextLeft = true;
            }

            // Once all text is typed, stop the timer and allow the user to proceed
            if (!anyTextLeft)
            {
                textComplete = true;
                typingTimer.Stop();
            }
        }

        private void StartTypingEffect()
        {
            lblstring1.Text = "";
            lblinstruction.Text = "";

            currentCharIndex = 0;
            currentCharIndex2 = 0;

            typingTimer = new Timer();
            typingTimer.Interval = 20; // Adjust typing speed here
            typingTimer.Tick += typingTimer_Tick;
            typingTimer.Start();
        }

        private void StartFadeOut()
        {
            fadeOutTimer = new Timer();
            fadeOutTimer.Interval = 50;
            fadeOutTimer.Tick += (s, e) =>
            {
                if (this.Opacity > 0.0)
                {
                    this.Opacity -= 0.05;
                }
                else
                {
                    fadeOutTimer.Stop();
                    this.Hide();
                    // Do not stop the music here; it will continue to play when moving to the next screen
                    TitleScreen Title = new TitleScreen();
                    Title.Show();
                }
            };
            fadeOutTimer.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                enterPressCount++; // Increment the counter on each Enter key press

                if (enterPressCount == 1 && !textComplete)
                {
                    // First Enter press, immediately show all the text
                    lblstring1.Text = fullText1;
                    lblinstruction.Text = fullText2;
                    textComplete = true;

                    typingTimer.Stop();
                }
                else if (enterPressCount == 2)
                {
                    // Second Enter press, proceed to the next form
                    StartFadeOut();
                }

                // After 2 Enter presses, disable further keypress actions
                if (enterPressCount >= 2)
                {
                    this.KeyDown -= Form1_KeyDown; // Remove the event handler to disable further key presses
                }
            }
        }

        private void IntroductionPanel5_Load(object sender, EventArgs e)
        {
            StartTypingEffect();
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblinstruction_Click(object sender, EventArgs e)
        {

        }
    }
}
