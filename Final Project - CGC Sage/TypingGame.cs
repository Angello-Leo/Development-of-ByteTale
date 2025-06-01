using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Final_Project___CGC_Sage
{
    public partial class Game : Form
    {
        string encconstring = "yONu9LKbdAh6y11QkhjHWg454/GtKyEL+80njGSLgV7kdSfxb0ubTtP2TSxI/r51BordTEAGk/dMIz+6bAHE40vptOn9vqcaVPF15lCNb2w=";
        private string currentUsername;
        private bool isGameOver = false;
        CachedSound shootSound;
        CachedSound misstypeSound;
        CachedSound regularCrashSound;
        CachedSound bigCrashSound;
        CachedSoundPlayer soundPlayer;

        Random rand = new Random(); // INITIALIZE RANDOM NUMBER GENERATOR   
        double multiplier = 0.05;
        int gauge = 0;
        public Player player;

        // Main Tools
        public List<CreateEnemy> words = new List<CreateEnemy>();
        public bool hasActiveEnemy;
        public CreateEnemy activeEnemy;
        public SoundPlayer BgMusic;
        public MultiplierBar multiplierBar;

        // Wave Difficulty & Settings
        int normalEnemies = 2;
        int norm;
        int normalEnemies2 = 2;
        int norm2;
        int eliteEnemies = 0;
        int elite;
        int eliteEnemies2 = 0;
        int elite2;
        int waveNum = 1;

        // Otherss
        string userInput = "";
        int scores;
        int plusScore;
        int currentEnemies = 0;
        bool specialAttacks = false;    

        public Game(string username)
        {
            InitializeComponent();
            currentUsername = username;
            //Set Current Enemies for spawnTimer
            norm = normalEnemies;
            norm2 = normalEnemies2;

            // Set Form Properties
            this.WindowState = FormWindowState.Maximized;
            this.Resize += new EventHandler(Game_Resize);
            soundPlayer = new CachedSoundPlayer();

            // Load shoot sound
            using (var shootStream = Properties.Resources.shoot)
            {
                shootStream.Position = 0;
                byte[] shootBytes = new byte[shootStream.Length];
                shootStream.Read(shootBytes, 0, (int)shootStream.Length);
                shootSound = new CachedSound(shootBytes);
            }

            // Load misstype sound
            using (var misstypeStream = Properties.Resources.MistypeSound)
            {
                byte[] misstypeBytes = new byte[misstypeStream.Length];
                misstypeStream.Read(misstypeBytes, 0, (int)misstypeStream.Length);
                misstypeSound = new CachedSound(misstypeBytes);
            }

            // Load regular crash sound
            using (var regularCrashStream = Properties.Resources.RegularandSmallRockExplosion)
            {
                byte[] regularCrashBytes = new byte[regularCrashStream.Length];
                regularCrashStream.Read(regularCrashBytes, 0, (int)regularCrashStream.Length);
                regularCrashSound = new CachedSound(regularCrashBytes);
            }

            // Load big crash sound
            using (var bigCrashStream = Properties.Resources.BigRockExplosion)
            {
                byte[] bigCrashBytes = new byte[bigCrashStream.Length];
                bigCrashStream.Read(bigCrashBytes, 0, (int)bigCrashStream.Length);
                bigCrashSound = new CachedSound(bigCrashBytes);
            }
        }

        private void TypingGame_Load(object sender, EventArgs e)
        {
            gamePanel.Size = new Size(800, 600);
            player = new Player(gamePanel);
            CenterGamePanel();
            multiplierBar = new MultiplierBar(gamePanel);
            BgMusic = new SoundPlayer(Properties.Resources.BGM);
            BgMusic.PlayLooping();

            // Double Buffered
            typeof(Panel).InvokeMember("DoubleBuffered",
            System.Reflection.BindingFlags.SetProperty |
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic,
            null, gamePanel, new object[] { true });
        }
        private void Game_Resize(object sender, EventArgs e)
        {
            CenterGamePanel();
        }
        private void CenterGamePanel()
        {
            int x = (this.ClientSize.Width - gamePanel.Width) / 2;
            int y = 0;
            gamePanel.Location = new Point(x, y);
            gamePanel.Height = this.ClientSize.Height;
        }
        private void spawnTimer_Tick(object sender, EventArgs e)
        {
            List<string> rocks = new List<string>();
            int maxWordsOnScreen = normalEnemies + normalEnemies2 + eliteEnemies + eliteEnemies2;
            if (norm != 0)
            {
                rocks.Add("normalEnemies");
            }
            if (norm2 != 0)
            {
                rocks.Add("normalEnemies2");
            }
            if (elite != 0)
            {
                rocks.Add("eliteEnemies");
            }
            if (elite2 != 0)
            {
                rocks.Add("eliteEnemies2");
            }
            Point spawnPoint = new Point(rand.Next(0, gamePanel.Width - 50), 0);
            int index = rand.Next(0, rocks.Count);

            if (index == rocks.FindIndex(x => x == "normalEnemies"))
            {
                string word = WordGenerator.GetNewNorm();
                PictureEnemy pictureEnemy = new PictureEnemy(gamePanel, spawnPoint);
                pictureEnemy.ChangePicture(word);
                CreateEnemy lblenemy = new CreateEnemy(gamePanel, word, pictureEnemy);
                words.Add(lblenemy);
                currentEnemies++;
                norm--;
            }
            else if (index == rocks.FindIndex(x => x == "normalEnemies2"))
            {
                string word = WordGenerator.GetNewNorm2();
                PictureEnemy pictureEnemy = new PictureEnemy(gamePanel, spawnPoint);
                pictureEnemy.ChangePicture(word);
                CreateEnemy lblenemy = new CreateEnemy(gamePanel, word, pictureEnemy);
                lblenemy.TrackPlayer = true;
                words.Add(lblenemy);
                currentEnemies++;
                norm2--;
            }
            else if (index == rocks.FindIndex(x => x == "eliteEnemies"))
            {
                string word = WordGenerator.GetNewElite();
                PictureEnemy pictureEnemy = new PictureEnemy(gamePanel, spawnPoint);
                pictureEnemy.ChangePicture(word);
                CreateEnemy lblenemy = new CreateEnemy(gamePanel, word, pictureEnemy);
                words.Add(lblenemy);
                lblenemy.Debris = true;
                currentEnemies++;
                elite--;
            }
            else if (index == rocks.FindIndex(x => x == "eliteEnemies2"))
            {
                string word = WordGenerator.GetNewElite2();
                PictureEnemy pictureEnemy = new PictureEnemy(gamePanel, spawnPoint);
                pictureEnemy.ChangePicture(word);
                CreateEnemy lblenemy = new CreateEnemy(gamePanel, word, pictureEnemy);
                lblenemy.TrackPlayer = true;
                words.Add(lblenemy);
                lblenemy.Debris = true;
                currentEnemies++;
                elite2--;
            }
            if (currentEnemies >= maxWordsOnScreen)
            {
                spawnTimer.Stop();
                return;
            }
        }
        private void Game_Shown(object sender, EventArgs e)
        {
            spawnTimer.Start();
            fallTimer.Start();
        }

        private void fallTimer_Tick_1(object sender, EventArgs e)
        {
            var toRemove = new List<CreateEnemy>();

            foreach (CreateEnemy word in gamePanel.Controls.OfType<CreateEnemy>())
            {
                if (word.TrackPlayer == true)
                {
                    // Move vertically
                    word.Top += 4;
                    word.AttachedPicture.Top += 4;

                    // Track player horizontally
                    if (word.Left < player.Left)
                    {
                        word.Left += 2;
                        word.AttachedPicture.Left += 2;
                    }
                    else if (word.Left > player.Left)
                    {
                        word.Left -= 2;
                        word.AttachedPicture.Left -= 2;
                    }
                }
                else
                {
                    // Use MovementDirection for debris and non-tracking enemies
                    word.Left += word.MovementDirection.X;
                    word.Top += word.MovementDirection.Y;
                    word.AttachedPicture.Left += word.MovementDirection.X;
                    word.AttachedPicture.Top += word.MovementDirection.Y;
                }
                // Check collision with player
                if (word.Bounds.IntersectsWith(player.Bounds)) // if Game Overr
                {
                    GameOver();
                }

                if (word.Top > gamePanel.Height)
                {
                    toRemove.Add(word);
                }
            }

            foreach (var word in toRemove)
            {
                gamePanel.Controls.Remove(word.AttachedPicture);
                word.AttachedPicture.Dispose();
                gamePanel.Controls.Remove(word);
                word.Dispose();
                words.Remove(word);
                if (gamePanel.Controls.OfType<CreateEnemy>().Count() == 0)
                {
                    fallTimer.Stop();
                    WaveClear();
                }
            }
        }
        void WaveClear()
        {
            // Wave Level
            Label lblWave = new Label();
            Label lblScore = new Label();
            lblWave.Text = "Wave " + waveNum.ToString() + " Cleared";
            lblWave.BackColor = System.Drawing.Color.Transparent;
            lblWave.ForeColor = System.Drawing.Color.Green;
            lblWave.BorderStyle = BorderStyle.None;
            lblWave.TextAlign = ContentAlignment.MiddleLeft;
            lblWave.Location = new Point(10, (gamePanel.Height - lblWave.Height) / 2 - 2);
            lblWave.AutoSize = true;
            lblWave.Font = new Font("Arial", 35, FontStyle.Bold);
            gamePanel.Controls.Add(lblWave);

            // Show scores
            lblScore.Text = "Score: " + scores;
            lblScore.BackColor = System.Drawing.Color.Transparent;
            lblScore.ForeColor = System.Drawing.Color.Green;
            lblScore.BorderStyle = BorderStyle.None;
            lblScore.TextAlign = ContentAlignment.MiddleLeft;
            lblScore.Location = new Point(10, (gamePanel.Height - lblScore.Height) / 2 + 50);
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Arial", 25, FontStyle.Bold);
            gamePanel.Controls.Add(lblScore);

            // Remove after 5 secs
            Timer messageTimer = new Timer();
            messageTimer.Interval = 5000;
            messageTimer.Tick += (s, e) =>
            {
                gamePanel.Controls.Remove(lblWave);
                lblWave.Dispose();
                gamePanel.Controls.Remove(lblScore);
                lblScore.Dispose();
                messageTimer.Stop();
                messageTimer.Dispose();

                // Change Difficulty
                if (waveNum == 1)
                {
                    normalEnemies += 1;
                    normalEnemies2 += 1;
                }
                else if (waveNum == 2)
                {
                    normalEnemies += 2;
                    normalEnemies2 += 2;
                }
                else if (waveNum == 3)
                {
                    normalEnemies = +2;
                    normalEnemies2 += 2;
                }
                else if (waveNum == 4)
                {
                    normalEnemies = +3;
                    eliteEnemies += 1;
                    eliteEnemies2 += 1;
                }
                else if (waveNum == 5)
                {
                    normalEnemies =+ 2;
                    eliteEnemies += 1;
                    eliteEnemies2 += 1;
                }
                else
                {
                    normalEnemies += 2;
                    normalEnemies2 += 2;
                    eliteEnemies += 1;
                    eliteEnemies2 += 1;
                }
                waveNum++;
                currentEnemies = 0;
                norm = normalEnemies;
                norm2 = normalEnemies2;
                elite = eliteEnemies;
                elite = eliteEnemies2;
                spawnTimer.Start();
                fallTimer.Start();
            };
            messageTimer.Start();
            SaveScoreToDatabase(scores);
        }

        private void Game_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space && multiplierBar.Value == multiplierBar.Maximum)
            {
                SpecialAttack();
            }
            char userPress = e.KeyChar;
            userInput += userPress;
            Letter(userPress); // Input Settings
        }
        public void Letter(char letter)
        {
            if (hasActiveEnemy)
            {
                if (activeEnemy.GetNextLetter() == letter)
                {
                    activeEnemy.RemoveLetter();
                    activeEnemy.BringToFront();
                    activeEnemy.ForeColor = System.Drawing.Color.Red;

                    activeEnemy.BringToFront();
                    activeEnemy.AttachedPicture.BringToFront();

                    player.RotateTowards(activeEnemy.Location);
                    FireBullet();
                    multiplier += 0.1;
                    gauge++;
                    multiplierBar.TrackMultiplierScores(gauge, specialAttacks);
                    PlayShootSound();
                }
                else
                {
                    PlayMisstypedSound();
                    multiplier = 0.1;
                    if (multiplierBar.Value == multiplierBar.Maximum)
                    {
                        return;
                    }
                    else
                    {
                        gauge = 0;
                        multiplierBar.TrackMultiplierScores(gauge, specialAttacks);
                    }
                }
            }
            else
            {
                bool foundMatch = false;
                foreach (CreateEnemy word in words)
                {
                    if (word.GetNextLetter() == letter)
                    {
                        activeEnemy = word;
                        hasActiveEnemy = true;
                        activeEnemy.RemoveLetter();
                        activeEnemy.ForeColor = System.Drawing.Color.Red;

                        activeEnemy.BringToFront();
                        activeEnemy.AttachedPicture.BringToFront();

                        player.RotateTowards(activeEnemy.Location);
                        FireBullet();
                        PlayShootSound();
                        foundMatch = true;
                        break;
                    }
                }

                if (!foundMatch)
                {
                    PlayMisstypedSound();
                    multiplier = 0.1;
                    if (multiplierBar.Value == multiplierBar.Maximum)
                    {
                        return;
                    }
                    else
                    {
                        gauge = 0;
                        multiplierBar.TrackMultiplierScores(gauge, specialAttacks);
                    }
                }
            }

            if (hasActiveEnemy && activeEnemy.Typed()) // If typed
            {
                // If it has debris
                if (activeEnemy.Debris)
                {
                    Debris(activeEnemy.Location);
                }
                if (activeEnemy.word.Length == 1 && activeEnemy.Typed())
                {
                    multiplier += 0.1;
                    gauge++;
                    multiplierBar.TrackMultiplierScores(gauge, specialAttacks);
                }

                EnemyScore();

                hasActiveEnemy = false;
                words.Remove(activeEnemy);

                gamePanel.Controls.Remove(activeEnemy.AttachedPicture);
                activeEnemy.AttachedPicture.Dispose();

                gamePanel.Controls.Remove(activeEnemy);
                activeEnemy.Dispose();

                userInput = "";

                if (gamePanel.Controls.OfType<CreateEnemy>().Count() == 0)
                {
                    fallTimer.Stop();
                    WaveClear();
                }
            }
        }
        public void FireBullet()
        {
            if (hasActiveEnemy)
            {
                Point targetPos = activeEnemy.GetNextLetterPosition();
                Shoot bullet = new Shoot(gamePanel, player, targetPos);
            }
        }
        public void PlayShootSound()
        {
            soundPlayer.PlaySound(shootSound);
        }
        public void PlayMisstypedSound()
        {
            soundPlayer.PlaySound(misstypeSound);
        }
        public int MultiplyScore(int score, double multiplier, int plusScore)
        {
            double add = Math.Round((plusScore * multiplier), 0);
            int newScore = score + (int)add;
            return newScore;
        }

        public void SpecialAttack()
        {
            specialAttacks = true;
            SpecialScore();
            multiplierBar.TrackMultiplierScores(gauge, specialAttacks);
            gauge = 0;
            SpecialAttack specialAttack = new SpecialAttack(gamePanel, words, player, () =>
            {
                if (gamePanel.Controls.OfType<CreateEnemy>().Count() == 0)
                {
                    fallTimer.Stop();
                    WaveClear();
                }
                gauge = 0;
                specialAttacks = false;
                multiplierBar.ResetAfterUltimate();
            });
            specialAttack.Activate();
            
        }
        private void Debris(Point location)
        {
            Random rand = new Random();
            List<Point> directions = new List<Point>
            {
                new Point(-3, 3),  // Left-down
                new Point(-1, 4),  // Slight left-down
                new Point(0, 5),   // Straight down
                new Point(1, 4),   // Slight right-down
                new Point(3, 3)    // Right-down
            };

            foreach (var dir in directions)
            {
                string debrisWord = WordGenerator.GetNewDebris();

                PictureEnemy debrisPicture = new PictureEnemy(gamePanel, location);
                debrisPicture.ChangePicture(debrisWord);
                debrisPicture.Location = location;

                CreateEnemy debrisEnemy = new CreateEnemy(gamePanel, debrisWord, debrisPicture)
                {
                    MovementDirection = dir  // Assign each its own direction
                };

                debrisEnemy.Location = new Point(debrisPicture.Left, debrisPicture.Bottom);
                gamePanel.Controls.Add(debrisEnemy);
                words.Add(debrisEnemy);
            }
        }
        private (int existingHighscore, bool isNewHighscore) SaveScoreToDatabase(int finalScore)
        {
            string constring = Guardian.Decrypt(encconstring);
            int existingHighscore = 0;
            bool isNewHighscore = false;

            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                conn.Open();

                string checkQuery = "SELECT highscore FROM highscore WHERE username = @username";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@username", currentUsername.ToLower());
                object existingScoreObj = checkCmd.ExecuteScalar();

                existingHighscore = existingScoreObj != null ? Convert.ToInt32(existingScoreObj) : 0;

                if (existingScoreObj != null && finalScore > existingHighscore)
                {
                    string updateQuery = "UPDATE highscore SET highscore = @highscore WHERE username = @username";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@username", currentUsername.ToLower());
                    updateCmd.Parameters.AddWithValue("@highscore", finalScore);
                    updateCmd.ExecuteNonQuery();
                    isNewHighscore = true;
                }
                else if (existingScoreObj == null)
                {
                    string insertQuery = "INSERT INTO highscore (username, highscore) VALUES (@username, @highscore)";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@username", currentUsername.ToLower());
                    insertCmd.Parameters.AddWithValue("@highscore", finalScore);
                    insertCmd.ExecuteNonQuery();
                    isNewHighscore = true;
                }
            }

            return (existingHighscore, isNewHighscore);
        }
        private void GameOver()
        {
            if (isGameOver) return;  // Prevent multiple triggers
            isGameOver = true;

            // Save final cumulative score and get highscore info
            var (existingHighscore, isNewHighscore) = SaveScoreToDatabase(scores);

            // Open your frmGameOver passing scores & highscore info
            frmGameOver gameOverForm = new frmGameOver(scores, existingHighscore, isNewHighscore);
            gameOverForm.Show();

            // Close or hide this game form to prevent further gameplay
            this.Hide();
        }

        public void PlayRegularCrashSound()
        {
            soundPlayer.PlaySound(regularCrashSound);
        }
        public void PlayBigCrashSound()
        {
            soundPlayer.PlaySound(bigCrashSound);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            soundPlayer.Dispose();
            base.OnFormClosing(e);
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void EnemyScore()
        {
            if (activeEnemy.word.Length == 1)
            {
                PlayRegularCrashSound();
                plusScore = 5;
                scores += 5;
                scores = MultiplyScore(scores, multiplier, plusScore);
            }
            else if (activeEnemy.word.Length >= 2 && activeEnemy.word.Length <= 4)
            {
                PlayRegularCrashSound();
                plusScore = 15;
                scores += 15;
                scores = MultiplyScore(scores, multiplier, plusScore);
            }
            else if (activeEnemy.word.Length >= 5 && activeEnemy.word.Length <= 6)
            {
                PlayBigCrashSound();
                plusScore = 20;
                scores += 20;
                scores = MultiplyScore(scores, multiplier, plusScore);
            }
            else if (activeEnemy.word.Length > 6)
            {
                PlayBigCrashSound();
                plusScore = 25;
                scores += 25;
                scores = MultiplyScore(scores, multiplier, plusScore);
            }
        }

        private void SpecialScore()
        {
            foreach (var word in words)
            {
                if (word.word.Length == 1)
                {
                    plusScore = 5;
                    scores += 5;
                    scores = MultiplyScore(scores, multiplier, plusScore);
                }
                else if (word.word.Length >= 2 && word.word.Length <= 4)
                {
                    plusScore = 15;
                    scores += 15;
                    scores = MultiplyScore(scores, multiplier, plusScore);
                }
                else if (word.word.Length >= 5 && word.word.Length <= 6)
                {
                    plusScore = 20;
                    scores += 20;
                    scores = MultiplyScore(scores, multiplier, plusScore);
                }
                else if (word.word.Length > 6)
                {
                    plusScore = 25;
                    scores += 25;
                    scores = MultiplyScore(scores, multiplier, plusScore);
                }
            }
        }


    }
}
