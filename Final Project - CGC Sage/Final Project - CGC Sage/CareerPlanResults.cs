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
    public partial class CareerPlanResults : Form
    {
        private CareerPlanQuestions result;
        private Label instructionLabel;

        private Timer typingTimer;
        private string fullTextToShow;
        private int currentCharIndex;
        private bool isTyping = false;

        // NPC Animation
        private Timer animationTimer;
        private Image frame1Image;
        private Image frame2Image;
        private bool isFrame1 = true;

        // Dimensions for layout
        private int guardWidth = 250;
        private int guardHeight = 200;
        private int panelWidth = 1000;
        private int panelHeight = 220;
        private int buttonWidth = 100;
        private int buttonHeight = 40;
        private int buttonSpacing = 40;
        private int spacing = 30;

        private PictureBox picHeart;
        private enum SelectedOption { Back }
        private SelectedOption currentSelection = SelectedOption.Back;
        private string shortIS = "The career for you is IS";
        private string shortGPD = "The career for you is GPD";
        private string shortIT = "The career for you is IT";

        // Long descriptions
        private string longIS = "An Information Systems (IS) major focuses on how technology can be used to manage and support business operations, decision-making, and innovation.";
        private string longGPD = "A Graphic and Product Design (GPD) major emphasizes creativity and visual communication, teaching you to design user-friendly and visually appealing products or interfaces.";
        private string longIT = "An Information Technology (IT) major prepares you to work with computer systems, networks, and security, focusing on practical tech support and infrastructure management.";

        // Tracking what is currently showing
        private bool showingShortMessage = true;
        private string currentShortMessage = "";
        private string currentLongMessage = "";

        // Tie short messages
        private string shortITGPD = "The best career path for you is both Information Technology and Graphics and Designs.";
        private string shortISGPD = "The best career path for you is both Intelligent Systems and Graphics and Designs.";
        private string shortISIT = "The best career path for you is both Information Technology and Intelligent Systems.";
        private string shortALL = "Every career path is for you.";

        // Tie long descriptions
        private string longITGPD = "You are suited for both Information Technology and Graphics and Designs, combining tech infrastructure knowledge with creative and design-oriented thinking.";
        private string longISGPD = "You are suited for both Intelligent Systems and Graphics and Designs, balancing AI, machine learning, and visual creativity.";
        private string longISIT = "You are suited for both Information Technology and Intelligent Systems, giving you strengths in tech infrastructure and intelligent, automated systems.";
        private string longALL = "You demonstrate interest across all fields—Information Technology, Graphics and Design, and Intelligent Systems—meaning you have a broad and versatile set of talents.";

        public Action OnReturnRequested;

        public CareerPlanResults(CareerPlanQuestions _result)
        {
            InitializeComponent();

            instructionLabel = new Label();
            instructionLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            instructionLabel.ForeColor = Color.White;  // Choose your preferred color
            instructionLabel.AutoSize = true;
            instructionLabel.TextAlign = ContentAlignment.MiddleCenter;
            instructionLabel.Location = new Point(pictureBox1.Right + 30, pictureBox1.Top + 20); // Position at the bottom of the form
            this.Controls.Add(instructionLabel);

            // Hide initially
            instructionLabel.Visible = false;
            btnBack.Visible = false;
            this.FormClosed += resultt_FormClosed;
            result = _result;

            // Setup the result text based on questions answers
            if (result.IS > result.GPD && result.IS > result.IT)
            {
                currentShortMessage = shortIS;
                currentLongMessage = longIS;
            }
            else if (result.GPD > result.IS && result.GPD > result.IT)
            {
                currentShortMessage = shortGPD;
                currentLongMessage = longGPD;
            }
            else if (result.IT > result.IS && result.IT > result.GPD)
            {
                currentShortMessage = shortIT;
                currentLongMessage = longIT;
            }
            else if (result.IT == result.GPD && result.IT > result.IS)
            {
                currentShortMessage = shortITGPD;
                currentLongMessage = longITGPD;
            }
            else if (result.IS == result.GPD && result.IS > result.IT)
            {
                currentShortMessage = shortISGPD;
                currentLongMessage = longISGPD;
            }
            else if (result.IS == result.IT && result.IS > result.GPD)
            {
                currentShortMessage = shortISIT;
                currentLongMessage = longISIT;
            }
            else
            {
                currentShortMessage = shortALL;
                currentLongMessage = longALL;
            }
            StartTypingAnimation(currentShortMessage);
            label1.TextAlign = ContentAlignment.MiddleCenter; 
            label1.MaximumSize = panel1.Size;
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);

            // Start NPC animation
            frame1Image = Image.FromFile("InGameSprites/InGameCareerGuard1.png");
            frame2Image = Image.FromFile("InGameSprites/InGameCareerGuard2.png");
            pictureBox1.Image = frame1Image;
            animationTimer = new Timer();
            animationTimer.Interval = 800;
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();

        }

        private void resultt_Load(object sender, EventArgs e)
        {

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(screenWidth, screenHeight);

            // Set form size and position
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            int panelWidth = 1000;
            int panelHeight = 220;
            int border = 5;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            // === PICTUREBOX ===
            pictureBox1.Size = new Size(guardWidth, guardHeight);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Location = new Point((w - guardWidth) / 2, 100);

            // === RESULT PANEL ===
            ResizeBorderedPanel(panelWidth, panelHeight, border);
            panel1.Location = new Point((screenWidth - panelWidth) / 2, pictureBox1.Bottom + spacing);

            // === BUTTONS ===
            int buttonsTop = panel1.Bottom + spacing;
            btnBack.Size = new Size(buttonWidth, buttonHeight);
            btnBack.Location = new Point((w / 2) - buttonWidth / 2, buttonsTop);
            btnNext.Location = btnBack.Location;
            btnBack.Text = "RETURN";

            // === HEART INDICATOR ===
            picHeart = new PictureBox();
            picHeart.Size = new Size(30, 30);
            picHeart.Image = Image.FromFile("C:\\Users\\gello\\source\\repos\\Final Project - CGC Sage\\Final Project - CGC Sage\\Resources\\soul.png"); // adjust path as needed
            picHeart.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(picHeart);
            UpdateHeartPosition(); // Set initial position above the Back button


            // === Adjust Label Text ===
            label1.AutoSize = false;
            label1.Size = panel1.Size;
            label1.MaximumSize = panel1.Size;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Dock = DockStyle.Fill; // Make it fill the panel
            label1.Padding = new Padding(10);
        }
        private void UpdateHeartPosition()
        {
            if (btnNext.Visible == true)
            {
                Label activeLabel = btnNext.Visible ? btnNext : btnBack;

                int offsetX = -picHeart.Width - 10; // Heart to the left of the label
                int offsetY = (activeLabel.Height - picHeart.Height) / 2;

                picHeart.Location = new Point(
                    activeLabel.Left + offsetX,
                    activeLabel.Top + offsetY
                    );
            }
            else
            {
                Label activeLabel = btnNext.Visible ? btnNext : btnBack;

                int offsetX = -picHeart.Width - 10; // Heart to the left of the label
                int offsetY = (activeLabel.Height - picHeart.Height) / 2;

                picHeart.Location = new Point(
                    activeLabel.Left + offsetX,
                    activeLabel.Top + offsetY
                    );
            }
        
        }

        // Animation timer for NPC frames
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (isFrame1)
            {
                pictureBox1.Image = frame1Image; // Show first frame
            }
            else
            {
                pictureBox1.Image = frame2Image; // Show second frame
            }

            // Toggle between frames
            isFrame1 = !isFrame1;
        }

        // Back button click handler
        private void btnBack_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Back button clicked.");
            PlayerState.ReturningFromCareerResults = true;
            this.Close(); 
            caveMenu cave = new caveMenu();
            cave.Show();
        }
        private void ResizeBorderedPanel(int outerWidth, int outerHeight, int border)
        {
            panel1.Size = new Size(outerWidth, outerHeight);
            panel1.Location = new Point((this.ClientSize.Width - outerWidth) / 2, 30);

            panel2.Size = new Size(outerWidth - (2 * border), outerHeight - (2 * border));
            panel2.Location = new Point(border, border);
        }

        // Clean up on form close
        private void resultt_FormClosed(object sender, FormClosedEventArgs e)
        {
            animationTimer.Stop();
            animationTimer.Dispose();
            if (result.bgmPlayer != null)
            {
                result.bgmPlayer.Stop();
                result.bgmPlayer.Dispose();
            }
        }
        private void StartTypingAnimation(string message)
        {
            fullTextToShow = message;
            currentCharIndex = 0;
            isTyping = true;
            label1.Text = "";
            instructionLabel.Visible = false;

            typingTimer = new Timer();
            typingTimer.Interval = 30; // Adjust typing speed (ms per character)
            typingTimer.Tick += TypingTimer_Tick;
            typingTimer.Start();
        }

        private void TypingTimer_Tick(object sender, EventArgs e)
        {
            if (currentCharIndex < fullTextToShow.Length)
            {
                label1.Text += fullTextToShow[currentCharIndex];
                currentCharIndex++;
            }
            else
            {
                typingTimer.Stop();
                typingTimer.Dispose();
                typingTimer = null;
                isTyping = false;
                if (showingShortMessage)
                {
                    // Show the instruction to continue
                    instructionLabel.Text = "Press Z to continue";
                    instructionLabel.Visible = true;
                }
                else
                {
                    // After finishing the long message
                    instructionLabel.Text = "Press Z to exit";
                    instructionLabel.Visible = true;
                }
                if (!showingShortMessage)
                {
                    btnBack.Visible = true;
                    btnNext.Visible = false;
                    UpdateHeartPosition();
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Z)
            {
                if (isTyping)
                {
                    // Prevent further action if typing is still happening
                    return true;
                }

                if (showingShortMessage)
                {
                    // Start typing the long message
                    showingShortMessage = false;
                    btnNext.Visible = false;
                    btnBack.Visible = false;
                    StartTypingAnimation(currentLongMessage);
                    return true;
                }

                if (btnBack.Visible)
                {
                    // Simulate a button click if Back button is visible
                    btnBack_Click(this, EventArgs.Empty);
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
