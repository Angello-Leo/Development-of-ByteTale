using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project___CGC_Sage
{
    public class MultiplierBar : ProgressBar
    {
        private bool ultimateReady = false;
        private Panel gamePanel;
        private Label ultimateReadyLabel;
        private Timer typingTimer;
        private string fullText = "ULTIMATE READY";
        private int currentCharIndex = 0;

        private Timer delayTimer; // delay timer for timing with the sound

        private WaveOutEvent ultimateSoundPlayer;
        private AudioFileReader ultimateAudioReader;
        private string ultimateReadySoundPath = Path.Combine(Application.StartupPath, "Resources", "UltimateReadySound.wav");
        private bool hasPlayedUltimateSound = false;

        private Label pressSpaceLabel;
        private Timer blinkTimer;

        public MultiplierBar(Panel _gamePanel)
        {
            gamePanel = _gamePanel;

            this.Width = 200;
            this.BackColor = Color.Gold;
            this.Height = 10;
            this.Dock = DockStyle.Bottom;
            this.Maximum = 45
                ; // 60 if not debbuging
            this.Value = 0;
            this.Style = ProgressBarStyle.Continuous;
            this.TabStop = false;

            gamePanel.Controls.Add(this);
            this.BringToFront();

            ultimateReadyLabel = new Label
            {
                Text = "",
                ForeColor = Color.Gold,
                Font = FontManager.GetFont("Pixel Operator HB 8", 15, FontStyle.Bold),
                AutoSize = true,
                Visible = false,
                BackColor = Color.Transparent
            };

            gamePanel.Controls.Add(ultimateReadyLabel);
            ultimateReadyLabel.BringToFront();

            //Delay for timing with sound
            delayTimer = new Timer();
            delayTimer.Interval = 3000; // 5 seconds
            delayTimer.Tick += DelayTimer_Tick;
            //Typing animation
            typingTimer = new Timer();
            typingTimer.Interval = 200; 
            typingTimer.Tick += TypingTimer_Tick;

            //Label for Instructions
            pressSpaceLabel = new Label
            {
                Text = "Press SPACEBAR to use ultimate",
                ForeColor = Color.White,
                Font = FontManager.GetFont("Pixel Operator HB 8", 12, FontStyle.Bold),
                AutoSize = true,
                Visible = false,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };

            gamePanel.Controls.Add(pressSpaceLabel);
            pressSpaceLabel.BringToFront();

            // Setup blink timer
            blinkTimer = new Timer();
            blinkTimer.Interval = 500; // Blink every 500ms
            blinkTimer.Tick += BlinkTimer_Tick;

            // Preloading audio 
            if (File.Exists(ultimateReadySoundPath))
            {
                ultimateAudioReader = new AudioFileReader(ultimateReadySoundPath);
                ultimateSoundPlayer = new WaveOutEvent();
                ultimateSoundPlayer.Init(ultimateAudioReader);
            }
        }

        public void TrackMultiplierScores(int gauge, bool specialUsed)
        {
            if (specialUsed)
            {
                ResetAfterUltimate();
                return;
            }

            if (!ultimateReady)
            {
                if (gauge < this.Maximum)
                {
                    this.Value = gauge;
                }
                else if (gauge >= this.Maximum)
                {
                    this.Value = this.Maximum;
                    ultimateReady = true;

                    ultimateReadyLabel.Text = "";
                    ultimateReadyLabel.Visible = true;
                    ultimateReadyLabel.Location = new Point(
                        this.Left + (this.Width - ultimateReadyLabel.Width) / 2,
                        this.Top - ultimateReadyLabel.Height - 5
                    );

                    currentCharIndex = 0;
                    delayTimer.Stop();
                    delayTimer.Start();
                    PlayUltimateReadySound();
                }
            }
        }



        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            delayTimer.Stop();

            currentCharIndex = 0;
            typingTimer.Start();
        }

        private void TypingTimer_Tick(object sender, EventArgs e)
        {
            if (currentCharIndex < fullText.Length)
            {
                ultimateReadyLabel.Text += fullText[currentCharIndex];
                currentCharIndex++;

                // Reposition in case width changed
                ultimateReadyLabel.Location = new Point(
                    this.Left + (this.Width - ultimateReadyLabel.Width) / 2,
                    this.Top - ultimateReadyLabel.Height - 5
                );
            }
            else
            {
                typingTimer.Stop();

                // Position of the instruction
                pressSpaceLabel.Location = new Point(
                    this.Left + (this.Width - pressSpaceLabel.Width) / 2,
                    ultimateReadyLabel.Top - pressSpaceLabel.Height - 5
                );

                pressSpaceLabel.Visible = true;
                blinkTimer.Start();
            }
        }
        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            pressSpaceLabel.Visible = !pressSpaceLabel.Visible;
        }

        private void PlayUltimateReadySound()
        {
            try
            {
                if (ultimateSoundPlayer != null)
                {
                    ultimateAudioReader.Position = 0; // rewind to start
                    ultimateSoundPlayer.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing sound: " + ex.Message);
            }


        }

        public void ResetAfterUltimate()
        {
            this.Value = 0;
            ultimateReady = false;

            delayTimer.Stop();
            typingTimer.Stop();
            blinkTimer.Stop();

            ultimateReadyLabel.Visible = false;
            ultimateReadyLabel.Text = ""; // Important: Clear label content
            pressSpaceLabel.Visible = false;
        }
    }
}
