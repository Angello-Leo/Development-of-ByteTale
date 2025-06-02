using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Final_Project___CGC_Sage.caveMenu;

namespace Final_Project___CGC_Sage
{
    public partial class mainDashboard : Form
    {
        bool isRunning = false;

        private Timer gameTimer;
        private SoundPlayer homeSound;
        Image player;
        List<string> playerMovements = new List<string>();
        int steps = 0;
        int slowDOwnFrameRate = 0;
        bool goLeft, goRight, goUp, goDown;
        int playerX;
        int playerY;
        int playerHeight = 100;
        int playerWidth = 100;
        int playerSpeed = 8; // 8 if not testing
        private Rectangle caveEntrance;
        private bool caveEntered = false;
        private bool isInteracting = false;

        // for interacting with saxophone
        private Rectangle interactionSaxophone;
        private bool showInteractPromptSax = false;
        private Label interactionPromptSax;
        private bool SaxMessageShown = false;
        private Rectangle showSaxDialogue;

        // for interacting with Doggo
        private Rectangle interactionDoggo;
        private bool showInteractPromptDoggo = false;
        private Label interactionPromptDoggo;
        private bool doggoMessageShown = false;
        private Rectangle showDoggoDialogue;

        // for interacting with Bass
        private Rectangle interactionBass;
        private bool showInteractPromptBass = false;
        private Label interactionPromptBass;
        private bool bassMessageShown = false;
        private Rectangle showBassDialogue;

        // for interacting with Controller
        private Rectangle interactionCont;
        private bool showInteractPromptCont = false;
        private Label interactionPromptCont;
        private bool contMessageShown = false;
        private Rectangle showContDialogue;

        // for interacting with Ball
        private Rectangle interactionBall;
        private bool showInteractPromptBall = false;
        private Label interactionPromptBall;
        private bool ballMessageShown = false;
        private Rectangle showBallDialogue;

        // for interacting with Options
        private Rectangle interactionOption;
        private bool showInteractPromptOption = false;
        private Label interactionPromptOption;
        private bool optionMessageShown = false;
        private Rectangle showOptionDialogue;

