using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Final_Project___CGC_Sage
{
    public partial class IntroductionPanel1 : Form
    {
        private Timer fadeInTimer;
        public static SoundPlayer player;

        string fullText1 = "“I was running from another failed test, another disappointed look... ";
        int currentCharIndex = 0;
        string fullText2 = "and then, the ground gave way.”";
        int currentCharIndex2 = 0;
        string fullText3 = "Press \"Enter\" to Continue..";
        int currentCharIndex3 = 0;

        bool textComplete = false;

        public IntroductionPanel1()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            if (player == null)
            {
                try
                {
                    // Path to your WAV file
                    player = new SoundPlayer(@"C:\\Users\\gello\\source\\repos\\Final Project - CGC Sage\\Final Project - CGC Sage\\introsound.wav");
                    player.Load();  // Load the WAV file
                    player.PlayLooping(); // Play the sound in a loop
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading the sound file: " + ex.Message);
                }
            }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Music will continue to play until we stop it explicitly in IntroductionPanel5
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
            // Type out second line of text
            else if (currentCharIndex2 < fullText2.Length)
            {
                lblstring2.Text += fullText2[currentCharIndex2];
                currentCharIndex2++;
                anyTextLeft = true;
            }
            // Type out instruction for pressing Enter to continue
            else if (currentCharIndex3 < fullText3.Length)
            {
                lblinstruction.Text += fullText3[currentCharIndex3];
                currentCharIndex3++;
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
            lblstring2.Text = "";
            lblinstruction.Text = "";

            currentCharIndex = 0;
            currentCharIndex2 = 0;
            currentCharIndex3 = 0;

            typingTimer.Interval = 20;
            typingTimer.Tick += typingTimer_Tick; // Ensure it's only added once
            typingTimer.Start();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        /* Fade in transition
        private void StartFadeIn()
        {
            fadeInTimer = new Timer();
            fadeInTimer.Interval = 50; // milliseconds
            fadeInTimer.Tick += (s, e) =>
            {
                if (this.Opacity < 1.0)
                {
                    this.Opacity += 0.05;
                }
                else
                {
                    fadeInTimer.Stop();
                }
            };
            fadeInTimer.Start();
        }
        */
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // If Enter is pressed and text has not been completed, finish the typing
            if (e.KeyCode == Keys.Enter && !textComplete)
            {
                // Immediately show the rest of the text
                lblstring1.Text = fullText1;
                lblstring2.Text = fullText2;
                lblinstruction.Text = fullText3;

                // Stop the timer since the text is now fully displayed
                typingTimer.Stop();

                // Set textComplete to true so we can move on to the next form
                textComplete = true;
            }
            // If Enter is pressed and text is complete, proceed to the next form
            else if (e.KeyCode == Keys.Enter && textComplete)
            {
                IntroductionPanel2 Intro2 = new IntroductionPanel2();
                Intro2.Show();
                this.Hide();
            }
        }

        private void IntroductionPanel1_Load(object sender, EventArgs e)
        {
            StartTypingEffect();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
