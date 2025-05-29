using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Final_Project___CGC_Sage
{
    public partial class frmGameOver : Form
    {
        private string fullTextToType = "";

        private List<Image> heartFrames = new List<Image>();
        private int currentFrame = 0;
        private Timer heartTimer = new Timer();
        private SoundPlayer bgmPlayer;
        private Timer fadeTimer = new Timer();
        private Timer typingTimer = new Timer();  // Timer for typing effect
        private int alphaValue = 0;

        // For custom text fade
        private string fadeText = "GAME OVER";
        private Font fadeFont = FontManager.GetFont("Pixel Operator HB 8", 30, FontStyle.Bold);
        private Color fadeColor = Color.White;
        private Panel fadeTextPanel = new Panel();

        private string typingText = "Press Enter to Restart";  // Text for typing animation
        private int currentTypingIndex = 0;  // Track position for typing animation

        private string motivationalMessage = "Don't give up, stay determined.";
        private string scoreMessage = "";
        private string highscoreMessage = "";
        private int playerScore;
        private int playerHighscore;
        private bool isNewHighscore;
        private int messageStep = 0;

        private Label lblGameMessage = new Label();

        public frmGameOver(int score, int highscore, bool isHighscore)
        {
            InitializeComponent();
            lblContinue.Text = "";
            lblContinue.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            // Setup heartBox (assuming it's a PictureBox added via designer)
            heartBox.Size = new Size(200, 200);
            heartBox.Location = new Point(350, 400);
            heartBox.BackColor = Color.Transparent;

            // Setup heart animation timer
            heartTimer.Interval = 200;
            heartTimer.Tick += HeartTimer_Tick;

            // Setup fade text panel
            fadeTextPanel.Size = new Size(400, 100);
            fadeTextPanel.Location = new Point(570, 100); // Adjust to your form layout
            fadeTextPanel.BackColor = Color.Transparent;
            fadeTextPanel.Paint += FadeTextPanel_Paint;
            Controls.Add(fadeTextPanel);

            // Setup typing timer
            typingTimer.Interval = 100;  // Adjust speed of typing animation
            typingTimer.Tick += TypingTimer_Tick;

            playerScore = score;
            playerHighscore = highscore;
            isNewHighscore = isHighscore;


        }

        private void frmGameOver_Load(object sender, EventArgs e)
        {
            // Load all frames
            heartFrames = new List<Image>
            {
                Image.FromFile("Sprites/GameOver/Gameover1.png"),
                Image.FromFile("Sprites/GameOver/Gameover1 - Copy.png"),
                Image.FromFile("Sprites/GameOver/Gameover2.png"),
                Image.FromFile("Sprites/GameOver/Gameover3.png"),
                Image.FromFile("Sprites/GameOver/Gameover4.png"),
                Image.FromFile("Sprites/GameOver/Gameover5.png"),
                Image.FromFile("Sprites/GameOver/Gameover6.png"),
                Image.FromFile("Sprites/GameOver/Gameover7.png"),
                Image.FromFile("Sprites/GameOver/Gameover8.png"),
                Image.FromFile("Sprites/GameOver/Gameover9.png"),
                Image.FromFile("Sprites/GameOver/Gameover10.png"),
                Image.FromFile("Sprites/GameOver/Gameover11.png"),
                Image.FromFile("Sprites/GameOver/Gameover12.png"),
                Image.FromFile("Sprites/GameOver/Gameover13.png"),
                Image.FromFile("Sprites/GameOver/Gameover14.png"),
                Image.FromFile("Sprites/GameOver/Gameover15.png"),
                Image.FromFile("Sprites/GameOver/Gameover16.png"),
                Image.FromFile("Sprites/GameOver/Gameover17.png")
            };

            currentFrame = 0;
            heartTimer.Start();

            // Play initial sound
            SoundPlayer sfx = new SoundPlayer("C:\\Users\\gello\\Desktop\\MAIN BACKUP\\Final Project - CGC Sage\\Final Project - CGC Sage\\heartBreak.wav");
            sfx.Play();
        }

        private void HeartTimer_Tick(object sender, EventArgs e)
        {
            if (currentFrame < heartFrames.Count)
            {
                heartBox.Image = heartFrames[currentFrame];
                currentFrame++;
            }
            else
            {
                heartTimer.Stop();

                // Delay before BGM
                Timer bgmDelay = new Timer();
                bgmDelay.Interval = 1000;
                bgmDelay.Tick += (s, args) =>
                {
                    bgmDelay.Stop();
                    bgmPlayer = new SoundPlayer("C:\\Users\\gello\\Desktop\\MAIN BACKUP\\Final Project - CGC Sage\\Final Project - CGC Sage\\gameOverBGM.wav");
                    bgmPlayer.PlayLooping();
                };
                bgmDelay.Start();

                // Start fade-in of text
                fadeTimer.Interval = 100;
                fadeTimer.Tick += FadeTimer_Tick;
                fadeTimer.Start();
            }
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            if (alphaValue < 255)
            {
                alphaValue += 5;
                if (alphaValue > 255) alphaValue = 255;
                Console.WriteLine($"{alphaValue}");
                fadeTextPanel.Invalidate(); // Repaint with new alpha
            }
            else
            {
                fadeTimer.Stop();
                SetupGameMessageLabel();
                DisplayNextMessage();

            }
        }

        private void FadeTextPanel_Paint(object sender, PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(alphaValue, fadeColor)))
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                SizeF textSize = e.Graphics.MeasureString(fadeText, fadeFont);
                float x = (fadeTextPanel.Width - textSize.Width) / 2;
                float y = (fadeTextPanel.Height - textSize.Height) / 2;

                e.Graphics.DrawString(fadeText, fadeFont, brush, x, y);
            }
        }

        private void TypingTimer_Tick(object sender, EventArgs e)
        {
            if (currentTypingIndex < fullTextToType.Length)
            {
                lblGameMessage.Text += fullTextToType[currentTypingIndex];
                currentTypingIndex++;
            }
            else
            {
                typingTimer.Stop();
                lblContinue.Text = "Press Enter to continue";
                lblContinue.Visible = true;
            }
        }

        private void SetupGameMessageLabel()
        {
            lblGameMessage.Font = FontManager.GetFont("Pixel Operator HB", 20, FontStyle.Regular);
            lblGameMessage.ForeColor = Color.White;
            lblGameMessage.BackColor = Color.Transparent;
            lblGameMessage.AutoSize = true;
            lblGameMessage.Location = new Point(500, 250); // Adjust as needed
            lblGameMessage.Text = "";
            Controls.Add(lblGameMessage);


        }
        private void DisplayNextMessage()
        {
            if (alphaValue < 255) return;

            lblContinue.Text = "";  // Reset before typing
            currentTypingIndex = 0;

            switch (messageStep)
            {
                case 0:
                    fullTextToType = motivationalMessage;
                    break;
                case 1:
                    fullTextToType = $"Your Score: {playerScore}";
                    break;
                case 2:
                    fullTextToType = isNewHighscore
                        ? "New Highscore!"
                        : $"No new highscore. Current highscore: {playerHighscore}";
                    break;
                case 3:
                    fullTextToType = "Press Enter to Restart";
                    break;
                default:
                    RestartGame();  // Or close form / go to main menu
                    return;
            }

            lblGameMessage.Text = "";  // Clear previous text
            lblContinue.Visible = false;
            typingTimer.Start();
            messageStep++;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (typingTimer.Enabled)
                {
                    // If user presses Enter during typing, skip to full message
                    typingTimer.Stop();
                    lblGameMessage.Text = fullTextToType;
                    lblContinue.Text = "Press Enter to continue";
                    lblContinue.Visible = true;
                }
                else if (lblContinue.Visible)
                {
                    lblContinue.Visible = false;
                    lblContinue.Text = "";
                    DisplayNextMessage();
                }
                return true; // We handled the key
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void RestartGame()
        {
            bgmPlayer?.Stop();

            // Tell the caveMenu you’re returning from the typing game
            PlayerState.ReturningFromTypingGame = true;
            PlayerState.typingGuardX = 1020; // Or whatever position you want to return to
            PlayerState.typingGuardY = 375;

            this.DialogResult = DialogResult.OK;
            this.Close();

            caveMenu cave = new caveMenu();
            cave.Show();
        }
    }
}
