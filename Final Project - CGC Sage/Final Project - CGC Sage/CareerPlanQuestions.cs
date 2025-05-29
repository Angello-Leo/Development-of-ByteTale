using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Final_Project___CGC_Sage
{
    public partial class CareerPlanQuestions : Form
    {
        public int IS = 0;
        public int GPD = 0;
        public int IT = 0;
        private int questionCounter = 1;
        private Label lblInstructions;

        private string[] questionsnum =
        {
                "Do you enjoy math, algorithms, and logic?",
                "Are you drawn to visual creativity and aesthetics?",
                "Do you enjoy managing systems, setting up networks, or troubleshooting problems?",
                "Are you curious about how machines can learn, reason, and make decisions?",
                "Do you enjoy using tools like Photoshop, Canva, Unity, or other designing apps or websites?",
                "Are you interested in security, databases, or enterprise-level IT infrastructure?",
                "Would you like to build smart systems, like chatbots, recommendation engines, or autonomous robots?",
                "Are you interested in how people interact with systems visually and intuitively?",
                "Do you like working with hardware, software setups, or tech support?",
                "Are you okay with lots of data and statistics?",
                "Do you want to work in game development, animation, UI/ UX, or digital art?",
                "Do you enjoy making systems efficient and secure?",
                "Do you want to work in fields like AI, robotics, data science, or automation?",
                "Do you like creating things that are both functional and beautiful?",
                "Do you want to work in IT support, cybersecurity, DevOps, or cloud services?",
                ""
        };

        private Timer animationTimer;
        private Image frame1Image;
        private Image frame2Image;
        private bool isFrame1 = true;
        private PictureBox picHeart;
        private enum SelectedOption { Yes, No }
        private SelectedOption currentSelection = SelectedOption.Yes;
        public SoundPlayer bgmPlayer { get; private set; }

        public CareerPlanQuestions()
        {
            InitializeComponent();
        }

        private void questions_Load(object sender, EventArgs e)
        {
            try
            {
                bgmPlayer = new SoundPlayer("C:\\Users\\gello\\Desktop\\test\\testingnungkayleo\\CareerPlanBgm.wav");
                bgmPlayer.Load();
                bgmPlayer.PlayLooping();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing background music: " + ex.Message);
            }



            LabelChange(questionCounter);

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(screenWidth, screenHeight);

            // === DIMENSIONS ===
            int guardWidth = 250;
            int guardHeight = 200;
            int panelWidth = 1000;
            int panelHeight = 220;
            int border = 5;
            int buttonWidth = 100;
            int buttonHeight = 40;
            int buttonSpacing = 40;
            int spacing = 30; // spacing between controls

            // === TOTAL HEIGHT OF ALL ELEMENTS STACKED ===
            int totalHeight = guardHeight + panelHeight + buttonHeight + (spacing * 2);

            // === STARTING Y POSITION (to vertically center the stack) ===
            int startY = (screenHeight - totalHeight) / 2;

            // === PICTUREBOX ===
            pictureBox1.Size = new Size(guardWidth, guardHeight);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Location = new Point((screenWidth - guardWidth) / 2, startY);

            // === QUESTION PANEL ===
            ResizeBorderedPanel(panelWidth, panelHeight, border);
            panel1.Location = new Point((screenWidth - panelWidth) / 2, pictureBox1.Bottom + spacing);

            // === BUTTONS ===
            int buttonsTop = panel1.Bottom + spacing;
            btnYes.Size = new Size(buttonWidth, buttonHeight);
            btnNO.Size = new Size(buttonWidth, buttonHeight);

            btnYes.Location = new Point((screenWidth / 2) - buttonWidth - (buttonSpacing / 2), buttonsTop);
            btnNO.Location = new Point((screenWidth / 2) + (buttonSpacing / 2), buttonsTop);

            // === HEART INDICATOR ===
            // Add the heart once (no need for checking picHeart == null)
            picHeart = new PictureBox();
            picHeart.Size = new Size(30, 30);
            picHeart.Image = Image.FromFile("C:\\Users\\gello\\source\\repos\\Final Project - CGC Sage\\Final Project - CGC Sage\\Resources\\soul.png"); // Adjust path as needed
            picHeart.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(picHeart);  // Only add it once

            UpdateHeartPosition(); // Set initial heart position

            // === LOAD SPRITES ===
            frame1Image = Image.FromFile("InGameSprites/InGameCareerGuard1.png");
            frame2Image = Image.FromFile("InGameSprites/InGameCareerGuard2.png");
            pictureBox1.Image = frame1Image;

            // === INSTRUCTIONS LABEL ===
            lblInstructions = new Label();
            lblInstructions.AutoSize = false;
            lblInstructions.Size = new Size(400, 100); // Adjust size as needed
            lblInstructions.Font = new Font("Arial", 12, FontStyle.Bold);
            lblInstructions.ForeColor = Color.White;
            lblInstructions.BackColor = Color.Transparent;
            lblInstructions.TextAlign = ContentAlignment.TopLeft;
            lblInstructions.Text = GetInstructionText(); // Set initial instruction

            // Position to the right of the NPC
            lblInstructions.Location = new Point(pictureBox1.Right + 30, pictureBox1.Top + 20);

            this.Controls.Add(lblInstructions);

            // === START ANIMATION ===
            animationTimer = new Timer();
            animationTimer.Interval = 800;
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }
        private string GetInstructionText()
        {
            int questionsLeft = 15 - questionCounter + 1;

            // Prevent showing "Questions left: 1" after the last question
            if (questionsLeft < 0) questionsLeft = 0;

            return $"Use A and D to move between the answers\nPress Z to submit your answer\nQuestions left: {questionsLeft}";
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Switch between the two frames
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

        private void HandleYesSelection()
        {
            if (questionCounter == 1 || questionCounter == 4 || questionCounter == 7 || questionCounter == 10 || questionCounter == 13)
            {
                IS++;
            }
            else if (questionCounter == 2 || questionCounter == 5 || questionCounter == 8 || questionCounter == 11 || questionCounter == 14)
            {
                GPD++;
            }
            else if (questionCounter == 3 || questionCounter == 6 || questionCounter == 9 || questionCounter == 12 || questionCounter == 15)
            {
                IT++;
            }

            questionCounter++;

            if (questionCounter <= 15)
            {
                LabelChange(questionCounter);
                lblInstructions.Text = GetInstructionText();
            }
            else
            {
                CareerPlanResults form2 = new CareerPlanResults(this);
                form2.Show();
                this.Hide();
            }
        }
        private void CheckProximityAndChangeColor()
        {
            int proximityThreshold = 100; // Proximity threshold for detecting proximity to buttons

            // Reset both buttons to default color first (before checking proximity)
            btnYes.ForeColor = Color.White;
            btnNO.ForeColor = Color.White;

            // Calculate the heart's center coordinates
            int heartCenterX = picHeart.Left + picHeart.Width / 2;
            int heartCenterY = picHeart.Top + picHeart.Height / 2;

            // Calculate the center coordinates of the "Yes" button
            int buttonYesCenterX = btnYes.Left + btnYes.Width / 2;
            int buttonYesCenterY = btnYes.Top + btnYes.Height / 2;

            // Calculate the center coordinates of the "No" button
            int buttonNoCenterX = btnNO.Left + btnNO.Width / 2;
            int buttonNoCenterY = btnNO.Top + btnNO.Height / 2;

            // Calculate the distance to the "Yes" button
            int distanceXYes = Math.Abs(heartCenterX - buttonYesCenterX);
            int distanceYYes = Math.Abs(heartCenterY - buttonYesCenterY);

            // Calculate the distance to the "No" button
            int distanceXNo = Math.Abs(heartCenterX - buttonNoCenterX);
            int distanceYNo = Math.Abs(heartCenterY - buttonNoCenterY);

            // Debugging: Check the distances to the "Yes" and "No" buttons
            Debug.WriteLine($"Distance to YES: X = {distanceXYes}, Y = {distanceYYes}");
            Debug.WriteLine($"Distance to NO: X = {distanceXNo}, Y = {distanceYNo}");

            // Determine which button the heart is closer to
            bool heartNearYes = distanceXYes < proximityThreshold && distanceYYes < proximityThreshold;
            bool heartNearNo = distanceXNo < proximityThreshold && distanceYNo < proximityThreshold;

            // If the heart is near the "Yes" button and closer than the "No" button
            if (heartNearYes && (!heartNearNo || distanceXYes < distanceXNo))
            {
                Debug.WriteLine("Heart near YES");
                btnYes.ForeColor = Color.Yellow; // Change the "Yes" button to yellow
            }

            // If the heart is near the "No" button and closer than the "Yes" button
            if (heartNearNo && (!heartNearYes || distanceXNo < distanceXYes))
            {
                Debug.WriteLine("Heart near NO");
                btnNO.ForeColor = Color.Yellow; // Change the "No" button to yellow
            }
        }





        private void btnYes_Click_1(object sender, EventArgs e)
        {
            HandleYesSelection();
            lblInstructions.Text = GetInstructionText();
        }

        private void btnNO_Click_1(object sender, EventArgs e)
        {
            HandleNoSelection();
            lblInstructions.Text = GetInstructionText();
        }
        private void HandleNoSelection()
        {
            questionCounter++;

            if (questionCounter <= 15)
            {
                LabelChange(questionCounter);
                lblInstructions.Text = GetInstructionText();
            }
            else
            {
                CareerPlanResults form2 = new CareerPlanResults(this);
                form2.Show();
                this.Hide();
            }
        }

        private void LabelChange(int j)
        {
            lblQ.Text = questionsnum[j - 1];

            lblQ.AutoSize = false; // We control the size now
            lblQ.TextAlign = ContentAlignment.MiddleCenter;

            // Make sure label fills panel2
            lblQ.Size = panel2.ClientSize;
            lblQ.Location = new Point(0, 0);

            // Optional: enable text wrapping
            lblQ.MaximumSize = panel2.Size;
            lblQ.AutoEllipsis = true;

            if (!panel2.Controls.Contains(lblQ))
            {
                panel2.Controls.Add(lblQ);
            }
        }

        private void ResizeBorderedPanel(int outerWidth, int outerHeight, int border)
        {
            panel1.Size = new Size(outerWidth, outerHeight);
            panel1.Location = new Point((this.ClientSize.Width - outerWidth) / 2, 30);

            panel2.Size = new Size(outerWidth - (2 * border), outerHeight - (2 * border));
            panel2.Location = new Point(border, border);
        }

        // Clean up on form close
        private void questions_FormClosed(object sender, FormClosedEventArgs e)
        {
            animationTimer.Stop();
            animationTimer.Dispose();
        }
        private void UpdateHeartPosition()
        {
            int offsetX = -40; // Move heart to the left

            // If "Yes" is selected, place the heart near the "Yes" button
            if (currentSelection == SelectedOption.Yes)
            {
                picHeart.Location = new Point(
                    btnYes.Left + offsetX,  // Set X position next to btnYes
                    btnYes.Top + (btnYes.Height - picHeart.Height) / 2 // Center vertically with btnYes
                );
            }
            // If "No" is selected, place the heart near the "No" button
            else
            {
                picHeart.Location = new Point(
                    btnNO.Left + offsetX, // Set X position next to btnNO
                    btnNO.Top + (btnNO.Height - picHeart.Height) / 2 // Center vertically with btnNO
                );
            }

            // Check the proximity to the buttons and change their colors accordingly
            CheckProximityAndChangeColor();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.A)
            {
                currentSelection = SelectedOption.Yes;
                UpdateHeartPosition();
                return true;
            }
            else if (keyData == Keys.D)
            {
                currentSelection = SelectedOption.No;
                UpdateHeartPosition();
                return true;
            }
            else if (keyData == Keys.Z || keyData == Keys.Enter)
            {
                if (currentSelection == SelectedOption.Yes)
                    HandleYesSelection();
                else
                    HandleNoSelection();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