        public mainDashboard()
        {
            this.WindowState = FormWindowState.Maximized;
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);
            this.KeyPreview = true;
            InitializeComponent();
            SetUp();
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void mainDashboard_Load(object sender, EventArgs e)
        {
            if (PlayerState.ReturningFromCave)
            {
                playerX = PlayerState.ReturnX;  // Position where the player should appear after returning
                playerY = PlayerState.ReturnY;
                PlayerState.ReturningFromCave = false;  // Reset flag
            }
            else
            {
                playerX = PlayerState.InitialX;  // Normal starting position
                playerY = PlayerState.InitialY;
            }

            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            this.Size = new System.Drawing.Size(Convert.ToInt32(0.5 * workingRectangle.Width),
                Convert.ToInt32(0.5 * workingRectangle.Height));

            this.Location = new System.Drawing.Point(10, 10);

            // Load and play a different sound (change the path to your file)
            System.Media.SoundPlayer sfx = new System.Media.SoundPlayer(Properties.Resources.mainDashboard_bgm___Home);
            sfx.PlayLooping();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (isInteracting) return; //Prevent movement/interactions while dialog is open

            if (e.KeyCode == Keys.A)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.D)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.W)
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.S)
            {
                goDown = true;
            }
            if (e.KeyCode == Keys.ShiftKey)
            {
                isRunning = true;
                playerSpeed = 16; // Double the normal speed
            }

            if (e.KeyCode == Keys.E && !SaxMessageShown && showInteractPromptSax)
            {
                SaxMessageShown = true;
                isInteracting = true;
                goLeft = goRight = goUp = goDown = false;
                frmSaxophoneDialogue saxDlg = new frmSaxophoneDialogue();
                saxDlg.FormClosed += (s, args) =>
                {
                    isInteracting = false;
                    System.Media.SoundPlayer sfx = new System.Media.SoundPlayer(Properties.Resources.mainDashboard_bgm___Home);
                    sfx.PlayLooping();
                    this.Focus();
                };
                saxDlg.Show();
            }
            else if (e.KeyCode == Keys.E && !doggoMessageShown && showInteractPromptDoggo)
            {
                doggoMessageShown = true;
                isInteracting = true;
                goLeft = goRight = goUp = goDown = false;
                frmDoggoDialogue doggoDlg = new frmDoggoDialogue();
                doggoDlg.FormClosed += (s, args) => isInteracting = false;
                doggoDlg.Show();
            }
            else if (e.KeyCode == Keys.E && !bassMessageShown && showInteractPromptBass)
            {
                bassMessageShown = true;
                isInteracting = true;
                goLeft = goRight = goUp = goDown = false;
                frmBassDialogue bassDlg = new frmBassDialogue();
                bassDlg.FormClosed += (s, args) =>
                {
                    isInteracting = false;
                    System.Media.SoundPlayer sfx = new System.Media.SoundPlayer(Properties.Resources.mainDashboard_bgm___Home);
                    sfx.PlayLooping();
                    this.Focus();
                };
                bassDlg.Show();
            }
            else if (e.KeyCode == Keys.E && !contMessageShown && showInteractPromptCont)
            {
                contMessageShown = true;
                isInteracting = true;
                goLeft = goRight = goUp = goDown = false;
                frmControllerDialogue contDlg = new frmControllerDialogue();
                contDlg.FormClosed += (s, args) => isInteracting = false;
                contDlg.Show();
            }
            else if (e.KeyCode == Keys.E && !ballMessageShown && showInteractPromptBall)
            {
                ballMessageShown = true;
                isInteracting = true;
                goLeft = goRight = goUp = goDown = false;
                frmBallDialogue ballDlg = new frmBallDialogue();
                ballDlg.FormClosed += (s, args) => isInteracting = false;
                ballDlg.Show();
            }
            else if (e.KeyCode == Keys.E && !optionMessageShown && showInteractPromptOption)
            {
                optionMessageShown = true;
                isInteracting = true;
                goLeft = goRight = goUp = goDown = false; 

                frmSettingsDialogue settingsDlg = new frmSettingsDialogue(PlayerState.Username);
                settingsDlg.OnSettingsDialogClosed += () =>
                {
                    isInteracting = false;

                    // ❗ Do NOT set all directions to true!
                    goLeft = goRight = goUp = goDown = false;

                    this.Focus();
                };
                settingsDlg.ShowDialog();
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.D)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.W)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.S)
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.E)
            {
                SaxMessageShown = false;  // Reset the flag when the key is released
                doggoMessageShown = false;
                ballMessageShown = false;     
                bassMessageShown = false;     
                contMessageShown = false;   
                optionMessageShown = false;
            }
            if (e.KeyCode == Keys.ShiftKey)
            {
                isRunning = false;
                playerSpeed = 8;
            }

        }

        private void TimerEvent(object sender, EventArgs e)
        {
            int caveWidth = 100;
            int caveHeight = 100;
            int marginFromEdge = 40;

            caveEntrance = new Rectangle(
                this.ClientSize.Width - caveWidth - marginFromEdge,
                this.ClientSize.Height - caveHeight - marginFromEdge,
                caveWidth,
                caveHeight);
            // Create a rectangle for the player
            Rectangle playerRect = new Rectangle(playerX, playerY, playerWidth, playerHeight);

            // Check for collision with the cave entrance
            if (playerRect.IntersectsWith(caveEntrance) && !caveEntered)
            {
                caveEntered = true; // make sure we don’t re-trigger

                // Open the new form (the cave)
                caveMenu cave = new caveMenu();
                cave.Show();
                this.Hide();
            }
            // For debugging player location
            //this.Text = $"Player Position: X = {playerX}, Y = {playerY}";

            // Player Logic
            if (goLeft && playerX > 0)
            {
                playerX -= playerSpeed;
                AnimatePllayer(0, 1);
            }
            else if (goRight && playerX + playerWidth < this.ClientSize.Width)
            {
                playerX += playerSpeed;
                AnimatePllayer(2, 3);
            }
            else if (goUp && playerY > 0)
            {
                playerY -= playerSpeed;
                AnimatePllayer(4, 5);
            }
            else if (goDown && playerY + playerHeight < this.ClientSize.Height)
            {
                playerY += playerSpeed; AnimatePllayer(0, 1);
            }
            else
            {
                AnimatePllayer(0, 1);
            }

            // Check proximity to interaction object
            if (playerRect.IntersectsWith(interactionSaxophone))
            {
                showInteractPromptSax = true;
                interactionPromptSax.Visible = true;

                // Center the prompt above the object
                interactionPromptSax.Location = new Point(
                    interactionSaxophone.X + (interactionSaxophone.Width / 2) - (interactionSaxophone.Width / 2),
                    interactionSaxophone.Y - 20
                );
            }
            else
            {
                showInteractPromptSax = false;
                interactionPromptSax.Visible = false;
            }

            // doggo interaction
            if (playerRect.IntersectsWith(interactionDoggo))
            {
                showInteractPromptDoggo = true;
                interactionPromptDoggo.Visible = true;

                // Center the prompt above the object
                interactionPromptDoggo.Location = new Point(
                    interactionDoggo.X + (interactionDoggo.Width / 2) - (interactionDoggo.Width / 2),
                    interactionDoggo.Y - 20
                );
            }
            else
            {
                showInteractPromptDoggo = false;
                interactionPromptDoggo.Visible = false;
            }

            // bass interaction
            if (playerRect.IntersectsWith(interactionBass))
            {
                showInteractPromptBass = true;
                interactionPromptBass.Visible = true;

                // Center the prompt above the object
                interactionPromptBass.Location = new Point(
                    interactionBass.X + (interactionBass.Width / 2) - (interactionBass.Width / 2),
                    interactionBass.Y - 20
                );
            }
            else
            {
                showInteractPromptBass = false;
                interactionPromptBass.Visible = false;
            }

            // Controller interaction
            if (playerRect.IntersectsWith(interactionCont))
            {
                showInteractPromptCont = true;
                interactionPromptCont.Visible = true;

                // Center the prompt above the object
                interactionPromptCont.Location = new Point(
                    interactionCont.X + (interactionCont.Width / 2) - (interactionCont.Width / 2),
                    interactionCont.Y - 20
                );
            }
            else
            {
                showInteractPromptCont = false;
                interactionPromptCont.Visible = false;
            }

            // Ball interaction
            if (playerRect.IntersectsWith(interactionBall))
            {
                showInteractPromptBall = true;
                interactionPromptBall.Visible = true;

                // Center the prompt above the object
                interactionPromptBall.Location = new Point(
                    interactionBall.X + (interactionBall.Width / 2) - (interactionBall.Width / 2),
                    interactionBall.Y - 20
                );
            }
            else
            {
                showInteractPromptBall = false;
                interactionPromptBall.Visible = false;
            }

            // Settings interaction
            if (playerRect.IntersectsWith(interactionOption))
            {
                showInteractPromptOption = true;
                interactionPromptOption.Visible = true;

                // Center the prompt above the object
                interactionPromptOption.Location = new Point(
                    interactionOption.X + (interactionOption.Width / 2) - (interactionOption.Width / 2),
                    interactionOption.Y - 20
                );
            }
            else
            {
                showInteractPromptOption = false;
                interactionPromptOption.Visible = false;
            }
            this.Invalidate(); 
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;
            Canvas.DrawImage(player, playerX, playerY, playerWidth, playerHeight);

            using (Brush caveBrush = new SolidBrush(Color.Black))
            {
                Canvas.FillRectangle(caveBrush, caveEntrance);
            }
        }

        private void SetUp()
        {
            playerX = 32;
            playerY = 16;
            this.BackgroundImage = Image.FromFile("mainbg.png"); // put bg here
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.DoubleBuffered = true;

            int caveWidth = 100;
            int caveHeight = 100;
            int marginFromEdge = 40;

            // Use ClientSize to get the actual drawable area
            caveEntrance = new Rectangle(
                this.ClientSize.Width - caveWidth - marginFromEdge,
                this.ClientSize.Height - caveHeight - marginFromEdge,
                caveWidth,
                caveHeight);


            //Player movement
            playerMovements = Directory.GetFiles("Sprites", "*.png").ToList();
            player = Image.FromFile(playerMovements[0]);

            // Add an interactable object for saxophone
            interactionSaxophone = new Rectangle(152, 96, 50, 50); // size is customizable

            // Create interaction prompt label
            interactionPromptSax = new Label
            {
                Text = "Interact (Press E)",
                AutoSize = true,
                BackColor = Color.LightYellow,
                Visible = false
            };
            this.Controls.Add(interactionPromptSax);

            showSaxDialogue = interactionSaxophone;

            // Add an interactable object for doggo
            interactionDoggo = new Rectangle(720, 88, 100, 100); // size is customizable

            // Create interaction prompt label
            interactionPromptDoggo = new Label
            {
                Text = "Interact (Press E)",
                AutoSize = true,
                BackColor = Color.LightYellow,
                Visible = false
            };
            this.Controls.Add(interactionPromptDoggo);

            showDoggoDialogue = interactionDoggo;

            // Add an interactable object for Bass
            interactionBass = new Rectangle(1384, 72, 50, 50); // size is customizable

            // Create interaction prompt label
            interactionPromptBass = new Label
            {
                Text = "Interact (Press E)",
                AutoSize = true,
                BackColor = Color.LightYellow,
                Visible = false
            };
            this.Controls.Add(interactionPromptBass);

            showBassDialogue = interactionBass;

            // Add an interactable object for Controller
            interactionCont = new Rectangle(416, 208, 100, 100); // size is customizable

            // Create interaction prompt label
            interactionPromptCont = new Label
            {
                Text = "Interact (Press E)",
                AutoSize = true,
                BackColor = Color.LightYellow,
                Visible = false
            };
            this.Controls.Add(interactionPromptCont);

            showContDialogue = interactionCont;

            // Add an interactable object for Ball
            interactionBall = new Rectangle(1032, 488, 50, 50); // size is customizable

            // Create interaction prompt label
            interactionPromptBall = new Label
            {
                Text = "Interact (Press E)",
                AutoSize = true,
                BackColor = Color.LightYellow,
                Visible = false
            };
            this.Controls.Add(interactionPromptBall);

            showBallDialogue = interactionBall;

            // Add an interactable object for Settings
            interactionOption = new Rectangle(48, 672, 100, 100); // size is customizable

            // Create interaction prompt label
            interactionPromptOption = new Label
            {
                Text = "Interact (Press E)",
                AutoSize = true,
                BackColor = Color.LightYellow,
                Visible = false
            };
            this.Controls.Add(interactionPromptOption);

            showOptionDialogue = interactionOption;
        }

        private void AnimatePllayer(int start, int end)
        {
            slowDOwnFrameRate += 1;

            if (slowDOwnFrameRate >= 4)
            {
                steps++;
                slowDOwnFrameRate = 0;
            }

            if (steps > end || steps < start)
            {
                steps = start;
            }

            player = Image.FromFile(playerMovements[steps]);
        }
    }
}
