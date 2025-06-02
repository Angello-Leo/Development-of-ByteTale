using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Final_Project___CGC_Sage
{
    public partial class caveMenu : Form
    {
        bool isRunning = false;

        private SoundPlayer caveSound;
        Image player;
        List<string> playerMovements = new List<string>();
        int steps = 0;
        int slowDOwnFrameRate = 0;
        bool goLeft, goRight, goUp, goDown;
        int playerX;
        int playerY;
        int playerHeight = 100;
        int playerWidth = 100;
        int playerSpeed = 8;  //set to 8 if not debugging
        private Rectangle caveEntrance;
        private bool caveEntered = false;
        private bool canReturnToDashboard = false;
        private Timer gracePeriodTimer;
        private bool isInteracting = false;

        private bool canReturntoCave = false;
        private bool interactionFin = false;
        //Walls
        List<Rectangle> walls = new List<Rectangle>();

        //Career Plan Guardian
        Image careerGuardIdle;
        List<string> careerGuardIdleFrames = new List<string>();
        int careerGuardX = 500; // Set to desired location
        int careerGuardY = 200;
        int careerGuardWidth = 150;
        int careerGuardHeight = 200;
        int careerGuardStep = 0;
        int careerGuardFrameDelay = 0;

        //Interaction with CG
        private Rectangle interactionCareerGuard;
        private bool showInteractPromptCareerGuard = false;
        private Label careerGuardInterction;
        private bool careerGuardMessageShown = false;
        private Rectangle showCareerGuardDialogue;

        //TypingGame Guardian
        Image typingGuardIdle;
        List<string> typingGuardIdleFrames = new List<string>();
        int typingGuardX = 998; // Set to desired location
        int typingGuardY = 200;
        int typingGuardWidth = 150;
        int typingGuardHeight = 200;
        int typingGuardStep = 0;
        int typingGuardFrameDelay = 0;

        //Interction with TG
        private Rectangle interactionTypingGuard;
        private bool showInteractPromptTypingGuard = false;
        private Label typingGuardInteraction;
        private bool typingGuardMessageShown = false;
        private Rectangle showTypingGuardDialogue;


        public caveMenu()
        {
            this.WindowState = FormWindowState.Maximized;
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);
            this.KeyPreview = true;
            InitializeComponent();
            SetUp();

            // Setup grace period timer
            gracePeriodTimer = new Timer();
            gracePeriodTimer.Interval = 1500; // 1.5 seconds
            gracePeriodTimer.Tick += (s, e) =>
            {
                canReturnToDashboard = true;
                gracePeriodTimer.Stop();
            };
            gracePeriodTimer.Start();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {

            // Create a rectangle for the player to check collision
            Rectangle playerRect = new Rectangle(playerX, playerY, playerWidth, playerHeight);

            // Check for collision with the cave entrance (if applicable)
            if (playerRect.IntersectsWith(caveEntrance) && canReturnToDashboard && !caveEntered)
            {
                caveEntered = true;
                // Set the player's position to the "return" position
                PlayerState.X = playerX;
                PlayerState.Y = playerY;
                PlayerState.ReturningFromCave = true;

                // Return to the main dashboard
                mainDashboard main = new mainDashboard();
                main.Show();
                this.Close();
            }
            // For debugging player location
            this.Text = $"Player Position: X = {playerX}, Y = {playerY}";
            
            // Handle player movement
            Rectangle nextPosition;

            if (goLeft && playerX > 0)
            {
                nextPosition = new Rectangle(playerX - playerSpeed, playerY, playerWidth, playerHeight);
                if (!walls.Any(w => w.IntersectsWith(nextPosition)))
                {
                    playerX -= playerSpeed;
                    AnimatePllayer(0, 1);  // Left animation
                }
            }
            else if (goRight && playerX + playerWidth < this.ClientSize.Width)
            {
                nextPosition = new Rectangle(playerX + playerSpeed, playerY, playerWidth, playerHeight);
                if (!walls.Any(w => w.IntersectsWith(nextPosition)))
                {
                    playerX += playerSpeed;
                    AnimatePllayer(2, 3);  // Right animation
                }
            }
            else if (goUp && playerY > 0)
            {
                nextPosition = new Rectangle(playerX, playerY - playerSpeed, playerWidth, playerHeight);
                if (!walls.Any(w => w.IntersectsWith(nextPosition)))
                {
                    playerY -= playerSpeed;
                    AnimatePllayer(4, 5);  // Up animation
                }
            }
            else if (goDown && playerY + playerHeight < this.ClientSize.Height)
            {
                nextPosition = new Rectangle(playerX, playerY + playerSpeed, playerWidth, playerHeight);
                if (!walls.Any(w => w.IntersectsWith(nextPosition)))
                {
                    playerY += playerSpeed;
                    AnimatePllayer(0, 1);  // Down animation (reusing left frames here)
                }
            }
            else
            {
                AnimatePllayer(0, 1);  // Idle animation
            }

            //Career Guard
            careerGuardFrameDelay++;
            if (careerGuardFrameDelay >= 10) // Adjust for speed
            {
                careerGuardStep = (careerGuardStep + 1) % careerGuardIdleFrames.Count;
                careerGuardIdle = Image.FromFile(careerGuardIdleFrames[careerGuardStep]);
                careerGuardFrameDelay = 0;
            }
            //Interaction with Career Guard
            if (playerRect.IntersectsWith(interactionCareerGuard))
            {
                showInteractPromptCareerGuard = true;
                careerGuardInterction.Visible = true;

                // Center the prompt above the object
                careerGuardInterction.Location = new Point(careerGuardX, careerGuardY);
            }
            else
            {
                showInteractPromptCareerGuard = false;
                careerGuardInterction.Visible = false;
            }

            //TypingGame Guard
            typingGuardFrameDelay++;
            if (typingGuardFrameDelay >= 10) // Adjust for speed
            {
                typingGuardStep = (typingGuardStep + 1) % typingGuardIdleFrames.Count;
                typingGuardIdle = Image.FromFile(typingGuardIdleFrames[typingGuardStep]);
                typingGuardFrameDelay = 0;
            }

            // interaction with typing game guard
            if (playerRect.IntersectsWith(interactionTypingGuard))
            {
                showInteractPromptTypingGuard = true;
                typingGuardInteraction.Visible = true;

                // Center the prompt above the object
                typingGuardInteraction.Location = new Point(typingGuardX, typingGuardY);
            }
            else
            {
                showInteractPromptTypingGuard = false;
                typingGuardInteraction.Visible = false;
            }


            // Trigger a redraw of the form (this causes the `Paint` event to be fired)
            this.Invalidate();  // Triggers the FormPaintEvent
        }

        private void caveMenu_Load(object sender, EventArgs e)
        {
            if (PlayerState.ReturningFromCave)
            {
                playerX = PlayerState.ReturnX;  // Position when returning to mainDashboard
                playerY = PlayerState.ReturnY;
                PlayerState.ReturningFromCave = false;  // Reset the flag
            }
            else if (PlayerState.ReturningFromCareerResults)
            {
                playerX = PlayerState.CareerGuardX;
                playerY = PlayerState.CareerGuardY;
                PlayerState.ReturningFromCareerResults = false;
                var postReturnDialog = new frmReturningFromCareerPlan();
                postReturnDialog.ShowDialog();
            }
            else if (PlayerState.ReturningFromTypingGame)
            {
                playerX = PlayerState.typingGuardX;
                playerY =PlayerState.typingGuardY;
                PlayerState.ReturningFromTypingGame = false;

            }
            else
            {
                playerX = 220;
                playerY = 675; //633
            }

            // Load and play a different sound (change the path to your file)
            System.Media.SoundPlayer sfx = new System.Media.SoundPlayer(Properties.Resources.caveMenuSound);
            sfx.PlayLooping();

            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            this.Size = new System.Drawing.Size(Convert.ToInt32(0.5 * workingRectangle.Width),
                Convert.ToInt32(0.5 * workingRectangle.Height));

            this.Location = new System.Drawing.Point(10, 10);
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (isInteracting) 
                return;

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
                playerSpeed = 16;
            }

            if (e.KeyCode == Keys.E && !typingGuardMessageShown && showInteractPromptTypingGuard)
            {
                typingGuardMessageShown = true;

               
                StartInteraction(new frmTypingGuradDialogue(PlayerState.Username));

            }
            else if (e.KeyCode == Keys.E && !careerGuardMessageShown && showInteractPromptCareerGuard)
            {
                careerGuardMessageShown = true;

                PlayerState.CareerGuardX = playerX;
                PlayerState.CareerGuardY = playerY;

                StartInteraction(new frmCareerPlanningGuardDialogue());
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
            if (e.KeyCode == Keys.ShiftKey)
            {
                isRunning = false;
                playerSpeed = 8;
            }
            if (e.KeyCode == Keys.E)
            {
                typingGuardMessageShown = false;  // Reset the flag when the key is released
                careerGuardMessageShown = false;
            }
        }

        private void StartInteraction(Form dialog)
        {
            isInteracting = true;

            // Reset movement flags immediately
            goLeft = goRight = goUp = goDown = false;

            dialog.FormClosed += (s, args) =>
            {
                isInteracting = false;
            };

            dialog.Show();
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;
            Canvas.DrawImage(player, playerX, playerY, playerWidth, playerHeight);

            Canvas.DrawImage(careerGuardIdle, careerGuardX, careerGuardY, careerGuardWidth, careerGuardHeight);

            Canvas.DrawImage(typingGuardIdle, typingGuardX, typingGuardY, typingGuardWidth, typingGuardHeight);

            /*foreach (var wall in walls) // debugging walls
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(120, Color.Red)), wall);  // Transparent red box
            }*/
        }

        private void SetUp()
        {
            // Player spawn position
            playerX = 196;
            playerY = 633;
            this.BackgroundImage = Image.FromFile("caveMenuBg.png"); // put bg here
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.DoubleBuffered = true;

            // Cave entrance setup
            int caveWidth = 100;
            int caveHeight = 100;
            int caveX = 84;
            int caveY = 633;

            caveEntrance = new Rectangle(caveX, caveY, caveWidth, caveHeight);

            // Load player sprites
            playerMovements = Directory.GetFiles("Sprites", "*.png").ToList();
            player = Image.FromFile(playerMovements[0]);

            interactionCareerGuard = new Rectangle(careerGuardX, careerGuardY, careerGuardWidth, careerGuardHeight);
            interactionTypingGuard = new Rectangle(typingGuardX, typingGuardY, typingGuardWidth, typingGuardHeight);

            //CareerPlanninng Guard
            careerGuardIdleFrames = new List<string>
            {
                "CareerPlan Guardian/CareerPlanGy1.png",
                "CareerPlan Guardian/CareerPlanGy2.png"
            };
            careerGuardIdle = Image.FromFile(careerGuardIdleFrames[0]);

            // Create interaction prompt label
            careerGuardInterction = new Label
            {
                Text = "Interact (Press E)",   
                AutoSize = true,
                BackColor = Color.LightYellow,
                Visible = false
            };
            this.Controls.Add(careerGuardInterction);

            //Typing Game Guard
            typingGuardIdleFrames = new List<string>
            {
                "Typing Game Guardian/TypingG1.png",
                "Typing Game Guardian/TypingG2.png"
            };
            typingGuardIdle = Image.FromFile(typingGuardIdleFrames[0]);

            //Interaction
            typingGuardInteraction = new Label
            {
                Text = "Interact (Press E)",
                AutoSize = true,
                BackColor = Color.LightYellow,
                Visible = false
            };
            this.Controls.Add(typingGuardInteraction);

            //Limit player mobement
            walls.Add(new Rectangle(148,217, 1400, 100));
            walls.Add(new Rectangle(40, 333, 120, 280));
            walls.Add(new Rectangle(546, 333, 3, 3));
            walls.Add(new Rectangle(1046, 333, 3, 3));


        }

        private void AnimatePllayer(int start, int end)
        {
            slowDOwnFrameRate += 1;

            if (slowDOwnFrameRate == 4)
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
